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
using System.Drawing;
using System.Windows.Forms;
using JiraSVN.Common.Interfaces;
using CSharpTest.Net.Reflection;

namespace JiraSVN.Plugin.UI
{
    partial class IssuesList : Form
    {
		readonly ToolTipLabel _tipitem;
		readonly IssuesListView _viewControl;
		readonly ObjectSerializer _serializer;
        private Timer _textChangedtimer;

        public IssuesList(IssuesListView viewControl)
		{
			_viewControl = viewControl;
            _serializer = new ObjectSerializer(this, "Top", "Left", "Height", "Width", "_splitter.SplitterDistance", "_worklogGroup.Visible");
			_serializer.ContinueOnError = true;

			_tipitem = new ToolTipLabel();
			this.Controls.Add(_tipitem);

			InitializeComponent();

			new ListViewSort(_listView);

			_viewControl.FoundIssues.ListChanged += new ListChangedEventHandler(FoundIssues_ListChanged);
			_binding.DataSource = _viewControl;
            _textChangedtimer = new Timer();
            _textChangedtimer.Interval = 500;
            _textChangedtimer.Tick += new EventHandler(_textChangedtimer_Tick);
		}

		void FoundIssues_ListChanged(object sender, ListChangedEventArgs e)
		{
			if (e.ListChangedType == ListChangedType.Reset)
			{
				Cursor oldCursor = this.Cursor;
				this.Cursor = Cursors.WaitCursor;
				_listView.Items.Clear();
				this.Update();

				_listView.SuspendLayout();
				_listView.BeginUpdate();
				try
				{
					foreach (IssueItemView item in _viewControl.FoundIssues)
					{
						ListViewItem lvi = new ListViewItem(item.DisplayId);
						lvi.Checked = item.Selected;
						lvi.SubItems.Add(item.Name);
						lvi.SubItems.Add(item.CurrentState.Name);
						lvi.SubItems.Add(item.AssignedTo.Name);
						lvi.SubItems.Add(item.ReportedBy.Name);
						lvi.SubItems.Add(item.LastModifiedOn.ToString("yyyy-MM-dd"));
						lvi.SubItems.Add(item.CreatedOn.ToString("yyyy-MM-dd"));
						lvi.Tag = item;
						lvi.ToolTipText = String.Format("{1}", item.Name, item.FullDescription);

						_listView.Items.Add(lvi);
					}

					if (_listView.Items.Count > 0 && _listView.Items.Count < 200)
					{
						_listView.Columns[0].Width = -1;
						for (int i = 2; i < _listView.Columns.Count; i++)
							_listView.Columns[i].Width = -1;
					}
				}
				finally
				{
					_listView.ResumeLayout();
					_listView.EndUpdate();
					this.Cursor = oldCursor;
				}
			}
		}

		#region Form Load / Close

		private void Form_Load(object sender, EventArgs e)
		{
			_serializer.Deserialize(new CSharpTest.Net.Serialization.StorageClasses.RegistryStorage());
            showTimeTrackingToolStripMenuItem.Checked = _worklogGroup.Visible;
			this.Activate();
		}

		private void Form_Shown(object sender, EventArgs e)
		{
			//Populate initial items...
			FoundIssues_ListChanged(null, new ListChangedEventArgs(ListChangedType.Reset, 0));
		}

		void Form_Closing(object sender, FormClosingEventArgs e)
		{
			_serializer.Serialize(new CSharpTest.Net.Serialization.StorageClasses.RegistryStorage());
			_binding.Dispose();
			//_binding.DataSource = typeof(IssuesListView);
		}

		#endregion

		void listView_ViewSelectedItem(object sender, EventArgs e)
		{
			ListViewItem lvi = _listView.FocusedItem;
			if (lvi != null && lvi.Tag is IIssue)
				((IIssue)lvi.Tag).View();
		}


		private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			IssueItemView issue = e.Item.Tag as IssueItemView;
			if (issue != null)
				issue.Selected = e.Item.Checked;
		}
		
		#region Tool-Tip behavior
		void _listView_MouseMove(object sender, MouseEventArgs e)
		{
			ListViewHitTestInfo hit = _listView.HitTest(e.Location);
			if (_tipitem.Visible && (hit.Item == null || _tipitem.Tag != hit.Item))
				_tipitem.Visible = false;

			if (!_tipitem.Visible)
			{
				Point loc = this.PointToClient(_listView.PointToScreen(e.Location));
				loc.Offset(5, 5);
				_tipitem.Location = loc;
			}
		}

		void _listView_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
		{
            if (e != null && e.Item != null && e.Item.Tag is IIssue
				&& !string.IsNullOrEmpty(e.Item.ToolTipText))	// don't show big blank square when tip is empty
			{
				if (!_tipitem.Visible)
				{
					_tipitem.DisplayWidth = _listView.Width / 2;
                    _tipitem.Tag = e.Item;
                    _tipitem.Text = e.Item.ToolTipText;
                    _tipitem.Visible = true;

                }
			}
		}
		#endregion
		#region Context Menu
		private void contextMenu_Opening(object sender, CancelEventArgs e)
		{
			if (_currentItem == null)
			{
				//e.Cancel = true;
				return;
			}

			for (int i = _contextMenu.Items.Count - 1; i >= 0; i--)
			{
				if (_contextMenu.Items[i] is ToolStripSeparator)
					break;
				_contextMenu.Items.RemoveAt(i);
			}

			if (_currentItem != null && _currentItem.Tag is IssueItemView)
			{
				IssueItemView issue = (IssueItemView)_currentItem.Tag;
				foreach (IIssueAction action in issue.GetActions())
				{
					ActionMenuItem menu = new ActionMenuItem(issue, action);
					menu.Click += new EventHandler(RefreshContents);
					_contextMenu.Items.Add(menu);
				}
			}
		}

		void RefreshContents(object sender, EventArgs e)
		{
			_viewControl.Refresh();
		}

		ListViewItem _currentItem = null;

		private void listView_MouseDown(object sender, MouseEventArgs e)
		{
			_currentItem = null;
			if (e.Button == MouseButtons.Right)
			{
				ListViewHitTestInfo hit = _listView.HitTest(e.Location);
				_currentItem = hit.Item;

				this.viewIssueToolStripMenuItem.Enabled = _currentItem != null;
				//_listView.ContextMenuStrip = (_currentItem == null) ? null : _listView.ContextMenuStrip = _contextMenu;
			}
		}
		#endregion

        private void showTimeTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _worklogGroup.Visible = ((ToolStripMenuItem)sender).Checked;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showTimeTrackingToolStripMenuItem.Checked)
                showTimeTrackingToolStripMenuItem.PerformClick();
        }

        private void _search_TextChanged(object sender, EventArgs e)
        {
            //stop and start the timer
            _textChangedtimer.Stop();
            _textChangedtimer.Start();
        }

        void _textChangedtimer_Tick(object sender, EventArgs e)
        {
            //force a binding
            foreach (Binding binding in _search.DataBindings)
                binding.WriteValue();

            //dont execute this again
            _textChangedtimer.Stop();
        }

	}
}

