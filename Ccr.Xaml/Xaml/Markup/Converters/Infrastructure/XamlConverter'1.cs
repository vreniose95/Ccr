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
		protected virtual T1 ConvertArg1(object arg)
		{
			return XamlUtilities.Convert<T1>(arg, this);
		}

		protected virtual ConverterParam ConvertParam(object param, CultureInfo cultureInfo)
		{
			return XamlUtilities.ConvertParam<TParam>(param, cultureInfo, this);
		}


		object IValueConverter.Convert(
			object value, 
			Type targetType, 
			object parameter, 
			CultureInfo cultureInfo)
		{
			var arg1 = ConvertArg1(value);

			var param = ConvertParam(parameter, cultureInfo);

			return Convert(arg1, (TParam)param);
		}

		public abstract TResult Convert(
		  T1 arg1, 
		  TParam param);

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
