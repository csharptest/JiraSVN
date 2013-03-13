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
using JiraSVN.Jira.Jira;

namespace JiraSVN.Jira
{
	class JiraFilter : BaseIdentifiable<RemoteFilter>, IIssueFilter
	{
		JiraConnection _connection;
		public JiraFilter(JiraConnection conn, RemoteFilter filter)
			: base(filter, filter.id, filter.name)
		{
			_connection = conn;
		}

        public IIssue[] GetIssues(int offsett, int maxNumber)
		{
            return _connection.GetIssuesByFilter(this, offsett, maxNumber);
		}
	}

	class JiraAllFilter : BaseIdentifiable<RemoteFilter>, IIssueFilterWithSearch
	{
		JiraConnection _connection;

		public JiraAllFilter(JiraConnection conn)
			: base(null, "[Search All Issues]", "[Search All Issues]")
		{
			_connection = conn;
		}

		public IIssue[] GetIssues(int offsett, int maxNumber)
		{
			//return _connection.GetAllIssues();
			return new IIssue[1] { JiraAllFilterMessage.Instance };
		}

        public IIssue[] GetIssues(string text, int offsett, int maxNumber)
		{
			try
			{
				if (String.IsNullOrEmpty(text) || text.Trim().Length < 2)
					return GetIssues(offsett, maxNumber);

                return _connection.GetAllIssues(text, offsett, maxNumber);
			}
			catch (Exception e)
			{
				Log.Warning(e);
                return GetIssues(offsett, maxNumber);
			}
		}

		#region class JiraAllFilterMessage : IIssue
		class JiraAllFilterMessage : IIssue
		{
			public static readonly JiraAllFilterMessage Instance = new JiraAllFilterMessage();
			private JiraAllFilterMessage() { }

			public void AddComment(string comment)
			{ }

			public IIssueUser AssignedTo
			{
				get { return JiraUser.Unknown; }
			}

			public DateTime CreatedOn
			{
				get { return DateTime.MinValue; }
			}

			public IIssueState CurrentState
			{
				get { return JiraStatus.Unknown; }
			}

			public string DisplayId
			{
				get { return String.Empty; }
			}

			public IIssueAction[] GetActions()
			{
				return new IIssueAction[0];
			}

			public DateTime LastModifiedOn
			{
				get { return DateTime.MinValue; }
			}

			public void ProcessAction(string comment, IIssueAction action, IIssueUser assignTo)
			{
			}

		    public void ProcessWorklog(string timeSpent, TimeEstimateRecalcualationMethod method, string newTimeEstimate)
		    {
		    }

		    public IIssueUser ReportedBy
			{
				get { return JiraUser.Unknown; }
			}

			public void View()
			{ }

			public string Id
			{
				get { return String.Empty; }
			}

			public string Name
			{
				get { return "Type search criteria in the 'Contains' box above."; }
			}

			public string FullDescription
			{
				get { return Name; }
			}
		}
		#endregion
	}
}
