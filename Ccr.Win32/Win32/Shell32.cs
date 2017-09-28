﻿using System;
namespace Ccr.Win32
{
	public partial class Shell32
	{
		/// <summary>
		/// CSIDL (constant special item ID list) values provide a unique system-independent way to identify special folders used frequently by applications,
		/// but which may not have the same name or location on any given system. For example, the system folder may be "C:\Windows" on one system and "C:\Winnt" on another.
		/// These constants are defined in Shlobj.h.
		/// </summary>
		/// <remarks>Used by <see cref="SHGetFolderPath(IntPtr, CSIDL, IntPtr, SHGetFolderPathFlags, char*)"/></remarks>
		[Flags]
		public enum CSIDL
		{

			/// <summary>
			/// Administrative Tools
			/// </summary>
			/// <remarks>
			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\Administrative Tools
			/// </remarks>
			CSIDL_ADMINTOOLS = 0x0030,

			/// <summary>
			/// Temporary Burn Folder
			/// </summary>
			/// <remarks>
			/// Maps to %LOCALAPPDATA%\Microsoft\Windows\Burn\Burn
			/// </remarks>
			CSIDL_CDBURN_AREA = 0x003b,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_ADMINTOOLS = 0x002f,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_OEM_LINKS = 0x003a,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_PROGRAMS = 0x0017,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_STARTMENU = 0x0016,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_STARTUP = 0x0018,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_ALTSTARTUP = 0x001e,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_TEMPLATES = 0x002d,

			/// <summary>
			/// <summary>
			CSIDL_DRIVES = 0x0011,

			/// <summary>
			/// <summary>
			CSIDL_CONNECTIONS = 0x0031,

			/// <summary>
			/// <summary>
			CSIDL_CONTROLS = 0x0003,

			/// <summary>
			/// <summary>
			CSIDL_COOKIES = 0x0021,

			/// <summary>
			/// <summary>
			CSIDL_DESKTOP = 0x0000,

			/// <summary>
			/// <summary>
			CSIDL_DESKTOPDIRECTORY = 0x0010,

			/// <summary>
			/// <summary>
			CSIDL_MYDOCUMENTS = CSIDL_PERSONAL,

			/// <summary>
			/// <summary>
			CSIDL_PERSONAL = 0x0005,

			/// <summary>
			/// <summary>
			CSIDL_FAVORITES = 0x0006,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_FAVORITES = 0x001f,

			/// <summary>
			/// <summary>
			CSIDL_FONTS = 0x0014,

			/// <summary>
			/// <summary>
			CSIDL_HISTORY = 0x0022,

			/// <summary>
			/// <summary>
			CSIDL_INTERNET_CACHE = 0x0020,

			/// <summary>
			/// <summary>
			CSIDL_INTERNET = 0x0001,

			/// <summary>
			/// <summary>
			CSIDL_LOCAL_APPDATA = 0x001c,

			/// <summary>
			/// <summary>
			CSIDL_RESOURCES_LOCALIZED = 0x0039,

			/// <summary>
			/// <summary>
			CSIDL_MYMUSIC = 0x000d,

			/// <summary>
			/// <summary>
			CSIDL_NETHOOD = 0x0013,

			/// <summary>
			/// <summary>
			CSIDL_NETWORK = 0x0012,

			/// <summary>
			/// <summary>
			CSIDL_COMPUTERSNEARME = 0x003d,

			/// <summary>
			/// <summary>
			CSIDL_MYPICTURES = 0x0027,

			/// <summary>
			/// <summary>
			CSIDL_PRINTERS = 0x0004,

			/// <summary>
			/// <summary>
			CSIDL_PRINTHOOD = 0x001b,

			/// <summary>
			/// <summary>
			CSIDL_PROFILE = 0x0028,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_APPDATA = 0x0023,

			/// <summary>
			/// <summary>
			CSIDL_PROGRAM_FILES = 0x0026,

			/// <summary>
			/// <summary>
			CSIDL_PROGRAM_FILESX86 = 0x002a,

			/// <summary>
			/// <summary>
			CSIDL_PROGRAM_FILES_COMMON = 0x002b,

			/// <summary>
			/// <summary>
			CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c,

			/// <summary>
			/// <summary>
			CSIDL_PROGRAMS = 0x0002,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_DOCUMENTS = 0x002e,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_MUSIC = 0x0035,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_PICTURES = 0x0036,

			/// <summary>
			/// <summary>
			CSIDL_COMMON_VIDEO = 0x0037,

			/// <summary>
			/// <summary>
			CSIDL_RECENT = 0x0008,

			/// <summary>
			/// <summary>
			CSIDL_BITBUCKET = 0x000a,

			/// <summary>
			/// <summary>
			CSIDL_RESOURCES = 0x0038,

			/// <summary>
			/// <summary>
			CSIDL_APPDATA = 0x001a,

			/// <summary>
			/// <summary>
			CSIDL_SENDTO = 0x0009,

			/// <summary>
			/// <summary>
			CSIDL_STARTMENU = 0x000b,

			/// <summary>
			/// <summary>
			CSIDL_STARTUP = 0x0007,

			/// <summary>
			/// <summary>
			CSIDL_ALTSTARTUP = 0x001d,

			/// <summary>
			/// <summary>
			CSIDL_SYSTEM = 0x0025,

			/// <summary>
			/// <summary>
			CSIDL_SYSTEMX86 = 0x0029,

			/// <summary>
			/// <summary>
			CSIDL_TEMPLATES = 0x0015,

			/// <summary>
			/// <summary>
			CSIDL_MYVIDEO = 0x000e,

			/// <summary>
			/// <summary>
			CSIDL_WINDOWS = 0x0024,

			/// <summary>
			/// Combine with another CSIDL to force the creation of the associated folder if it does not exist.
			/// </summary>
			CSIDL_FLAG_CREATE = 0x8000,

			/// <summary>
			/// Combine with another CSIDL constant to ensure the expansion of environment variables.
			/// </summary>
			CSIDL_FLAG_DONT_UNEXPAND = 0x2000,

			/// <summary>
			/// Combine with another CSIDL constant, except for <see cref="CSIDL_FLAG_CREATE"/>, to return an unverified folder path with no attempt to create or initialize the folder.
			/// </summary>
			CSIDL_FLAG_DONT_VERIFY = 0x4000,

			/// <summary>
			/// Combine with another CSIDL constant to ensure the retrieval of the true system path for the folder, free of any aliased placeholders such as %USERPROFILE%,
			/// returned by <see cref="SHGetFolderLocation(IntPtr, CSIDL, IntPtr, int, out ITEMIDLIST*)"/>. This flag has no effect on paths returned by <see cref="SHGetFolderPath(IntPtr, CSIDL, IntPtr, SHGetFolderPathFlags, char*)"/>.
			/// </summary>
			CSIDL_FLAG_NO_ALIAS = 0x1000,

			/// <summary>
			/// Combine with another CSIDL to force the creation of the associated folder if it does not exist.
			/// </summary>
			CSIDL_FLAG_PER_USER_INIT = 0x0800,

			/// <summary>
			/// A mask for any valid CSIDL flag value.
			/// </summary>
			CSIDL_FLAG_MASK = 0xff00
		}
	}
}