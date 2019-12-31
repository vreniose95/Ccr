using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Nav 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Nav()
			: base("nav")
		{
		}
	}
}