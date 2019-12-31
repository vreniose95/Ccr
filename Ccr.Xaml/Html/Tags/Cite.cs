using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Cite
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Cite()
			: base("cite")
		{
		}
	}
}