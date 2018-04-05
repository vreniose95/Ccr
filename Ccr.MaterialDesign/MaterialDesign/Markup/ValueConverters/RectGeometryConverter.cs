using System.Windows;
using System.Windows.Media;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
  public class RectGeometryConverter
    : XamlConverter<
      double,
      double, 
      double,
      ConverterParam<bool>, 
      RectangleGeometry>
  {
    public override RectangleGeometry Convert(
      double width,
      double height,
      double cornerRadius,
      ConverterParam<bool> shouldDisable)
    {
      var effectRadius = shouldDisable.Value
        ? 0
        : cornerRadius;

      return new RectangleGeometry(
        new Rect(
          0, 
          0, 
          width, 
          height))
      {
        RadiusX = effectRadius,
        RadiusY = effectRadius
      };
    }
  }
}
