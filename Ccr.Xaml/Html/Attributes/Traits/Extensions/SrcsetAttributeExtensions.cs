using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class SrcsetAttributeExtensions
	{
		public static void AddSrcset(
			this ISupportsSrcsetAttribute tag, 
			string srcset)
		{
			if (string.IsNullOrWhiteSpace(srcset))
				throw new ArgumentException();

			tag.AddAttribute("srcset", srcset);
		}
	}
}