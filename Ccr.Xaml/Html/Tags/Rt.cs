using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Rt 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Rt()
			: base("rt")
		{
		}
	}
}