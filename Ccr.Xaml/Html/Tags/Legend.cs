using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Legend 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Legend()
			: base("legend")
		{

		}
	}
}