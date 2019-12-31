using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class UsemapAttributeExtensions
	{
		public static void AddUsemap(
			this ISupportsUsemapAttribute tag,
			string id)
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentException();

			tag.AddAttribute("usemap", id);
		}
	}
}