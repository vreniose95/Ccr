using System;
using Ccr.MaterialDesign.Controls.Icons;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
  public class IconFlipToScaleTransform
    : XamlConverter<
      IconFlip, 
      ConverterParam<string>,
      double>
  {
    public override double Convert(
      IconFlip iconFlip, 
      ConverterParam<string> propertyParam)
    {
      var x = 0;
      var y = 0;

      switch (iconFlip)
      {
        case IconFlip.None:
        {
          x = 1;
          y = 1;
          break;
        }
        case IconFlip.Horizontal:
        {
          x = -1;
          y = 1;
           break;
        }
        case IconFlip.Vertial:
        {
          x = 1;
          y = -1;
          break;
        }
        case IconFlip.Both:
        {
          x = -1;
          y = -1;
          break;
        }
        default:
          throw new ArgumentOutOfRangeException();
      }
      switch (propertyParam.Value)
      {
        case "X":
          return x;

        case "Y":
          return y;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }

} 
