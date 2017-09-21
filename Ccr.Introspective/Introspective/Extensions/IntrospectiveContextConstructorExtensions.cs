using System;
using System.Linq;
using System.Reflection;
using Ccr.Core.Extensions;
using Ccr.Introspective.Infrastructure.Context;
using JetBrains.Annotations;
using MemberDescriptor = Ccr.Introspective.Infrastructure.MemberDescriptor;

namespace Ccr.Introspective.Extensions
{
	public static class IntrospectiveContextConstructorExtensions
	{
		public static TValue CreateInstance<TValue>(
			[NotNull] this IntrospectiveStaticContext<TValue> @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[ItemCanBeNull] params object[] arguments)
		{
			@this.IsNotNull(nameof(@this));
			memberDescriptor.IsNotNull(nameof(memberDescriptor));

			var parameterTypes = arguments
				.Select(t => t?.GetType())
				.ToArray();

			var constructorInfo = @this.TargetType.GetConstructor(
				memberDescriptor,
				null,
				CallingConventions.Any,
				parameterTypes,
				new ParameterModifier[] { });

			if (constructorInfo == null)
				throw new TypeInitializationException(
					@this.TargetType.FullName, null);
			
			var instance = constructorInfo.Invoke(arguments);
			var valueType = typeof(TValue);

			if (!valueType.IsInstanceOfType(instance))
			{

			}
			return (TValue)instance;
			//throw new InvalidCastException($"Cannot cast property value \'{returnVal.GetType().Name}\' to {typeof(TResult).Name}");
		}


		public static object CreateInstance(
			[NotNull] this IntrospectiveStaticContext @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[ItemCanBeNull] params object[] arguments)
		{
			@this.IsNotNull(nameof(@this));
			memberDescriptor.IsNotNull(nameof(memberDescriptor));

			var parameterTypes = arguments
				.Select(t => t?.GetType())
				.ToArray();

			var constructorInfo = @this.TargetType.GetConstructor(
				memberDescriptor,
				null,
				CallingConventions.Any,
				parameterTypes,
				new ParameterModifier[] { });

			if (constructorInfo == null)
				throw new TypeInitializationException(
					@this.TargetType.FullName, null);
			
			var instance = constructorInfo.Invoke(arguments);
			return instance;

			//throw new InvalidCastException($"Cannot cast property value \'{returnVal.GetType().Name}\' to {typeof(TResult).Name}");
		}

		public static TReturns InvokeCtorGeneric<TReturns>(
			[NotNull] this IntrospectiveStaticContext<TReturns> @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[ItemNotNull] Type[] genericTypeArgs,
			[ItemCanBeNull] object[] methodArgs)
		{
			@this.IsNotNull(nameof(@this));
			memberDescriptor.IsNotNull(nameof(memberDescriptor));
			
			var constructorInfo = @this.TargetType.GetConstructor(genericTypeArgs);

			if (constructorInfo == null)
				throw new MissingMemberException();

			var rawReturnValue = constructorInfo.Invoke(methodArgs);

			if (rawReturnValue is TReturns)
			{
				return (TReturns)rawReturnValue;
			}
			throw new NotImplementedException();


			//var parameterTypes = arguments
			//	.Select(t => t?.GetType())
			//	.ToArray();

			//var constructorInfo = @this.TargetType.GetConstructor(
			//	memberDescriptor,
			//	null,
			//	CallingConventions.Any,
			//	parameterTypes,
			//	new ParameterModifier[] { });

			//if (constructorInfo == null)
			//	throw new TypeInitializationException(
			//		@this.TargetType.FullName, null);

			//var instance = constructorInfo.Invoke(arguments);
			//var valueType = typeof(TValue);

			//if (!valueType.IsInstanceOfType(instance))
			//{

			//}
			//return (TValue)instance;
			//throw new InvalidCastException($"Cannot cast property value \'{returnVal.GetType().Name}\' to {typeof(TResult).Name}");
		}
	}
}
