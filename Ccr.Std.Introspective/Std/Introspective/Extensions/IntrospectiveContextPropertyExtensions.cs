using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ccr.Std.Core.Extensions;
using Ccr.Std.Introspective.Infrastructure.Context;
using JetBrains.Annotations;
using MemberDescriptor = Ccr.Std.Introspective.Infrastructure.MemberDescriptor;

namespace Ccr.Std.Introspective.Extensions
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




    public static void SetPropertyValue<TValue>(
      [NotNull] this IntrospectiveContext @this,
      [NotNull] MemberDescriptor memberDescriptor,
      [NotNull] string propertyName,
      [CanBeNull] TValue value)
    {
      @this.IsNotNull(nameof(@this));
      memberDescriptor.IsNotNull(nameof(memberDescriptor));
      propertyName.IsNotNull(nameof(propertyName));

      var ownerType = @this.GetType();
      var propertyInfo = ownerType.GetProperty(
        propertyName,
        memberDescriptor);

      if (propertyInfo == null)
        throw new MissingMemberException(
          ownerType.Name, 
          nameof(propertyInfo));

      propertyInfo.SetValue(
        @this, 
        value);
    }

    public static object GetPropertyValue(
      [NotNull] this IntrospectiveContext @this,
      [NotNull] MemberDescriptor memberDescriptor,
      [NotNull] string fieldName) 
    {
      return @this.GetFieldValue<object>(
        memberDescriptor,
        fieldName);
    }

	  public static TValue GetPropertyValue<TValue>(
	    [NotNull] this IntrospectiveContext @this,
	    [NotNull] MemberDescriptor memberDescriptor,
	    [NotNull] string propertyName)
	  {
	    @this.IsNotNull(nameof(@this));
	    memberDescriptor.IsNotNull(nameof(memberDescriptor));
	    propertyName.IsNotNull(nameof(propertyName));

	    var ownerType = @this.TargetType;
	    var propertyInfo = ownerType.GetProperty(
	      propertyName,
	      memberDescriptor);

	    if (propertyInfo == null)
	      throw new MissingMemberException(
	        ownerType.Name,
	        nameof(propertyInfo));

	    var boxedValue = propertyInfo.GetValue(
	      @this.TargetObject);

	    return (TValue) boxedValue;
	  }
	}
}
