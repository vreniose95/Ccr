using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class ColspanValueAttributeExtensions
	{
		public static void AddColspan(
			this ISupportsColspanAttribute tag,
			int value)
		{
			if (value < 0)
				throw new ArgumentException();

			tag.AddAttribute("colspan", value.ToString());
		}
	}
}