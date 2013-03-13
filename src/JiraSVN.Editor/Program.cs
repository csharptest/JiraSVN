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
using System.IO;
using System.Windows.Forms;
using JiraSVN.Plugin;

namespace JiraSVN.Editor
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.  This program expects a single input argument
		/// in the same format as provided by the svn checkin tool.  Use this executable to provide
		/// comments/updates from the command-line.
		/// </summary>
		[STAThread]
		static int Main( string[] args )
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

		    // running as a text-editor for cmd version of svn:
			if (args.Length > 0)
			{
				string inputFile = args[0];
				if (!File.Exists(inputFile))
				{
					MessageBox.Show(null, 
						String.Format("Unable to locate input file: \r\n{0}", inputFile),
						"File not found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return -1;
				}

				string[] data = File.ReadAllLines(inputFile);
				List<string> filesChanged = new List<string>();

				foreach (string sline in data)
				{
					if (sline.Length <= 5)
						continue;

					string tmp = sline.Substring(5);
					if (File.Exists(tmp))
						filesChanged.Add(tmp);
				}

				try
				{
					string inputMessage = String.Empty;
					string[] paths = filesChanged.ToArray();
					string commonRoot = Environment.CurrentDirectory;

					using (TortoiseSvnPlugin plugin = new TortoiseSvnPlugin())
					{
						if (!plugin.IsConfigured(IntPtr.Zero, String.Empty, Environment.CurrentDirectory))
							throw new OperationCanceledException(String.Format("Unable to configure the plugin. Please look into the log file at \r\n"));

						string message = plugin.GetCommitMsg(IntPtr.Zero, String.Empty, inputMessage, commonRoot, paths);
						if (plugin.Canceled)
							File.Delete(inputFile);
						else
						{
                            message = plugin.CommitChanges(IntPtr.Zero, String.Empty, message, -1, commonRoot, paths);

							if (message.Length > 0)
								File.WriteAllText(inputFile, message);
						}
					}
				}
				catch(Exception e)
				{
					MessageBox.Show(null, e.Message, e.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
					File.Delete(inputFile);
					Environment.Exit(-1);
				}
			}
			return Environment.ExitCode;
		}
	}
}
