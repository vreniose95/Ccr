using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Ccr.MDHybrid.Demo
{
	public class IsNullOrEmptyToVisibilityConverter
		: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return Visibility.Hidden;

			if (value is string s)
			{
				return string.IsNullOrEmpty(s)
					? Visibility.Hidden
					: Visibility.Visible;
			}

			var str = value.ToString();

			return string.IsNullOrEmpty(str)
				? Visibility.Hidden
				: Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
