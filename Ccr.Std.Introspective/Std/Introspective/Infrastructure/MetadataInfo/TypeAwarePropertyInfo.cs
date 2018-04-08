using System;
using System.Reflection;

namespace Ccr.Std.Introspective.Infrastructure.MetadataInfo
{
  public class TypeAwarePropertyInfo<TPropertyType>
  {
    private PropertyInfo _propertyInfo;


    public TypeAwarePropertyInfo(
      PropertyInfo propertyInfo)
    {
      _propertyInfo = propertyInfo;
      
    }
  }
  public class AttributeAwarePropertyInfo<TAttributeType>
    where TAttributeType
      : Attribute
    
  {
    private PropertyInfo _propertyInfo;

    public TAttributeType AttributeInstance { get; }


    public MemberTypes MemberType
    {
      get => MemberTypes.Property;
    }

    public string Name
    {
      get => _propertyInfo.Name;
    }

    public Type DeclaringType
    {
      get => _propertyInfo.DeclaringType;
    }




    public AttributeAwarePropertyInfo(
      PropertyInfo propertyInfo)
    {
      _propertyInfo = propertyInfo;

      AttributeInstance = _propertyInfo
        .GetCustomAttribute<TAttributeType>();
    }
  }
}
