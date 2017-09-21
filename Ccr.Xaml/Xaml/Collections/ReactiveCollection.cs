using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Xaml.Collections
{
	public class ReactiveCollection<TValue>
		: Collection<TValue>,
			IReactiveCollection<TValue>
	{
		private readonly SimpleMonitor _monitor = new SimpleMonitor();
		private const string countString = "Count";
		private const string indexerName = "Item[]";


		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add => PropertyChanged += value;
			remove => PropertyChanged -= value;
		}
		/// <summary>
		/// Occurs when an item is added, removed, changed, moved, or the entire list is refreshed.
		/// </summary>
		public virtual event NotifyCollectionChangedEventHandler CollectionChanged;

		/// <summary>
		/// Occurs when an item is added, removed, changed, moved, or the entire list is refreshed.
		/// </summary>
		public virtual event NotifyCollectionChangedEventHandler<TValue> CollectionChangedGeneric;

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		protected virtual event PropertyChangedEventHandler PropertyChanged;




		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" /> 
		/// class.
		/// </summary>
		public ReactiveCollection()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" /> 
		/// class that contains elements copied from the specified list.
		/// </summary>
		/// <param name="list">
		/// The list from which the elements are copied.
		/// </param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="list" /> parameter cannot be <see langword="null" />
		/// </exception>
		public ReactiveCollection(
			[CanBeNull] List<TValue> list) : base(
				list == null ? new List<TValue>()
				: new List<TValue>(list.Count))
		{
			CopyFrom(list);
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" /> class that contains elements copied from the specified collection.</summary>
		/// <param name="collection">
		/// The collection from which the elements are copied.
		/// </param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="collection" /> parameter cannot be <see langword="null" />.
		/// </exception>
		public ReactiveCollection(
			[NotNull] IEnumerable<TValue> collection)
		{
			collection.IsNotNull(nameof(collection));
			CopyFrom(collection);
		}

		private void CopyFrom(
			[CanBeNull] IEnumerable<TValue> collection)
		{
			var items = Items;
			if (collection == null || items == null)
				return;

			foreach (var obj in collection)
				items.Add(obj);
		}

		/// <summary>
		/// Moves the item at the specified index to a new location in the collection.
		/// </summary>
		/// <param name="oldIndex">
		/// The zero-based index specifying the location of the item to be moved.
		/// </param>
		/// <param name="newIndex">
		/// The zero-based index specifying the new location of the item.
		/// </param>
		public void Move(int oldIndex, int newIndex)
		{
			MoveItem(oldIndex, newIndex);
		}


		/// <summary>
		/// Removes all items from the collection.
		/// </summary>
		protected void TriggerPropertyChanges()
		{
			OnPropertyChanged(countString);
			OnPropertyChanged(indexerName);
		}


		/// <summary>
		/// Removes all items from the collection.
		/// </summary>
		protected override void ClearItems()
		{
			CheckReentrancy();
			base.ClearItems();
			TriggerPropertyChanges();
			OnCollectionReset();
		}

		/// <summary>
		/// Removes the item at the specified index of the collection.
		/// </summary>
		/// <param name="index">
		/// The zero-based index of the element to remove.
		/// </param>
		protected override void RemoveItem(int index)
		{
			CheckReentrancy();
			var obj = this[index];
			base.RemoveItem(index);
			TriggerPropertyChanges();
			OnCollectionChangedGeneric(
				NotifyCollectionChangedAction.Remove,
				obj,
				index);
		}

		/// <summary>
		/// Inserts an item into the collection at the specified index.
		/// </summary>
		/// <param name="index">
		/// The zero-based index at which <paramref name="item" /> should be inserted.
		/// </param>
		/// <param name="item">
		/// The object to insert.
		/// </param>
		protected override void InsertItem(int index, TValue item)
		{
			CheckReentrancy();
			base.InsertItem(index, item);
			TriggerPropertyChanges();
			OnCollectionChangedGeneric(
				NotifyCollectionChangedAction.Add,
				item,
				index);
		}

		/// <summary>
		/// Replaces the element at the specified index.
		/// </summary>
		/// <param name="index">
		/// The zero-based index of the element to replace.
		/// </param>
		/// <param name="item">
		/// The new value for the element at the specified index.
		/// </param>
		protected override void SetItem(int index, TValue item)
		{
			CheckReentrancy();
			var obj = this[index];
			base.SetItem(index, item);
			OnPropertyChanged(indexerName);
			OnCollectionChangedGeneric(
				NotifyCollectionChangedAction.Replace,
				obj,
				item,
				index);
		}

		/// <summary>
		/// Moves the item at the specified index to a new location in the collection.
		/// </summary>
		/// <param name="oldIndex">
		/// The zero-based index specifying the location of the item to be moved.
		/// </param>
		/// <param name="newIndex">
		/// The zero-based index specifying the new location of the item.
		/// </param>
		protected virtual void MoveItem(int oldIndex, int newIndex)
		{
			CheckReentrancy();
			var obj = this[oldIndex];
			base.RemoveItem(oldIndex);
			base.InsertItem(newIndex, obj);
			OnPropertyChanged(indexerName);
			OnCollectionChangedGeneric(
				NotifyCollectionChangedAction.Move,
				obj,
				newIndex,
				oldIndex);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Collections.ObjectModel.ObservableCollection`1.PropertyChanged" /> 
		/// event with the provided arguments.
		/// </summary>
		/// <param name="e">
		/// Arguments of the event being raised.
		/// </param>
		protected virtual void OnPropertyChanged(
			PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Collections.ObjectModel.ObservableCollection`1.CollectionChanged" /> 
		/// event with the provided arguments.
		/// </summary>
		/// <param name="args">
		/// Arguments of the event being raised.
		/// </param>
		protected virtual void OnCollectionChangedBase(
			NotifyCollectionChangedEventArgs args)
		{
			if (CollectionChanged == null)
				return;

			using (BlockReentrancy())
			{
				CollectionChanged?.Invoke(this, args);
			}
		}
		/// <summary>
		/// Raises the <see cref="E:System.Collections.ObjectModel.ObservableCollection`1.CollectionChanged" /> 
		/// event with the provided arguments.
		/// </summary>
		/// <param name="args">
		/// Arguments of the event being raised.
		/// </param>
		protected virtual void OnCollectionChangedGeneric(
			NotifyCollectionChangedEventArgs<TValue> args)
		{
			OnCollectionChangedBase(args);
			if (CollectionChangedGeneric == null)
				return;

			using (BlockReentrancy())
			{
				CollectionChangedGeneric?.Invoke(this, args);
			}
		}

		/// <summary>
		/// Disallows reentrant attempts to change this collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.IDisposable" /> object that can be used to dispose of the object.
		/// </returns>
		protected IDisposable BlockReentrancy()
		{
			_monitor.Enter();
			return _monitor;
		}

		/// <summary>
		/// Checks for reentrant attempts to change this collection.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">
		/// If there was a call to 
		/// <see cref="M:System.Collections.ObjectModel.ObservableCollection`1.BlockReentrancy" /> 
		/// of which the <see cref="T:System.IDisposable" /> return value has not yet been disposed of.
		///  Typically, this means when there are additional attempts to change this collection during
		///  a <see cref="E:System.Collections.ObjectModel.ObservableCollection`1.CollectionChanged" /> 
		/// event. However, it depends on when derived classes choose to call 
		/// <see cref="M:System.Collections.ObjectModel.ObservableCollection`1.BlockReentrancy" />.
		/// </exception>
		protected void CheckReentrancy()
		{
			if (_monitor.Busy && CollectionChanged != null
			    && CollectionChanged.GetInvocationList().Length > 1)
				throw new InvalidOperationException(
					"Observable Collection Reentrancy Not Allowed");
		}

		private void OnPropertyChanged(
			string propertyName)
		{
			OnPropertyChanged(
				new PropertyChangedEventArgs(
					propertyName));
		}

		//private void OnCollectionChanged(
		//	NotifyCollectionChangedAction action,
		//	object item, 
		//	int index)
		//{
		//	OnCollectionChanged(
		//		new NotifyCollectionChangedEventArgs(
		//			action, 
		//			item,
		//			index));
		//}

		//private void OnCollectionChanged(
		//	NotifyCollectionChangedAction action, 
		//	object item,
		//	int index,
		//	int oldIndex)
		//{
		//	OnCollectionChanged(
		//		new NotifyCollectionChangedEventArgs(
		//			action,
		//			item, 
		//			index, 
		//			oldIndex));
		//}

		//private void OnCollectionChanged(
		//	NotifyCollectionChangedAction action, 
		//	object oldItem,
		//	object newItem, 
		//	int index)
		//{
		//	OnCollectionChanged(
		//		new NotifyCollectionChangedEventArgs(
		//			action, 
		//			newItem, 
		//			oldItem, 
		//			index));
		//}


		private void OnCollectionChangedGeneric(
			NotifyCollectionChangedAction action,
			TValue item,
			int index)
		{
			OnCollectionChangedGeneric(
				new NotifyCollectionChangedEventArgs<TValue>(
					action,
					item,
					index));
		}

		private void OnCollectionChangedGeneric(
			NotifyCollectionChangedAction action,
			TValue item,
			int index,
			int oldIndex)
		{
			OnCollectionChangedGeneric(
				new NotifyCollectionChangedEventArgs<TValue>(
					action,
					item,
					index,
					oldIndex));
		}

		private void OnCollectionChangedGeneric(
			NotifyCollectionChangedAction action,
			TValue oldItem,
			TValue newItem,
			int index)
		{
			OnCollectionChangedGeneric(
				new NotifyCollectionChangedEventArgs<TValue>(
					action,
					newItem,
					oldItem,
					index));
		}


		private void OnCollectionReset()
		{
			OnCollectionChangedGeneric(
				new NotifyCollectionChangedEventArgs<TValue>(
					NotifyCollectionChangedAction.Reset));
		}

		private class SimpleMonitor : IDisposable
		{
			private int _busyCount;

			public bool Busy
			{
				get => _busyCount > 0;
			}

			public void Enter()
			{
				_busyCount = _busyCount + 1;
			}

			public void Dispose()
			{
				_busyCount = _busyCount - 1;
			}
		}
	}
}
