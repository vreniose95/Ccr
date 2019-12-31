using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class NumberValueAttributeExtensions
	{
		public static void AddValue(
			this ISupportsNumberValueAttribute tag, 
			int value)
		{
			if (value < 0)
				throw new ArgumentException();

			tag.AddAttribute("value", value.ToString());
		}
	}
}