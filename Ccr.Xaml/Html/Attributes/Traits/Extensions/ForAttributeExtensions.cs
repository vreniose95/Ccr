using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class ForAttributeExtensions
	{
		public static void AddFor(
			this ISupportsForAttribute tag,
			string id)
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentException(); 

			tag.AddAttribute("for", id);
		}
	}
}