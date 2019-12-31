using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Code
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Code()
			: base("code")
		{
		}
	}
}