using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class CharsetAttributeExtensions
	{
		public static void AddCharset(
			this ISupportsCharsetAttribute tag, 
			Charset charset)
		{
			tag.AddAttribute("charset", charset.LiteralValue());
		}
	}
}