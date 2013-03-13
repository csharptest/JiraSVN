using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiraSVN.Plugin.UI
{
    /// <summary>
    /// A connection Dialog
    /// </summary>
    public partial class ConnectingDialog : Form
    {
        /// <summary>
        /// The amount of dots currently visible on the label
        /// </summary>
        private int _connectionLabelDots;
        private string _connectionText;

        /// <summary>
        /// Create a new dialog
        /// </summary>
        public ConnectingDialog()
        {
            InitializeComponent();
            _connectionLabelDots = 0;
            _connectionText = _connectionLabel.Text;
        }

        /// <summary>
        /// The backgroundworker for this dialog
        /// </summary>
        public BackgroundWorker Worker { get { return _backgroundWorker; } }

        /// <summary>
        /// The Exception from the Worker
        /// </summary>
        public Exception Error { get; private set; }

        /// <summary>
        /// The Argument for the Background Worker
        /// </summary>
        public object Argument { get; set; }

        /// <summary>
        /// The result of the worker
        /// </summary>
        public object Result { get; set; }

        private void _cancelLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _backgroundWorker.CancelAsync();
            DialogResult = DialogResult.Cancel;
        }

        private void _animationTimer_Tick(object sender, EventArgs e)
        {
            _connectionLabelDots = (_connectionLabelDots + 1) % 4;
            _connectionLabel.Text = _connectionText + new string('.', _connectionLabelDots);
        }

        private void ConnectingDialog_Load(object sender, EventArgs e)
        {
            _animationTimer.Enabled = true;
            Worker.RunWorkerAsync(Argument);
        }

        private void ConnectingDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _animationTimer.Enabled = false;
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Error = e.Error;
                DialogResult = DialogResult.Abort;
            }
            else if (e.Cancelled)
                DialogResult = DialogResult.Cancel;
            else
            {
                DialogResult = DialogResult.OK;
                Result = e.Result;
            }
        }
    }
}
