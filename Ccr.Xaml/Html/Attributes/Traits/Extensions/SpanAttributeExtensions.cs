using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class SpanAttributeExtensions
	{
		public static void AddSpan(
			this ISupportsSpanAttribute tag,
			int span)
		{
			if (span < 0)
				throw new ArgumentException();

			tag.AddAttribute("span", span.ToString());
		}
	}
}