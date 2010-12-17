namespace CSharpTest.Net.SvnPlugin.UI
{
    partial class IssuesList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Panel panel1;
			System.Windows.Forms.Panel actionpanel;
			System.Windows.Forms.BindingSource possibleAssignmentsBindingSource;
			System.Windows.Forms.BindingSource actionsAvailableBindingSource;
			System.Windows.Forms.Panel panel2;
			System.Windows.Forms.BindingSource statusFilterBindingSource;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.BindingSource assignmentFilterBindingSource;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.BindingSource filtersBindingSource;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.ColumnHeader hdrId;
			System.Windows.Forms.ColumnHeader hdrSummary;
			System.Windows.Forms.ColumnHeader hdrAssignedTo;
			System.Windows.Forms.ColumnHeader hdrReportedBy;
			System.Windows.Forms.ColumnHeader hdrLastMod;
			System.Windows.Forms.ColumnHeader hdrCreated;
			System.Windows.Forms.ColumnHeader hdrStatus;
			System.Windows.Forms.Label label5;
			this._assignTo = new CSharpTest.Net.SvnPlugin.UI.BindingComboBox();
			this._binding = new System.Windows.Forms.BindingSource(this.components);
			this._doAssignTo = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this._takeAction = new CSharpTest.Net.SvnPlugin.UI.BindingComboBox();
			this._doTakeAction = new System.Windows.Forms.CheckBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this._search = new System.Windows.Forms.TextBox();
			this._status = new CSharpTest.Net.SvnPlugin.UI.BindingComboBox();
			this._assigned = new CSharpTest.Net.SvnPlugin.UI.BindingComboBox();
			this._filters = new CSharpTest.Net.SvnPlugin.UI.BindingComboBox();
			this._splitter = new System.Windows.Forms.SplitContainer();
			this._listView = new System.Windows.Forms.ListView();
			this._contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.viewIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this._comment = new System.Windows.Forms.TextBox();
			panel1 = new System.Windows.Forms.Panel();
			actionpanel = new System.Windows.Forms.Panel();
			possibleAssignmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			actionsAvailableBindingSource = new System.Windows.Forms.BindingSource(this.components);
			panel2 = new System.Windows.Forms.Panel();
			statusFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			assignmentFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
			label1 = new System.Windows.Forms.Label();
			filtersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			label2 = new System.Windows.Forms.Label();
			hdrId = new System.Windows.Forms.ColumnHeader();
			hdrSummary = new System.Windows.Forms.ColumnHeader();
			hdrAssignedTo = new System.Windows.Forms.ColumnHeader();
			hdrReportedBy = new System.Windows.Forms.ColumnHeader();
			hdrLastMod = new System.Windows.Forms.ColumnHeader();
			hdrCreated = new System.Windows.Forms.ColumnHeader();
			hdrStatus = new System.Windows.Forms.ColumnHeader();
			label5 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			actionpanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._binding)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(possibleAssignmentsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(actionsAvailableBindingSource)).BeginInit();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(statusFilterBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(assignmentFilterBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(filtersBindingSource)).BeginInit();
			this._splitter.Panel1.SuspendLayout();
			this._splitter.Panel2.SuspendLayout();
			this._splitter.SuspendLayout();
			this._contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(actionpanel);
			panel1.Controls.Add(this.cancelButton);
			panel1.Controls.Add(this.okButton);
			panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel1.Location = new System.Drawing.Point(0, 327);
			panel1.Name = "panel1";
			panel1.Padding = new System.Windows.Forms.Padding(10);
			panel1.Size = new System.Drawing.Size(592, 46);
			panel1.TabIndex = 3;
			// 
			// actionpanel
			// 
			actionpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			actionpanel.Controls.Add(this._assignTo);
			actionpanel.Controls.Add(this._doAssignTo);
			actionpanel.Controls.Add(this.label6);
			actionpanel.Controls.Add(this._takeAction);
			actionpanel.Controls.Add(this._doTakeAction);
			actionpanel.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanPerformActions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			actionpanel.Location = new System.Drawing.Point(0, 0);
			actionpanel.Name = "actionpanel";
			actionpanel.Padding = new System.Windows.Forms.Padding(10);
			actionpanel.Size = new System.Drawing.Size(417, 46);
			actionpanel.TabIndex = 7;
			// 
			// _assignTo
			// 
			this._assignTo.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedAssignee", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._assignTo.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanAssignTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._assignTo.DataSource = possibleAssignmentsBindingSource;
			this._assignTo.Dock = System.Windows.Forms.DockStyle.Left;
			this._assignTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._assignTo.FormattingEnabled = true;
			this._assignTo.IndexSelected = -1;
			this._assignTo.Location = new System.Drawing.Point(274, 10);
			this._assignTo.Name = "_assignTo";
			this._assignTo.Size = new System.Drawing.Size(120, 21);
			this._assignTo.TabIndex = 6;
			// 
			// _binding
			// 
			this._binding.DataSource = typeof(CSharpTest.Net.SvnPlugin.UI.IssuesListView);
			// 
			// possibleAssignmentsBindingSource
			// 
			possibleAssignmentsBindingSource.DataMember = "PossibleAssignments";
			possibleAssignmentsBindingSource.DataSource = this._binding;
			// 
			// _doAssignTo
			// 
			this._doAssignTo.AutoSize = true;
			this._doAssignTo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._binding, "AssignTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._doAssignTo.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "PerformAction", true));
			this._doAssignTo.Dock = System.Windows.Forms.DockStyle.Left;
			this._doAssignTo.Location = new System.Drawing.Point(182, 10);
			this._doAssignTo.Name = "_doAssignTo";
			this._doAssignTo.Size = new System.Drawing.Size(92, 26);
			this._doAssignTo.TabIndex = 4;
			this._doAssignTo.Text = "and assign to ";
			this._doAssignTo.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(172, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(10, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = " ";
			// 
			// _takeAction
			// 
			this._takeAction.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._takeAction.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "PerformAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._takeAction.DataSource = actionsAvailableBindingSource;
			this._takeAction.Dock = System.Windows.Forms.DockStyle.Left;
			this._takeAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._takeAction.FormattingEnabled = true;
			this._takeAction.IndexSelected = -1;
			this._takeAction.Location = new System.Drawing.Point(52, 10);
			this._takeAction.Name = "_takeAction";
			this._takeAction.Size = new System.Drawing.Size(120, 21);
			this._takeAction.TabIndex = 3;
			// 
			// actionsAvailableBindingSource
			// 
			actionsAvailableBindingSource.DataMember = "ActionsAvailable";
			actionsAvailableBindingSource.DataSource = this._binding;
			// 
			// _doTakeAction
			// 
			this._doTakeAction.AutoSize = true;
			this._doTakeAction.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._binding, "PerformAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._doTakeAction.Dock = System.Windows.Forms.DockStyle.Left;
			this._doTakeAction.Location = new System.Drawing.Point(10, 10);
			this._doTakeAction.Name = "_doTakeAction";
			this._doTakeAction.Size = new System.Drawing.Size(42, 26);
			this._doTakeAction.TabIndex = 2;
			this._doTakeAction.Text = "Set";
			this._doTakeAction.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cancelButton.Location = new System.Drawing.Point(504, 11);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(423, 11);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			panel2.Controls.Add(this._search);
			panel2.Controls.Add(this._status);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(this._assigned);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(this._filters);
			panel2.Controls.Add(label2);
			panel2.Dock = System.Windows.Forms.DockStyle.Top;
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(592, 72);
			panel2.TabIndex = 4;
			// 
			// _search
			// 
			this._search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._search.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "TextFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._search.Location = new System.Drawing.Point(415, 39);
			this._search.Name = "_search";
			this._search.Size = new System.Drawing.Size(165, 20);
			this._search.TabIndex = 5;
			// 
			// _status
			// 
			this._status.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedStatusFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._status.DataSource = statusFilterBindingSource;
			this._status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._status.FormattingEnabled = true;
			this._status.IndexSelected = -1;
			this._status.Location = new System.Drawing.Point(243, 39);
			this._status.Name = "_status";
			this._status.Size = new System.Drawing.Size(100, 21);
			this._status.TabIndex = 4;
			// 
			// statusFilterBindingSource
			// 
			statusFilterBindingSource.DataMember = "StatusFilter";
			statusFilterBindingSource.DataSource = this._binding;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(197, 42);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(40, 13);
			label4.TabIndex = 3;
			label4.Text = "Status:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(358, 42);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(51, 13);
			label3.TabIndex = 3;
			label3.Text = "Contains:";
			// 
			// _assigned
			// 
			this._assigned.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedAssignmentFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._assigned.DataSource = assignmentFilterBindingSource;
			this._assigned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._assigned.FormattingEnabled = true;
			this._assigned.IndexSelected = -1;
			this._assigned.Location = new System.Drawing.Point(82, 39);
			this._assigned.Name = "_assigned";
			this._assigned.Size = new System.Drawing.Size(100, 21);
			this._assigned.TabIndex = 4;
			// 
			// assignmentFilterBindingSource
			// 
			assignmentFilterBindingSource.DataMember = "AssignmentFilter";
			assignmentFilterBindingSource.DataSource = this._binding;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(11, 42);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(65, 13);
			label1.TabIndex = 3;
			label1.Text = "Assinged to:";
			// 
			// _filters
			// 
			this._filters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._filters.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._filters.DataSource = filtersBindingSource;
			this._filters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._filters.FormattingEnabled = true;
			this._filters.IndexSelected = -1;
			this._filters.Location = new System.Drawing.Point(82, 10);
			this._filters.Name = "_filters";
			this._filters.Size = new System.Drawing.Size(498, 21);
			this._filters.TabIndex = 2;
			// 
			// filtersBindingSource
			// 
			filtersBindingSource.DataMember = "Filters";
			filtersBindingSource.DataSource = this._binding;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(15, 13);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(61, 13);
			label2.TabIndex = 1;
			label2.Text = "Apply Filter:";
			// 
			// hdrId
			// 
			hdrId.Text = "Id";
			// 
			// hdrSummary
			// 
			hdrSummary.Text = "Summary";
			hdrSummary.Width = 400;
			// 
			// hdrAssignedTo
			// 
			hdrAssignedTo.Text = "Assigned To";
			hdrAssignedTo.Width = 100;
			// 
			// hdrReportedBy
			// 
			hdrReportedBy.Text = "Reported By";
			hdrReportedBy.Width = 100;
			// 
			// hdrLastMod
			// 
			hdrLastMod.Text = "Last Modified";
			hdrLastMod.Width = 100;
			// 
			// hdrCreated
			// 
			hdrCreated.Text = "Created On";
			hdrCreated.Width = 100;
			// 
			// hdrStatus
			// 
			hdrStatus.Text = "Status";
			hdrStatus.Width = 100;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Dock = System.Windows.Forms.DockStyle.Top;
			label5.Location = new System.Drawing.Point(0, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(59, 13);
			label5.TabIndex = 1;
			label5.Text = "Comments:";
			// 
			// _splitter
			// 
			this._splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this._splitter.Location = new System.Drawing.Point(0, 72);
			this._splitter.Name = "_splitter";
			this._splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// _splitter.Panel1
			// 
			this._splitter.Panel1.Controls.Add(this._listView);
			// 
			// _splitter.Panel2
			// 
			this._splitter.Panel2.Controls.Add(this._comment);
			this._splitter.Panel2.Controls.Add(label5);
			this._splitter.Size = new System.Drawing.Size(592, 255);
			this._splitter.SplitterDistance = 181;
			this._splitter.TabIndex = 5;
			// 
			// _listView
			// 
			this._listView.CheckBoxes = true;
			this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            hdrId,
            hdrSummary,
            hdrStatus,
            hdrAssignedTo,
            hdrReportedBy,
            hdrLastMod,
            hdrCreated});
			this._listView.ContextMenuStrip = this._contextMenu;
			this._listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._listView.FullRowSelect = true;
			this._listView.Location = new System.Drawing.Point(0, 0);
			this._listView.Name = "_listView";
			this._listView.Size = new System.Drawing.Size(592, 181);
			this._listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this._listView.TabIndex = 2;
			this._listView.UseCompatibleStateImageBehavior = false;
			this._listView.View = System.Windows.Forms.View.Details;
			this._listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_ItemChecked);
			this._listView.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this._listView_ItemMouseHover);
			this._listView.MouseMove += new System.Windows.Forms.MouseEventHandler(this._listView_MouseMove);
			this._listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDown);
			// 
			// _contextMenu
			// 
			this._contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewIssueToolStripMenuItem,
            this.refreshIssueToolStripMenuItem,
            this.toolStripSeparator1});
			this._contextMenu.Name = "_contextMenu";
			this._contextMenu.Size = new System.Drawing.Size(138, 32);
			this._contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
			// 
			// viewIssueToolStripMenuItem
			// 
			this.viewIssueToolStripMenuItem.Name = "viewIssueToolStripMenuItem";
			this.viewIssueToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.viewIssueToolStripMenuItem.Text = "&View Issue...";
			this.viewIssueToolStripMenuItem.ToolTipText = "Open the issue in the default viewer.";
			this.viewIssueToolStripMenuItem.Click += new System.EventHandler(this.listView_ViewSelectedItem);
			// 
			// refreshIssueToolStripMenuItem
			// 
			this.refreshIssueToolStripMenuItem.Name = "refreshIssueToolStripMenuItem";
			this.refreshIssueToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.refreshIssueToolStripMenuItem.Text = "&Refresh Issues List";
			this.refreshIssueToolStripMenuItem.ToolTipText = "Requery the server and refresh the list.";
			this.refreshIssueToolStripMenuItem.Click += new System.EventHandler(this.RefreshContents);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
			// 
			// _comment
			// 
			this._comment.AcceptsReturn = true;
			this._comment.AcceptsTab = true;
			this._comment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "Comments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._comment.Dock = System.Windows.Forms.DockStyle.Fill;
			this._comment.Location = new System.Drawing.Point(0, 13);
			this._comment.Multiline = true;
			this._comment.Name = "_comment";
			this._comment.Size = new System.Drawing.Size(592, 57);
			this._comment.TabIndex = 0;
			// 
			// IssuesList
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.Controls.Add(this._splitter);
			this.Controls.Add(panel2);
			this.Controls.Add(panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 400);
			this.Name = "IssuesList";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Issue(s)";
			this.Load += new System.EventHandler(this.Form_Load);
			this.Shown += new System.EventHandler(this.Form_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
			panel1.ResumeLayout(false);
			actionpanel.ResumeLayout(false);
			actionpanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._binding)).EndInit();
			((System.ComponentModel.ISupportInitialize)(possibleAssignmentsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(actionsAvailableBindingSource)).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(statusFilterBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(assignmentFilterBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(filtersBindingSource)).EndInit();
			this._splitter.Panel1.ResumeLayout(false);
			this._splitter.Panel2.ResumeLayout(false);
			this._splitter.Panel2.PerformLayout();
			this._splitter.ResumeLayout(false);
			this._contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ListView _listView;
		private System.Windows.Forms.CheckBox _doTakeAction;
		private CSharpTest.Net.SvnPlugin.UI.BindingComboBox _filters;
		private System.Windows.Forms.TextBox _search;
		private CSharpTest.Net.SvnPlugin.UI.BindingComboBox _status;
		private CSharpTest.Net.SvnPlugin.UI.BindingComboBox _assigned;
		private System.Windows.Forms.TextBox _comment;
		private System.Windows.Forms.SplitContainer _splitter;
		private System.Windows.Forms.CheckBox _doAssignTo;
		private CSharpTest.Net.SvnPlugin.UI.BindingComboBox _takeAction;
		private CSharpTest.Net.SvnPlugin.UI.BindingComboBox _assignTo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.BindingSource _binding;
		private System.Windows.Forms.ContextMenuStrip _contextMenu;
		private System.Windows.Forms.ToolStripMenuItem viewIssueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshIssueToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}