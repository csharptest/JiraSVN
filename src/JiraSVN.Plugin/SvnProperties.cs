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
using System.IO;

namespace CSharpTest.Net.JiraSVN.Plugin
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
			
			return SearchPath(new DirectoryInfo(path), recurseUp, propName);
		}

		private static string SearchPath(DirectoryInfo di, bool recurseUp, string propName)
		{
			DirectoryInfo[] svn = di.GetDirectories(".svn");
			if( svn.Length == 0 )
				svn = di.GetDirectories("_svn", SearchOption.TopDirectoryOnly);

			foreach (DirectoryInfo diSvn in svn)
			{
				string value;
				FileInfo[] dirProps = diSvn.GetFiles("dir-props");
				if (dirProps.Length == 0)
					dirProps = diSvn.GetFiles("dir-prop-base");

				if (dirProps.Length == 1 && null != (value = ReadSetting(dirProps[0], propName)))
					return value;
			}

			if (recurseUp && di.Parent != null)
				return SearchPath(di.Parent, true, propName);

			return null;
		}

		private static string ReadSetting(FileInfo file, string propName)
		{
			Dictionary<string, string> props = ReadSettings(file);
			
			string value;
			if (props.TryGetValue(propName, out value))
				return value;
			return null;
		}

		private static Dictionary<string, string> ReadSettings(FileInfo file)
		{
			Dictionary<string, string> properties = new Dictionary<string, string>();
			try
			{
				int count;
				char[] buffer;
				string line, key, value;

				using (TextReader rdr = file.OpenText())
				{
					while (null != (line = rdr.ReadLine()))
					{
						if (line.StartsWith("K ") == false)
							continue;

						count = int.Parse(line.Substring(2));
						buffer = new char[count];
						if (count != rdr.Read(buffer, 0, count))
							break;

						key = new String(buffer);
						rdr.ReadLine();//value followed by eol
						if (null == (line = rdr.ReadLine()))
							break;

						if (line.StartsWith("V ") == false)
							continue;

						count = int.Parse(line.Substring(2));
						buffer = new char[count];
						if (count != rdr.Read(buffer, 0, count))
							break;

						value = new String(buffer);
						properties.Add(key, value);
						
						rdr.ReadLine();
					}
				}
			}
			catch { }
			return properties;
		}
	}
}
