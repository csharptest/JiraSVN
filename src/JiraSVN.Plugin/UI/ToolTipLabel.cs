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
using System.Drawing;
using System.Windows.Forms;

namespace JiraSVN.Plugin.UI
{
	class ToolTipLabel : Label
	{
		int _keepWidth;
	
		public ToolTipLabel()
		{
			this.BorderStyle = BorderStyle.FixedSingle;
			this.BackColor = SystemColors.Info;
			this.ForeColor = SystemColors.InfoText;
			this.AutoSize = false;
			this.Width = _keepWidth = 400;
			this.Height = 150;
			this.Visible = false;
		}

		public int DisplayWidth { get { return _keepWidth; } set { _keepWidth = value; } }

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				if (String.IsNullOrEmpty(value) || Parent == null)
				{
					base.Text = String.Empty;
					this.Visible = false;
					this.Parent.MouseLeave -= new EventHandler(Parent_MouseLeave);
				}
				else
				{
					base.Text = value;
					this.Parent.Controls.SetChildIndex(this, 0);
					this.Parent.MouseLeave += new EventHandler(Parent_MouseLeave);

					SizeF size = this.Size;
					try
					{
						using (Graphics g = Graphics.FromHwnd(this.Handle))
							size = g.MeasureString(this.Text, this.Font, this.DisplayWidth);
					}
					catch { }

					this.Width = 4 + this.Margin.Horizontal + (int)size.Width;
					this.Height = 4 + this.Margin.Vertical + (int)size.Height;
				}
			}
		}

		void Parent_MouseLeave(object sender, EventArgs e)
		{
			this.Visible = false;
			this.Parent.MouseLeave -= new EventHandler(Parent_MouseLeave);
		}
	}
}
