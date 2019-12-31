using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Output 
		: Tag, 
			ISupportsForAttribute, 
			ISupportsFormAttribute,
			ISupportsNameAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Output()
			: base("output")
		{
		}
	}
}