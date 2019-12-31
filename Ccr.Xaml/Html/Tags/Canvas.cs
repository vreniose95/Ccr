using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Canvas 
		: Tag, 
			ISupportsHeightAttribute, 
			ISupportsWidthAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Canvas()
			: base("canvas")
		{
		}
	}
}