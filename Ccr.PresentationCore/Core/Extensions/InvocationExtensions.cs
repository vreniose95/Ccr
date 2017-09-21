using System;
using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.Core.Extensions
{
	public static class InvocationExtensions
	{
		public static void TryInvoke<TOwner, TValue>(
			this PropertyChange<TOwner, TValue> @this,
			DependencyObject dependencyObject, 
			DependencyPropertyChangedEventArgs args) 
				where TOwner : DependencyObject
		{
			if (!(dependencyObject is TOwner))
				throw new InvalidCastException(
					$"The \'dependencyObject\' argument must be of type \'{typeof(TOwner).Name}\'.");
			var owner = (TOwner)dependencyObject;

			@this?.Invoke(owner, new DPChangedEventArgs<TValue>(args));
		}

		public static object TryInvoke<TOwner, TValue>(
			this PropertyCoerce<TOwner, TValue> @this, 
			DependencyObject dependencyObject, 
			object baseValue) 
				where TOwner : DependencyObject
		{
			if (@this == null)
				return (TValue)baseValue;
			
			if(!(dependencyObject is TOwner))
				throw new InvalidCastException(
					$"The \'dependencyObject\' argument must be of type \'{typeof(TOwner).Name}\'.");
			var owner = (TOwner) dependencyObject;

			if (!(baseValue is TValue))
				throw new InvalidCastException(
					$"The \'baseValue\' argument must be of type \'{typeof(TValue).Name}\'.");
			var value = (TValue)baseValue;

			return @this.Invoke(owner, value);
		}

		public static bool TryInvoke<TValue>(
			this PropertyValidate<TValue> @this, 
			object _value)
		{
			if (@this == null)
				return true;

			if (_value == null)
				return false;

			if (!(_value is TValue))
				throw new InvalidCastException(
					$"The \'baseValue\' argument must be of type \'{typeof(TValue).Name}\'.");
			var value = (TValue)_value;

			return @this.Invoke(value);
		}
	}
}
