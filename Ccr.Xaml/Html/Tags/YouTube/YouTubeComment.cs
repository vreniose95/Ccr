using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags.YouTube
{
	public class YouTubeComment
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public YouTubeComment()
			: base(
				"ytd_comment_renderer")
		{
		}
	}
}
