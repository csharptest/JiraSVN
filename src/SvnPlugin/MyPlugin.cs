#region Copyright 2010 by Roger Knapp, Licensed under the Apache License, Version 2.0
/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security.Cryptography;
using Interop.BugTraqProvider;
using CSharpTest.Net.WinForms;
using CSharpTest.Net.Crypto;
using CSharpTest.Net.SvnPlugin.Interfaces;
using CSharpTest.Net.SvnPlugin.UI;
using System.Runtime.CompilerServices;
using System.Configuration;
using CSharpTest.Net.Serialization;

namespace CSharpTest.Net.SvnPlugin
{
	/// <summary>
	/// COM Registered InterOp for TortoiseSVN integration
	/// </summary>
	[ComVisible(true), ProgId("SvnPlugin.MyPlugin"), Guid(MyPlugin.GUID), ClassInterface(ClassInterfaceType.AutoDual)]
	public class MyPlugin : IDisposable, IBugTraqProvider, IBugTraqProvider2
	{
        const string GUID = "CF732FD7-AA8A-4E9D-9E15-025E4D1A7E9D";
        const string CLSID = "{" + GUID + "}";
		const string BUTTON_TEXT = "{0} Issues";

		private IIssuesService _connector = null;
		private IIssuesServiceConnection _service = null;
		private IssuesListView _issues = null;
		private Configuration _config = null;
		private bool _cancelled = true;

		/// <summary> Constructs a MyPlugin </summary>
		public MyPlugin()
		{
			//System.Diagnostics.Debugger.Break();
			Log.Write("Started, logging to {0}", Log.Config.LogFile);
            Resolver.Hook();
            CertificateHandler.Hook();
		}

		#region Public Interfaces:

		/// <summary> Returns true if the operation was cancelled </summary>
		public bool Canceled { get { return _cancelled; } }

		private string GetAppSetting(string name)
		{
			if (_config == null)
			{
				Log.Verbose("Settings = {0}", this.GetType().Assembly.Location);
				_config = ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);
			}

			KeyValueConfigurationElement setting = _config.AppSettings.Settings[name];
			return setting == null ? null : setting.Value;
		}

		/// <summary> Returns the Issue tracking connector </summary>
		public IIssuesService Connector
		{
			get
			{
				if (_connector == null)
				{
					string fullClass = GetAppSetting(typeof(IIssuesService).FullName);
					Log.Verbose("IIssuesService = '{0}'", fullClass);

					if (string.IsNullOrEmpty(fullClass))
						throw new ApplicationException("Unable to locate CSharpTest.Net.SvnPlugin.Interfaces.IIssuesService entry in app.config");
					_connector = (IIssuesService)Type.GetType(fullClass, true).InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, null, null);
				}
				return _connector;
			}
		}

		/// <summary>
		/// Returns true if the configuration is present (not nessessarily valid)
		/// </summary>
		public bool IsConfigured(IntPtr hParentWnd, string rootUrl, string commonRoot)
		{
			string service, user, password;
			return TryParseParameters(hParentWnd, rootUrl, commonRoot, out service, out user, out password);
		}

		/// <summary>
		/// Attepts to log on to the specified instance.  The instance url must contain a user
		/// name in the format of "http://user@server:port/".
		/// </summary>
		public bool Logon(IntPtr hParentWnd, string rootUrl, string commonRoot)
		{
			string message;
			if (_service != null)
				return true;

			if (!TryLogon(hParentWnd, rootUrl, commonRoot, out message, out _service))
			{
				ShowError(hParentWnd, String.Format("Unable to connect to {1}, check your configuration.\r\nReason: {0}", message, Connector.ServiceName), "Login Error");
				return false;
			}

			return _service != null;
		}

		/// <summary>
		/// Prompt the user for the comments and related issues
		/// </summary>
		public string GetCommitMsg(IntPtr hParentWnd, string rootUrl, string originalMessage, string commonRoot, string[] files)
		{
			string message = originalMessage;
			try
			{
				if (!Logon(hParentWnd, rootUrl, commonRoot))
					return originalMessage;

				if (_issues == null)
					_issues = new IssuesListView(_service, originalMessage, files);
				else
					_issues.SyncComments(originalMessage);

                IssuesList form = new IssuesList(_issues);
				if (hParentWnd == IntPtr.Zero)
					form.ShowInTaskbar = true;

				if (form.ShowDialog(Win32Window.FromHandle(hParentWnd)) != DialogResult.OK)
				{ _cancelled = true; return originalMessage; }

				_cancelled = false;
				return _issues.GetFullComments();
			}
			catch (OperationCanceledException) { _cancelled = true; return originalMessage; }
			catch (Exception ex)
			{
				ShowError(hParentWnd, ex.Message, ex.GetType().FullName);
				throw;
			}
		}

		/// <summary>
		/// Commit the requested changes for any related issues
		/// </summary>
		public string CommitChanges(IntPtr hParentWnd, string originalMessage, int revision, string[] files)
		{
			if (Canceled) return originalMessage;
			if (_service == null || _issues == null)
				throw new UnauthorizedAccessException();

			_issues.SyncComments(originalMessage);

			StringBuilder sbResponse = new StringBuilder();
			sbResponse.AppendFormat("{0}", originalMessage);

			if (GetAppSetting("addRevisionComment") == "false")
				revision = -1;
			if (GetAppSetting("addFilesComment") == "false")
				files = new string[0];

			foreach (Exception e in _issues.CommitChanges(revision, files))
			{
				sbResponse.AppendLine();
				sbResponse.AppendFormat("ERROR: {0}", e.Message);
			}

			return sbResponse.ToString();
		}

		#endregion
		#region Private Helpers

		void ShowError(IntPtr hParentWnd, string text, string caption)
		{
			_cancelled = true;
			MessageBox.Show(Win32Window.FromHandle(hParentWnd), text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		void SaveSettings(string userId, string uri, string password)
		{
			INameValueStore storage = new CSharpTest.Net.Serialization.StorageClasses.RegistryStorage();
			
			try
			{
				if (String.IsNullOrEmpty(password))
				{
					storage.Delete(uri, "UserName");
					storage.Delete(uri, "Password");
				}
				else
				{
					storage.Write(uri, "UserName", userId);
					storage.Write(uri, "Password", Encryption.CurrentUser.Encrypt(password));
				}
			}
			catch { }
		}

		string ReadSettings(IntPtr hParentWnd, string serviceUri, ref string userId)
		{
			INameValueStore storage = new CSharpTest.Net.Serialization.StorageClasses.RegistryStorage();
			try
			{
				string password;
				storage.Read(serviceUri, "UserName", out userId);
				if (storage.Read(serviceUri, "Password", out password))
					return Encryption.CurrentUser.Decrypt(password);
			}
			catch { }

			PasswordEntry pwdDlg = new PasswordEntry(userId, serviceUri);
			if (pwdDlg.ShowDialog(Win32Window.FromHandle(hParentWnd)) == DialogResult.OK)
			{
				userId = pwdDlg.UserName.Text;
				SaveSettings(userId, serviceUri, pwdDlg.Password.Text);
				return pwdDlg.Password.Text;
			}

			return null;
		}

		bool TryParseParameters(IntPtr hParentWnd, string parameters, string commonRoot, out string serviceUri, out string user, out string password)
		{
			serviceUri = user = password = null;

			if (String.IsNullOrEmpty(parameters) && !String.IsNullOrEmpty(commonRoot))
			{ //Read from svn...
				SvnProperties props = new SvnProperties(commonRoot);
				string testUri = props.Search(".", true, Connector.UriPropertyName);
				if (!String.IsNullOrEmpty(testUri))
					parameters = testUri;
			}
			if (String.IsNullOrEmpty(parameters))
			{
				string test = System.Configuration.ConfigurationManager.AppSettings[Connector.UriPropertyName];
				if (!String.IsNullOrEmpty(test))
					parameters = test;
			}

			Uri uri;
			if (Uri.TryCreate(parameters, UriKind.Absolute, out uri))
			{
				serviceUri = String.Format("{0}://{1}:{2}{3}", uri.Scheme, uri.Host, uri.Port, uri.PathAndQuery);

				if (!String.IsNullOrEmpty(uri.UserInfo))
				{
					string[] parts = uri.UserInfo.Split(':');
					if (parts.Length == 2 && !String.IsNullOrEmpty(parts[0]) && !String.IsNullOrEmpty(parts[1]))
					{
						user = parts[0];
						password = parts[1];
					}
					else
					{
						user = uri.UserInfo;
						password = ReadSettings(hParentWnd, serviceUri, ref user);
					}
				}
				else
					password = ReadSettings(hParentWnd, serviceUri, ref user);

				if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(password))
					return true;
			}
			return false;
		}

		string GetParamDesc()
		{
			string message = "Parameter must be a valid absolute uri optionally with \r\n" +
					"a user name and password.  Leave blank to read value from svn \r\n" +
					"property named: '{0}'\r\n" +
					"\tExample 1: http://{2}.com:8080\r\n" +
					"\tExample 2: http://username@{2}.com:8080\r\n" +
					"\tExample 3: http://username:password@{2}.com:8080";
			return String.Format(message, Connector.UriPropertyName, Connector.ServiceName, Connector.ServiceName.ToLower());
		}

		bool TryLogon(IntPtr hParentWnd, string parameters, string commonRoot, out string message, out IIssuesServiceConnection service)
		{
			IIssuesService connector = this.Connector;
			string serviceUri, user, password;

			message = null;
			service = null;
			if (!TryParseParameters(hParentWnd, parameters, commonRoot, out serviceUri, out user, out password))
			{
				message = GetParamDesc();
				return false;
			}

			try
			{
				if (!connector.Connect(serviceUri, user, password, GetAppSetting, out service))
				{
					SaveSettings(user, serviceUri, null);
					return false;
				}
				return true;
			}
			catch (Exception e)
			{
				Log.Error(e);
				message = e.Message;
				return false;
			}
		}

		#endregion

		/// <summary> Releases any locked resources </summary>
		public void Dispose()
		{
			if (_issues != null)
				_issues.Dispose();
			_issues = null;

			if (_service != null)
				_service.Dispose();
			_service = null;
		}

		#region IBugTraqProvider2 Members

		bool IBugTraqProvider2.ValidateParameters(IntPtr hParentWnd, string parameters)
		{
			try
			{
				return String.IsNullOrEmpty(parameters) || Logon(hParentWnd, parameters, null);
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider2.GetLinkText(IntPtr hParentWnd, string parameters)
		{
			try
			{
				return String.Format(BUTTON_TEXT, Connector.ServiceName);
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider2.GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
		{
			try
			{
				return GetCommitMsg(hParentWnd, parameters, originalMessage, commonRoot, pathList);
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider2.GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string originalMessage, string bugID, out string bugIDOut, out string[] revPropNames, out string[] revPropValues)
		{
			try
			{
				bugIDOut = bugID;
				revPropNames = new string[0];
				revPropValues = new string[0];

				string message = GetCommitMsg(hParentWnd, parameters, originalMessage, commonRoot, pathList);
				if (_issues != null)
				{
					foreach (IIssue issue in _issues.SelectedIssues)
					{ bugIDOut = issue.DisplayId; break; }
				}
				return message;
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider2.CheckCommit(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string commitMessage)
		{
			try
			{
				return String.Empty;
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider2.OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string originalMessage, int revision)
		{
			try
			{
				return CommitChanges(hParentWnd, originalMessage, revision, pathList);
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		bool IBugTraqProvider2.HasOptions() { return true; }

		///TODO: - need to complete implementation for options dialog
		string IBugTraqProvider2.ShowOptionsDialog(IntPtr hParentWnd, string parameters)
		{
			try
			{
				OptionUrlEntry dlg = new OptionUrlEntry(parameters, GetParamDesc());

				if (dlg.ShowDialog(Win32Window.FromHandle(hParentWnd)) == DialogResult.OK)
					return dlg.ServiceUri.Text;

				return parameters;
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		#endregion

		#region IBugTraqProvider Members

		bool IBugTraqProvider.ValidateParameters(IntPtr hParentWnd, string parameters)
		{
			try
			{
				return String.IsNullOrEmpty(parameters) || Logon(hParentWnd, parameters, null);
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider.GetLinkText(IntPtr hParentWnd, string parameters)
		{
			try
			{
				return String.Format(BUTTON_TEXT, Connector.ServiceName);
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider.GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
		{
			try
			{
				string message = GetCommitMsg(hParentWnd, parameters, originalMessage, commonRoot, pathList);
				message = CommitChanges(hParentWnd, message, -1, new string[0]);
				return message;
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		#endregion

		#region COM Interop/Registration

        static IEnumerable<string> GetRegistryKeysToAdd()
		{
            yield return String.Format(@"CLSID\{0}\Implemented Categories\{{3494FA92-B139-4730-9591-01135D5E7831}}", CLSID);
            yield return String.Format(@"CLSID\{0}\Implemented Categories\{{62C8FE65-4EBB-45e7-B440-6E39B2CDBF29}}", CLSID);
		}

		/// <summary>
		/// Registeres this assembly with COM using the custom keys required for TortoiseSVN interop
		/// </summary>
		[ComRegisterFunction]
		public static void RegisterFunction(Type t)
		{
			try
			{
				if (typeof(MyPlugin) == t)
				{
                    foreach (string keypath in GetRegistryKeysToAdd())
						using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(keypath))
						{ key.Close(); }//{ Console.WriteLine(key.ToString()); }

                    using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(String.Format(@"CLSID\{0}\InprocServer32", CLSID)))
                        if (key != null) key.SetValue("Assembly", t.Assembly.FullName);

                    if (t.Assembly.Location != null && System.IO.File.Exists(t.Assembly.Location))
                    {
                        using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(String.Format(@"CLSID\{0}\InprocServer32", CLSID)))
                            if (key != null) key.SetValue("CodeBase", t.Assembly.Location);
                        using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(String.Format(@"CLSID\{0}\InprocServer32\{1}", CLSID, t.Assembly.GetName().Version)))
                        {
                            if (key != null)
                            {
                                key.SetValue(null, "mscoree.dll");
                                key.SetValue("ThreadingModel", "Both");
                                key.SetValue("CodeBase", t.Assembly.Location);
                            }
                        }
                    }
				}
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e.ToString());
			}
		}

		/// <summary>
		/// Unregisteres this assembly removing the custom keys required for TortoiseSVN interop
		/// </summary>
		[ComUnregisterFunction]
		public static void UnregisterFunction(Type t)
        {
			try
			{
                foreach (string key in GetRegistryKeysToAdd())
					Registry.ClassesRoot.DeleteSubKey(key, false);
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e.ToString());
			}
		}

		#endregion
	}

}