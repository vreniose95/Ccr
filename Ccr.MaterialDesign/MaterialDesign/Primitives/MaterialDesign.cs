using System;
using System.Windows;
using Ccr.MaterialDesign.Static;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using static System.Windows.FrameworkPropertyMetadataOptions;

namespace Ccr.MaterialDesign.Primitives
{
	public class MaterialDesign
	{
		private static readonly Type _type = typeof(MaterialDesign);


		public static readonly DependencyProperty SwatchProperty = DP.Attach(_type,
			new MetaBase<SwatchClassifier>(SwatchClassifier.Blue, onSwatchChanged));

		public static SwatchClassifier GetSwatch(DependencyObject i) => i.Get<SwatchClassifier>(SwatchProperty);
		public static void SetSwatch(DependencyObject i, SwatchClassifier v) => i.Set(SwatchProperty, v);



		public static readonly DependencyProperty ThemeProperty = DP.Attach(_type,
			new MetaBase<Swatch>(onThemeChanged, Inherits));

		public static Swatch GetTheme(DependencyObject i) => i.Get<Swatch>(ThemeProperty);
		public static void SetTheme(DependencyObject i, Swatch v) => i.Set(ThemeProperty, v);



		private static void onThemeChanged(
      DependencyObject @this, 
			DPChangedEventArgs<Swatch> args)
		{
		}

		private static void onSwatchChanged(
			DependencyObject @this,
			DPChangedEventArgs<SwatchClassifier> args)
		{
      var swatch = GlobalResources
		    .MaterialDesignPalette
		    .GetSwatch(
		      args.NewValue);

      SetTheme(@this, swatch);
		}

	}
}
