namespace JiraSVN.Plugin.UI
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
            System.Windows.Forms.FlowLayoutPanel panel1;
            System.Windows.Forms.BindingSource possibleAssignmentsBindingSource;
            System.Windows.Forms.BindingSource actionsAvailableBindingSource;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.BindingSource filtersBindingSource;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.BindingSource statusFilterBindingSource;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.BindingSource assignmentFilterBindingSource;
            System.Windows.Forms.ColumnHeader hdrId;
            System.Windows.Forms.ColumnHeader hdrSummary;
            System.Windows.Forms.ColumnHeader hdrAssignedTo;
            System.Windows.Forms.ColumnHeader hdrReportedBy;
            System.Windows.Forms.ColumnHeader hdrLastMod;
            System.Windows.Forms.ColumnHeader hdrCreated;
            System.Windows.Forms.ColumnHeader hdrStatus;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesList));
            this._showHideMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showTimeTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this._binding = new System.Windows.Forms.BindingSource(this.components);
            this._filterGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._filters = new JiraSVN.Plugin.UI.BindingComboBox();
            this._search = new System.Windows.Forms.TextBox();
            this._status = new JiraSVN.Plugin.UI.BindingComboBox();
            this._assigned = new JiraSVN.Plugin.UI.BindingComboBox();
            this._issuesGroup = new System.Windows.Forms.GroupBox();
            this._listView = new System.Windows.Forms.ListView();
            this._contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._doTakeAction = new System.Windows.Forms.CheckBox();
            this._assignTo = new JiraSVN.Plugin.UI.BindingComboBox();
            this._takeAction = new JiraSVN.Plugin.UI.BindingComboBox();
            this._doAssignTo = new System.Windows.Forms.CheckBox();
            this._commentGroup = new System.Windows.Forms.GroupBox();
            this._comment = new System.Windows.Forms.TextBox();
            this._addWorklog = new System.Windows.Forms.CheckBox();
            this._worklogAction = new JiraSVN.Plugin.UI.BindingComboBox();
            this.remainingEstimateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._worklog = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._worklogGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._splitter = new System.Windows.Forms.SplitContainer();
            panel1 = new System.Windows.Forms.FlowLayoutPanel();
            possibleAssignmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            actionsAvailableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label6 = new System.Windows.Forms.Label();
            filtersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            statusFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            assignmentFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            hdrId = new System.Windows.Forms.ColumnHeader();
            hdrSummary = new System.Windows.Forms.ColumnHeader();
            hdrAssignedTo = new System.Windows.Forms.ColumnHeader();
            hdrReportedBy = new System.Windows.Forms.ColumnHeader();
            hdrLastMod = new System.Windows.Forms.ColumnHeader();
            hdrCreated = new System.Windows.Forms.ColumnHeader();
            hdrStatus = new System.Windows.Forms.ColumnHeader();
            panel1.SuspendLayout();
            this._showHideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(possibleAssignmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._binding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(actionsAvailableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(filtersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(statusFilterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(assignmentFilterBindingSource)).BeginInit();
            this._filterGroup.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this._issuesGroup.SuspendLayout();
            this._contextMenu.SuspendLayout();
            this.statusGroup.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this._commentGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remainingEstimateBindingSource)).BeginInit();
            this._worklogGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._splitter.Panel1.SuspendLayout();
            this._splitter.Panel2.SuspendLayout();
            this._splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.ContextMenuStrip = this._showHideMenu;
            panel1.Controls.Add(this.cancelButton);
            panel1.Controls.Add(this.okButton);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panel1.Location = new System.Drawing.Point(8, 452);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            panel1.Size = new System.Drawing.Size(636, 33);
            panel1.TabIndex = 2;
            // 
            // _showHideMenu
            // 
            this._showHideMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTimeTrackingToolStripMenuItem});
            this._showHideMenu.Name = "_showHideMenu";
            this._showHideMenu.Size = new System.Drawing.Size(165, 26);
            // 
            // showTimeTrackingToolStripMenuItem
            // 
            this.showTimeTrackingToolStripMenuItem.Checked = true;
            this.showTimeTrackingToolStripMenuItem.CheckOnClick = true;
            this.showTimeTrackingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTimeTrackingToolStripMenuItem.Name = "showTimeTrackingToolStripMenuItem";
            this.showTimeTrackingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.showTimeTrackingToolStripMenuItem.Text = "Show time tracking";
            this.showTimeTrackingToolStripMenuItem.Click += new System.EventHandler(this.showTimeTrackingToolStripMenuItem_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(559, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(478, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // possibleAssignmentsBindingSource
            // 
            possibleAssignmentsBindingSource.DataMember = "PossibleAssignments";
            possibleAssignmentsBindingSource.DataSource = this._binding;
            // 
            // _binding
            // 
            this._binding.DataSource = typeof(JiraSVN.Plugin.UI.IssuesListView);
            // 
            // actionsAvailableBindingSource
            // 
            actionsAvailableBindingSource.DataMember = "ActionsAvailable";
            actionsAvailableBindingSource.DataSource = this._binding;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label6.AutoSize = true;
            label6.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "AddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            label6.Location = new System.Drawing.Point(294, 7);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(106, 13);
            label6.TabIndex = 2;
            label6.Text = "and update estimate:";
            // 
            // filtersBindingSource
            // 
            filtersBindingSource.DataMember = "Filters";
            filtersBindingSource.DataSource = this._binding;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 7);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 13);
            label2.TabIndex = 0;
            label2.Text = "Apply Filter:";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(358, 34);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 6;
            label3.Text = "Contains:";
            // 
            // statusFilterBindingSource
            // 
            statusFilterBindingSource.DataMember = "StatusFilter";
            statusFilterBindingSource.DataSource = this._binding;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 13);
            label1.TabIndex = 2;
            label1.Text = "Assinged to:";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(201, 34);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(40, 13);
            label4.TabIndex = 4;
            label4.Text = "Status:";
            // 
            // assignmentFilterBindingSource
            // 
            assignmentFilterBindingSource.DataMember = "AssignmentFilter";
            assignmentFilterBindingSource.DataSource = this._binding;
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
            // _filterGroup
            // 
            this._filterGroup.AutoSize = true;
            this._filterGroup.Controls.Add(this.tableLayoutPanel3);
            this._filterGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this._filterGroup.Location = new System.Drawing.Point(8, 8);
            this._filterGroup.Name = "_filterGroup";
            this._filterGroup.Size = new System.Drawing.Size(636, 73);
            this._filterGroup.TabIndex = 0;
            this._filterGroup.TabStop = false;
            this._filterGroup.Text = "Filter";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this._filters, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this._search, 5, 1);
            this.tableLayoutPanel3.Controls.Add(label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(label3, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this._status, 3, 1);
            this.tableLayoutPanel3.Controls.Add(label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(label4, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this._assigned, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(630, 54);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // _filters
            // 
            this._filters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this._filters, 5);
            this._filters.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._filters.DataSource = filtersBindingSource;
            this._filters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._filters.FormattingEnabled = true;
            this._filters.IndexSelected = -1;
            this._filters.Location = new System.Drawing.Point(79, 3);
            this._filters.Name = "_filters";
            this._filters.Size = new System.Drawing.Size(548, 21);
            this._filters.TabIndex = 1;
            // 
            // _search
            // 
            this._search.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "TextFilter", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this._search.Dock = System.Windows.Forms.DockStyle.Fill;
            this._search.Location = new System.Drawing.Point(415, 30);
            this._search.Name = "_search";
            this._search.Size = new System.Drawing.Size(212, 20);
            this._search.TabIndex = 7;
            this._search.TextChanged += new System.EventHandler(this._search_TextChanged);
            // 
            // _status
            // 
            this._status.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedStatusFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._status.DataSource = statusFilterBindingSource;
            this._status.Dock = System.Windows.Forms.DockStyle.Fill;
            this._status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._status.FormattingEnabled = true;
            this._status.IndexSelected = -1;
            this._status.Location = new System.Drawing.Point(247, 30);
            this._status.Name = "_status";
            this._status.Size = new System.Drawing.Size(102, 21);
            this._status.TabIndex = 5;
            // 
            // _assigned
            // 
            this._assigned.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedAssignmentFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._assigned.DataSource = assignmentFilterBindingSource;
            this._assigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this._assigned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._assigned.FormattingEnabled = true;
            this._assigned.IndexSelected = -1;
            this._assigned.Location = new System.Drawing.Point(79, 30);
            this._assigned.Name = "_assigned";
            this._assigned.Size = new System.Drawing.Size(102, 21);
            this._assigned.TabIndex = 3;
            // 
            // _issuesGroup
            // 
            this._issuesGroup.Controls.Add(this._listView);
            this._issuesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this._issuesGroup.Location = new System.Drawing.Point(0, 0);
            this._issuesGroup.Name = "_issuesGroup";
            this._issuesGroup.Size = new System.Drawing.Size(636, 200);
            this._issuesGroup.TabIndex = 1;
            this._issuesGroup.TabStop = false;
            this._issuesGroup.Text = "Issues";
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
            this._listView.Location = new System.Drawing.Point(3, 16);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(630, 181);
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
            this._contextMenu.Size = new System.Drawing.Size(166, 54);
            this._contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // viewIssueToolStripMenuItem
            // 
            this.viewIssueToolStripMenuItem.Name = "viewIssueToolStripMenuItem";
            this.viewIssueToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.viewIssueToolStripMenuItem.Text = "&View Issue...";
            this.viewIssueToolStripMenuItem.ToolTipText = "Open the issue in the default viewer.";
            this.viewIssueToolStripMenuItem.Click += new System.EventHandler(this.listView_ViewSelectedItem);
            // 
            // refreshIssueToolStripMenuItem
            // 
            this.refreshIssueToolStripMenuItem.Name = "refreshIssueToolStripMenuItem";
            this.refreshIssueToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.refreshIssueToolStripMenuItem.Text = "&Refresh Issues List";
            this.refreshIssueToolStripMenuItem.ToolTipText = "Requery the server and refresh the list.";
            this.refreshIssueToolStripMenuItem.Click += new System.EventHandler(this.RefreshContents);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // statusGroup
            // 
            this.statusGroup.AutoSize = true;
            this.statusGroup.Controls.Add(this.tableLayoutPanel2);
            this.statusGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusGroup.Location = new System.Drawing.Point(0, 121);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new System.Drawing.Size(636, 46);
            this.statusGroup.TabIndex = 10;
            this.statusGroup.TabStop = false;
            this.statusGroup.Text = "Status";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.15783F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.84217F));
            this.tableLayoutPanel2.Controls.Add(this._doTakeAction, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this._assignTo, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this._takeAction, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this._doAssignTo, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(630, 27);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // _doTakeAction
            // 
            this._doTakeAction.AutoSize = true;
            this._doTakeAction.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._binding, "PerformAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._doTakeAction.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanPerformActions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._doTakeAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this._doTakeAction.Location = new System.Drawing.Point(3, 3);
            this._doTakeAction.Name = "_doTakeAction";
            this._doTakeAction.Size = new System.Drawing.Size(70, 21);
            this._doTakeAction.TabIndex = 6;
            this._doTakeAction.Text = "Set:";
            this._doTakeAction.UseVisualStyleBackColor = true;
            // 
            // _assignTo
            // 
            this._assignTo.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedAssignee", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._assignTo.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanAssignTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._assignTo.DataSource = possibleAssignmentsBindingSource;
            this._assignTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._assignTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._assignTo.FormattingEnabled = true;
            this._assignTo.IndexSelected = -1;
            this._assignTo.Location = new System.Drawing.Point(418, 3);
            this._assignTo.Name = "_assignTo";
            this._assignTo.Size = new System.Drawing.Size(209, 21);
            this._assignTo.TabIndex = 9;
            // 
            // _takeAction
            // 
            this._takeAction.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "SelectedAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._takeAction.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "PerformAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._takeAction.DataSource = actionsAvailableBindingSource;
            this._takeAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this._takeAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._takeAction.FormattingEnabled = true;
            this._takeAction.IndexSelected = -1;
            this._takeAction.Location = new System.Drawing.Point(79, 3);
            this._takeAction.Name = "_takeAction";
            this._takeAction.Size = new System.Drawing.Size(209, 21);
            this._takeAction.TabIndex = 7;
            // 
            // _doAssignTo
            // 
            this._doAssignTo.AutoSize = true;
            this._doAssignTo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._binding, "AssignTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._doAssignTo.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "PerformAction", true));
            this._doAssignTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._doAssignTo.Location = new System.Drawing.Point(294, 3);
            this._doAssignTo.Name = "_doAssignTo";
            this._doAssignTo.Size = new System.Drawing.Size(118, 21);
            this._doAssignTo.TabIndex = 8;
            this._doAssignTo.Text = "and assign to:";
            this._doAssignTo.UseVisualStyleBackColor = true;
            // 
            // _commentGroup
            // 
            this._commentGroup.AutoSize = true;
            this._commentGroup.Controls.Add(this._comment);
            this._commentGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this._commentGroup.Location = new System.Drawing.Point(0, 0);
            this._commentGroup.Name = "_commentGroup";
            this._commentGroup.Size = new System.Drawing.Size(636, 75);
            this._commentGroup.TabIndex = 11;
            this._commentGroup.TabStop = false;
            this._commentGroup.Text = "Comment";
            // 
            // _comment
            // 
            this._comment.AcceptsReturn = true;
            this._comment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "Comments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this._comment.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._comment.Location = new System.Drawing.Point(3, 16);
            this._comment.Multiline = true;
            this._comment.Name = "_comment";
            this._comment.Size = new System.Drawing.Size(630, 56);
            this._comment.TabIndex = 1;
            // 
            // _addWorklog
            // 
            this._addWorklog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._addWorklog.AutoSize = true;
            this._addWorklog.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._binding, "AddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._addWorklog.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanAddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._addWorklog.Location = new System.Drawing.Point(3, 5);
            this._addWorklog.Name = "_addWorklog";
            this._addWorklog.Size = new System.Drawing.Size(69, 17);
            this._addWorklog.TabIndex = 0;
            this._addWorklog.Text = "Log time:";
            this._addWorklog.UseVisualStyleBackColor = true;
            // 
            // _worklogAction
            // 
            this._worklogAction.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "AddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._worklogAction.DataBindings.Add(new System.Windows.Forms.Binding("IndexSelected", this._binding, "TimeEstimateRecalcualation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._worklogAction.DataSource = this.remainingEstimateBindingSource;
            this._worklogAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this._worklogAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._worklogAction.FormattingEnabled = true;
            this._worklogAction.IndexSelected = -1;
            this._worklogAction.Location = new System.Drawing.Point(418, 3);
            this._worklogAction.Name = "_worklogAction";
            this._worklogAction.Size = new System.Drawing.Size(126, 21);
            this._worklogAction.TabIndex = 3;
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
            this._worklog.Dock = System.Windows.Forms.DockStyle.Fill;
            this._worklog.Location = new System.Drawing.Point(79, 3);
            this._worklog.Name = "_worklog";
            this._worklog.Size = new System.Drawing.Size(209, 20);
            this._worklog.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._binding, "NewTimeEstimate", true));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanSpecifyNewEstimate", true));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(550, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 20);
            this.textBox1.TabIndex = 4;
            // 
            // _worklogGroup
            // 
            this._worklogGroup.AccessibleDescription = "";
            this._worklogGroup.AutoSize = true;
            this._worklogGroup.Controls.Add(this.tableLayoutPanel1);
            this._worklogGroup.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._binding, "CanAddWorklog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._worklogGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._worklogGroup.Location = new System.Drawing.Point(0, 75);
            this._worklogGroup.Name = "_worklogGroup";
            this._worklogGroup.Size = new System.Drawing.Size(636, 46);
            this._worklogGroup.TabIndex = 6;
            this._worklogGroup.TabStop = false;
            this._worklogGroup.Text = "Time tracking";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.85586F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.14414F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this._worklog, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._worklogAction, 3, 0);
            this.tableLayoutPanel1.Controls.Add(label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this._addWorklog, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(630, 27);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // _splitter
            // 
            this._splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitter.Location = new System.Drawing.Point(8, 81);
            this._splitter.Name = "_splitter";
            this._splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitter.Panel1
            // 
            this._splitter.Panel1.Controls.Add(this._issuesGroup);
            // 
            // _splitter.Panel2
            // 
            this._splitter.Panel2.Controls.Add(this._commentGroup);
            this._splitter.Panel2.Controls.Add(this._worklogGroup);
            this._splitter.Panel2.Controls.Add(this.statusGroup);
            this._splitter.Size = new System.Drawing.Size(636, 371);
            this._splitter.SplitterDistance = 200;
            this._splitter.TabIndex = 1;
            // 
            // IssuesList
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(652, 493);
            this.ContextMenuStrip = this._showHideMenu;
            this.Controls.Add(this._splitter);
            this.Controls.Add(this._filterGroup);
            this.Controls.Add(panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "IssuesList";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Issue(s)";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            panel1.ResumeLayout(false);
            this._showHideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(possibleAssignmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._binding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(actionsAvailableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(filtersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(statusFilterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(assignmentFilterBindingSource)).EndInit();
            this._filterGroup.ResumeLayout(false);
            this._filterGroup.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this._issuesGroup.ResumeLayout(false);
            this._contextMenu.ResumeLayout(false);
            this.statusGroup.ResumeLayout(false);
            this.statusGroup.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this._commentGroup.ResumeLayout(false);
            this._commentGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remainingEstimateBindingSource)).EndInit();
            this._worklogGroup.ResumeLayout(false);
            this._worklogGroup.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this._splitter.Panel1.ResumeLayout(false);
            this._splitter.Panel2.ResumeLayout(false);
            this._splitter.Panel2.PerformLayout();
            this._splitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ListView _listView;
		private System.Windows.Forms.CheckBox _doTakeAction;
		private JiraSVN.Plugin.UI.BindingComboBox _filters;
		private System.Windows.Forms.TextBox _search;
		private JiraSVN.Plugin.UI.BindingComboBox _status;
		private JiraSVN.Plugin.UI.BindingComboBox _assigned;
		private System.Windows.Forms.TextBox _comment;
		private System.Windows.Forms.SplitContainer _splitter;
		private System.Windows.Forms.CheckBox _doAssignTo;
		private JiraSVN.Plugin.UI.BindingComboBox _takeAction;
        private JiraSVN.Plugin.UI.BindingComboBox _assignTo;
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
        private System.Windows.Forms.ContextMenuStrip _showHideMenu;
        private System.Windows.Forms.ToolStripMenuItem showTimeTrackingToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox statusGroup;
        private System.Windows.Forms.GroupBox _commentGroup;
        private System.Windows.Forms.GroupBox _issuesGroup;
        private System.Windows.Forms.GroupBox _filterGroup;
    }
}