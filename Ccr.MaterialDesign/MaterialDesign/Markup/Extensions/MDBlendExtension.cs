using System;
using System.Windows.Markup;

namespace Ccr.MaterialDesign.Markup.Extensions
{
	public class MDBlendExtension
    : MarkupExtension
  {
    [ConstructorArgument("initialSwatchClassifier")]
    public SwatchClassifier InitialSwatchClassifier { get; }

    [ConstructorArgument("initialLuminosity")]
    public int InitialLuminosity { get; }

    [ConstructorArgument("mixedSwatchClassifier")]
    public SwatchClassifier MixedSwatchClassifier { get; }

    [ConstructorArgument("mixedLuminosity")]
    public int MixedLuminosity { get; }


    public MDBlendExtension(
      SwatchClassifier initalSwatchClassifier,
      int initialLuminosity,
      SwatchClassifier mixedSwatchClassifier,
      int mixedLuminosity)
    {
      InitialSwatchClassifier = initalSwatchClassifier;
      InitialLuminosity = initialLuminosity;
      MixedSwatchClassifier = mixedSwatchClassifier;
      MixedLuminosity = mixedLuminosity;
    }


    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      throw new NotImplementedException();
    }
  }
}