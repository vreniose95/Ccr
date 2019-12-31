using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Img 
		: Tag, 
			ISupportsHeightAttribute, 
			ISupportsSrcsetAttribute,
			ISupportsUsemapAttribute, 
			ISupportsWidthAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Img(
			string src,
			string alt)
				: base("img")
		{
			AddAttribute("src", src);
			AddAttribute("alt", alt);
		}
	}
}