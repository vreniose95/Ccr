using System.ComponentModel;
using System.Windows;
using Ccr.MaterialDesign.Markup.TypeConverters;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.MaterialDesign
{
	[TypeConverter(typeof(MaterialIdentityConverter))]
  public class MaterialIdentity
      : Freezable
  {
    private static readonly DependencyPropertyKey SwatchClassifierPropertyKey = DP.RegisterReadOnly(
      new Meta<MaterialIdentity, SwatchClassifier>());
    public static readonly DependencyProperty SwatchClassifierProperty = SwatchClassifierPropertyKey.DependencyProperty;


    private static readonly DependencyPropertyKey IsAccentPropertyKey = DP.RegisterReadOnly(
      new Meta<MaterialIdentity, bool>());
    public static readonly DependencyProperty IsAccentProperty = IsAccentPropertyKey.DependencyProperty;


    private static readonly DependencyPropertyKey LuminosityPropertyKey = DP.RegisterReadOnly(
      new Meta<MaterialIdentity, Luminosity>());
    public static readonly DependencyProperty LuminosityProperty = LuminosityPropertyKey.DependencyProperty;


    private static readonly DependencyPropertyKey OpacityPropertyKey = DP.RegisterReadOnly(
      new Meta<MaterialIdentity, double>(1d), opacityPropertyValidator);
    public static readonly DependencyProperty OpacityProperty = OpacityPropertyKey.DependencyProperty;



    public SwatchClassifier SwatchClassifier
    {
      get => (SwatchClassifier)GetValue(SwatchClassifierProperty);
      protected set => SetValue(SwatchClassifierPropertyKey, value);
    }

    public bool IsAccent
    {
      get => (bool)GetValue(IsAccentProperty);
      protected set => SetValue(IsAccentPropertyKey, value);
    }

    public Luminosity Luminosity
    {
      get => (Luminosity)GetValue(LuminosityProperty);
      protected set => SetValue(LuminosityPropertyKey, value);
    }

    public double Opacity
    {
      get => (double)GetValue(OpacityProperty);
      protected set => SetValue(OpacityPropertyKey, value);
    }


    internal MaterialIdentity(
      SwatchClassifier swatchClassifier,
      Luminosity luminosity,
      double opacity = 1.0)
    {
      SwatchClassifier = swatchClassifier;
      IsAccent = luminosity.IsAccent;
      Luminosity = luminosity;
      Opacity = opacity;
    }


    private static bool opacityPropertyValidator(
      double value)
    {
      return value.IsWithin((0d, 1d));
    }


    public override string ToString()
    {
      return SwatchClassifier + "." + (IsAccent ? "A" : "P")
        + Luminosity.LuminosityIndex.ToString("000");
    }


    protected override Freezable CreateInstanceCore()
    {
      return new MaterialIdentity(
        SwatchClassifier,
        Luminosity,
        Opacity);
    }
  }
}
