using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class SrcAttributeExtensions
	{
		public static void AddSrc(
			this ISupportsSrcAttribute tag, 
			string src)
		{
			if (string.IsNullOrWhiteSpace(src))
				throw new ArgumentException();

			tag.AddAttribute("src", src);
		}
	}
}