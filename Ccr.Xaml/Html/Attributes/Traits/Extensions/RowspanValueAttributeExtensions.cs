using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class RowspanValueAttributeExtensions
	{
		public static void AddRowspan(
			this ISupportsRowspanAttribute tag,
			int value)
		{
			if (value < 0)
				throw new ArgumentException();

			tag.AddAttribute("rowspan", value.ToString());
		}
	}
}