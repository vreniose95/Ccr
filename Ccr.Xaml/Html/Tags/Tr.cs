using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Tr 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Tr()
			: base("tr")
		{
		}
	}
}