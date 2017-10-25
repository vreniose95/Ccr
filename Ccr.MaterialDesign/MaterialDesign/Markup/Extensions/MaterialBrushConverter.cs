using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Media;
using System.Xaml;

namespace Ccr.MaterialDesign.Markup.Extensions
{
  [TypeConverter(typeof(MaterialBrush))]
  public class MaterialBrushConverter
    : TypeConverter
  {
    public override bool CanConvertFrom(
      ITypeDescriptorContext context,
      Type sourceType)
    {
      if (sourceType == typeof(string)
        || sourceType == typeof(Brush)
        || sourceType == typeof(SolidColorBrush)
        || sourceType == typeof(MaterialBrush))
      {
        return true;
      }
      return base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(
      ITypeDescriptorContext context,
      Type destinationType)
    {
      if (destinationType == typeof(string)
          || destinationType == typeof(Brush)
          || destinationType == typeof(SolidColorBrush)
          || destinationType == typeof(MaterialBrush))
      {
        return true;
      }
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      var destinationTypeProvider =
        context.GetService(
          typeof(IDestinationTypeProvider))
          as IDestinationTypeProvider;

      if (destinationTypeProvider == null)
        throw new NullReferenceException(
          $"The destination type provider is null.");

      var destinationType = destinationTypeProvider
        .GetDestinationType();

      if (destinationType == typeof(string))
      {

      }
      else if (destinationType == typeof(SolidColorBrush))
      {
        switch (value)
        {
          case string @string:
            throw new Exception();

          case SolidColorBrush solidColorBrush:
            return solidColorBrush;

          case Brush brush:
            return (SolidColorBrush)brush;

          case MaterialBrush materialBrush:
            return materialBrush.Brush;

          default:
            throw new InvalidEnumArgumentException();
        }
      }
      else if (destinationType == typeof(Brush))
      {
        switch (value)
        {
          case string @string:
            throw new Exception();

          case SolidColorBrush solidColorBrush:
            return solidColorBrush;

          case Brush brush:
            return brush;

          case MaterialBrush materialBrush:
            return materialBrush.Brush;

          default:
            throw new InvalidEnumArgumentException();
        }
      }
      else if (destinationType == typeof(MaterialBrush))
      {
        switch (value)
        {
          case string @string:
            throw new Exception();

          case SolidColorBrush solidColorBrush:
            return solidColorBrush;

          case Brush brush:
            return brush;

          case MaterialBrush materialBrush:
            return materialBrush.Brush;

          default:
            throw new InvalidEnumArgumentException();
        }
      }
      return base.ConvertFrom(context, culture, value);
    }
  }
}
