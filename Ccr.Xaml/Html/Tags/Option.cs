using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Option 
		: Tag, 
			ISupportsDisabledAttribute, 
			ISupportsLabelAttribute,
			ISupportsStringValueAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Option()
			: base("option")
		{
		}


		public virtual void AddSelected()
		{
			AddAttribute("selected", "selected");
		}
	}
}