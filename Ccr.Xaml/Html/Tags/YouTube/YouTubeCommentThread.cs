using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags.YouTube
{
	public class YouTubeCommentThread
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public YouTubeCommentThread()
			: base(
				"ytd_comment_thread_renderer")
		{
		}
	}
}