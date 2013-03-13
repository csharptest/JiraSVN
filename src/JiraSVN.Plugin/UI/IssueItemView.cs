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
using JiraSVN.Common.Interfaces;

namespace JiraSVN.Plugin.UI
{
	class IssueItemView : IIssue
	{
		readonly IssuesListView _view;
		readonly IIssue Issue;

		public IssueItemView(IssuesListView view, IIssue issue) 
		{
			this._view = view;
			this.Issue = issue; 
		}

		public bool Selected
		{
			get { return _view.IsSelected(this); } 
			set { _view.Select(this, value); } 
		}

		public string Id
		{
			get { return Issue.Id; }
		}

		public string Name
		{
			get { return Issue.Name; }
		}

		public string DisplayId
		{
			get { return Issue.DisplayId; }
		}

		public string FullDescription
		{
			get { return Issue.FullDescription; }
		}

		public IIssueState CurrentState
		{
			get { return Issue.CurrentState; }
		}

		public IIssueUser AssignedTo
		{
			get { return Issue.AssignedTo; }
		}

		public IIssueUser ReportedBy
		{
			get { return Issue.ReportedBy; }
		}

		public DateTime CreatedOn
		{
			get { return Issue.CreatedOn; }
		}

		public DateTime LastModifiedOn
		{
			get { return Issue.LastModifiedOn; }
		}

		public void View()
		{
			Issue.View();
		}

		public void AddComment(string comment)
		{
			Issue.AddComment(comment);
		}

		public IIssueAction[] GetActions()
		{
			return Issue.GetActions();
		}

		public void ProcessAction(string comment, IIssueAction action, IIssueUser assignTo)
		{
			Issue.ProcessAction(comment, action, assignTo);
		}

	    public void ProcessWorklog(string timeSpent, TimeEstimateRecalcualationMethod method, string newTimeEstimate)
	    {
            Issue.ProcessWorklog(timeSpent, method, newTimeEstimate);
	    }
	}
}
