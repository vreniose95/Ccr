using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Media;

namespace Ccr.MaterialDesign.Markup.TypeConverters
{
	public class MaterialBrushToColorConverter
		: TypeConverter
	{
		internal interface IColor
		{
			
		}
		internal class ColorLiteral
		{
			
			private string _stringLiteral;
			private Nullable<Color> _color;
			private SolidColorBrush _solidColorBrush;
			private MaterialBrush _innerMaterialBrush;


			public static ColorLiteral FromString(
				string stringLiteral)
			{
				throw new Exception();
			}

		}

		private static readonly Type[] _acceptedInputTypes =
		{
			typeof(string),
			typeof(Color),
			typeof(SolidColorBrush),
			typeof(MaterialBrush)
		};

		private static readonly Type[] _acceptedOutputTypes =
		{
			typeof(string),
			typeof(Color),
			typeof(SolidColorBrush),
			typeof(MaterialBrush)
		};


		public override bool CanConvertFrom(
			ITypeDescriptorContext context,
			Type sourceType)
		{
			return _acceptedInputTypes
				.Contains(sourceType);
		}

		public override bool CanConvertTo(
			ITypeDescriptorContext context,
			Type destinationType)
		{
			return _acceptedOutputTypes
				.Contains(destinationType);
		}

		public override object ConvertFrom(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value)
		{
			switch (value)
			{
				case string str:
				{
					break;
				}
				case Color color:
				{
					break;
				}
				case SolidColorBrush solidColorBrush:
				{
					return solidColorBrush.Color;
				}
				case MaterialBrush materialBrush:
				{
					break;
				}

			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value,
			Type destinationType)
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object CreateInstance(
			ITypeDescriptorContext context,
			IDictionary propertyValues)
		{
			return base.CreateInstance(context, propertyValues);
		}

		public override bool GetCreateInstanceSupported(
			ITypeDescriptorContext context)
		{
			return base.GetCreateInstanceSupported(context);
		}

		public override PropertyDescriptorCollection GetProperties(
			ITypeDescriptorContext context,
			object value,
			Attribute[] attributes)
		{
			return base.GetProperties(context, value, attributes);
		}

		public override bool GetPropertiesSupported(
			ITypeDescriptorContext context)
		{
			return base.GetPropertiesSupported(context);
		}

		public override StandardValuesCollection GetStandardValues(
			ITypeDescriptorContext context)
		{
			return base.GetStandardValues(context);
		}

		public override bool GetStandardValuesExclusive(
			ITypeDescriptorContext context)
		{
			return base.GetStandardValuesExclusive(context);
		}

		public override bool GetStandardValuesSupported(
			ITypeDescriptorContext context)
		{
			return base.GetStandardValuesSupported(context);
		}

		public override bool IsValid(
			ITypeDescriptorContext context,
			object value)
		{
			return base.IsValid(context, value);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
