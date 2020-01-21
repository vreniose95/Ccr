using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public class GradientMaterialStop 
		: DependencyObject
	{
		public static readonly DependencyProperty SwatchProperty = DP.Register(
			new Meta<GradientMaterialStop, Swatch>());

		public static readonly DependencyProperty OffsetProperty = DP.Register(
			new Meta<GradientMaterialStop, double>(1));


		public GradientMaterialStop()
		{
		}
		
		public GradientMaterialStop(
			Swatch swatch)
		{
			Swatch = swatch;
		}

		public GradientMaterialStop(
			Swatch swatch, 
			double offset)
				: this(swatch)
		{
			Offset = offset;
		}


		public Swatch Swatch
		{
			get => (Swatch)GetValue(SwatchProperty);
			set => SetValue(SwatchProperty, value);
		}

		public double Offset
		{
			get => (double)GetValue(OffsetProperty);
			set => SetValue(OffsetProperty, value);
		}
	}
}
