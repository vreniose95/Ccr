using System.ComponentModel;
using System.Windows;

namespace Ccr.Core.Extensions
{
	public static class DependencyExtensions
	{
		public static TElement XamlSet<TElement>(
			this TElement @this,
			DependencyProperty property,
			object value)
				where TElement 
					: DependencyObject
		{
			var converter = TypeDescriptor.GetConverter(property.PropertyType);
			var convertedValue = converter.ConvertFrom(value);

			@this.SetValue(property, convertedValue);

			return @this;
		}
	}
}
