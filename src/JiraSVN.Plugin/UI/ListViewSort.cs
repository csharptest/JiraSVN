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
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JiraSVN.Plugin.UI
{
	class ListViewSort
	{
		readonly ListView _listView;
		public ListViewSort(ListView listView)
		{
			_listView = listView;
			_listView.Sorting = SortOrder.Ascending;
			_listView.ListViewItemSorter = new FieldComparer(0, true);
			_listView.ColumnClick += ListHeader_Click;
		}

		#region List View Sorting...
		private void ListHeader_Click(object sender, ColumnClickEventArgs e)
		{
			bool currSortAsc = _listView.ListViewItemSorter is FieldComparer ? ((FieldComparer)_listView.ListViewItemSorter).Ascending : false;
			int currSortIx = _listView.ListViewItemSorter is FieldComparer ? ((FieldComparer)_listView.ListViewItemSorter).ColumnIndex : -1;

			this._listView.ListViewItemSorter = new FieldComparer(e.Column, currSortIx != e.Column ? true : !currSortAsc);
		}

		class FieldComparer : IComparer
		{
			private static Regex _numberMatch = new Regex("(\\d+)");

			public readonly bool Ascending;
			public readonly int ColumnIndex;
			public FieldComparer(int ix, bool ascending) { ColumnIndex = ix; Ascending = ascending; }

			int IComparer.Compare(object x, object y)
			{
				int order = TrueCompare(x, y);
				if (!Ascending)
					return order < 0 ? 1 : order == 0 ? 0 : -1;
				return order;
			}

			private int TrueCompare(object x, object y)
			{
				if (!(x is ListViewItem && y is ListViewItem))
					return 0;

				string s1 = ((ListViewItem)x).SubItems[ColumnIndex].Text;
				string s2 = ((ListViewItem)y).SubItems[ColumnIndex].Text;

				if (ColumnIndex == 0)
					return SortId(s1, s2);

				return StringComparer.OrdinalIgnoreCase.Compare(s1, s2);
			}

			private int SortId(string s1, string s2)
			{
				int x1, x2;
				Match m = _numberMatch.Match(s1);
				if (m.Success && int.TryParse(m.Value, out x1))
				{
					m = _numberMatch.Match(s2);
					if (m.Success && int.TryParse(m.Value, out x2))
					{
						return x1 < x2 ? -1 : x1 == x2 ? 0 : 1;
					}
				}

				return StringComparer.OrdinalIgnoreCase.Compare(s1, s2);
			}
		}
		#endregion

	}
}
