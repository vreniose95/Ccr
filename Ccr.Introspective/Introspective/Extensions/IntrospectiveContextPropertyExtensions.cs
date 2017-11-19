using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ccr.Core.Extensions;
using Ccr.Introspective.Infrastructure.Context;
using JetBrains.Annotations;
using MemberDescriptor = Ccr.Introspective.Infrastructure.MemberDescriptor;

namespace Ccr.Introspective.Extensions
{
	public static class IntrospectiveContextPropertyExtensions
	{
    
		public static IEnumerable<PropertyInfo> GetProperties(
			[NotNull] this IntrospectiveStaticContext @this,
			[NotNull] MemberDescriptor memberDescriptor)
		{
			@this.IsNotNull(nameof(@this));
		  memberDescriptor.IsNotNull(nameof(memberDescriptor));
      
		  var propertyInfos = @this
        .TargetType
        .GetProperties(
          memberDescriptor);

		  return propertyInfos;
		}

	  public static IEnumerable<PropertyInfo> GetPropertiesOfType<TPropertyType>(
	    [NotNull] this IntrospectiveStaticContext @this,
	    [NotNull] MemberDescriptor memberDescriptor)
	  {
	    @this.IsNotNull(nameof(@this));
	    memberDescriptor.IsNotNull(nameof(memberDescriptor));

	    return @this
	      .GetProperties(memberDescriptor)
	      .Where(t => t.PropertyType == typeof(TPropertyType));
	  }

    [NotNull]
	  public static IEnumerable<(PropertyInfo propertyInfo, TAttributeType attribute)> 
      GetPropertiesWithAttribute<TAttributeType>(
	      [NotNull] this IntrospectiveStaticContext @this,
	      [NotNull] MemberDescriptor memberDescriptor,
        bool inheritAttributes = true)
          where TAttributeType
            : Attribute
	  {
	    @this.IsNotNull(nameof(@this));
	    memberDescriptor.IsNotNull(nameof(memberDescriptor));

	    return @this
	      .GetProperties(memberDescriptor)
	      .Select(t => (
	                propertyInfo: t,
	                attribute: t.GetCustomAttribute<TAttributeType>(inheritAttributes)))
	      .Where(t => t.attribute != null);
	  }

    [CanBeNull]
	  public static PropertyInfo GetPropertyByName(
	    [NotNull] this IntrospectiveStaticContext @this,
	    [NotNull] MemberDescriptor memberDescriptor,
      [NotNull] string propertyName)
	  {
	    @this.IsNotNull(nameof(@this));
	    memberDescriptor.IsNotNull(nameof(memberDescriptor));
	    propertyName.IsNotNull(nameof(propertyName));

      var propertyInfo = @this
	      .TargetType
	      .GetProperty(
	        propertyName,
          memberDescriptor);

	    return propertyInfo;
	  }


  }
}



//public static TValue CreateInstance<TValue>(
//	[NotNull] this IntrospectiveStaticContext @this,
//	[NotNull] MemberDescriptor descriptor,
//	[ItemCanBeNull] params object[] arguments)
//{
//	@this.ThrowIfNull();
//	descriptor.ThrowIfNull();

//	var parameterTypes = arguments
//		.Select(t => t?.GetType())
//		.ToArray();

//	var constructorInfo = @this.TargetType.GetConstructor(
//		descriptor,
//		null,
//		CallingConventions.Any,
//		parameterTypes,
//		new ParameterModifier[] { });

//	if (constructorInfo == null)
//		throw new TypeInitializationException(@this.TargetType.FullName, null);

//	var instance = constructorInfo.Invoke(arguments);
//	var valueType = typeof(TValue);

//	if (!valueType.IsInstanceOfType(instance))
//	{

//	}
//	return (TValue)instance;

//	//throw new InvalidCastException($"Cannot cast property value \'{returnVal.GetType().Name}\' to {typeof(TResult).Name}");
//}

