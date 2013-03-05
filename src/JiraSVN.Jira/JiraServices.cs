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
using System.Web.Services.Protocols;
using JiraSVN.Common.Interfaces;

namespace JiraSVN.Jira
{
	/// <summary>
	/// Provides an initial connection to Jira Services
	/// </summary>
	public class JiraServices : IIssuesService
	{
		/// <summary> Names this type of connection </summary>
		public string ServiceName
		{
			get { return "Jira"; }
		}

		/// <summary> Property we look for </summary>
		public string UriPropertyName
		{
			get { return "jira:url"; }
		}

		/// <summary>
		/// Establises a connection to the jira soap server
		/// </summary>
		public bool Connect(string url, string userName, string password, Converter<string, string> settings, out IIssuesServiceConnection connection)
		{
			try
			{
				connection = new JiraConnection(url, userName, password, settings);
				return true;
			}
			catch (SoapException se)
			{
				if (se.Message.IndexOf("RemoteAuthenticationException", StringComparison.OrdinalIgnoreCase) > 0 ||
					se.Message.IndexOf("Invalid username or password", StringComparison.OrdinalIgnoreCase) > 0)
				{
					Log.Error(se, "Logon failed for user {0} at {1}", userName, url);
					connection = null;
					return false;
				}

				throw;
			}
		}

	}
#if false		
	/// <summary> Simple test </summary>
	[TestFixture]
	public class JiraServicesTest
	{
		/// <summary> Simple test </summary>
		[Test]
		public void TestService()
		{
			IIssuesServiceConnection connection;
			string[] args = File.ReadAllLines(@"C:\" + this.GetType().Name + ".test");

			//Assert.IsFalse(new JiraServices().Connect(args[0], args[1], "Not the right password", out connection));
			Assert.IsTrue(new JiraServices().Connect(args[0], args[1], args[2], out connection));

			Assert.Greater(connection.GetFilters().Length, 1);
			Assert.Greater(connection.GetUsers().Length, 0);

			IIssueFilter filter = connection.GetFilters()[0];
			IIssue[] issues = filter.GetIssues();
			Assert.Greater(issues.Length, 0);

			IIssue issue = issues[0];

			Assert.AreEqual(connection.CurrentUser, issue.AssignedTo);
			Assert.AreNotEqual(connection.CurrentUser, issue.ReportedBy);
		}
	}
#endif
}
