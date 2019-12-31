using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class MaxLengthAttributeExtensions
	{
		public static void AddMaxLength(
			this ISupportsMaxLengthAttribute tag,
			int maxlength)
		{
			if (maxlength < 0)
				throw new ArgumentException();

			tag.AddAttribute("maxlength", maxlength.ToString());
		}
	}
}