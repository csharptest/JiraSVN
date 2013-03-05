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
using JiraSVN.Common.Interfaces;

namespace JiraSVN.Plugin.UI
{
	class AllUsersFilter : IIssueUser
	{
		public static readonly AllUsersFilter Instance = new AllUsersFilter();
		public string Id { get { return this.GetType().FullName; } }
		public string Name { get { return "[All]"; } }
		public override string ToString() { return Name; }
	}

	class ReportedByUser : IIssueUser
	{
		public static readonly ReportedByUser Instance = new ReportedByUser();
		public string Id { get { return this.GetType().FullName; } }
		public string Name { get { return "[Reporter]"; } }
		public override string ToString() { return Name; }
	}

	class AllStatusFilter : IIssueState
	{
		public static readonly AllStatusFilter Instance = new AllStatusFilter();
		public string Id { get { return this.GetType().FullName; } }
		public string Name { get { return "[All]"; } }
		public override string ToString() { return Name; }
	}
}
