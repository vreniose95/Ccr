using System;
using System.Runtime.InteropServices;
using Ccr.WinCore.WinCore.Common;

namespace Ccr.WinCore.Common
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct __TASK_BAR_DATA
	{
		internal uint cbSize;
		internal IntPtr hWnd;
		internal uint uCallbackMessage;
		internal __APP_BAR_EDGE uEdge;
		internal __RECT rc;
		internal int lParam;
	}
}