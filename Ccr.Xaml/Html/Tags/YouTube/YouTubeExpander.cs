using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags.YouTube
{
	public class YouTubeExpander
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public YouTubeExpander()
			: base(
				"ytd_expander")
		{
		}
	}
}