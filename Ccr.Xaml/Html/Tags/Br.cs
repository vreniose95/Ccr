using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Br
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Br()
			: base("br")
		{
		}
	}
}