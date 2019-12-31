using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Figcaption 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Figcaption()
			: base("figcaption")
		{
		}
	}
}