using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Encoders;
using Ccr.Html.Tags.Infrastructure;
using System.Collections.Generic;
using System.Text;
using Ccr.Html.Attributes.Extensions;

namespace Ccr.Html.Tags
{
	public class Iframe
		: Tag,
			ISupportsHeightAttribute,
			ISupportsWidthAttribute,
			ISupportsNameAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Iframe(string src)
			: base("iframe")
		{
			AddAttribute("src", src);
		}


		public void AddSrcdoc(
			string srcdoc)
		{
			AddAttribute("srcdoc", srcdoc, new PassThroughEncoder());
		}

		public void AddSandbox(
			params Sandbox[] sandbox)
		{
			var builder = new StringBuilder();

			foreach (var s in new HashSet<Sandbox>(sandbox))
			{
				builder.Append(s.LiteralValue());
				builder.Append(" ");
			}

			AddAttribute("sandbox", builder.ToString().Trim());
		}
	}
}