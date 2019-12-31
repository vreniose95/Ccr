using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Header
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Header()
			: base("header")
		{
		}
	}
}