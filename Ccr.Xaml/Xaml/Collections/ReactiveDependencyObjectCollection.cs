using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;

namespace Ccr.Xaml.Collections
{
	public class ReactiveDependencyObjectCollection<TValue>
		: DependencyObject,
			IReactiveCollection<TValue>
		where TValue : DependencyObject
	{
		private readonly ReactiveCollection<TValue> _reactiveCollection 
			= new ReactiveCollection<TValue>();


		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable)_reactiveCollection).GetEnumerator();
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection)_reactiveCollection).CopyTo(array, index);
		}

		public int Count
		{
			get => _reactiveCollection.Count;
		}
		public object SyncRoot
		{
			get => ((ICollection)_reactiveCollection).SyncRoot;
		}
		public bool IsSynchronized
		{
			get => ((ICollection)_reactiveCollection).IsSynchronized;
		}
		public event NotifyCollectionChangedEventHandler CollectionChanged
		{
			add => _reactiveCollection.CollectionChanged += value;
			remove => _reactiveCollection.CollectionChanged -= value;
		}
		public event PropertyChangedEventHandler PropertyChanged
		{
			add => ((INotifyPropertyChanged)_reactiveCollection).PropertyChanged += value;
			remove => ((INotifyPropertyChanged)_reactiveCollection).PropertyChanged -= value;
		}
		public event NotifyCollectionChangedEventHandler<TValue> CollectionChangedGeneric
		{
			add => _reactiveCollection.CollectionChangedGeneric += value;
			remove => _reactiveCollection.CollectionChangedGeneric -= value;
		}
	}
}