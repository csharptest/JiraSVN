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
using System.ComponentModel;

namespace JiraSVN.Common.Interfaces
{
    ///<summary>
    /// Defines method Jira will use to update Estimated time.
    ///</summary>
    public enum TimeEstimateRecalcualationMethod
    {
        /// <summary>
        /// The estimate will be reduced by the amount of work done
        /// </summary>
        [Description("Adjust automatically")]
        AdjustAutomatically,
        /// <summary>
        /// The stimate will not be changed
        /// </summary>
        [Description("Leave existing estimate")]
        DoNotChange,
        /// <summary>
        /// The new estimate will be set explicitly
        /// </summary>
        [Description("Set new estimate")]
        SetToNewValue,
    };

	/// <summary>
	/// Represents a single issue within an issue tracking system.
	/// </summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public interface IIssue : IIdentifiable
	{
		/// <summary> returns a human-readable identifier, can be == Id </summary>
		string DisplayId { get; }

		/// <summary> Returns the complete detialed description of the item </summary>
		string FullDescription { get; }

		/// <summary> Returns the current state of the item (i.e. open, closed, etc) </summary>
		IIssueState CurrentState { get; }

		/// <summary> Returns the current user this is assigned to </summary>
		IIssueUser AssignedTo { get; }
		/// <summary> Returns the user this was reported by </summary>
		IIssueUser ReportedBy { get; }

		/// <summary> Returns the date/time the issue was first reported </summary>
		DateTime CreatedOn { get; }
		/// <summary> Returns the date/time the issue was last updated </summary>
		DateTime LastModifiedOn { get; }

		/// <summary> View the current issue in the default user interface </summary>
		void View();

		/// <summary> Adds a comment to this issue </summary>
		void AddComment(string comment);

		/// <summary>
		/// Retieves the actions the current user could possible take on the issue (ie. fixed, closed, etc).
		/// </summary>
		IIssueAction[] GetActions();
		/// <summary>
		/// Processes a given action against this issue
		/// </summary>
		/// <param name="comment"> A comment to append to the issue, or null/empty for none. </param>
		/// <param name="action"> The action to perform </param>
		/// <param name="assignTo"> A user to assign the issue to, or this.AssignedTo to leave it alone </param>
		void ProcessAction(string comment, IIssueAction action, IIssueUser assignTo);

	    /// <summary>
	    /// Adds a worklog to given issue
	    /// </summary>
	    /// <param name="timeSpent">Spent time in Jira format</param>
	    /// <param name="method"></param>
	    /// <param name="newTimeEstimate"></param>
	    void ProcessWorklog(string timeSpent, TimeEstimateRecalcualationMethod method, string newTimeEstimate);
	}
}
