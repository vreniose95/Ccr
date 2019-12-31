using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Noscript
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Noscript()
			: base("noscript")
		{
		}
	}
}