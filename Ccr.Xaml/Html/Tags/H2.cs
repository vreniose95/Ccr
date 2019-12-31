using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class H2
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public H2()
			: base("h2")
		{
		}
	}
}