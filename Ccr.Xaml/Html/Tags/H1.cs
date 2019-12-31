using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class H1
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public H1()
			: base("h1")
		{
		}
	}
}