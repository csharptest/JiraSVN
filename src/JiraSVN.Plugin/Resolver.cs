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
using System.Reflection;
using System.Threading;

namespace JiraSVN.Plugin
{
    static class Resolver
    {
        static int _hooked;
        static Dictionary<string, Assembly> _assemblies = new Dictionary<string,Assembly>(StringComparer.Ordinal);
        
        public static void Hook()
        {
            if(0 == Interlocked.Exchange(ref _hooked, 1))
                AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
        }

        static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            lock (typeof(Resolver))
            {
                try
                {
                    Assembly loaded = null;
                    if (_assemblies.TryGetValue(args.Name, out loaded))
                        return loaded;

                    Log.Verbose("Resolving {0}", args.Name);
                    AssemblyName name = new AssemblyName(args.Name);
                    string path = Path.Combine(Path.GetDirectoryName(typeof(Resolver).Assembly.Location), name.Name + ".dll");
                    if (File.Exists(path))
                    {
                        AssemblyName test = AssemblyName.GetAssemblyName(path);
                        if (name == test)
                            loaded = Assembly.LoadFile(path, AppDomain.CurrentDomain.Evidence);
                        _assemblies[args.Name] = loaded;
                    }

                    Log.Info("Resolved {0} = ", path, loaded);
                    return loaded;
                }
                catch(Exception e) 
                {
                    Log.Error(e);
                    return null; 
                }
            }
        }
    }
}
