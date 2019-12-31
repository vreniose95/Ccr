using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;
using System;
using Ccr.Html.Attributes.Extensions;

namespace Ccr.Html.Tags
{
	public class Textarea
			: Tag,
				ISupportsAutofocusAttribute,
				ISupportsDisabledAttribute,
				ISupportsFormAttribute,
				ISupportsMaxLengthAttribute,
				ISupportsNameAttribute,
				ISupportsPlaceholderAttribute,
				ISupportsReadonlyAttribute,
				ISupportsRequiredAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Textarea()
			: base("textarea")
		{
		}


		public void AddCols(int cols)
		{
			if (cols < 0)
				throw new ArgumentException();

			AddAttribute("cols", cols.ToString());
		}

		public void AddRows(int rows)
		{
			if (rows < 0)
				throw new ArgumentException();

			AddAttribute("rows", rows.ToString());
		}

		public void AddWrap(Wrap wrap)
		{
			AddAttribute("wrap", wrap.LiteralValue());
		}
	}
}