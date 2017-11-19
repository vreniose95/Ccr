using System;
using System.Data.Entity.Infrastructure.Interception;

namespace Ccr.Data.EntityFramework.Infrastructure
{
	public class DatabaseFileLogger
		: DatabaseLogger
	{

		/// <summary>
		/// Creates a new logger that will send log output to the console.
		/// </summary>
		public DatabaseFileLogger()
		{
		}

		/// <summary>
		/// Creates a new logger that will send log output to a file. If the file already exists then
		/// it is overwritten.
		/// </summary>
		/// <param name="path">
		/// A path to the file to which log output will be written.
		/// </param>
		public DatabaseFileLogger(
			string path)
				: base(
						resolvePath(path))
		{
		}
    

		public DatabaseFileLogger(
			string path,
			string options)
				: this(path)
		{
		}

		private static string resolvePath(
			string templatedPath)
		{
			throw new Exception();
			//var _parser = new DatabaseFileTemplateParser(
			//	templatedPath);

			//var _resolved = _parser.Parse();

			//return _resolved;
		}

	}


}
