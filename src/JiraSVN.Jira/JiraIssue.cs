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
using JiraSVN.Common.Interfaces;
using JiraSVN.Jira.Jira;
using CSharpTest.Net.Reflection;

namespace JiraSVN.Jira
{
	class JiraIssue : BaseIdentifiable<RemoteIssue>, IIssue
	{
		readonly IIssueUser _assignee, _reporter;
		readonly JiraConnection _connection;

		public JiraIssue(JiraConnection conn, RemoteIssue issue)
			: base(issue, issue.id, issue.summary)
		{
			_connection = conn;
			_assignee = _connection.GetUser(Object.assignee);
			_reporter = _connection.GetUser(Object.reporter);
		}

		public string DisplayId { get { return Object.key; } }

		public IIssueState CurrentState
		{
			get { return _connection.GetStatus(Object.status); }
		}

		public string FullDescription
		{
			get { return Object.description != null ? Object.description : String.Empty; }
		}

		public DateTime CreatedOn
		{
			get { return Object.created.Value; }
		}

		public DateTime LastModifiedOn
		{
			get { return Object.updated.Value; }
		}

		public IIssueUser AssignedTo
		{
			get { return _assignee; }
		}

		public IIssueUser ReportedBy
		{
			get { return _reporter; }
		}

		public void View()
		{
			_connection.ViewIssue(this);
		}

		public void AddComment(string comment)
		{
			_connection.AddComment(this, comment);
		}

		public IIssueAction[] GetActions()
		{
			return _connection.GetActions(this);
		}

		public void ProcessAction(string comment, IIssueAction action, IIssueUser assignTo)
		{
			if (!String.IsNullOrEmpty(comment))
				AddComment(comment);

			_connection.ProcessAction(this, action, assignTo);
		}

	    public void ProcessWorklog(string timeSpent, TimeEstimateRecalcualationMethod method, string newTimeEstimate)
	    {
            _connection.ProcessWorklog(this, timeSpent, method, newTimeEstimate);
	    }

		private string[] GetCustomFieldValue(string fieldName)
		{
			foreach (RemoteCustomFieldValue fld in Object.customFieldValues)
			{
				if (StringComparer.OrdinalIgnoreCase.Equals(fld.customfieldId, fieldName))
					return fld.values;
			}

			return null;
			//throw new ApplicationException("Unable to find custom field: " + fieldName);
		}

		internal string[] GetFieldValue(string fieldName)
		{
			if (fieldName.StartsWith("customfield_", StringComparison.OrdinalIgnoreCase))
				return GetCustomFieldValue(fieldName);

			//some inconsistant naming in the jira api
			if (fieldName == "issuetype") fieldName = "type";
			if (fieldName == "versions") fieldName = "affectsVersions";
			if (fieldName == "attachment") fieldName = "attachmentNames";

			PropertyValue property = new PropertyValue(this.Object, fieldName);
			object oval = property.Value;
			if (oval != null)
			{
				if (oval is AbstractRemoteEntity[])
				{
					List<string> ids = new List<string>();
					foreach (AbstractRemoteEntity o in ((AbstractRemoteEntity[])oval))
						ids.Add(o.id);
					return ids.ToArray();
				}
				else
				{
					return new string[] { oval.ToString() };
				}
			}
			return null;
		}
	}
}
