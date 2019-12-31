using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Ccr.MaterialDesign.Markup.TypeConverters
{
  public class LuminosityConverter
    : TypeConverter
  {
    public Type TargetType => typeof(Luminosity);


    public override bool CanConvertFrom(
      ITypeDescriptorContext context,
      Type sourceType)
    {
      if (sourceType == typeof(string)
        || TargetType.IsAssignableFrom(sourceType))
        return true;
      return false;
    }

    public override bool CanConvertTo(
      ITypeDescriptorContext context,
      Type destinationType)
    {
      if (destinationType == typeof(InstanceDescriptor)
        || destinationType == typeof(string)
        || destinationType == TargetType)
        return true;
      return false;
    }

    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      if (value == null)
        return null;

      var propertyType = context?.PropertyDescriptor?.PropertyType;
      if (propertyType == null)
        throw new NotSupportedException();

      switch (value)
      {
        case string @string:
        {
          if (propertyType == typeof(InstanceDescriptor))
          {
            return Luminosity.Parse(@string);
          }
          else if (propertyType == typeof(Luminosity))
          {
            return Luminosity.Parse(@string);
          }
          else if (propertyType == typeof(string))
          {
            return @string;
          }

          throw new NotSupportedException();
        }
        case Luminosity luminosity:
        {
          if (propertyType == typeof(InstanceDescriptor))
          {
            return luminosity;
          }
          else if (propertyType == typeof(Luminosity))
          {
            return luminosity;
          }
          else if (propertyType == typeof(string))
          {
            return luminosity.ToString();
          }

          throw new NotSupportedException();
        }
        default:
        {
          throw new NotSupportedException();
        }
      }
    }

    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      switch (value)
      {
        case string @string:
        {
          if (destinationType == typeof(InstanceDescriptor))
          {
            return Luminosity.Parse(@string);
          }
          else if (destinationType == typeof(Luminosity))
          {
            return Luminosity.Parse(@string);
          }
          else if (destinationType == typeof(string))
          {
            return @string;
          }

          throw new NotSupportedException();
        }
        case Luminosity luminosity:
        {
          if (destinationType == typeof(InstanceDescriptor))
          {
            return luminosity;
          }
          else if (destinationType == typeof(Luminosity))
          {
            return luminosity;
          }
          else if (destinationType == typeof(string))
          {
            return luminosity.ToString();
          }

          throw new NotSupportedException();
        }
        default:
        {
          throw new NotSupportedException();
        }
      }
    }
  }
}