using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Ccr.Xaml.Collections
{
	public interface IReactiveCollection
		: ICollection,
			INotifyCollectionChanged,
			INotifyPropertyChanged
	{
	}

	public interface IReactiveCollection<TValue>
		: IReactiveCollection,
			INotifyCollectionChanged<TValue>
	{
	}
}