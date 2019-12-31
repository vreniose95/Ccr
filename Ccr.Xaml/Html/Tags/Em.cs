using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Em
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Em()
			: base("em")
		{
		}
	}
}