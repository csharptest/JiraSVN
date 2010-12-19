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
            System.Windows.Forms.Label label6;
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
            this._worklogGroup = new System.Windows.Forms.GroupBox();
            this._worklogAction = new CSharpTest.Net.SvnPlugin.UI.BindingComboBox();
            this._binding = new System.Windows.Forms.BindingSource(this.components);
            this.remainingEstimateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._worklog = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._addWorklog = new System.Windows.Forms.CheckBox();
            this._assignTo = new CSharpTest.Net.SvnPlugin.UI.BindingComboBox();
            this._doAssignTo = new System.Windows.Forms.CheckBox();
            this._doTakeAction = new System.Windows.Forms.CheckBox();
            this._takeAction = new CSharpTest.Net.SvnPlugin.UI.BindingComboBox();
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
            label6 = new System.Windows.Forms.Label();
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
            this._worklogGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._binding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remainingEstimateBindingSource)).BeginInit();
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
            panel1.Controls.Add(this._worklogGroup);
            panel1.Controls.Add(this._assignTo);
            panel1.Controls.Add(this._doAssignTo);
            panel1.Controls.Add(this._doTakeAction);
            panel1.Controls.Add(this._takeAction);
            panel1.Controls.Add(this.cancelButton);
            panel1.Controls.Add(this.okButton);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(3, 316);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(5);
            panel1.Size = new System.Drawing.Size(628, 93);
            panel1.TabIndex = 2;
            // 
            // _worklogGroup
            // 
            this._worklogGroup.AccessibleDescription = "";
            this._worklogGroup.Controls.Add(this._worklogAction);
            this._worklogGroup.Controls.Add(this._worklog);
            this._worklogGroup.Controls.Add(this.textBox1);
            this._worklogGroup.Controls.Add(label6);
            this._worklogGroup.Controls.Add(this._addWorklog);
            this._worklogGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this._worklogGroup.Location = new System.Drawing.Point(5, 5);
            this._worklogGroup.Name = "_worklogGroup";
            this._worklogGroup.Size = new System.Drawing.Size(618, 50);
            this._worklogGroup.TabIndex = 6;
            this._worklogGroup.TabStop = false;
            this._worklogGroup.Text = "Worklog";
            // 
            // _worklogAction
            // 
            this._worklogAction.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "AddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._worklogAction.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "TimeEstimateRecalcualation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._worklogAction.DataSource = this.remainingEstimateBindingSource;
            this._worklogAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._worklogAction.FormattingEnabled = true;
            this._worklogAction.IndexSelected = -1;
            this._worklogAction.Location = new System.Drawing.Point(285, 18);
            this._worklogAction.Name = "_worklogAction";
            this._worklogAction.Size = new System.Drawing.Size(145, 21);
            this._worklogAction.TabIndex = 3;
            // 
            // _binding
            // 
            this._binding.DataSource = typeof(CSharpTest.Net.SvnPlugin.UI.IssuesListView);
            // 
            // remainingEstimateBindingSource
            // 
            this.remainingEstimateBindingSource.DataMember = "TimeEstimateMethodsAvailable";
            this.remainingEstimateBindingSource.DataSource = this._binding;
            // 
            // _worklog
            // 
            this._worklog.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "AddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._worklog.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "TimeSpent", true));
            this._worklog.Location = new System.Drawing.Point(92, 19);
            this._worklog.Name = "_worklog";
            this._worklog.Size = new System.Drawing.Size(75, 20);
            this._worklog.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "NewTimeEstimate", true));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanSpecifyNewEstimate", true));
            this.textBox1.Location = new System.Drawing.Point(436, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "AddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            label6.Location = new System.Drawing.Point(173, 22);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(106, 13);
            label6.TabIndex = 2;
            label6.Text = "and update estimate:";
            // 
            // _addWorklog
            // 
            this._addWorklog.AutoSize = true;
            this._addWorklog.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._binding, "AddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._addWorklog.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanAddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._addWorklog.Location = new System.Drawing.Point(11, 20);
            this._addWorklog.Name = "_addWorklog";
            this._addWorklog.Size = new System.Drawing.Size(69, 17);
            this._addWorklog.TabIndex = 0;
            this._addWorklog.Text = "Log time:";
            this._addWorklog.UseVisualStyleBackColor = true;
            // 
            // _assignTo
            // 
            this._assignTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._assignTo.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedAssignee", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._assignTo.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanAssignTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._assignTo.DataSource = possibleAssignmentsBindingSource;
            this._assignTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._assignTo.FormattingEnabled = true;
            this._assignTo.IndexSelected = -1;
            this._assignTo.Location = new System.Drawing.Point(298, 64);
            this._assignTo.Name = "_assignTo";
            this._assignTo.Size = new System.Drawing.Size(144, 21);
            this._assignTo.TabIndex = 9;
            // 
            // possibleAssignmentsBindingSource
            // 
            possibleAssignmentsBindingSource.DataMember = "PossibleAssignments";
            possibleAssignmentsBindingSource.DataSource = this._binding;
            // 
            // _doAssignTo
            // 
            this._doAssignTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._doAssignTo.AutoSize = true;
            this._doAssignTo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._binding, "AssignTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._doAssignTo.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "PerformAction", true));
            this._doAssignTo.Location = new System.Drawing.Point(200, 68);
            this._doAssignTo.Name = "_doAssignTo";
            this._doAssignTo.Size = new System.Drawing.Size(92, 17);
            this._doAssignTo.TabIndex = 8;
            this._doAssignTo.Text = "and assign to:";
            this._doAssignTo.UseVisualStyleBackColor = true;
            // 
            // _doTakeAction
            // 
            this._doTakeAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._doTakeAction.AutoSize = true;
            this._doTakeAction.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._binding, "PerformAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._doTakeAction.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanPerformActions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._doTakeAction.Location = new System.Drawing.Point(12, 68);
            this._doTakeAction.Name = "_doTakeAction";
            this._doTakeAction.Size = new System.Drawing.Size(45, 17);
            this._doTakeAction.TabIndex = 6;
            this._doTakeAction.Text = "Set:";
            this._doTakeAction.UseVisualStyleBackColor = true;
            // 
            // _takeAction
            // 
            this._takeAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._takeAction.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._takeAction.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "PerformAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._takeAction.DataSource = actionsAvailableBindingSource;
            this._takeAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._takeAction.FormattingEnabled = true;
            this._takeAction.IndexSelected = -1;
            this._takeAction.Location = new System.Drawing.Point(63, 64);
            this._takeAction.Name = "_takeAction";
            this._takeAction.Size = new System.Drawing.Size(119, 21);
            this._takeAction.TabIndex = 7;
            // 
            // actionsAvailableBindingSource
            // 
            actionsAvailableBindingSource.DataMember = "ActionsAvailable";
            actionsAvailableBindingSource.DataSource = this._binding;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(541, 62);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(460, 62);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
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
            panel2.Location = new System.Drawing.Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(628, 72);
            panel2.TabIndex = 0;
            // 
            // _search
            // 
            this._search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._search.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "TextFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._search.Location = new System.Drawing.Point(415, 39);
            this._search.Name = "_search";
            this._search.Size = new System.Drawing.Size(201, 20);
            this._search.TabIndex = 7;
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
            this._status.TabIndex = 5;
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
            label4.TabIndex = 4;
            label4.Text = "Status:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(358, 42);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 6;
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
            this._assigned.TabIndex = 3;
            // 
            // assignmentFilterBindingSource
            // 
            assignmentFilterBindingSource.DataMember = "AssignmentFilter";
            assignmentFilterBindingSource.DataSource = this._binding;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 13);
            label1.TabIndex = 2;
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
            this._filters.Size = new System.Drawing.Size(534, 21);
            this._filters.TabIndex = 1;
            // 
            // filtersBindingSource
            // 
            filtersBindingSource.DataMember = "Filters";
            filtersBindingSource.DataSource = this._binding;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 13);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 13);
            label2.TabIndex = 0;
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
            label5.Location = new System.Drawing.Point(3, 3);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(4);
            label5.Size = new System.Drawing.Size(67, 21);
            label5.TabIndex = 0;
            label5.Text = "Comments:";
            // 
            // _splitter
            // 
            this._splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitter.Location = new System.Drawing.Point(3, 75);
            this._splitter.Name = "_splitter";
            this._splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitter.Panel1
            // 
            this._splitter.Panel1.Controls.Add(this._listView);
            this._splitter.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // _splitter.Panel2
            // 
            this._splitter.Panel2.Controls.Add(this._comment);
            this._splitter.Panel2.Controls.Add(label5);
            this._splitter.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this._splitter.Size = new System.Drawing.Size(628, 241);
            this._splitter.SplitterDistance = 151;
            this._splitter.TabIndex = 1;
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
            this._listView.Location = new System.Drawing.Point(3, 3);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(622, 145);
            this._listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._listView.TabIndex = 0;
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
            this._contextMenu.Size = new System.Drawing.Size(169, 54);
            this._contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // viewIssueToolStripMenuItem
            // 
            this.viewIssueToolStripMenuItem.Name = "viewIssueToolStripMenuItem";
            this.viewIssueToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.viewIssueToolStripMenuItem.Text = "&View Issue...";
            this.viewIssueToolStripMenuItem.ToolTipText = "Open the issue in the default viewer.";
            this.viewIssueToolStripMenuItem.Click += new System.EventHandler(this.listView_ViewSelectedItem);
            // 
            // refreshIssueToolStripMenuItem
            // 
            this.refreshIssueToolStripMenuItem.Name = "refreshIssueToolStripMenuItem";
            this.refreshIssueToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.refreshIssueToolStripMenuItem.Text = "&Refresh Issues List";
            this.refreshIssueToolStripMenuItem.ToolTipText = "Requery the server and refresh the list.";
            this.refreshIssueToolStripMenuItem.Click += new System.EventHandler(this.RefreshContents);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // _comment
            // 
            this._comment.AcceptsReturn = true;
            this._comment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "Comments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this._comment.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._comment.Location = new System.Drawing.Point(3, 24);
            this._comment.Multiline = true;
            this._comment.Name = "_comment";
            this._comment.Size = new System.Drawing.Size(622, 59);
            this._comment.TabIndex = 1;
            // 
            // IssuesList
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this._splitter);
            this.Controls.Add(panel2);
            this.Controls.Add(panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "IssuesList";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Issue(s)";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            this._worklogGroup.ResumeLayout(false);
            this._worklogGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._binding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remainingEstimateBindingSource)).EndInit();
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
		private System.Windows.Forms.BindingSource _binding;
		private System.Windows.Forms.ContextMenuStrip _contextMenu;
		private System.Windows.Forms.ToolStripMenuItem viewIssueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource remainingEstimateBindingSource;
        private System.Windows.Forms.GroupBox _worklogGroup;
        private BindingComboBox _worklogAction;
        private System.Windows.Forms.TextBox _worklog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox _addWorklog;
    }
}