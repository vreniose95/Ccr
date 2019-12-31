using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class WidthAttributeExtensions
	{
		public static void AddWidth(
			this ISupportsWidthAttribute tag, 
			int width)
		{
			if (width < 0)
				throw new ArgumentException();

			tag.AddAttribute("width", width.ToString());
		}
	}
}