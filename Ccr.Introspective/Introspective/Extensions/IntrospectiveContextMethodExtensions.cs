﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ccr.Core.Extensions;
using Ccr.Introspective.Infrastructure.Context;
using JetBrains.Annotations;
using MemberDescriptor = Ccr.Introspective.Infrastructure.MemberDescriptor;

namespace Ccr.Introspective.Extensions
{
	public static class IntrospectiveContextMethodExtensions
	{
		public static void InvokeMethod(
			[NotNull] this IntrospectiveContext @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[NotNull] string methodName,
			params object[] methodArgs)
		{
			@this.IsNotNull(nameof(@this));
			memberDescriptor.IsNotNull(nameof(memberDescriptor));
			methodName.IsNotNull(nameof(methodName));

			var ownerType = @this.TargetType;
			var methodInfo = ownerType.GetMethod(methodName, memberDescriptor);

			if (methodInfo == null)
				throw new MissingMethodException(
					ownerType.Name,
					methodName);

			methodInfo.Invoke(
				@this.TargetObject,
				methodArgs);
		}
		public static TReturns InvokeMethod<TReturns>(
			[NotNull] this IntrospectiveContext @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[NotNull] string methodName,
			params object[] methodArgs)
		{
			@this.IsNotNull(nameof(@this));
			memberDescriptor.IsNotNull(nameof(memberDescriptor));
			methodName.IsNotNull(nameof(methodName));

			var ownerType = @this.TargetType;
			var methodInfo = ownerType.GetMethod(methodName, memberDescriptor);

			if (methodInfo == null)
				throw new MissingMethodException(
					ownerType.Name,
					methodName);

			var rawReturnValue = methodInfo.Invoke(
				@this.TargetObject,
				methodArgs);

			if (rawReturnValue is TReturns)
			{
				return (TReturns)rawReturnValue;
			}
			throw new InvalidCastException(
				$"Cannot cast raw returned value of type \'{rawReturnValue.GetType().FormatName()}\' " +
				$"to the expected return type of \'{typeof(TReturns).FormatName()}\'.");
		}

		public static TReturns InvokeMethodGeneric<TReturns>(
			[NotNull] this IntrospectiveContext @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[NotNull] string methodName,
			Type[] genericTypeArgs,
			object[] methodArgs)
		{
			@this.IsNotNull(nameof(@this));
			memberDescriptor.IsNotNull(nameof(memberDescriptor));
			methodName.IsNotNull(nameof(methodName));

			var ownerType = @this.TargetType;
			var methodInfo = ownerType.GetMethod(methodName, memberDescriptor);

			if (methodInfo == null)
				throw new MissingMethodException(
					ownerType.Name,
					methodName);

			var genericMethodInfo = methodInfo.MakeGenericMethod(genericTypeArgs);

			if (genericMethodInfo == null)
				throw new ArgumentException(
					$"Unable to create a generic method from the provided " +
					$"generic type arguments: <" +
					string.Join(", ",
						genericTypeArgs
							.Select(
								t => t.FormatName())
							.ToArray()) + ">.",
					new MissingMethodException(
						ownerType.Name,
						methodName));

			var rawReturnValue = genericMethodInfo.Invoke(
				@this.TargetObject,
				methodArgs);

			if (rawReturnValue is TReturns)
			{
				return (TReturns)rawReturnValue;
			}
			throw new InvalidCastException(
				$"Cannot cast raw returned value of type \'{rawReturnValue.GetType().FormatName()}\' " +
				$"to the expected return type of \'{typeof(TReturns).FormatName()}\'.");
		}



	  [NotNull]
	  public static IEnumerable<(MethodInfo methodInfo, TAttributeType attribute)>
	    GetMethodsWithAttribute<TAttributeType>(
	      [NotNull] this Type @this,
	      BindingFlags memberDescriptor,
	      bool inheritAttributes = true)
	        where TAttributeType
	          : Attribute
	  {
	    @this.IsNotNull(nameof(@this));
	    memberDescriptor.IsNotNull(nameof(memberDescriptor));

	    return @this
	      .GetMethods(memberDescriptor)
	      .Select(t => (
	                propertyInfo: t,
	                attribute: t.GetCustomAttribute<TAttributeType>(
	                  inheritAttributes)))
	      .Where(t => t.attribute != null);
	  }




    //var fieldType = fieldInfo.FieldType;
    //var valueType = typeof(TValue);

    //var rawValue = fieldInfo.GetValue(@this.TargetObject);
    //return (TValue)rawValue;

    //if (!fieldType.IsAssignableFrom(valueType))
    //var adjustedValue = value;
    //throw new InvalidCastException($"Cannot cast property value \'{returnVal.GetType().Name}\' to {typeof(TResult).Name}");

  }
}
