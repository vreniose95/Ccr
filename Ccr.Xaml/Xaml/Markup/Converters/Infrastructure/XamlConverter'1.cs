using System;
using System.Globalization;
using System.Windows.Data;
using Ccr.Xaml.Markup.Extensions;

namespace Ccr.Xaml.Markup.Converters.Infrastructure
{
	public abstract class XamlConverter<T1, TParam, TResult> 
		: MarkupExtensionAbstractSingletonFactory, 
			IValueConverter
				where TParam 
					: ConverterParam
	{
		object IValueConverter.Convert(
			object value, 
			Type targetType, 
			object parameter, 
			CultureInfo cultureInfo)
		{
			var arg1 = XamlUtilities.Convert<T1>(value, this);

			var param = XamlUtilities.ConvertParam<TParam>(
				parameter, cultureInfo, this);

			return Convert(arg1, (TParam)param);
		}

		public abstract TResult Convert(T1 arg1, TParam param);

		object IValueConverter.ConvertBack(
			object value, 
			Type targetTypes, 
			object parameter,
			CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
