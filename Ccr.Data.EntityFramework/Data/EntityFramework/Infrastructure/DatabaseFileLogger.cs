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


		private static string resolvePath(
			string templatedPath)
		{
      throw new NotImplementedException();
			//var _resolved = DatabaseFileTemplateParser.Parse(
			//	templatedPath);

			//return _resolved;
		}

	  //private static class DatabaseFileTemplateParser
	  //{
	  //  public static string Parse(
	  //    string templatedPath)
	  //  {

	      
	  //  }

   // }

  }


}
