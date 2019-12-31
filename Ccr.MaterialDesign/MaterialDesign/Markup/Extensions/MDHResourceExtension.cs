



using System;
using System.Windows;
using System.Windows.Markup;
using System.Xaml;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Markup.Extensions
{
//  [MarkupExtensionReturnType(typeof(object))]
//  [Localizability(LocalizationCategory.NeverLocalize)]
//  public class MDHResourceExtension
//    : StaticResourceExtension
//  {

//    public MDHResourceExtension()
//    {
//    }
//    public MDHResourceExtension(
//      [NotNull] object resourceKey) : base(
//        resourceKey)
//    {
//    }


//    public override object ProvideValue(
//      IServiceProvider serviceProvider)
//    {
//      var definedResourceValue = base.ProvideValue(serviceProvider);

//      if (definedResourceValue == null)
//        throw new InvalidOperationException(
//          $"The StaticResource value cannot be null");


//      var xamlSchemaContextProvider = serviceProvider
//        .GetService<IXamlSchemaContextProvider>();

//      var provideValueTarget = serviceProvider
//        .GetService<IProvideValueTarget>();


//      var definedResourceType = definedResourceValue.GetType();

//      var targetType = provideValueTarget
//        .TargetProperty
//        .As<DependencyProperty>()
//        .PropertyType;

//      var initialXamlType = xamlSchemaContextProvider
//        .SchemaContext
//        .GetXamlType(definedResourceType);

//      var typeConverterInstance = initialXamlType
//        .TypeConverter
//        .ConverterInstance;


//      var convertedValue = typeConverterInstance.ConvertTo(
//        definedResourceValue,
//        targetType);

//      return convertedValue;
//    }
//  }
//}

//var assemblyName = AssemblyName.GetAssemblyName(
//  "PresentationFramework, " +
//  "Version=4.0.0.0, " +
//  "Culture=neutral, " +
//  "PublicKeyToken=31bf3856ad364e35");

//var assembly = Assembly.Load(assemblyName);

//var systemResourceKey = ForeignNonPublicTypeProxy
//  .CreateProxy(
//     assembly.FullName, 
//     "System.Windows.SystemResourceKey");

//var systemResourceKeyType = systemResourceKey
//  .CreateInstance()
//  .GetType();

//if (ResourceKey.GetType() == systemResourceKeyType)
//{
//  var resource = ResourceKey
//    .Reflect()
//    .>()
//}

//  if (ResourceKey is SystemResourceKey)
//  return (ResourceKey as SystemResourceKey).Resource;
}