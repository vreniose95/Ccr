using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class SizeAttributeExtensions
	{
		public static void AddSize(
			this ISupportsSizeAttribute tag, 
			int value)
		{
			if (value < 0)
				throw new ArgumentException();

			tag.AddAttribute("size", value.ToString());
		}
	}
}