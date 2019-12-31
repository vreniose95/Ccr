using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Fieldset 
		: Tag, 
			ISupportsDisabledAttribute, 
			ISupportsFormAttribute,
			ISupportsNameAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Fieldset()
			: base("fieldset")
		{
		}
	}
}