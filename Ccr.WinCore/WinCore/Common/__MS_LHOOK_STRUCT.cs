using System;
using System.Runtime.InteropServices;
using Ccr.WinCore.WinCore.Common;

namespace Ccr.WinCore.Common
{
	[StructLayout(LayoutKind.Sequential)]
	public struct __MS_LHOOK_STRUCT
	{
		public __POINT pt;
		public uint mouseData;
		public uint flags;
		public uint time;
		public IntPtr dwExtraInfo;
	}
}
