namespace Ccr.Xaml.Collections
{
	public interface INotifyCollectionChanged<TValue>
	{
		/// <summary>Occurs when the collection changes.</summary>
		event NotifyCollectionChangedEventHandler<TValue> CollectionChangedGeneric;
	}
}