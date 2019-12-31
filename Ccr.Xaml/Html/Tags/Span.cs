using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Span 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Span()
			: base("span")
		{
		}
	}
}