using System.IO;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using Microsoft.WindowsAPICodePack.Shell;

namespace Ccr.PresentationCore.Media.Metadata
{
	public abstract class ShellRefObject
	{
		private FileInfo _fileInfo;
		private ShellObject _shellObject;

		[NotNull]
		public FileInfo FileInfo
		{
			[NotNull] get => _fileInfo;
			[NotNull]
			private set
			{
				value.IsNotNull(nameof(value));

				if (!value.Exists)
					throw new FileNotFoundException(
						$"Cannot find the file {value.FullName.Quote()}.");

				_fileInfo = value;

				ShellObject = ShellObject.FromParsingName(_fileInfo.FullName);
			}
		}

		[NotNull]
		public ShellObject ShellObject
		{
			[NotNull] get => _shellObject;
			[NotNull]
			private set
			{
				value.IsNotNull(nameof(value));

				_shellObject = value;
			}
		}


		protected ShellRefObject(
			[NotNull] FileInfo fileInfo)
		{
			FileInfo = fileInfo;
		}
	}
}
