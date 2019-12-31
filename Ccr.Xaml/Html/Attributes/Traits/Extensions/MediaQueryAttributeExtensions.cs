using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class MediaQueryAttributeExtensions
	{
		public static void AddMedia(
			this ISupportsMediaQueryAttribute tag, 
			string media)
		{
			if (string.IsNullOrWhiteSpace(media))
				throw new ArgumentException();

			tag.AddAttribute("media", media);
		}
	}
}