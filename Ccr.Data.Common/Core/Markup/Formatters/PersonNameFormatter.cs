using System;
using Ccr.Data.Common.Constructs;

namespace Ccr.Core.Markup.Formatters
{
	public class PersonNameFormatter
		: IFormatProvider,
			ICustomFormatter
	{
		public object GetFormat(Type formatType)
		{
			return formatType == typeof(ICustomFormatter)
				? this
				: null;
		}

		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			switch (arg)
			{
				case PersonName personName:
					return personName.ToString(
						format, 
						formatProvider);
				
				default:
					throw new ArgumentException();
			}
		}
	}
}