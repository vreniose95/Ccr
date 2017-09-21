using System;
using System.Runtime.InteropServices;
using Ccr.WinCore.Common;
using Ccr.WinCore.Derived;
using Ccr.WinCore.WinCore.Common;

namespace Ccr.WinCore.WinCore.WinAPIs
{
	public partial class Shell32
	{
		/*
		[DllImport(nameof(Shell32), CharSet = CharSet.Unicode)]
		public static extern unsafe HResult SHGetFolderPath(
			IntPtr hwndOwner,
			CSIDL nFolder,
			IntPtr hToken,
			SHGetFolderPathFlags dwFlags,
			[Friendly(FriendlyFlags.Array)] char* pszPath);

		/// <summary>
		/// Retrieves the path of a known folder as an ITEMIDLIST structure.
		/// </summary>
		/// <param name="rfid">A reference to the <see cref="KNOWNFOLDERID"/> that identifies the folder. The folders associated with the known folder IDs might not exist on a particular system.</param>
		/// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, it is one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.</param>
		/// <param name="hToken">
		/// An access token used to represent a particular user. This parameter is usually set to NULL, in which case the function tries to access the current user's instance of the folder. However, you may need to assign a value to <paramref name="hToken"/> for those folders that can have multiple users but are treated as belonging to a single user. The most commonly used folder of this type is Documents.
		/// The calling application is responsible for correct impersonation when <paramref name="hToken"/> is non-null. It must have appropriate security privileges for the particular user, including TOKEN_QUERY and TOKEN_IMPERSONATE, and the user's registry hive must be currently mounted. See Access Control for further discussion of access control issues.
		/// Assigning the <paramref name="hToken"/> parameter a value of -1 indicates the Default User. This allows clients of SHGetKnownFolderIDList to find folder locations (such as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special folders such as Documents and Desktop. Any items added to the Default User folder also appear in any new user account. Note that access to the Default User folders requires administrator privileges.
		/// </param>
		/// <param name="pidl">When this method returns, contains a pointer to the PIDL of the folder. This parameter is passed uninitialized. The caller is responsible for freeing the returned PIDL when it is no longer needed by calling <see cref="ILFree(void*)"/>.</param>
		/// <returns>
		/// Returns S_OK if successful, or an error value otherwise, including the following:
		/// <see cref="HResult.Code.E_INVALIDARG"/>
		/// Among other things, this value can indicate that the rfid parameter references a KNOWNFOLDERID that is not present on the system. Not all KNOWNFOLDERID values are present on all systems. Use IKnownFolderManager::GetFolderIds to retrieve the set of KNOWNFOLDERID values for the current system.
		/// </returns>
		[DllImport(nameof(Shell32))]
		public static extern unsafe HResult SHGetKnownFolderIDList(
			[MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
			KNOWN_FOLDER_FLAG dwFlags,
			IntPtr hToken,
			out ITEMIDLIST* pidl);


		/// <summary>
		/// Converts an item identifier list to a file system path.
		/// </summary>
		/// <param name="pidl">The address of an item identifier list that specifies a file or directory location relative to the root of the namespace (the desktop).</param>
		/// <param name="pszPath">The address of a buffer to receive the file system path. This buffer must be at least MAX_PATH characters in size.</param>
		/// <returns>Returns TRUE if successful; otherwise, FALSE.</returns>
		[DllImport(nameof(Shell32), CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool SHGetPathFromIDList(
			ITEMIDLIST* pidl,
			[Friendly(FriendlyFlags.Array)] char* pszPath);

		/// <summary>
		/// Frees an <see cref="ITEMIDLIST"/> structure allocated by the Shell.
		/// </summary>
		/// <param name="pidl">A pointer to the <see cref="ITEMIDLIST"/> structure to be freed. This parameter can be NULL.</param>
		/// <remarks>
		/// <see cref="ILFree(void*)"/> is often used with <see cref="ITEMIDLIST"/> structures allocated by one of the other IL functions, but it can be used to free any such structure returned by the Shell—for example, the <see cref="ITEMIDLIST"/> structure returned by SHBrowseForFolder or used in a call to <see cref="SHGetFolderLocation(IntPtr, CSIDL, IntPtr, int, out ITEMIDLIST*)"/>.
		/// </remarks>
		[DllImport(nameof(Shell32))]
		public static extern unsafe void ILFree(void* pidl);





		/// <summary>
		/// Gets the path of a folder identified by a CSIDL value.
		/// </summary>
		/// <param name="rfid">
		/// A <see cref="Guid"/> value that identifies the folder whose path is to be retrieved.
		/// As defined in <see cref="KNOWNFOLDERID"/>.
		/// </param>
		/// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.</param>
		/// <param name="hToken">
		/// An access token that represents a particular user. If this parameter is NULL, which is the most common usage, the function requests the known folder for the current user.
		/// Assigning the hToken parameter a value of -1 indicates the Default User.
		/// Microsoft Windows 2000 and earlier: Always set this parameter to NULL.
		/// Windows XP and later: This parameter is usually set to NULL, but you might need to assign a non-NULL value to hToken for those folders that can have multiple users but are treated as belonging to a single user.The most commonly used folder of this type is Documents.
		/// </param>
		/// <returns>
		/// The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
		/// </returns>
		/// <remarks>
		/// As of Windows Vista, this function is merely a wrapper for <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/>.
		/// The returned path does not include a trailing backslash.
		/// For example, "C:\Users" is returned rather than "C:\Users\".
		/// </remarks>
		public static unsafe string SHGetKnownFolderPath(Guid rfid, KNOWN_FOLDER_FLAG dwFlags = KNOWN_FOLDER_FLAG.None, IntPtr hToken = default(IntPtr))
		{
			char* pszPath;
			SHGetKnownFolderPath(rfid, dwFlags, hToken, out pszPath).ThrowOnFailure();

			try
			{
				return new string(pszPath);
			}
			finally
			{
				Marshal.FreeCoTaskMem((IntPtr)pszPath);
			}
		}

		public static unsafe string SHGetPathFromIDList(ITEMIDLIST* pidl)
		{
			char* pszPath = stackalloc char[Kernel32.MAX_PATH + 1];
			if (!SHGetPathFromIDList(pidl, pszPath))
			{
				throw new ArgumentException();
			}

			return new string(pszPath);
		}*/

		[DllImport("shell32.dll", SetLastError = true)]
		internal static extern IntPtr SHAppBarMessage(
				__APP_BAR_MESSAGES dwMessage,
				ref __TASK_BAR_DATA pData);
		
		/// <summary>Specify special retrieval options for known folders.</summary>
		/// <remarks>These values supersede CSIDL values, which have parallel meanings.</remarks>
		[Flags]
		public enum KNOWN_FOLDER_FLAG : uint
		{
			/// <summary>
			/// Define no flags.
			/// </summary>
			None = 0x00000000,

			/// <summary>
			/// Build a simple IDList (PIDL) This value can be used when you want to retrieve the file system path
			/// but do not specify this value if you are retrieving the localized display name of the folder because it might not resolve correctly.
			/// </summary>
			KF_FLAG_SIMPLE_IDLIST = 0x00000100,

			/// <summary>
			/// Gets the folder's default path independent of the current location of its parent. <see cref="KF_FLAG_DEFAULT_PATH"/> must also be set.
			/// </summary>
			KF_FLAG_NOT_PARENT_RELATIVE = 0x00000200,

			/// <summary>
			/// Gets the default path for a known folder. If this flag is not set, the function retrieves the current—and possibly redirected—path of the folder.
			/// The execution of this flag includes a verification of the folder's existence unless <see cref="KF_FLAG_DONT_VERIFY"/> is set.
			/// </summary>
			KF_FLAG_DEFAULT_PATH = 0x00000400,

			/// <summary>
			/// Initializes the folder using its Desktop.ini settings. If the folder cannot be initialized, the function returns a failure code and no path is returned.
			/// This flag should always be combined with <see cref="KF_FLAG_CREATE"/>.
			/// </summary>
			/// <remarks>If the folder is located on a network, the function might take a longer time to execute.</remarks>
			KF_FLAG_INIT = 0x00000800,

			/// <summary>
			/// Gets the true system path for the folder, free of any aliased placeholders such as %USERPROFILE%, returned by SHGetKnownFolderIDList and IKnownFolder::GetIDList.
			/// This flag has no effect on paths returned by <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/> and IKnownFolder::GetPath.
			/// By default, known folder retrieval functions and methods return the aliased path if an alias exists.
			/// </summary>
			KF_FLAG_NO_ALIAS = 0x00001000,

			/// <summary>
			/// Stores the full path in the registry without using environment strings. If this flag is not set, portions of the path may be represented by environment strings
			/// such as %USERPROFILE%. This flag can only be used with SHSetKnownFolderPath and IKnownFolder::SetPath.
			/// </summary>
			KF_FLAG_DONT_UNEXPAND = 0x00002000,

			/// <summary>
			/// Do not verify the folder's existence before attempting to retrieve the path or IDList. If this flag is not set,
			/// an attempt is made to verify that the folder is truly present at the path. If that verification fails due to the folder being absent or inaccessible,
			/// the function returns a failure code and no path is returned.
			/// </summary>
			/// <remarks>If the folder is located on a network, the function might take a longer time to execute. Setting this flag can reduce that lag time.</remarks>
			KF_FLAG_DONT_VERIFY = 0x00004000,

			/// <summary>
			/// Forces the creation of the specified folder if that folder does not already exist. The security provisions predefined for that folder are applied.
			/// If the folder does not exist and cannot be created, the function returns a failure code and no path is returned.
			/// </summary>
			/// <remarks>This value can be used only with the following functions and methods: <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/>, SHGetKnownFolderIDList, IKnownFolder::GetIDList, IKnownFolder::GetPath, IKnownFolder::GetShellItem</remarks>
			KF_FLAG_CREATE = 0x00008000,

			/// <summary>
			/// When running inside an app container, or when providing an app container token, this flag prevents redirection to app container folders.
			/// Instead, it retrieves the path that would be returned where it not running inside an app container.
			/// </summary>
			/// <remarks>Introduced in Windows 7</remarks>
			KF_FLAG_NO_APPCONTAINER_REDIRECTION = 0x00010000,

			/// <summary>
			/// Return only aliased PIDLs. Do not use the file system path.
			/// </summary>
			/// <remarks>Introduced in Windows 7</remarks>
			KF_FLAG_ALIAS_ONLY = 0x80000000

		}

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
			/// Administrative Tools
			/// </summary>
			/// <summary>
			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Administrative Tools
			/// </summary>
			CSIDL_COMMON_ADMINTOOLS = 0x002f,

			/// <summary>
			/// OEM Links
			///</summary>>
			/// <summary>
			/// Maps to %ALLUSERSPROFILE%\OEM Links
			/// </summary>
			CSIDL_COMMON_OEM_LINKS = 0x003a,

			/// <summary>
			/// Programs
			/// </summary>>
			/// <summary>
			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs
			/// </summary>
			CSIDL_COMMON_PROGRAMS = 0x0017,

			/// <summary>
			/// Start Menu
			/// </summary>
			/// <summary>
			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu
			/// </summary>
			CSIDL_COMMON_STARTMENU = 0x0016,

			/// <summary>
			/// Startup
			/// </summary>
			/// <summary>
			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp
			/// </summary>
			CSIDL_COMMON_STARTUP = 0x0018,

			/// <summary>
			/// Startup
			/// </summary>
			/// <summary>
			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp
			/// </summary>
			CSIDL_COMMON_ALTSTARTUP = 0x001e,

			/// <summary>
			/// Templates
			/// </summary>
			/// <summary>
			/// Maps to %ALLUSERSPROFILE%\Microsoft\Windows\Templates
			/// </summary>
			CSIDL_COMMON_TEMPLATES = 0x002d,

			/// <summary>
			/// Computer
			/// </summary>
			/// <summary>
			/// virtual folder
			/// </summary>
			CSIDL_DRIVES = 0x0011,

			/// <summary>
			/// Network Connections
			/// </summary>
			/// <summary>
			/// Maps to virtual folder
			/// </summary>
			CSIDL_CONNECTIONS = 0x0031,

			/// <summary>
			/// Account Pictures
			/// </summary>
			/// <summary>
			/// Maps to virtual folder
			/// </summary>
			CSIDL_CONTROLS = 0x0003,

			/// <summary>
			/// Cookies
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA%\Microsoft\Windows\Cookies
			/// </summary>
			CSIDL_COOKIES = 0x0021,

			/// <summary>
			/// Desktop
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Desktop
			/// </summary>
			CSIDL_DESKTOP = 0x0000,

			/// <summary>
			/// Desktop
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Desktop
			/// </summary>
			CSIDL_DESKTOPDIRECTORY = 0x0010,

			/// <summary>
			/// Documents
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Documents
			/// </summary>
			CSIDL_MYDOCUMENTS = CSIDL_PERSONAL,

			/// <summary>
			/// Documents
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Documents
			/// </summary>
			CSIDL_PERSONAL = 0x0005,

			/// <summary>
			/// Favorites
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Favorites
			/// </summary>
			CSIDL_FAVORITES = 0x0006,

			/// <summary>
			/// Favorites
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Favorites
			/// </summary>
			CSIDL_COMMON_FAVORITES = 0x001f,

			/// <summary>
			/// Fonts
			/// </summary>
			/// <summary>
			/// Maps to %windir%\Fonts
			/// </summary>
			CSIDL_FONTS = 0x0014,

			/// <summary>
			/// History
			/// </summary>
			/// <summary>
			/// Maps to %LOCALAPPDATA%\Microsoft\Windows\History
			/// </summary>
			CSIDL_HISTORY = 0x0022,

			/// <summary>
			/// Temporary Internet Files
			/// </summary>
			/// <summary>
			/// Maps to %LOCALAPPDATA%\Microsoft\Windows\Temporary Internet Files
			/// </summary>
			CSIDL_INTERNET_CACHE = 0x0020,

			/// <summary>
			/// The Internet
			/// </summary>
			/// <summary>
			/// virtual folder
			/// </summary>
			CSIDL_INTERNET = 0x0001,

			/// <summary>
			/// Local
			/// </summary>
			/// <summary>
			/// Maps to %LOCALAPPDATA% (%USERPROFILE%\AppData\Local)
			/// </summary>
			CSIDL_LOCAL_APPDATA = 0x001c,

			/// <summary>
			/// None
			/// </summary>
			/// <summary>
			/// Maps to %windir%\resources\0409 (code page)
			/// </summary>
			CSIDL_RESOURCES_LOCALIZED = 0x0039,

			/// <summary>
			/// Music
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Music
			/// </summary>
			CSIDL_MYMUSIC = 0x000d,

			/// <summary>
			/// Network Shortcuts
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA%\Microsoft\Windows\Network Shortcuts
			/// </summary>
			CSIDL_NETHOOD = 0x0013,

			/// <summary>
			/// Network
			/// </summary>
			/// <summary>
			/// virtual folder
			/// </summary>
			CSIDL_NETWORK = 0x0012,

			/// <summary>
			/// Network
			/// </summary>
			/// <summary>
			/// virtual folder
			/// </summary>
			CSIDL_COMPUTERSNEARME = 0x003d,

			/// <summary>
			/// Pictures
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Pictures
			/// </summary>
			CSIDL_MYPICTURES = 0x0027,

			/// <summary>
			/// Printers
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Music\Playlists
			/// </summary>
			CSIDL_PRINTERS = 0x0004,

			/// <summary>
			/// Printer Shortcuts
			/// </summary>
			/// <summary>
			/// virtual folder
			/// </summary>
			CSIDL_PRINTHOOD = 0x001b,

			/// <summary>
			/// The user's username (%USERNAME%)
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE% (%SystemDrive%\Users\%USERNAME%)
			/// </summary>
			CSIDL_PROFILE = 0x0028,

			/// <summary>
			/// ProgramData
			/// </summary>
			/// <summary>
			/// Maps to %ALLUSERSPROFILE% (%ProgramData%, %SystemDrive%\ProgramData)
			/// </summary>
			CSIDL_COMMON_APPDATA = 0x0023,

			/// <summary>
			/// Program Files
			/// </summary>
			/// <summary>
			/// Maps to %ProgramFiles% (%SystemDrive%\Program Files)
			/// </summary>
			CSIDL_PROGRAM_FILES = 0x0026,

			/// <summary>
			/// Program Files
			/// </summary>
			/// <summary>
			/// Maps to %ProgramFiles% (%SystemDrive%\Program Files)
			/// </summary>
			CSIDL_PROGRAM_FILESX86 = 0x002a,

			/// <summary>
			/// Common Files
			/// </summary>
			/// <summary>
			/// Maps to %ProgramFiles%\Common Files
			/// </summary>
			CSIDL_PROGRAM_FILES_COMMON = 0x002b,

			/// <summary>
			/// Common Files
			/// </summary>
			/// <summary>
			/// Maps to %ProgramFiles%\Common Files
			/// </summary>
			CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c,

			/// <summary>
			/// Programs
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs
			/// </summary>
			CSIDL_PROGRAMS = 0x0002,

			/// <summary>
			/// Public Desktop
			/// </summary>
			/// <summary>
			/// Maps to %PUBLIC%\Desktop
			/// </summary>
			CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,

			/// <summary>
			/// Public Documents
			/// </summary>
			/// <summary>
			/// Maps to %PUBLIC%\Documents
			/// </summary>
			CSIDL_COMMON_DOCUMENTS = 0x002e,

			/// <summary>
			/// Public Music
			/// </summary>
			/// <summary>
			/// Maps to %PUBLIC%\Music
			/// </summary>
			CSIDL_COMMON_MUSIC = 0x0035,

			/// <summary>
			/// Public Pictures
			/// </summary>
			/// <summary>
			/// Maps to %PUBLIC%\Pictures
			/// </summary>
			CSIDL_COMMON_PICTURES = 0x0036,

			/// <summary>
			/// Public Videos
			/// </summary>
			/// <summary>
			/// Maps to %%PUBLIC%\Videos
			/// </summary>
			CSIDL_COMMON_VIDEO = 0x0037,

			/// <summary>
			/// Recent Items
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA%\Microsoft\Windows\Recent
			/// </summary>
			CSIDL_RECENT = 0x0008,

			/// <summary>
			/// Recycle Bin
			/// </summary>
			/// <summary>
			/// virtual folder
			/// </summary>
			CSIDL_BITBUCKET = 0x000a,

			/// <summary>
			/// Resources
			/// </summary>
			/// <summary>
			/// Maps to %windir%\Resources
			/// </summary>
			CSIDL_RESOURCES = 0x0038,

			/// <summary>
			/// Roaming
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA% (%USERPROFILE%\AppData\Roaming)
			/// </summary>
			CSIDL_APPDATA = 0x001a,

			/// <summary>
			/// SendTo
			/// </summary>
			/// <summary>
			/// Maps to %%APPDATA%\Microsoft\Windows\SendTo
			/// </summary>
			CSIDL_SENDTO = 0x0009,

			/// <summary>
			/// Start Menu
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu
			/// </summary>
			CSIDL_STARTMENU = 0x000b,

			/// <summary>
			/// Startup
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp
			/// </summary>
			CSIDL_STARTUP = 0x0007,

			/// <summary>
			/// Startup
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp
			/// </summary>
			CSIDL_ALTSTARTUP = 0x001d,

			/// <summary>
			/// System32
			/// </summary>
			/// <summary>
			/// Maps to %windir%\system32
			/// </summary>
			CSIDL_SYSTEM = 0x0025,

			/// <summary>
			/// System32
			/// </summary>
			/// <summary>
			/// Maps to %windir%\system32
			/// </summary>
			CSIDL_SYSTEMX86 = 0x0029,

			/// <summary>
			/// Templates
			/// </summary>
			/// <summary>
			/// Maps to %APPDATA%\Microsoft\Windows\Templates
			/// </summary>
			CSIDL_TEMPLATES = 0x0015,

			/// <summary>
			/// Videos
			/// </summary>
			/// <summary>
			/// Maps to %USERPROFILE%\Videos
			/// </summary>
			CSIDL_MYVIDEO = 0x000e,

			/// <summary>
			/// Windows
			/// </summary>
			/// <summary>
			/// Maps to %windir%
			/// </summary>
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
