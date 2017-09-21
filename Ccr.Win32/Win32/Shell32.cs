using System;
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

			/// <summary>			/// Administrative Tools			/// </summary>
			/// <summary>			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Administrative Tools			/// </summary>
			CSIDL_COMMON_ADMINTOOLS = 0x002f,

			/// <summary>			/// OEM Links			///</summary>>
			/// <summary>			/// Maps to %ALLUSERSPROFILE%\OEM Links			/// </summary>
			CSIDL_COMMON_OEM_LINKS = 0x003a,

			/// <summary>			/// Programs			/// </summary>>
			/// <summary>			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs			/// </summary>
			CSIDL_COMMON_PROGRAMS = 0x0017,

			/// <summary>			/// Start Menu			/// </summary>
			/// <summary>			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu			/// </summary>
			CSIDL_COMMON_STARTMENU = 0x0016,

			/// <summary>			/// Startup			/// </summary>
			/// <summary>			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp			/// </summary>
			CSIDL_COMMON_STARTUP = 0x0018,

			/// <summary>			/// Startup			/// </summary>
			/// <summary>			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp			/// </summary>
			CSIDL_COMMON_ALTSTARTUP = 0x001e,

			/// <summary>			/// Templates			/// </summary>
			/// <summary>			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Templates			/// </summary>
			CSIDL_COMMON_TEMPLATES = 0x002d,

			/// <summary>			/// Computer			/// </summary>
			/// <summary>			/// virtual folder			/// </summary>
			CSIDL_DRIVES = 0x0011,

			/// <summary>			/// Network Connections			/// </summary>
			/// <summary>			/// Maps to virtual folder			/// </summary>
			CSIDL_CONNECTIONS = 0x0031,

			/// <summary>			/// Account Pictures			/// </summary>
			/// <summary>			/// Maps to virtual folder			/// </summary>
			CSIDL_CONTROLS = 0x0003,

			/// <summary>			/// Cookies			/// </summary>
			/// <summary>			/// Maps to %APPDATA%\Microsoft\Windows\Cookies			/// </summary>
			CSIDL_COOKIES = 0x0021,

			/// <summary>			/// Desktop			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Desktop			/// </summary>
			CSIDL_DESKTOP = 0x0000,

			/// <summary>			/// Desktop			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Desktop			/// </summary>
			CSIDL_DESKTOPDIRECTORY = 0x0010,

			/// <summary>			/// Documents			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Documents			/// </summary>
			CSIDL_MYDOCUMENTS = CSIDL_PERSONAL,

			/// <summary>			/// Documents			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Documents			/// </summary>
			CSIDL_PERSONAL = 0x0005,

			/// <summary>			/// Favorites			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Favorites			/// </summary>
			CSIDL_FAVORITES = 0x0006,

			/// <summary>			/// Favorites			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Favorites			/// </summary>
			CSIDL_COMMON_FAVORITES = 0x001f,

			/// <summary>			/// Fonts			/// </summary>
			/// <summary>			/// Maps to %windir%\Fonts			/// </summary>
			CSIDL_FONTS = 0x0014,

			/// <summary>			/// History			/// </summary>
			/// <summary>			/// Maps to %LOCALAPPDATA%\Microsoft\Windows\History			/// </summary>
			CSIDL_HISTORY = 0x0022,

			/// <summary>			/// Temporary Internet Files			/// </summary>
			/// <summary>			/// Maps to %LOCALAPPDATA%\Microsoft\Windows\Temporary Internet Files			/// </summary>
			CSIDL_INTERNET_CACHE = 0x0020,

			/// <summary>			/// The Internet			/// </summary>
			/// <summary>			/// virtual folder			/// </summary>
			CSIDL_INTERNET = 0x0001,

			/// <summary>			/// Local			/// </summary>
			/// <summary>			/// Maps to %LOCALAPPDATA% (%USERPROFILE%\AppData\Local)			/// </summary>
			CSIDL_LOCAL_APPDATA = 0x001c,

			/// <summary>			/// None			/// </summary>
			/// <summary>			/// Maps to %windir%\resources\0409 (code page)			/// </summary>
			CSIDL_RESOURCES_LOCALIZED = 0x0039,

			/// <summary>			/// Music			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Music			/// </summary>
			CSIDL_MYMUSIC = 0x000d,

			/// <summary>			/// Network Shortcuts			/// </summary>
			/// <summary>			/// Maps to %APPDATA%\Microsoft\Windows\Network Shortcuts			/// </summary>
			CSIDL_NETHOOD = 0x0013,

			/// <summary>			/// Network			/// </summary>
			/// <summary>			/// virtual folder			/// </summary>
			CSIDL_NETWORK = 0x0012,

			/// <summary>			/// Network			/// </summary>
			/// <summary>			/// virtual folder			/// </summary>
			CSIDL_COMPUTERSNEARME = 0x003d,

			/// <summary>			/// Pictures			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Pictures			/// </summary>
			CSIDL_MYPICTURES = 0x0027,

			/// <summary>			/// Printers			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Music\Playlists			/// </summary>
			CSIDL_PRINTERS = 0x0004,

			/// <summary>			/// Printer Shortcuts			/// </summary>
			/// <summary>			/// virtual folder			/// </summary>
			CSIDL_PRINTHOOD = 0x001b,

			/// <summary>			/// The user's username (%USERNAME%)			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE% (%SystemDrive%\Users\%USERNAME%)			/// </summary>
			CSIDL_PROFILE = 0x0028,

			/// <summary>			/// ProgramData			/// </summary>
			/// <summary>			/// Maps to %ALLUSERSPROFILE% (%ProgramData%, %SystemDrive%\ProgramData)			/// </summary>
			CSIDL_COMMON_APPDATA = 0x0023,

			/// <summary>			/// Program Files			/// </summary>
			/// <summary>			/// Maps to %ProgramFiles% (%SystemDrive%\Program Files)			/// </summary>
			CSIDL_PROGRAM_FILES = 0x0026,

			/// <summary>			/// Program Files			/// </summary>
			/// <summary>			/// Maps to %ProgramFiles% (%SystemDrive%\Program Files)			/// </summary>
			CSIDL_PROGRAM_FILESX86 = 0x002a,

			/// <summary>			/// Common Files			/// </summary>
			/// <summary>			/// Maps to %ProgramFiles%\Common Files			/// </summary>
			CSIDL_PROGRAM_FILES_COMMON = 0x002b,

			/// <summary>			/// Common Files			/// </summary>
			/// <summary>			/// Maps to %ProgramFiles%\Common Files			/// </summary>
			CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c,

			/// <summary>			/// Programs			/// </summary>
			/// <summary>			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs			/// </summary>
			CSIDL_PROGRAMS = 0x0002,

			/// <summary>			/// Public Desktop			/// </summary>
			/// <summary>			/// Maps to %PUBLIC%\Desktop			/// </summary>
			CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,

			/// <summary>			/// Public Documents			/// </summary>
			/// <summary>			/// Maps to %PUBLIC%\Documents			/// </summary>
			CSIDL_COMMON_DOCUMENTS = 0x002e,

			/// <summary>			/// Public Music			/// </summary>
			/// <summary>			/// Maps to %PUBLIC%\Music			/// </summary>
			CSIDL_COMMON_MUSIC = 0x0035,

			/// <summary>			/// Public Pictures			/// </summary>
			/// <summary>			/// Maps to %PUBLIC%\Pictures			/// </summary>
			CSIDL_COMMON_PICTURES = 0x0036,

			/// <summary>			/// Public Videos			/// </summary>
			/// <summary>			/// Maps to %%PUBLIC%\Videos			/// </summary>
			CSIDL_COMMON_VIDEO = 0x0037,

			/// <summary>			/// Recent Items			/// </summary>
			/// <summary>			/// Maps to %APPDATA%\Microsoft\Windows\Recent			/// </summary>
			CSIDL_RECENT = 0x0008,

			/// <summary>			/// Recycle Bin			/// </summary>
			/// <summary>			/// virtual folder			/// </summary>
			CSIDL_BITBUCKET = 0x000a,

			/// <summary>			/// Resources			/// </summary>
			/// <summary>			/// Maps to %windir%\Resources			/// </summary>
			CSIDL_RESOURCES = 0x0038,

			/// <summary>			/// Roaming			/// </summary>
			/// <summary>			/// Maps to %APPDATA% (%USERPROFILE%\AppData\Roaming)			/// </summary>
			CSIDL_APPDATA = 0x001a,

			/// <summary>			/// SendTo			/// </summary>
			/// <summary>			/// Maps to %%APPDATA%\Microsoft\Windows\SendTo			/// </summary>
			CSIDL_SENDTO = 0x0009,

			/// <summary>			/// Start Menu			/// </summary>
			/// <summary>			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu			/// </summary>
			CSIDL_STARTMENU = 0x000b,

			/// <summary>			/// Startup			/// </summary>
			/// <summary>			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp			/// </summary>
			CSIDL_STARTUP = 0x0007,

			/// <summary>			/// Startup			/// </summary>
			/// <summary>			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp			/// </summary>
			CSIDL_ALTSTARTUP = 0x001d,

			/// <summary>			/// System32			/// </summary>
			/// <summary>			/// Maps to %windir%\system32			/// </summary>
			CSIDL_SYSTEM = 0x0025,

			/// <summary>			/// System32			/// </summary>
			/// <summary>			/// Maps to %windir%\system32			/// </summary>
			CSIDL_SYSTEMX86 = 0x0029,

			/// <summary>			/// Templates			/// </summary>
			/// <summary>			/// Maps to %APPDATA%\Microsoft\Windows\Templates			/// </summary>
			CSIDL_TEMPLATES = 0x0015,

			/// <summary>			/// Videos			/// </summary>
			/// <summary>			/// Maps to %USERPROFILE%\Videos			/// </summary>
			CSIDL_MYVIDEO = 0x000e,

			/// <summary>			/// Windows			/// </summary>
			/// <summary>			/// Maps to %windir%			/// </summary>
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
