using System.Runtime.InteropServices;

namespace Ccr.WinCore.WinCore.Common
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct __RECT
	{
		internal int left;
		internal int top;
		internal int right;
		internal int bottom;
	}
}