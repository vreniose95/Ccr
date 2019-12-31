using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Label 
		: Tag,
			ISupportsForAttribute, 
			ISupportsFormAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Label()
			: base("label")
		{
		}
	}
}