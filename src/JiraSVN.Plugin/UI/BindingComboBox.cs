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

namespace JiraSVN.Plugin.UI
{
	/// <summary>
	/// What is this for?
	/// It fixes a flaw in the databinding of the SelectedIndex property when the databinding
	/// is configured to update on property change instead of on validation.  When configured
	/// this way the combo box will get confused about the currently selected item and revert
	/// it's selection to the prior value.  By subscribing to the change of the SelectedIndex
	/// below we can then use the control's "BeginInvoke" to delay execution of the change
	/// until after the completion of the control's state change.  This way the control will
	/// complete setting the newly selected item prior to us being notified of the property
	/// change.
	/// </summary>
	class BindingComboBox : ComboBox
	{
		public BindingComboBox()
		{
			base.SelectedIndexChanged += new EventHandler(BindingComboBox_SelectedIndexChanged);
		}

		public override int SelectedIndex
		{
			get { return base.SelectedIndex; }
			set
			{
				if (value < Items.Count)
					base.SelectedIndex = value;
			}
		}

		void BindingComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(IndexSelectedChanged != null)
				this.BeginInvoke(IndexSelectedChanged, sender, e);
		}

		public event EventHandler IndexSelectedChanged;

		public int IndexSelected
		{
			get { return base.SelectedIndex; }
			set 
			{
				if (value >= -1 && value < Items.Count)
					base.SelectedIndex = value;
			}
		}

		protected override void OnDataSourceChanged(EventArgs e)
		{
			base.OnDataSourceChanged(e);
		}

		protected override void SetItemsCore(System.Collections.IList value)
		{
			base.SetItemsCore(value);
		}
	}
}
