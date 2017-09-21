namespace Ccr.Xaml.Collections
{
	public delegate void NotifyCollectionChangedEventHandler<TValue>(
		IReactiveCollection<TValue> sender,
		NotifyCollectionChangedEventArgs<TValue> args);
}