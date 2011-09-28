﻿#region Copyright 2010 by Roger Knapp, Licensed under the Apache License, Version 2.0
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

namespace CSharpTest.Net.JiraSVN.Common.Interfaces
{
	/// <summary>
	/// Represents a group of displayable issues
	/// </summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public interface IIssueFilter : IIdentifiable
	{
		/// <summary>
		/// Returns the list of issues matching this filter/group
		/// </summary>
		IIssue[] GetIssues(int offsett, int maxNumber);
	}

	/// <summary>
	/// Represents a group of displayable issues
	/// </summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public interface IIssueFilterWithSearch : IIssueFilter
	{
		/// <summary>
		/// Returns the list of issues matching this filter/group
		/// </summary>
        IIssue[] GetIssues(string searchText, int offsett, int maxNumber);
	}
}
