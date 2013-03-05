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
	class BaseIdentifiable<T> : IIdentifiable
	{
		protected readonly T Object;
		private string _id, _name;

		protected BaseIdentifiable(T obj, string id, string name)
		{
			this.Object = obj;
			_id = id;
			_name = name;
		}

		public string Id { get { return _id; } }
		public string Name { get { return _name; } }

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is BaseIdentifiable<T>)
				return this.Id == ((BaseIdentifiable<T>)obj).Id;
			return base.Equals(obj);
		}

		public override string ToString()
		{
			return _name;
		}
	}

	#region Simple Types:

	class JiraUser : BaseIdentifiable<RemoteUser>, IIssueUser
	{
		public JiraUser(RemoteUser user)
			: base(user, user.name, !String.IsNullOrEmpty(user.fullname) ? user.fullname : user.name)
		{ }

		public JiraUser(string name, string fullName)
			: base(null, name, fullName)
		{ }

		public static readonly JiraUser Unknown = new JiraUser(String.Empty, "[Unknown]");
	}

	class JiraStatus : BaseIdentifiable<RemoteStatus>, IIssueState
	{
		public JiraStatus(RemoteStatus status)
			: base(status, status.id, status.name)
		{ }

		private JiraStatus(string name)
			: base(null, name, name)
		{ }

		public static readonly JiraStatus Unknown = new JiraStatus("[Unknown]");
	}

	class JiraAction : BaseIdentifiable<RemoteNamedObject>, IIssueAction
	{
		public JiraAction(RemoteNamedObject action)
			: base(action, action.id, action.name)
		{ }
	}

	#endregion
}
