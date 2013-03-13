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
using System.IO;
using SharpSvn;

namespace JiraSVN.Plugin
{
	class SvnProperties
	{
		readonly string _base;
		public SvnProperties(string basePath)
		{ _base = basePath; }

		public string Search(string path, bool recurseUp, string propName)
		{

			if (!String.IsNullOrEmpty(_base))
				path = Path.Combine(_base, path);

			if (!Directory.Exists(path) )
			{
				if( !File.Exists(path) )
					throw new FileNotFoundException(path);
				path = Path.GetDirectoryName(path);
			}

            using (var client = new SvnClient()) {
                string result;
                Guid guid;
                do {
                    client.TryGetProperty(SvnTarget.FromString(path), propName, out result);
                    path = Directory.GetParent(path).FullName;
                } while (result == null && recurseUp && client.TryGetRepositoryId(path, out guid));
                return result ?? string.Empty;
            }
		}
	}
}
