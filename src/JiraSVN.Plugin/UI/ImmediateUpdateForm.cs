#region Copyright 2009 by Roger Knapp, Licensed under the Apache License, Version 2.0
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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JiraSVN.Plugin.UI
{
	class ImmediateUpdateForm : IDisposable
	{
		readonly Control _top;
		readonly ControlEventHandler Added;
		readonly ControlEventHandler Removed;

		public ImmediateUpdateForm(Control topLevel)
		{
			Added = new ControlEventHandler(ChildAdded);
			Removed = new ControlEventHandler(ChildRemoved);

			_top = topLevel;
			BindToControl(_top, true);
		}

		public void Dispose()
		{
			BindToControl(_top, false);
		}

		void BindToControl(Control parent, bool adding)
		{
			if (adding)
			{
				parent.ControlAdded += Added;
				parent.ControlRemoved += Removed;
				HookControlValidate(parent);
			}
			else
			{
				parent.ControlAdded -= Added;
				parent.ControlRemoved -= Removed;
			}

			foreach (Control ch in parent.Controls)
				BindToControl(ch, adding);
		}

		void ChildRemoved(object sender, ControlEventArgs e)
		{
			BindToControl(e.Control, false);
		}

		void ChildAdded(object sender, ControlEventArgs e)
		{
			BindToControl(e.Control, true);
		}

		void HookControlValidate(Control ctrl)
		{
			if (ctrl is ListControl)
				((ListControl)ctrl).SelectedValueChanged += new EventHandler(ValidateControl);
			if (ctrl is TextBoxBase)
				((TextBoxBase)ctrl).TextChanged += new EventHandler(ValidateControl);
			if (ctrl is CheckBox)
				((CheckBox)ctrl).CheckedChanged += new EventHandler(ValidateControl);
			if (ctrl is RadioButton)
				((RadioButton)ctrl).CheckedChanged += new EventHandler(ValidateControl);
		}

		void ValidateControl(object sender, EventArgs args)
		{
			Form frm = _top.FindForm();
			if (frm != null)
			{
				if (sender is Control && ((Control)sender).Focused)
				{
					Log.Verbose("{0} Changed: {1}", sender, ((Control)sender).Text);
					((Control)sender).DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
					((Control)sender).DataBindings[0].ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
				}
			}
		}
	}
}
