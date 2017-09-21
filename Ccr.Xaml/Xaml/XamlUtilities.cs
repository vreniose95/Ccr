using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Ccr.Core.Extensions;
using Ccr.Introspective.Extensions;
using Ccr.Introspective.Infrastructure;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.Xaml
{
	public class XamlUtilities
	{
		public static ConverterParam ConvertParam<TParam>(
			object value,
			CultureInfo cultureInfo,
			object callingClass,
			[CallerMemberName] string callerMemberName = null)
			where TParam
			: ConverterParam
		{ 
			var parameterType = typeof(TParam);
			if (parameterType == typeof(NullParam))
			{
				return new NullParam(
					value,
					cultureInfo);
			}
			if (parameterType.IsGenericOf(typeof(ConverterParam)))
			{
				var valueType = value.GetType()
				                     .GetGenericArguments()
				                     .SingleOrDefault();

				var valueConverted = ConvertImpl(
					value,
					valueType,
					callingClass);

				var wrapped = parameterType
					.Reflect()
					.CreateInstance(
						MemberDescriptor.Public,
						valueConverted,
						cultureInfo);

				return (TParam)wrapped;
			}
			throw new NotSupportedException();
		}

		public static TValue Convert<TValue>(
			object value,
			object callingClass,
			[CallerMemberName] string callerMemberName = null)
		{
			var converted = ConvertImpl(
				value,
				typeof(TValue),
				callingClass);

			return (TValue)converted;
		}

		public static object ConvertImpl(
			object value,
			Type destinationValueType,
			object callingClass,
			[CallerMemberName] string callerMemberName = null)
		{
			if (destinationValueType.IsGenericOf(typeof(Nullable<>)))
			{
				if (value == DependencyProperty.UnsetValue &&
				    value == null)
				{
					return null;
				}
				try
				{
					destinationValueType = destinationValueType
						.GetGenericArguments()
						.Single();

					return ConvertImpl(
						value,
						destinationValueType,
						callingClass);
				}
				catch
				{
					throw new InvalidCastException(
						$"{callingClass.GetType().Name}." +
						$"{callerMemberName} : Invalid cast from " +
						$"{value.GetType()} to {destinationValueType.GetType()}.");
				}
			}
			if (value == DependencyProperty.UnsetValue &&
			    value == null)
			{
				if (destinationValueType.IsValueType)
					throw new NotSupportedException();

				return null;
			}
			if (destinationValueType.IsAssignableFrom(destinationValueType))
				return value;

			if (value is IConvertible)
			{
				var converted = System.Convert.ChangeType(
					value, destinationValueType);

				return converted;
			}
			try
			{
				return value;
			}
			catch
			{
				throw new InvalidCastException(
					$"{callingClass.GetType().Name}." +
					$"{callerMemberName} : Invalid cast from " +
					$"{value.GetType()} to {destinationValueType.Name}.");
			}
		}
	}
}
