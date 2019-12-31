using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class HeightAttributeExtensions
	{
		public static void AddHeight(
			this ISupportsHeightAttribute tag,
			int height)
		{
			if (height < 0)
				throw new ArgumentException();

			tag.AddAttribute("height", height.ToString());
		}
	}
}