using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;
using Ccr.MaterialDesign.Static;

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
      //_initialSwatch.

      //_mixedSwatch = GlobalResources
      //  .MaterialDesignPalette
      //  .GetSwatch(
      //    mixedSwatchClassifier);

    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      throw new NotImplementedException();
    }
  }
}