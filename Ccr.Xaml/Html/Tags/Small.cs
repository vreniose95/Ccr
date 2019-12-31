using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Small 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Small()
			: base("small")
		{
		}
	}
}