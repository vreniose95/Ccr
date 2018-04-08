using System;
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
  public class CardRectConverter
    : XamlConverter<
      double,
      double,
      double,
      Thickness,
      ConverterParam<bool>,
      Rect>
  {
    public override Rect Convert(
      double width,
      double height,
      double cornerRadius,
      Thickness padding,
      ConverterParam<bool> shouldDisable)
    {
      var farPoint = new Point(
        Math.Max(0, width),
        Math.Max(0, height));

    farPoint.Offset(
      padding.Left + padding.Right,
      padding.Top + padding.Bottom);

      return new Rect(
        new Point(),
        new Point(farPoint.X, farPoint.Y));
    }
  }
}
