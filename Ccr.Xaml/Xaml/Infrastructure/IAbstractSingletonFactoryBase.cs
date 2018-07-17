using System;

namespace Ccr.Xaml.Infrastructure
{
  public interface IAbstractSingletonFactoryBase
  {
    object GetInstanceBase(
      Type type,
      params object[] constructorArgs);
  }
}