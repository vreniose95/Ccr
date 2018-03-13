using System.ComponentModel;
using System.Windows;
using Ccr.MaterialDesign.Markup.TypeConverters;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign
{
	[TypeConverter(typeof(MaterialIdentityConverter))]
	public class MaterialIdentity
    : Freezable
	{
	  protected static readonly DependencyPropertyKey SwatchClassifierPropertyKey = DP.RegisterReadOnly(
	    new Meta<MaterialIdentity, SwatchClassifier>());
    public static readonly DependencyProperty SwatchClassifierProperty = SwatchClassifierPropertyKey.DependencyProperty;


	  protected static readonly DependencyPropertyKey IsAccentPropertyKey = DP.RegisterReadOnly(
	    new Meta<MaterialIdentity, bool>());
	  public static readonly DependencyProperty IsAccentProperty = IsAccentPropertyKey.DependencyProperty;


	  protected static readonly DependencyPropertyKey LuminosityPropertyKey = DP.RegisterReadOnly(
	    new Meta<MaterialIdentity, Luminosity>());
    public static readonly DependencyProperty LuminosityProperty = LuminosityPropertyKey.DependencyProperty;



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

    
    internal MaterialIdentity(
			SwatchClassifier swatchClassifier,
			bool isAccent,
			Luminosity luminosity)
		{
			SwatchClassifier = swatchClassifier;
			IsAccent = isAccent;
			Luminosity = luminosity;
		}

	  public override string ToString()
	  {
	    return (IsAccent ? "A" : "") 
        + Luminosity.LuminosityIndex;
	  }


	  protected override Freezable CreateInstanceCore()
		{
			return new MaterialIdentity(
				SwatchClassifier,
				IsAccent,
			  Luminosity);
		}
	}
}