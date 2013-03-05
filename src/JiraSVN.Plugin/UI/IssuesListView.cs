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
using System.ComponentModel;
using System.Text;
using JiraSVN.Common.Interfaces;
using CSharpTest.Net.Reflection;
using CSharpTest.Net.Serialization;

namespace JiraSVN.Plugin.UI
{
	class IssuesListView : IDisposable, INotifyPropertyChanged
	{
		#region Loads of properties :(

		readonly ObjectSerializer _serializer;
		readonly INameValueStore _storage = new CSharpTest.Net.Serialization.StorageClasses.RegistryStorage();
		IIssuesServiceConnection _service;

		Dictionary<string, bool> _selected = new Dictionary<string, bool>();
		DataBindingList<IIssueFilter> _filters = new DataBindingList<IIssueFilter>(false);
		DataBindingList<IIssueUser> _assignedFilter = new DataBindingList<IIssueUser>(true);
		DataBindingList<IIssueState> _statusFilter = new DataBindingList<IIssueState>(true);
		string _textFilter = String.Empty, _lastTextFilter = String.Empty;

		IssueItemView[] _found = new IssueItemView[0];
		DataBindingList<IssueItemView> _filtered = new DataBindingList<IssueItemView>(false);
		string _comments = String.Empty;
		string _lastCommentAppended = String.Empty;

		bool _doAction = false;
		DataBindingList<IIssueAction> _actions = new DataBindingList<IIssueAction>(true);

		bool _doAssign = false;
		DataBindingList<IIssueUser> _assignees = new DataBindingList<IIssueUser>(true);

	    private bool _addWorklog;
	    private string _timeSpent;
	    private TimeEstimateRecalcualationMethod _timeEstimateRecalcualationMethod;
	    private string _newTimeEstimate;

		#endregion

		public IssuesListView(IIssuesServiceConnection service, string message, string[] files)
		{
			PropertyChanged += new PropertyChangedEventHandler(DebugPropertyChanged);

			_service = service;
			_comments = message;

			_filters.ReplaceContents(_service.GetFilters());

			_assignees.AddRange(new IIssueUser[] { ReportedByUser.Instance, _service.CurrentUser });
			_assignees.AddRange(_service.GetUsers());

			_serializer = new ObjectSerializer(this, 
				"_filters.SelectedText",
				"_assignedFilter.SelectedText",
				"_statusFilter.SelectedText",
				"_actions.SelectedText",
				"_assignees.SelectedText"
				);
			_serializer.ContinueOnError = true;
			_serializer.Deserialize(_storage);

			// if no filter is pre-selected, select the last one, as this is the search filter
            // this increases the performance (no need to display all items)
            if (_filters.SelectedIndex == -1 && _filters.Count > 0)
                _filters.SelectedIndex = _filters.Count - 1; 

            ServerFilterChanged(String.Empty);
		}

		public void Dispose()
		{
			_serializer.Serialize(_storage);
		}

		#region event PropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		void DebugPropertyChanged(object sender, PropertyChangedEventArgs e)
		{ Log.Verbose("Property {0} changed.", e.PropertyName); }

		private void OnPropertyChanged(params string[] properties)
		{
			foreach (String property in properties)
			{
				object state = new PropertyChangedEventArgs(property);
				PropertyChanged(this, (PropertyChangedEventArgs)state);
			}
		}
		#endregion

		#region Server/Client Filtering
		void ServerFilterChanged(string propertyName)
		{
			OnPropertyChanged(propertyName);

			if (!_filters.IsSelectionDirty)
				return;
			_filters.ClearSelectionDirty();
			Refresh();
		}

		public void Refresh() { Refresh(true); }

		public void Refresh(bool applyLocal)
		{
			IIssueFilter filter;
			List<IssueItemView> found = new List<IssueItemView>();

			Dictionary<string, IIssueUser> distinct = new Dictionary<string, IIssueUser>();
			Dictionary<string, IIssueUser> assigned = new Dictionary<string, IIssueUser>();
			assigned[AllUsersFilter.Instance.Id] = AllUsersFilter.Instance;

			Dictionary<string, IIssueState> statuses = new Dictionary<string, IIssueState>();
			statuses[AllStatusFilter.Instance.Id] = AllStatusFilter.Instance;

			if (_filters.TryGetSelection(out filter))
			{
				IIssue[] items;
				if (filter is IIssueFilterWithSearch)
					items = ((IIssueFilterWithSearch)filter).GetIssues(_textFilter, 0, 50);
				else
					items = filter.GetIssues(0, 50);

				foreach (IIssue issue in items)
				{
					IssueItemView item = new IssueItemView(this, issue);
					found.Add(item);

					distinct[item.AssignedTo.Id] = item.AssignedTo;
					distinct[item.ReportedBy.Id] = item.ReportedBy;

					assigned[item.AssignedTo.Id] = item.AssignedTo;
					statuses[item.CurrentState.Id] = item.CurrentState;
				}
			}

			_found = found.ToArray();
			_assignees.AddRange(distinct.Values);

			_assignedFilter.ReplaceContents(assigned.Values);
			if (_assignedFilter.SelectedItem == null)
			{
				_assignedFilter.SelectedItem = AllUsersFilter.Instance;
				if (_assignedFilter.IsSelectionDirty)
					OnPropertyChanged("SelectedAssignmentFilter");
			}
			_statusFilter.ReplaceContents(statuses.Values);
			if (_statusFilter.SelectedItem == null)
			{
				_statusFilter.SelectedItem = AllStatusFilter.Instance;
				if (_statusFilter.IsSelectionDirty)
					OnPropertyChanged("SelectedStatusFilter");
			}

			if(applyLocal)
				LocalFilterChanged();
		}

		void CheckIfFilterChanged(string propertyName)
		{
			OnPropertyChanged(propertyName);
			if (_statusFilter.IsSelectionDirty || _assignedFilter.IsSelectionDirty || _lastTextFilter != _textFilter)
			{
				Log.Verbose("Apply filter for property {0}", propertyName);
				LocalFilterChanged();
			}
		}

		void LocalFilterChanged()
		{
			_statusFilter.ClearSelectionDirty();
			_assignedFilter.ClearSelectionDirty();
			_lastTextFilter = _textFilter;

			List<IssueItemView> filtered = new List<IssueItemView>();

			IIssueFilter filter;
			if (_filters.TryGetSelection(out filter) && filter is IIssueFilterWithSearch)
				Refresh(false);

			foreach (IssueItemView item in _found)
			{
				if(MatchesCurrentFilter(item))
					filtered.Add(item);
			}

			_filtered.ReplaceContents(filtered);
			RebuildActions();
		}

		bool MatchesCurrentFilter(IssueItemView item)
		{
			IIssueUser byAssignee;
			if (_assignedFilter.TryGetSelection(out byAssignee) && byAssignee.Id != AllUsersFilter.Instance.Id)
			{
				if (item.AssignedTo.Id != byAssignee.Id)
					return false;
			}

			IIssueState byStatus;
			if (_statusFilter.TryGetSelection(out byStatus) && byStatus.Id != AllStatusFilter.Instance.Id)
			{
				if (item.CurrentState.Id != byStatus.Id)
					return false;
			}

			if (!String.IsNullOrEmpty(_textFilter))
			{
				foreach (string part in _textFilter.Split(' ', '\t'))
				{
					string phrase = part.Trim();
					if (String.IsNullOrEmpty(phrase))
						continue;
					if (item.Name.IndexOf(phrase, StringComparison.InvariantCultureIgnoreCase) < 0 &&
						item.DisplayId.IndexOf(phrase, StringComparison.InvariantCultureIgnoreCase) < 0 &&
						item.FullDescription.IndexOf(phrase, StringComparison.InvariantCultureIgnoreCase) < 0 &&
						item.CurrentState.Name.IndexOf(phrase, StringComparison.InvariantCultureIgnoreCase) < 0 &&
						item.AssignedTo.Name.IndexOf(phrase, StringComparison.InvariantCultureIgnoreCase) < 0 &&
						item.ReportedBy.Name.IndexOf(phrase, StringComparison.InvariantCultureIgnoreCase) < 0)
						return false;
				}
			}

			return true;
		}
		#endregion

		public IBindingList<IssueItemView> FoundIssues { get { return _filtered; } }

		public IList<IIssue> SelectedIssues
		{
			get
			{
				List<IIssue> issues = new List<IIssue>();
				foreach (IIssue issue in _filtered)
				{
					if (IsSelected(issue) == true)
						issues.Add(issue);
				}
				return issues;
			}
		}

		internal bool IsSelected(IIssue issue)
		{
			bool val;
			return _selected.TryGetValue(issue.Id, out val) && val; 	
		}

		internal void Select(IIssue issue, bool select)
		{
			if (IsSelected(issue) != select)
			{
				if (select)
					_selected[issue.Id] = select;
				else
					_selected.Remove(issue.Id);

				RebuildActions();
                OnPropertyChanged("CanAddWorklog");
			}
		}

		/// <summary>
		/// Used to re-sync with comments edited within the Tortoise dialog
		/// </summary>
		/// <param name="newComments"></param>
		public void SyncComments(string newComments)
		{
			if (newComments == null || newComments == _comments) return;
			if (newComments.EndsWith(_lastCommentAppended))
				newComments = newComments.Substring(0, newComments.Length - _lastCommentAppended.Length);
			if (newComments.Trim() != _comments.Trim())
				this.Comments = newComments;
		}

		public string GetFullComments()
		{ return GetFullComments(this.Comments); }
		protected string GetFullComments(string message)
		{
			StringBuilder result = new StringBuilder(message.TrimEnd());
			int posStart = result.Length;
			if (result.Length > 0)
				result.AppendLine(Environment.NewLine);

			string actionName = "Working";
			if (PerformAction && null != _actions.SelectedItem)
				actionName = _actions.SelectedItem.Name;

			foreach (IIssue issue in SelectedIssues)
			{
				result.AppendFormat("{0} {1} : {2}", actionName, issue.DisplayId, issue.Name);
				result.AppendLine();
			}

			_lastCommentAppended = result.ToString(posStart, result.Length - posStart);
			return result.ToString();
		}

		public IEnumerable<Exception> CommitChanges(int revision, string[] files)
		{
			_serializer.Serialize(_storage);

			List<Exception> errors = new List<Exception>();
			IList<IIssue> selectedIssues = this.SelectedIssues;
			_selected.Clear(); //don't want to do this twice...
			StringBuilder comments = new StringBuilder(Comments);
			if (revision > 0)
			{
				if (comments.Length > 0)
					comments.AppendLine(Environment.NewLine);
				comments.AppendFormat("revision: {0}", revision);
			}
			if (files != null && files.Length > 0)
			{
				if (comments.Length > 0)
					comments.AppendLine();
				foreach (string file in files)
					comments.AppendLine(file);
			}

			string actionName = null;
			if (PerformAction && _actions.SelectedItem != null)
				actionName = _actions.SelectedItem.Name;

			IIssueUser assignee = null;
			if (AssignTo && _assignees.SelectedItem != null)
				assignee = _assignees.SelectedItem;

			foreach (IIssue issue in selectedIssues)
			{
				try
				{
                    if (AddWorklog && TimeSpent.Length > 0)
                        issue.ProcessWorklog(_timeSpent, _timeEstimateRecalcualationMethod, _newTimeEstimate);
                }
				catch (Exception e)
				{
					Log.Error(e, "Failed to commit issue {0} - {1}", issue.DisplayId, issue.Name);
					errors.Add(e);
				}

				try
				{
                    if (actionName != null)
					{
						IIssueUser finalAssignee = assignee;
						if (finalAssignee == ReportedByUser.Instance)
							finalAssignee = issue.ReportedBy;
						if (finalAssignee == null)
							finalAssignee = issue.AssignedTo;

						IIssueAction finalAction = null;
						foreach (IIssueAction action in issue.GetActions())
						{
							if (action.Name == actionName)
							{ finalAction = action; break; }
						}

						if (finalAction == null)
							throw new ApplicationException(String.Format("Action {0} not found.", actionName));
						if (finalAssignee == null)
							throw new ApplicationException("Invalid assignee.");

						issue.ProcessAction(comments.ToString(), finalAction, finalAssignee);
					}
					else
                        issue.AddComment(comments.ToString());
                }
				catch (Exception e)
				{
					Log.Error(e, "Failed to commit issue {0} - {1}", issue.DisplayId, issue.Name);
					errors.Add(e);
				}
			}
			return errors;
		}

		/// <summary>
		/// Get an intersection of the actions available on all visible and selected items.
		/// </summary>
		void RebuildActions()
		{
			Dictionary<string, int> actionsCount = new Dictionary<string, int>();
			Dictionary<string, IIssueAction> actions = new Dictionary<string, IIssueAction>();

			IList<IIssue> selected = this.SelectedIssues;
			foreach (IIssue issue in selected)
			{
				foreach (IIssueAction action in issue.GetActions())
				{
					actions[action.Name] = action;
					int count;
					if (!actionsCount.TryGetValue(action.Name, out count))
						count = 0;
					actionsCount[action.Name] = count + 1;
				}
			}

			foreach (string key in new List<String>(actions.Keys))
			{
				if (actionsCount[key] != selected.Count)
					actions.Remove(key);
			}

			_actions.ReplaceContents(actions.Values);
			OnPropertyChanged("CanPerformActions");
			if(CanPerformActions)
				OnPropertyChanged("SelectedAction");
		}

		#region Data bound properties

		public int SelectedFilter
		{
			get { return _filters.SelectedIndex; }
			set { _filters.SelectedIndex = value; ServerFilterChanged("SelectedFilter"); } 
		}
		public IBindingList<IIssueFilter> Filters { get { return _filters; } }

		public int SelectedAssignmentFilter
		{
			get { return _assignedFilter.SelectedIndex; }
			set { _assignedFilter.SelectedIndex = value; CheckIfFilterChanged("SelectedAssignmentFilter"); } 
		}
		public IBindingList<IIssueUser> AssignmentFilter { get { return _assignedFilter; } }

		public int SelectedStatusFilter
		{
			get { return _statusFilter.SelectedIndex; }
			set { _statusFilter.SelectedIndex = value; CheckIfFilterChanged("SelectedStatusFilter"); } 
		}
		public IBindingList<IIssueState> StatusFilter { get { return _statusFilter; } }
		public string TextFilter
		{
			get { return _textFilter; }
			set { _textFilter = value; CheckIfFilterChanged("TextFilter"); }
		}

		public string Comments
		{
			get { return _comments; }
			set { _comments = value; OnPropertyChanged("Comments"); }
		}

        public bool CanAddWorklog { get { return _selected.Count > 0; }  }

	    public bool AddWorklog
	    {
            get { return _addWorklog; }
            set { _addWorklog = value; OnPropertyChanged("AddWorklog"); }
	    }

        public string TimeSpent
        {
            get { return _timeSpent; }
            set { _timeSpent  = value; OnPropertyChanged("TimeSpent"); }
        }

        public List<string> TimeEstimateMethodsAvailable
	    {
            get
            {
                var result = new List<string>();

                foreach (TimeEstimateRecalcualationMethod enumValue in
                           Enum.GetValues(typeof(TimeEstimateRecalcualationMethod)))
                {
                    var fi = typeof(TimeEstimateRecalcualationMethod).GetField((enumValue.ToString()));

                    var da  = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

                    if (da != null)
                        result.Add(da.Description);
                }

                return result;
            }
	    }

	    public bool CanSpecifyNewEstimate
	    {
            get
            {
                return AddWorklog 
                    && _timeEstimateRecalcualationMethod == TimeEstimateRecalcualationMethod.SetToNewValue;
            }
	    }

	    public int TimeEstimateRecalcualation
	    {
            get { return (int)_timeEstimateRecalcualationMethod; }
            set { _timeEstimateRecalcualationMethod = (TimeEstimateRecalcualationMethod)value; OnPropertyChanged("TimeEstimateRecalcualation"); }
	    }

	    public string NewTimeEstimate
	    {
            get { return _newTimeEstimate; }
            set { _newTimeEstimate = value; OnPropertyChanged("NewTimeEstimate"); }
	    }

        public bool CanPerformActions { get { return _actions.Count > 0; } }

		public bool PerformAction
		{
			get { return _doAction; }
			set { _doAction = value; OnPropertyChanged("PerformAction", "CanAssignTo"); }
		}
		public int SelectedAction
		{ 
			get { return _actions.SelectedIndex; }
			set { _actions.SelectedIndex = value; OnPropertyChanged("SelectedAction"); } 
		}
		public IBindingList<IIssueAction> ActionsAvailable { get { return _actions; } }

		public bool CanAssignTo
		{
			get { return CanPerformActions && AssignTo && PerformAction; }
		}
		public bool AssignTo
		{
			get { return _doAssign; }
			set { _doAssign = value; OnPropertyChanged("AssignTo", "CanAssignTo"); }
		}
		public int SelectedAssignee
		{
			get { return _assignees.SelectedIndex; }
			set { _assignees.SelectedIndex = value; OnPropertyChanged("SelectedAssignee"); } 
		}
		public IBindingList<IIssueUser> PossibleAssignments { get { return _assignees; } }

		#endregion
	}
}
