using System;
using System.Runtime.InteropServices;
using System.Windows;
using Ccr.WinCore.Common;
using Ccr.WinCore.WinCore.Common;
using Ccr.WinCore.WinCore.WinAPIs;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable ConvertToAutoPropertyWhenPossible
// ReSharper disable ArrangeAccessorOwnerBody

namespace Ccr.WinCore.Derived
{
	public sealed class __WIN32_SHELL_TASKBAR
	{
		#region Consts
		private const string _className = "Shell_TrayWnd";

		#endregion

		#region Fields
		private static __WIN32_SHELL_TASKBAR _i;
		private Rect _bounds;
		private __TASK_BAR_POSITION _position;
		private bool _alwaysOnTop;
		private bool _autoHide;

		#endregion

		#region Singleton
		public static __WIN32_SHELL_TASKBAR I
		{
			get => _i ?? (_i = new __WIN32_SHELL_TASKBAR());
		}

		#endregion

		#region Properties
		internal Rect Bounds
		{
			get => _bounds;
		}

		internal __TASK_BAR_POSITION Position
		{
			get => _position;
		}

		internal Point Location
		{
			get => _bounds.Location;
		}

		public Size Size
		{
			get => _bounds.Size;
		}

		//Always returns false under Windows 7
		public bool AlwaysOnTop
		{
			get => _alwaysOnTop;
		}

		public bool AutoHide
		{
			get => _autoHide;
		}

		#endregion

		#region Constructor
		private __WIN32_SHELL_TASKBAR()
		{
			var taskbarHandle = User32.FindWindow(
				_className,
				null);

			var data = new __TASK_BAR_DATA
			{
				cbSize = (uint)Marshal.SizeOf(
					typeof(__TASK_BAR_DATA)),
				hWnd = taskbarHandle
			};

			var result = Shell32.SHAppBarMessage(
				__APP_BAR_MESSAGES.GetTaskbarPos,
				ref data);

			if (result == IntPtr.Zero)
				throw new InvalidOperationException(
					$"Taskbar position handle IntPtr cannot be retrieved.");

			_position = (__TASK_BAR_POSITION)data.uEdge;

			_bounds = new Rect(
				new Point(data.rc.left, data.rc.top),
				new Point(data.rc.right, data.rc.bottom));

			data.cbSize = (uint)Marshal.SizeOf(
				typeof(__TASK_BAR_DATA));

			result = Shell32.SHAppBarMessage(
				__APP_BAR_MESSAGES.GetState,
				ref data);

			var state = result.ToInt32();

			_alwaysOnTop = (state & __APP_BAR_STATE.AlwaysOnTop) 
				== __APP_BAR_STATE.AlwaysOnTop;

			_autoHide = (state & __APP_BAR_STATE.Autohide) 
				== __APP_BAR_STATE.Autohide;

		}
		#endregion

	}
}
