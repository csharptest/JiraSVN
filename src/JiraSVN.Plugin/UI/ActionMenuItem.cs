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
using System.Windows.Forms;
using JiraSVN.Common.Interfaces;

namespace JiraSVN.Plugin.UI
{
	class ActionMenuItem : ToolStripMenuItem
	{
		IssueItemView _issue;
		IIssueAction _action;
		public ActionMenuItem(IssueItemView item, IIssueAction action)
			: base(action.Name)
		{
			_issue = item;
			_action = action;

			ToolTipText = String.Format("{0} and assign to {1}.", _action.Name, _issue.ReportedBy.Name);

			base.Click += new EventHandler(DoClick);
		}

		void DoClick(object sender, EventArgs args)
		{
			try
			{
				_issue.ProcessAction(String.Empty, _action, _issue.ReportedBy);
			}
			catch (Exception e)
			{
				Control ctrl = sender as Control;

				MessageBox.Show(ctrl == null ? null : ctrl.FindForm(), e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
