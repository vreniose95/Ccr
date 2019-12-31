using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Footer
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Footer()
			: base("footer")
		{
		}
	}
}