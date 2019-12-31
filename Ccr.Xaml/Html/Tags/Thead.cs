using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Thead 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}

		public Thead()
			: base("thead")
		{
		}
	}
}