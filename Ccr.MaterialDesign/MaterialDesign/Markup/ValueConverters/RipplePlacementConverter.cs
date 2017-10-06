using System.Windows;
using Ccr.Core.Extensions;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class RipplePlacementConverter
		: XamlConverter<
			double, 
			double, 
			double, 
			Point,
			NullParam, 
			Point>
	{
		public override Point Convert(
			double width, 
			double height, 
			double rippleHeight, 
			Point mousePosition,
			NullParam param)
		{
			var upperRightOriginOffset = new Point(
					rippleHeight / 2,
					rippleHeight / 2)
				.Invert();

			var rippleOffset = upperRightOriginOffset
				.Push(mousePosition.X, mousePosition.Y);

			return rippleOffset;
		}
	}
}
