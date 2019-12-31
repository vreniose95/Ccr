using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class U
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public U()
			: base("u")
		{
		}
	}
}