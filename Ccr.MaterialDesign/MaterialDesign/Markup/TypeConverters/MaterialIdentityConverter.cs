using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Ccr.MaterialDesign.Markup.TypeConverters
{
	public class MaterialIdentityConverter
		: TypeConverter
	{
		private static readonly Regex _parserRegex = new Regex(
			@"\A[\s]*(?<swatchName>[A-z]*)(?<luminosity>[0-9]{3})");

		public Type TargetType => typeof(MaterialIdentity);

		public override bool CanConvertFrom(
			ITypeDescriptorContext context,
			Type sourceType)
		{
			if (sourceType == typeof(string) || TargetType.IsAssignableFrom(sourceType))
				return true;
			return false;
		}

		public override bool CanConvertTo(
			ITypeDescriptorContext context,
			Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor) || destinationType == TargetType)
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

			var match = _parserRegex.Match(value.ToString());

			var swatchName = match.Groups["swatchName"].Value;
			
			var luminosityStr = match.Groups["luminosity"].Value;
			var luminosity = int.Parse(luminosityStr);

			var isAccent = swatchName.EndsWith("A");
				//match.Groups["accentOptional"].Success;
			
			if(isAccent)
				swatchName = swatchName.Substring(0, swatchName.Length - 1);

			SwatchClassifier swatchClassifier;
			if(!Enum.TryParse(swatchName, out swatchClassifier))
				throw new FormatException(
					$"\"{swatchName}\" cannot be parsed into a \"SwatchClassifier\" enum object.");

			return new MaterialIdentity(
				swatchClassifier,
				isAccent,
				luminosity);
		}
	}
}