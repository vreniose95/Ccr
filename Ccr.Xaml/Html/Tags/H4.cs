using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class H4
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public H4()
			: base("h4")
		{
		}
	}
}