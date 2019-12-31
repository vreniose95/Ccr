using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class HeadersAttributeExtensions
	{
		public static void AddHeaders(
			this ISupportsHeadersAttribute tag, 
			string headers)
		{
			if (string.IsNullOrWhiteSpace(headers))
				throw new ArgumentException();

			tag.AddAttribute("headers", headers);
		}
	}
}