using System;
using System.Linq;
using System.Reflection;
using Ccr.Core.Extensions;
using Ccr.Std.Introspective.Infrastructure.Context;
using JetBrains.Annotations;
using MemberDescriptor = Ccr.Std.Introspective.Infrastructure.MemberDescriptor;

namespace Ccr.Std.Introspective.Extensions
{
	public static class IntrospectiveContextConstructorExtensions
	{
	  /// <summary>
	  /// Creates an instance of the type with the specified constructor arguments for the Type 
	  /// specified in <paramref name="this"/>'s <see cref="IntrospectiveStaticContext.TargetType"/> 
	  /// </summary>
	  /// <typeparam name="TValue">
	  /// The Type of the object being created through the constructor matching the corresponding
	  /// type signature of the arguments provided through the <paramref name="arguments"/> parameter.
	  /// </typeparam>
	  /// <param name="this">
	  /// The instance of the <see cref="IntrospectiveStaticContext"/> describing the introspection 
	  /// context for the <see cref="System.Reflection"/> calls to the constructor.
	  /// </param>
	  /// <param name="descriptor">
	  /// The <see cref="MemberDescriptor"/> instance specifying the member filtering, fluently
	  /// wrapping the <see cref="BindingFlags"/> configuration to use in the <see cref="System.Reflection"/>
	  /// </param>
	  /// <param name="arguments">
	  /// An optional param array of <see cref="object"/> that specifies the constructor arguments.
	  /// </param>
	  /// <returns>
	  /// An instance of <typeparamref name="TValue"/> created with the provided constructor arguments.
	  /// </returns>
	  public static TValue CreateInstance<TValue>(
	    [NotNull] this IntrospectiveStaticContext @this,
	    [NotNull] MemberDescriptor descriptor,
	    [ItemCanBeNull] params object[] arguments)
	  {
	    @this.IsNotNull(nameof(@this));
	    descriptor.IsNotNull(nameof(descriptor));

	    var instance = CreateInstanceImpl(
	      @this,
	      descriptor,
	      arguments);

	    if (instance is TValue)
	      return (TValue)instance;

	    throw new InvalidCastException(
	      $"Cannot cast property of type \'{instance.GetType().Name}\' to \'{typeof(TValue).Name}\'");
	  }

	  /// <summary>
	  /// 
	  /// </summary>
	  /// <param name="this"></param>
	  /// <param name="descriptor"></param>
	  /// <param name="arguments"></param>
	  /// <returns></returns>
	  public static object CreateInstanceImpl(
	    [NotNull] this IntrospectiveStaticContext @this,
	    [NotNull] MemberDescriptor descriptor,
	    [ItemCanBeNull] params object[] arguments)
	  {
	    @this.IsNotNull(nameof(@this));
	    descriptor.IsNotNull(nameof(descriptor));

	    var parameterTypes = arguments
	      .Select(t => t?.GetType())
	      .ToArray();

	    var constructorInfo = @this.TargetType.GetConstructor(
	      descriptor,
	      null,
	      CallingConventions.Any,
	      parameterTypes,
	      new ParameterModifier[] { });

	    if (constructorInfo == null)
	      throw new TypeInitializationException(@this.TargetType.FullName, null);

	    var instance = constructorInfo.Invoke(arguments);
	    return instance;
	  }

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
