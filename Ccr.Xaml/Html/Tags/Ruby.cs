using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Ruby 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Ruby()
			: base("ruby")
		{
		}
	}
}