using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Html
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Html()
			: base("html")
		{
		}
	}
}