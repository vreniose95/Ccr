using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Section
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Section()
			: base("section")
		{
		}
	}
}