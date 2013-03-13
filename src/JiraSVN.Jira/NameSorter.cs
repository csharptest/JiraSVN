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
using System.Collections.Generic;
using JiraSVN.Common.Interfaces;

namespace JiraSVN.Jira
{
	class NameSorter<T> : IComparer<T>
		where T : IIdentifiable
	{
		int IComparer<T>.Compare(T x, T y)
		{
			int result = StringComparer.OrdinalIgnoreCase.Compare(x.Name, y.Name);
			if (result == 0)
				result = StringComparer.OrdinalIgnoreCase.Compare(x.Id, y.Id);
			return result;
		}
	}
}
