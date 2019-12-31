using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class H6 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public H6()
			: base("h6")
		{
		}
	}
}