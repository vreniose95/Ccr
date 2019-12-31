using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Extensions;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Track
		: Tag, 
			ISupportsLabelAttribute, 
			ISupportsSrcAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Track()
			: base("track")
		{
		}


		public virtual void AddDefault()
		{
			AddAttribute("default", "default");
		}

		public virtual void AddKind(
			Kind kind,
			string srclang = null)
		{
			if (!string.IsNullOrEmpty(srclang))
				AddAttribute("srclang", srclang);
			
			else if (kind == Kind.Subtitles)
				throw new InvalidAttributeException("kind", this);
			
			AddAttribute("kind", kind.LiteralValue());
		}
	}
}