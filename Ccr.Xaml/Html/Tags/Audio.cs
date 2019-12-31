using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Audio
		: Tag,
			ISupportsAutoplayAttribute, 
			ISupportsControlsAttribute,
			ISupportsLoopAttribute,
			ISupportsMutedAttribute, 
			ISupportsPreloadAttribute,
			ISupportsSrcAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Audio()
			: base("audio")
		{
		}
	}
}