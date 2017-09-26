using Ccr.Core.Extensions;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class RippleDiameterConverter
		: XamlConverter<
			double, 
			double, 
			NullParam, 
			double>
	{
		public override double Convert(
			double containerHeight, 
			double containerWidth, 
			NullParam param)
		{
			return containerHeight.Smallest(containerWidth) / 2d;
		}
	}
}
