using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Abbr
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Abbr()
			: base("abbr")
		{
		}
	}
}