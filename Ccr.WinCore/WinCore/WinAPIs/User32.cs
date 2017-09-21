using System;
using System.Runtime.InteropServices;

namespace Ccr.WinCore.WinCore.WinAPIs
{
	internal static class User32
	{
		[DllImport("User32.dll", SetLastError = true)]
		internal static extern IntPtr FindWindow(
			string lpClassName,
			string lpWindowName);
	}
}
