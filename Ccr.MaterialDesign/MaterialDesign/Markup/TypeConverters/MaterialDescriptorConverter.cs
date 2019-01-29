using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Text.RegularExpressions;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Infrastructure.Descriptors;
using Ccr.MaterialDesign.Static;

namespace Ccr.MaterialDesign.Markup.TypeConverters
{
  public class MaterialDescriptorConverter
    : TypeConverter
  {
	  public Type TargetType
	  {
			get => typeof(AbstractMaterialDescriptor);
		}


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
          || destinationType == TargetType)
        return true;
      return false;
    }


    private static readonly Regex _literalDescriptorRegex
      = new Regex(
        @"->(?<swatchName>[A-z]*)(?<luminosity>[A|P]{1}[0-9]{1,3})(?:,(?<opacity>[0-9.]*))?");

    private static readonly Regex _luminosityDescriptorRegex
      = new Regex(
        @"(?<luminosity>[A|P]{1}[0-9]{1,3})(?:,(?<opacity>[0-9.]*))?");


    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      if (value == null)
        throw new InvalidOperationException(
          $"Cannot convert from a null value to a MaterialDescriptor.");

      var strVal = value.ToString().Trim();

      if (_literalDescriptorRegex.IsMatch(strVal))
      {
        var match = _literalDescriptorRegex.Match(strVal);

        var swatchName = match.Groups["swatchName"].Value;
        if (!Enum.TryParse<SwatchClassifier>(swatchName, out var classifier))
          throw new FormatException(
            $"The swatch name {swatchName.Quote()} is not a valid defined member of the enum " +
            $"{typeof(SwatchClassifier).Name.SQuote()}.");

        var swatch = GlobalResources.Palette.GetSwatch(classifier);

        var luminosityStr = match.Groups["luminosity"].Value;
        var luminosity = Luminosity.Parse(luminosityStr);

        var material = swatch.GetMaterial(luminosity);

        var opacityStr = match.Groups["opacity"]?.Value ?? "1";
        var opacity = double.Parse(opacityStr);

        return new LiteralMaterialDescriptor(
            material,
            opacity);
      }
      if (_luminosityDescriptorRegex.IsMatch(strVal))
      {
        var match = _luminosityDescriptorRegex.Match(strVal);

        var luminosityStr = match.Groups["luminosity"].Value;
        var luminosity = Luminosity.Parse(luminosityStr);

        var opacityStr = match.Groups["opacity"]?.Value ?? "1";
        var opacity = double.Parse(opacityStr);

        return new LuminosityMaterialDescriptor(
          luminosity,
          opacity);
      }
      else
      {
        throw new FormatException(
          $"The value {strVal.Quote()} cannot be converted to a MaterialDescriptor.");
      }
    }


    public override object ConvertTo(
      ITypeDescriptorContext context, 
      CultureInfo culture, 
      object value, 
      Type destinationType)
    {
      throw new NotImplementedException();
    }

    //public override bool IsValid(ITypeDescriptorContext context, object value)
    //{
    //	try
    //	{
    //		return FlexEnum.IsDefined(TargetType, value);
    //	}
    //	catch
    //	{
    //		throw new Exception("isvalid failed");
    //	}

    //}
  }
}
