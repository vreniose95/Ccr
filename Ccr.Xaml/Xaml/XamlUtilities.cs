using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Ccr.Std.Introspective.Extensions;
using Ccr.Std.Core.Extensions;
using Ccr.Std.Extensions;
using Ccr.Xaml.Markup.Converters.Infrastructure;
using MemberDescriptor = Ccr.Std.Introspective.Infrastructure.MemberDescriptor;
using StringExtensions = Ccr.Core.Extensions.StringExtensions;
using TypeExtensions = Ccr.Core.Extensions.TypeExtensions;

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
			if (TypeExtensions.IsGenericOf(parameterType, typeof(ConverterParam<>)))
			{
				var valueType = parameterType
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
		  if (destinationValueType.IsGenericOf(typeof(VeridicBinding<>)))
		  {

		  }
			if (TypeExtensions.IsGenericOf(destinationValueType, typeof(Nullable<>)))
			{
        if (value == DependencyProperty.UnsetValue ||
				    value == null)
				{
          return destinationValueType.CreateDefaultValue();
          //     return null;
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
						$"{StringExtensions.SQuote(value.GetType().FormatName())} " +
						$"to {StringExtensions.SQuote(destinationValueType.FormatName())}.");
				}
			}
			if (value == DependencyProperty.UnsetValue ||
			    value == null)
			{
				if (destinationValueType.IsValueType)
				{
				  return destinationValueType.CreateDefaultValue();

				  //throw new NotSupportedException();
				}

				return null;
			}
			if (destinationValueType.IsInstanceOfType(value))
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
