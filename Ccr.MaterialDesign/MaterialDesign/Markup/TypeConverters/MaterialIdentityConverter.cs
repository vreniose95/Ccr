using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Text.RegularExpressions;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.Markup.TypeConverters
{
	public class MaterialIdentityConverter
		: TypeConverter
	{
		private static readonly Regex _parserRegex = new Regex(
			@"\A[\s]*(?<swatchName>[A-z]*).(?<isAccent>[A])?(?<luminosity>[0-9]{3})");

		public Type TargetType
		{
			get => typeof(MaterialIdentity);
		}


		public override bool CanConvertFrom(
			ITypeDescriptorContext context,
			Type sourceType)
		{
			return sourceType == typeof(string) 
				|| TargetType.IsAssignableFrom(sourceType);
		}

		public override bool CanConvertTo(
		  ITypeDescriptorContext context,
		  Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor)
				|| destinationType == typeof(string)
				|| destinationType == TargetType;
		}

		public override object ConvertFrom(
		  ITypeDescriptorContext context,
		  CultureInfo culture,
		  object value)
		{
			if (value == null)
				return null;

			var match = _parserRegex.Match(value.ToString());

			var swatchName = match.Groups["swatchName"].Value;
			var luminosityStr = match.Groups["luminosity"].Value;
			var isAccent = match.Groups["isAccent"].Value.IsNotNullOrEmpty();

			var luminosityVal = int.Parse(luminosityStr);

			var luminosity = new Luminosity(luminosityVal, isAccent);

			if (!Enum.TryParse(swatchName, out SwatchClassifier swatchClassifier))
				swatchClassifier = SwatchClassifier.Blue;

			return new MaterialIdentity(
				swatchClassifier,
				luminosity);
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

				return identity.SwatchClassifier.ToString() + (identity.IsAccent ? "A" : "" + identity.Luminosity.LuminosityIndex);
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}