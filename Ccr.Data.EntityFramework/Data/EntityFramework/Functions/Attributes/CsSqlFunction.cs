using System;

namespace Ccr.Data.EntityFramework.Functions.Attributes
{
  [AttributeUsage(AttributeTargets.Method)]
	public class CsSqlFunction
		 : Attribute
	{
		public CsSqlFunction()
		{
		}
	}
}
