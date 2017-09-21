using System;
using System.Globalization;
using System.Windows.Data;
using Ccr.Xaml.Markup.Extensions;

namespace Ccr.Xaml.Markup.Converters.Infrastructure
{
	public abstract class XamlConverter<T1, T2, T3, T4, TParam, TResult>
		: MarkupExtensionAbstractSingletonFactory,
			IMultiValueConverter
				where TParam
				: ConverterParam
	{
		object IMultiValueConverter.Convert(
			object[] values,
			Type targetType,
			object parameter,
			CultureInfo cultureInfo)
		{
			var arg1 = XamlUtilities.Convert<T1>(values[0], this);

			var arg2 = XamlUtilities.Convert<T2>(values[1], this);

			var arg3 = XamlUtilities.Convert<T3>(values[2], this);

			var arg4 = XamlUtilities.Convert<T4>(values[3], this);

			var param = XamlUtilities.ConvertParam<TParam>(
				parameter, cultureInfo, this);

			return Convert(arg1, arg2, arg3, arg4, (TParam)param);
		}

		public abstract TResult Convert(T1 arg1, T2 arg2, T3 arg3, T4 arg4, TParam param);

		public object[] ConvertBack(
			object value,
			Type[] targetTypes,
			object parameter,
			CultureInfo cultureInfo)
		{
			throw new NotImplementedException();
		}
	}
}
