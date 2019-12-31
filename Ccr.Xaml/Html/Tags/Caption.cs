using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Caption
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Caption()
			: base("caption")
		{
		}
	}
}