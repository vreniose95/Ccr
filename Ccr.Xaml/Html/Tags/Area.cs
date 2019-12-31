using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Area
		: Tag,
			ISupportsAltAttribute, 
			ISupportsTargetAttribute,
			ISupportsDownloadAttribute, 
			ISupportsMediaQueryAttribute, 
			ISupportsRelAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Area()
			: base("area")
		{
		}


		public virtual void AddCoords(
			string coords)
		{
			AddAttribute("coords", coords);
		}

		public virtual void AddHref(
			string href)
		{
			AddAttribute("href", href);
		}

		public virtual void AddShape(
			Shape shape)
		{
			AddAttribute("shape", shape.LiteralValue());
		}
	}
}