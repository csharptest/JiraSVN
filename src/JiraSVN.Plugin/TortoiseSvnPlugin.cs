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
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using CSharpTest.Net.Crypto;
using JiraSVN.Common.Interfaces;
using JiraSVN.Plugin.UI;
using CSharpTest.Net.Serialization;
using CSharpTest.Net.WinForms;
using Interop.BugTraqProvider;
using Microsoft.Win32;
using System.Reflection;
using System.ComponentModel;

namespace JiraSVN.Plugin
{
	/// <summary>
	/// COM Registered InterOp for TortoiseSVN integration
	/// </summary>
    [ComVisible(true), ProgId("JiraSVN.Plugin.TortoiseSvnPlugin"), Guid(GUID), ClassInterface(ClassInterfaceType.AutoDual)]
    public class TortoiseSvnPlugin : IDisposable, IBugTraqProvider, IBugTraqProvider2
	{
        const string GUID = "CF732FD7-AA8A-4E9D-9E15-025E4D1A7E9D";
        const string CLSID = "{" + GUID + "}";
		const string BUTTON_TEXT = "{0}";
        
		private IIssuesService _connector = null;
		private IIssuesServiceConnection _service = null;
		private IssuesListView _issues = null;
		private Configuration _config = null;
		private bool _cancelled = true;
	    private string _commonURL = string.Empty;
        private ConnectingDialog _connectingDialog;

		/// <summary> Constructs a MyPlugin </summary>
		public TortoiseSvnPlugin()
		{
#if DEBUG
			System.Diagnostics.Debugger.Launch();
#endif
            _connectingDialog = new ConnectingDialog();
            _connectingDialog.Worker.DoWork += BackgroundWorkerDoWork;
            Log.Write("Started, logging to {0}", Log.Config.LogFile);
		}

		#region Public Interfaces:

		/// <summary> Returns true if the operation was cancelled </summary>
		public bool Canceled { get { return _cancelled; } }

		private string GetAppSetting(string name)
		{
			if (_config == null)
			{
				Log.Verbose("Loading Settings = {0}", this.GetType().Assembly.Location);
				_config = ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);
                Log.Verbose("Loaded");
			}

			KeyValueConfigurationElement setting = _config.AppSettings.Settings[name];
			return setting == null ? null : setting.Value;
		}

        /// <summary>Returns a setting. This is taken out of svn propertiesor config file </summary>
        private string GetSetting(string name, string commonRoot) 
        {
            Log.Verbose("Getting Setting for name = {0} commonRoot = {1}", name, commonRoot); 
            var result = string.Empty;
            if (!String.IsNullOrEmpty(commonRoot)) 
            { //Read from svn...
                SvnProperties props = new SvnProperties(commonRoot);
                result = props.Search(".", true, name);
            }
            result = !String.IsNullOrEmpty(result) ? result : GetAppSetting(name);
            Log.Verbose("Setting for name = {0} commonRoot = {1} is {3} ", name, commonRoot, result); 
            return result;
        }

		/// <summary> Returns the Issue tracking connector </summary>
		public IIssuesService Connector
		{
			get
			{
				if (_connector == null)
				{
                    Log.Verbose("Creating a new Connector for the service");
                    string fullClass = GetAppSetting(typeof(IIssuesService).FullName);
					Log.Verbose("IIssuesService = '{0}'", fullClass);

					if (string.IsNullOrEmpty(fullClass))
						throw new ApplicationException("Unable to locate JiraSVN.Common.Interfaces.IIssuesService entry in app.config");
					_connector = (IIssuesService)Type.GetType(fullClass, true).InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, null, null);
				   
                    Log.Verbose("Connector Created");
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
            Log.Verbose("Logging into Issue Services");
            if (_service != null)
            {
                Log.Verbose("Already Logged. No more work required");
                return true;
            }

            Log.Verbose("Not Logged. Logging in");
            _connectingDialog.Argument = new object[] { hParentWnd, rootUrl, commonRoot };
            var connectionResult = _connectingDialog.ShowDialog(Win32Window.FromHandle(hParentWnd));
            if ( connectionResult == DialogResult.OK )
                _service = _connectingDialog.Result as IIssuesServiceConnection;
            if ( connectionResult == DialogResult.Abort)
                ShowError(hParentWnd, _connectingDialog.Error.Message, "Login Error");
            else if (connectionResult == DialogResult.Cancel)
                _service = null;

            Log.Verbose("Finished Logging in");
			return _service != null;
		}

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs args )
        {
            string message;
            IIssuesServiceConnection service;
            var arguments = ((object[])args.Argument);
            IntPtr hParentWnd = (IntPtr)arguments[0];
            string rootUrl = (string)arguments[1];
            string commonRoot = (string)arguments[2];

            if (!TryLogon(hParentWnd, rootUrl, commonRoot, out message, out service))
            {
                throw new ApplicationException(String.Format("Unable to connect to {1}, check your configuration.\r\nReason: {0}", message, Connector.ServiceName));
            }
            args.Result = service;
        }

		/// <summary>
		/// Prompt the user for the comments and related issues
		/// </summary>
		public string GetCommitMsg(IntPtr hParentWnd, string parameters, string originalMessage, string commonRoot, string[] files)
		{
            Log.Verbose("Loading form...");
            DateTime time = DateTime.Now;
			string message = originalMessage;
			try
			{
				if (!Logon(hParentWnd, parameters, commonRoot))
					return originalMessage;

				if (_issues == null)
					_issues = new IssuesListView(_service, originalMessage, files);
				else
					_issues.SyncComments(originalMessage);

                Log.Verbose("Opening form");
                Log.Info("Time required to connect: {0}", DateTime.Now - time);
                IssuesList form = new IssuesList(_issues);
				form.ShowInTaskbar = hParentWnd == IntPtr.Zero;
                
                Log.Info("Time required to open form: {0}", DateTime.Now - time);
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
        public string CommitChanges(IntPtr hParentWnd, string rootUrl, string originalMessage, int revision, string commonRoot, string[] files)
		{
			if (Canceled) return originalMessage;
			if (_service == null || _issues == null)
				throw new UnauthorizedAccessException();
			
			_issues.SyncComments(originalMessage);

			StringBuilder sbResponse = new StringBuilder();
			sbResponse.AppendFormat("{0}", originalMessage);

            if (GetSetting("jira:addRevisionComment", commonRoot) == "false")
				revision = -1;
            if (GetSetting("jira:addFilesComment", commonRoot) == "false")
                files = new string[0];
            else {
                //replace the commonRoot to rootUrl. This will also let us know of the branch/trunk...
                for (var i = 0; i < files.Length; i++) {
                    files[i] = files[i].Replace(commonRoot.Replace('\\', '/'), rootUrl);
                }
            }

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
            Log.Verbose("Acquiring username and password");
			INameValueStore storage = new CSharpTest.Net.Serialization.StorageClasses.RegistryStorage();
			try
			{
                Log.Verbose("Trying to read username and password from the cache");
				string password;
				storage.Read(serviceUri, "UserName", out userId);
                if (storage.Read(serviceUri, "Password", out password))
                {
                    string pass = Encryption.CurrentUser.Decrypt(password);
                    Log.Verbose("Successfully read Username and password from the cache");
                    return pass;
                }
			}
			catch { }

            Log.Verbose("Failed reading username and password from the cache. Prompting user");
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
            Log.Verbose("Parsing Parameters");
            if(String.IsNullOrEmpty(parameters)) {
                parameters = GetSetting(Connector.UriPropertyName, commonRoot);
            }

			Uri uri;
			if (Uri.TryCreate(parameters, UriKind.Absolute, out uri))
			{
				serviceUri = String.Format("{0}://{1}:{2}{3}", uri.Scheme, uri.Host, uri.Port, uri.PathAndQuery);
                Log.Verbose("Using uri: {0}", serviceUri);

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
                {
                    Log.Verbose("Successfully acquired username and password");
                    return true;
                }
			}
            Log.Error("Could not create uri with the parameters provided. Uri: {0}", uri);
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

        string GetIssueId(IIssue issue, string commonRoot) 
        {
            var prefix = GetSetting("jira:idprefix", commonRoot);
            return !String.IsNullOrEmpty(prefix) ? issue.DisplayId.Replace(prefix, String.Empty) : issue.DisplayId;
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
				return GetCommitMsg(hParentWnd, String.Empty, originalMessage, commonRoot, pathList);
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
				if (_issues != null) {
				    
                    bugIDOut = string.Empty;
                    var first = true;
                    foreach (IIssue issue in _issues.SelectedIssues)
					{
                        bugIDOut += first ? GetIssueId(issue, commonRoot) : "," + GetIssueId(issue, commonRoot);
                        first = false;
                    }
				}
				return message;
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider2.CheckCommit(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string commitMessage)
		{
			try 
            {
			    _commonURL = commonURL;
				return String.Empty;
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		string IBugTraqProvider2.OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string originalMessage, int revision)
		{
			try
			{
                return CommitChanges(hParentWnd, _commonURL, originalMessage, revision, commonRoot, pathList);
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
                message = CommitChanges(hParentWnd, string.Empty, message, -1, commonRoot, new string[0]);
				return message;
			}
			catch (Exception e) { Log.Error(e); throw; }
		}

		#endregion

		#region COM Interop/Registration

        static IEnumerable<string> GetRegistryKeysToAdd()
		{
            return new string[] {@"Implemented Categories\{3494FA92-B139-4730-9591-01135D5E7831}", 
                                 @"Implemented Categories\{62C8FE65-4EBB-45e7-B440-6E39B2CDBF29}"};
		}

		/// <summary>
		/// Registeres this assembly with COM using the custom keys required for TortoiseSVN interop
		/// </summary>
		[ComRegisterFunction]
		public static void RegisterFunction(Type t)
		{
			try
			{
                if (typeof(TortoiseSvnPlugin) == t)
				{
                    using (var rootKey = Registry.ClassesRoot.CreateSubKey(string.Format(@"CLSID\{0}", CLSID)))
                    {
                        foreach (string keypath in GetRegistryKeysToAdd())
                            using (RegistryKey key = rootKey.CreateSubKey(keypath))
						    { key.Close(); }

                        using (RegistryKey key = rootKey.CreateSubKey(@"InprocServer32"))
                            if (key != null) key.SetValue("Assembly", t.Assembly.FullName);

                        if (t.Assembly.Location != null && System.IO.File.Exists(t.Assembly.Location))
                        {
                            using (RegistryKey key = rootKey.CreateSubKey(@"InprocServer32"))
                                if (key != null) key.SetValue("CodeBase", t.Assembly.Location);
                            using (RegistryKey key = rootKey.CreateSubKey(String.Format(@"InprocServer32\{1}", t.Assembly.GetName().Version)))
                            {
                                if (key != null)
                                {
                                    key.SetValue(null, "mscoree.dll");
                                    key.SetValue("ThreadingModel", "Both");
                                    key.SetValue("CodeBase", t.Assembly.Location);
                                }
                            }
                        }
                        rootKey.Close();
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
					Registry.ClassesRoot.DeleteSubKey(string.Format(@"CLSID\{0}\", CLSID) + key.TrimStart('\\'), false);
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e.ToString());
			}
		}

		#endregion
    }

}