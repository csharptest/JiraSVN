namespace JiraSVN.Plugin.UI
{
    partial class ConnectingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectingDialog));
            this._cancelLabel = new System.Windows.Forms.LinkLabel();
            this._animationTimer = new System.Windows.Forms.Timer(this.components);
            this._connectionLabel = new System.Windows.Forms.Label();
            this._backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // _cancelLabel
            // 
            this._cancelLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._cancelLabel.Location = new System.Drawing.Point(0, 20);
            this._cancelLabel.Name = "_cancelLabel";
            this._cancelLabel.Size = new System.Drawing.Size(192, 23);
            this._cancelLabel.TabIndex = 2;
            this._cancelLabel.TabStop = true;
            this._cancelLabel.Text = "Cancel";
            this._cancelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._cancelLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._cancelLabel_LinkClicked);
            // 
            // _animationTimer
            // 
            this._animationTimer.Interval = 500;
            this._animationTimer.Tick += new System.EventHandler(this._animationTimer_Tick);
            // 
            // _connectionLabel
            // 
            this._connectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._connectionLabel.AutoSize = true;
            this._connectionLabel.Location = new System.Drawing.Point(64, 7);
            this._connectionLabel.Name = "_connectionLabel";
            this._connectionLabel.Size = new System.Drawing.Size(61, 13);
            this._connectionLabel.TabIndex = 0;
            this._connectionLabel.Text = "Connecting";
            this._connectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _backgroundWorker
            // 
            this._backgroundWorker.WorkerSupportsCancellation = true;
            this._backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorker_RunWorkerCompleted);
            // 
            // ConnectingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelLabel;
            this.ClientSize = new System.Drawing.Size(192, 43);
            this.Controls.Add(this._connectionLabel);
            this.Controls.Add(this._cancelLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Please Wait";
            this.Load += new System.EventHandler(this.ConnectingDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectingDialog_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel _cancelLabel;
        private System.Windows.Forms.Timer _animationTimer;
        private System.Windows.Forms.Label _connectionLabel;
        private System.ComponentModel.BackgroundWorker _backgroundWorker;



    }
}