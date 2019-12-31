using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags.YouTube
{
	public class YouTubeImageShadow
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public YouTubeImageShadow()
			: base(
				"yt_image_shadow")
		{
		}
	}
}