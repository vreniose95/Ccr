using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Text.RegularExpressions;
using Ccr.Core.Extensions;

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
      if (destinationType == typeof(string))
      {
        var identity = value.As<MaterialIdentity>();
        return identity.ToString();

        return (identity.IsAccent ? "A" : "") + identity.Luminosity.LuminosityIndex;
      }

      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}