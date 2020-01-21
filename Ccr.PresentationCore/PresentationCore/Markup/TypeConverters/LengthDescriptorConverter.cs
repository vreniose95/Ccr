using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using Ccr.PresentationCore.Layout;

namespace Ccr.PresentationCore.Markup.TypeConverters
{
	public class LengthDescriptorConverter : TypeConverter
	{
		public Type TargetType => typeof(LengthDescriptor);

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string) || TargetType.IsAssignableFrom(sourceType))
				return true;
			return false;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor) || destinationType == TargetType)
				return true;
			return false;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			try
			{
				if (value == null)
					return null;

				var stringValue = value.ToString().Trim().ToLower();

				LengthMode? lengthMode = null;

				string numericValue = null;
				if (stringValue.EndsWith("%"))
				{
					lengthMode = LengthMode.Percent;
					numericValue = stringValue.Replace("%", "").Trim();
				}
				else if (stringValue.EndsWith("px"))
				{
					lengthMode = LengthMode.Pixels;
					numericValue = stringValue.Replace("px", "").Trim();
				}
				
				if(!lengthMode.HasValue || string.IsNullOrWhiteSpace(numericValue))
					throw new NotSupportedException();

				return new LengthDescriptor(double.Parse(numericValue), lengthMode.Value);
			}
			catch
			{
				throw new Exception("convertfrom failed");
			}
		}


		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			try
			{
				//{
				//	destinationType.ShouldNotBeNull();
				//	value.ShouldNotBeNull();
				//	var strValue = ConvertToInvariantString(context, value);
				//	if (destinationType == typeof(string)) return value.ToString();
				//	if (destinationType == typeof(InstanceDescriptor))
				//	{
				//		var info = TargetType.GetField(strValue);
				//		if (info != null) return new InstanceDescriptor(info, null);
				//	}
				//	if (destinationType == TargetType)
				//		return FlexEnum.Parse(TargetType, strValue);
				throw new Exception("convertto failed");
			}
			catch
			{
				throw new Exception("convertto failed unknown");
			}
		}
	}
}
