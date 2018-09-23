using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Media;
using System.Xaml;
using Ccr.Core.Extensions;

namespace Ccr.MaterialDesign.Markup.TypeConverters
{
  //[TypeConverter(typeof(MaterialBrush))]
  public class MaterialBrushConverter
    : TypeConverter
  {
    public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
    {
      return base.CreateInstance(context, propertyValues);
    }

    public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
    {
      return base.GetCreateInstanceSupported(context);
    }

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
      return base.GetProperties(context, value, attributes);
    }

    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
      return base.GetStandardValues(context);
    }

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
      return base.CanConvertTo(
        context,
        destinationType);
    }

    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      var destinationTypeProvider =
        context.GetService(
            typeof(IDestinationTypeProvider))
               .As<IDestinationTypeProvider>();

      if (destinationTypeProvider == null)
        throw new NullReferenceException(
          $"The destination type provider is null " +
          $"and not available in this context.");

      var destinationType = destinationTypeProvider
        .GetDestinationType();

      if (destinationType == typeof(string))
      {
        switch (value)
        {
          case string @string:
            return @string;

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
      if (destinationType == typeof(SolidColorBrush))
      {
        switch (value)
        {
          case string @string:
            throw new NotImplementedException();

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
      if (destinationType == typeof(Brush))
      {
        switch (value)
        {
          case string @string:
            throw new NotImplementedException();

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
      if (destinationType == typeof(MaterialBrush))
      {
        switch (value)
        {
          case string @string:
            {
              throw new NotImplementedException();
              //  return GlobalResources.MaterialDesignPalette.Swatches[]i
            }

          case SolidColorBrush solidColorBrush:
            throw new NotImplementedException();

          case Brush brush:
            throw new NotImplementedException();

          case MaterialBrush materialBrush:
            return materialBrush;

          default:
            throw new InvalidEnumArgumentException();
        }
      }
      return base.ConvertFrom(context, culture, value);
    }

    private MaterialBrush _performConvert(
      SolidColorBrush solidColorBrush)
    {
      throw new Exception();
    }


    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      if (destinationType == typeof(string))
      {

      }
      if (destinationType == typeof(SolidColorBrush))
      {
        switch (value)
        {
          case string @string:
            throw new NotImplementedException();

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
      if (destinationType == typeof(Brush))
      {
        switch (value)
        {
          case string @string:
            throw new NotImplementedException();

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
      if (destinationType == typeof(MaterialBrush))
      {
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }

    public override bool IsValid(ITypeDescriptorContext context, object value)
    {
      return base.IsValid(context, value);
    }
  }
}