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
	/// Wraps an established connection to an issue tracking system
	/// </summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public interface IIssuesServiceConnection : IDisposable
	{
		/// <summary> Returns the current user </summary>
		IIssueUser CurrentUser { get; }

		/// <summary>
		/// Retrieves a list of filters/groups of issues that can be retrieved from the server.
		/// </summary>
		IIssueFilter[] GetFilters();

		/// <summary>
		/// Returns all known users in the system, throwing NotSupportedException or NotImplementedExcpetion
		/// will cause the system to track unique users seen.
		/// </summary>
		IIssueUser[] GetUsers();
	}
}
