using System.Windows;
using System.Windows.Media;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
  public class RectGeometryConverter
    : XamlConverter<
      double,
      double, 
      ConverterParam<double>, 
      RectangleGeometry>
  {
    public override RectangleGeometry Convert(
      double width,
      double height,
      ConverterParam<double> corner)
    {
      return new RectangleGeometry(
        new Rect(
          0, 
          0, 
          width, 
          height))
      {
        RadiusX = corner.Value,
        RadiusY = corner.Value
      };
    }
  }
}
