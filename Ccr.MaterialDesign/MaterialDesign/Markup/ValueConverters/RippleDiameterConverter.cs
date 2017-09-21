using System;
using System.Globalization;
using System.Windows.Data;
using Ccr.Xaml.Markup.Extensions;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class RippleDiameterConverter
		: MarkupExtensionAbstractSingletonFactory,
			IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
