using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Bdi
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Bdi()
			: base("bdi")
		{
		}
	}
}