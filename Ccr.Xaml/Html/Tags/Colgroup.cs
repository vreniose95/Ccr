using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Colgroup 
		: Tag, 
			ISupportsSpanAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Colgroup()
			: base("colgroup")
		{
		}
	}
}