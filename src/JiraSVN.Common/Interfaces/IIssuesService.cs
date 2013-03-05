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

namespace JiraSVN.Common.Interfaces
{
	/// <summary>
	/// Connection to the main issue tracking service 
	/// </summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public interface IIssuesService
	{
		/// <summary>
		/// Returns the proper name of the system this plugin talks to, i.e. the name of the 
		/// issue tracking system
		/// </summary>
		string ServiceName { get; }

		/// <summary>
		/// Returns the SVN property/app setting name that stores the connection URL
		/// </summary>
		string UriPropertyName { get; }

		/// <summary> 
		/// Open the connection to the issue tracking system with the given credentials. 
		/// If the logon was successful the return value should be true.  If the credentials are
		/// invalid the return value should be false.  All other failures should result in an
		/// excpetion.
		/// </summary>
		/// <param name="url"> A Uri describing the connection information required </param>
		/// <param name="userName"> The current user name to use for logon </param>
		/// <param name="password"> The current password to use for logon </param>
		/// <param name="settings"> The method used to retrive app.config settings </param>
		/// <param name="connection"> The resulting connection with the issue tracking server </param>
		/// <returns> True if the logon was successful, or false if the credentials are invalid </returns>
		bool Connect(string url, string userName, string password, Converter<string, string> settings, out IIssuesServiceConnection connection);
	}
}
