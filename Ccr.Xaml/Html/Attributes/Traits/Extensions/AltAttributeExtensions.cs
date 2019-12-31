using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class AltAttributeExtensions
	{
		public static void AddAlt(
			this ISupportsAltAttribute tag,
			string alt)
		{
			if (string.IsNullOrWhiteSpace(alt))
				throw new ArgumentException();
			
			tag.AddAttribute("alt", alt);
		}
	}
}