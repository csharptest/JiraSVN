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
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace Interop.BugTraqProvider
{
	[ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("298B927C-7220-423C-B7B4-6E241F00CD93")]
	public interface IBugTraqProvider
	{
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool ValidateParameters(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters);

		[return: MarshalAs(UnmanagedType.BStr)]
		string GetLinkText(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters);

		[return: MarshalAs(UnmanagedType.BStr)]
		string GetCommitMessage(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string originalMessage);
	}

	[ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("C5C85E31-2F9B-4916-A7BA-8E27D481EE83")]
	public interface IBugTraqProvider2 : IBugTraqProvider
	{
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool ValidateParameters(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters);

		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetLinkText(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters);

		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetCommitMessage(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string originalMessage);

		[return: MarshalAs(UnmanagedType.BStr)]
		string GetCommitMessage2(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters,
			[MarshalAs(UnmanagedType.BStr)] string commonURL,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string originalMessage,
			[MarshalAs(UnmanagedType.BStr)] string bugID,
			[MarshalAs(UnmanagedType.BStr)] out string bugIDOut,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] revPropNames,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] revPropValues);

		[return: MarshalAs(UnmanagedType.BStr)]
		string CheckCommit(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters,
			[MarshalAs(UnmanagedType.BStr)] string commonURL,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string commitMessage);

		[return: MarshalAs(UnmanagedType.BStr)]
		string OnCommitFinished(
			IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string logMessage,
			[MarshalAs(UnmanagedType.U4)] int revision);

		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool HasOptions();

		[return: MarshalAs(UnmanagedType.BStr)]
		string ShowOptionsDialog(
			IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters);
	}
}