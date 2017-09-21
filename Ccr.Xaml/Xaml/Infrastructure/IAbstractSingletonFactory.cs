using System;

namespace Ccr.Xaml.Infrastructure
{
	public interface IAbstractSingletonFactoryBase
	{
		object GetInstanceBase(
			Type type,
			params object[] constructorArgs);
	}

	public interface IAbstractSingletonFactory<in TValue> :
		IAbstractSingletonFactoryBase
	{
		TResult GetInstance<TResult>(
			params object[] constructorArgs)
				where TResult : TValue;
	}
	internal interface SingletonProvider<out TValue>
	{
		TValue I { get; }
	}
}
