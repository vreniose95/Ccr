using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Dd 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Dd()
			: base("dd")
		{
		}
	}
}