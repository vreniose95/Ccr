using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class NameAttributeExtensions
	{
		public static void AddName(
			this ISupportsNameAttribute tag, 
			string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException();

			tag.AddAttribute("name", name);
		}
	}
}