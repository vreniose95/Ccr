using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Tbody
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Tbody()
			: base("tbody")
		{
		}
	}
}