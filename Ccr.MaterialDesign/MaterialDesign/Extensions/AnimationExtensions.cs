using System.ComponentModel;
using System.Windows;

namespace Ccr.MaterialDesign.Extensions
{
	public static class AnimationExtensions
	{
		public static TElement Set<TElement>(this TElement @this,
			DependencyProperty property, object value)
			where TElement : DependencyObject
		{
			var converter = TypeDescriptor.GetConverter(property.PropertyType);
			var convertedValue = converter.ConvertFrom(value);
			@this.SetValue(property, convertedValue);
			return @this;
		}
		//public static TElement SetAttachedPath<TElement>(this TElement @this,
		//	DependencyProperty property, object value)
		//	where TElement : DependencyObject
		//{
		//	var converter = new PropertyPathConverter();
		//	var convertedValue = converter.ConvertFrom(value);
		//	@this.SetValue(property, convertedValue);
		//	return @this;
		//}
	}
}
