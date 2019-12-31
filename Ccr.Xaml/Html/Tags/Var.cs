using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Var
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Var()
			: base("var")
		{
		}
	}
}