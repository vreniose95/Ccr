using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class CiteAttributeExtensions
	{
		public static void AddCite(
			this ISupportsCiteAttribute tag,
			string cite)
		{
			if (string.IsNullOrWhiteSpace(cite))
				throw new ArgumentException();

			tag.AddAttribute("cite", cite);
		}
	}
}