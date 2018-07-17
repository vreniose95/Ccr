namespace Ccr.Xaml.Infrastructure
{
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
