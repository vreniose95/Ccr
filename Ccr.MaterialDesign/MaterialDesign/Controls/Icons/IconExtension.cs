using System;
using System.Windows.Markup;

namespace Ccr.MaterialDesign.Controls.Icons
{
	[MarkupExtensionReturnType(typeof(Icon))]
	public class IconExtension
		: MarkupExtension
	{
		[ConstructorArgument("kind")]
		public IconKind Kind { get; set; }

		[ConstructorArgument("size")]
		public double? Size { get; set; }


		public IconExtension()
		{
		}

		public IconExtension(IconKind kind)
			: this()
		{
			Kind = kind;
		}

		public IconExtension(
			IconKind kind,
			double size)
				: this(
					kind)
		{
			Size = size;
		}


		public override object ProvideValue(
			IServiceProvider serviceProvider)
		{
			var result = new Icon
			{
				Kind = Kind
			};

			if (Size.HasValue)
			{
				result.Height = Size.Value;
				result.Width = Size.Value;
			}

			return result;
		}
	}
}