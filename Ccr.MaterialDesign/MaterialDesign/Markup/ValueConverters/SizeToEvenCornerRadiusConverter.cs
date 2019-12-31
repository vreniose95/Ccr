using System.Windows;
using Ccr.Std.Core.Extensions.NumericExtensions;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class SizeToEvenCornerRadiusConverter
		: XamlConverter<
			double, 
			double, 
			NullParam, 
			CornerRadius>
	{
		public override CornerRadius Convert(
			double height, 
			double width, 
			NullParam param)
		{
			if (height <= 0 && width <= 0)
				return new CornerRadius(0);

			var radius = height.Smallest(width) / 2d;
			return new CornerRadius(radius);
		}
	}
}
