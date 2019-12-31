using System;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
  //[AttributeUsage(AttributeTargets.GenericParameter)]
  //public class MixedTypeConstraintAttribute
  //  : Attribute
  //{
  //  public Type[] AcceptedTypes { get; }

  //  public MixedTypeConstraintAttribute(
  //    params Type[] types)
  //  {
  //    AcceptedTypes = types;
  //  }
  //}

  public static class IServiceProviderExtensions
  {
    //private static readonly Type[] ServiceTypes = new[]
    //{
    //  typeof(ITypeDiscoveryService),
    //  typeof(IExtenderProviderService),
    //  typeof(IProvideValueTarget),
    //  typeof()

    //};
    [NotNull]
    public static TService GetService<TService>(
      [NotNull] this IServiceProvider @this)
        where TService
         :  class
    {
      @this.IsNotNull(nameof(@this));

      var service = @this.GetService(typeof(TService)) as TService;
      
      if(service != null)
        return service.As<TService>();
      
      throw new InvalidOperationException(
        $"The service type {typeof(TService).Name.SQuote()} is not" +
        $"available from the \'IServiceProvider\' in this context.");
    }
  }
}
