using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Video 
		: Tag, 
			ISupportsAutoplayAttribute, 
			ISupportsControlsAttribute,
			ISupportsHeightAttribute,
			ISupportsLoopAttribute,
			ISupportsMutedAttribute,
			ISupportsPreloadAttribute,
			ISupportsSrcAttribute, 
			ISupportsWidthAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Video()
			: base("video")
		{
		}


		public virtual void AddPoster(string url)
		{
			AddAttribute("poster", url);
		}
	}
}