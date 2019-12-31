using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Dt
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Dt()
			: base("dt")
		{
		}
	}
}