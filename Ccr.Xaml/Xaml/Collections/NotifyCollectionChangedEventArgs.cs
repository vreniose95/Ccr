using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Ccr.Core.Extensions;
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter
// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.Xaml.Collections
{
	public class NotifyCollectionChangedEventArgs<TValue>
		: EventArgs
	{
		private int _newStartingIndex = -1;
		private int _oldStartingIndex = -1;
		private NotifyCollectionChangedAction _action;
		private IList<TValue> _newItems;
		private IList<TValue> _oldItems;

		/// <summary>Gets the action that caused the event. </summary>
		/// <returns>A <see cref="T:System.Collections.Specialized.NotifyCollectionChangedAction" /> value that describes the action that caused the event.</returns>
		public NotifyCollectionChangedAction Action
		{
			get
			{
				return _action;
			}
		}

		/// <summary>Gets the list of new items involved in the change.</summary>
		/// <returns>The list of new items involved in the change.</returns>
		public IList<TValue> NewItems
		{
			get
			{
				return _newItems;
			}
		}

		/// <summary>Gets the list of items affected by a <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" />, Remove, or Move action.</summary>
		/// <returns>The list of items affected by a <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" />, Remove, or Move action.</returns>
		public IList<TValue> OldItems
		{
			get
			{
				return _oldItems;
			}
		}

		/// <summary>Gets the index at which the change occurred.</summary>
		/// <returns>The zero-based index at which the change occurred.</returns>
		public int NewStartingIndex
		{
			get
			{
				return _newStartingIndex;
			}
		}

		/// <summary>Gets the index at which a <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Move" />, Remove, or Replace action occurred.</summary>
		/// <returns>The zero-based index at which a <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Move" />, Remove, or Replace action occurred.</returns>
		public int OldStartingIndex
		{
			get
			{
				return _oldStartingIndex;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Reset" /> change.</summary>
		/// <param name="action">The action that caused the event. This must be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Reset" />.</param>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action)
		{
			if (action != NotifyCollectionChangedAction.Reset)
				throw new ArgumentException(
					"Wrong Action For Ctor (Reset)",
					nameof(action));

			InitializeAdd(action, null, -1);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a one-item change.</summary>
		/// <param name="action">The action that caused the event. This can be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Reset" />, <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Add" />, or <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Remove" />.</param>
		/// <param name="changedItem">The item that is affected by the change.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Reset, Add, or Remove, or if <paramref name="action" /> is Reset and <paramref name="changedItem" /> is not null.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			TValue changedItem)
		{
			if (action != NotifyCollectionChangedAction.Add
					&& action != NotifyCollectionChangedAction.Remove
					&& action != NotifyCollectionChangedAction.Reset)
				throw new ArgumentException(
					"Must Be Reset Add Or Remove Action For Ctor",
					nameof(action));

			if (action == NotifyCollectionChangedAction.Reset)
			{
				if (changedItem != null)
					throw new ArgumentException(
						"ResetActionRequiresNullItem",
						nameof(action));

				InitializeAdd(action, null, -1);
			}
			else
				InitializeAddOrRemove(action, new[]
				{
					changedItem
				}, -1);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a one-item change.</summary>
		/// <param name="action">The action that caused the event. This can be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Reset" />, <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Add" />, or <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Remove" />.</param>
		/// <param name="changedItem">The item that is affected by the change.</param>
		/// <param name="index">The index where the change occurred.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Reset, Add, or Remove, or if <paramref name="action" /> is Reset and either <paramref name="changedItems" /> is not null or <paramref name="index" /> is not -1.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			TValue changedItem,
			int index)
		{
			if (action != NotifyCollectionChangedAction.Add
					&& action != NotifyCollectionChangedAction.Remove
					&& action != NotifyCollectionChangedAction.Reset)
				throw new ArgumentException(
					"Must Be Reset Add Or Remove Action For Ctor",
					nameof(action));

			if (action == NotifyCollectionChangedAction.Reset)
			{
				if (changedItem != null)
					throw new ArgumentException(
						"Reset Action Requires Null Item",
						nameof(action));

				if (index != -1)
					throw new ArgumentException(
						"Reset Action Requires Index Minus 1",
						nameof(action));

				InitializeAdd(action, null, -1);
			}
			else
				InitializeAddOrRemove(action, new[]
				{
					changedItem
				}, index);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a multi-item change.</summary>
		/// <param name="action">The action that caused the event. This can be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Reset" />, <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Add" />, or <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Remove" />.</param>
		/// <param name="changedItems">The items that are affected by the change.</param>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			IList<TValue> changedItems)
		{
			if (action != NotifyCollectionChangedAction.Add
					&& action != NotifyCollectionChangedAction.Remove
					&& action != NotifyCollectionChangedAction.Reset)
				throw new ArgumentException(
					"Must Be Reset Add Or Remove Action For Ctor",
					nameof(action));
			if (action == NotifyCollectionChangedAction.Reset)
			{
				if (changedItems != null)
					throw new ArgumentException(
						"Reset Action Requires Null Item",
						nameof(action));

				InitializeAdd(action, null, -1);
			}
			else
			{
				if (changedItems == null)
					throw new ArgumentNullException(nameof(changedItems));

				InitializeAddOrRemove(action, changedItems, -1);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a multi-item change or a <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Reset" /> change.</summary>
		/// <param name="action">The action that caused the event. This can be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Reset" />, <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Add" />, or <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Remove" />.</param>
		/// <param name="changedItems">The items affected by the change.</param>
		/// <param name="startingIndex">The index where the change occurred.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Reset, Add, or Remove, if <paramref name="action" /> is Reset and either <paramref name="changedItems" /> is not null or <paramref name="startingIndex" /> is not -1, or if action is Add or Remove and <paramref name="startingIndex" /> is less than -1.</exception>
		/// <exception cref="T:System.ArgumentNullException">If <paramref name="action" /> is Add or Remove and <paramref name="changedItems" /> is null.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			IList<TValue> changedItems,
			int startingIndex)
		{
			if (action != NotifyCollectionChangedAction.Add
					&& action != NotifyCollectionChangedAction.Remove
					&& action != NotifyCollectionChangedAction.Reset)
				throw new ArgumentException(
					"Must Be Reset Add Or Remove Action For Ctor",
					nameof(action));

			if (action == NotifyCollectionChangedAction.Reset)
			{
				if (changedItems != null)
					throw new ArgumentException(
						"Reset Action Requires Null Item",
						nameof(action));

				if (startingIndex != -1)
					throw new ArgumentException(
						"Reset Action Requires Index Minus 1",
						nameof(action));

				InitializeAdd(action, null, -1);
			}
			else
			{
				if (changedItems == null)
					throw new ArgumentNullException(
						nameof(changedItems));

				if (startingIndex < -1)
					throw new ArgumentException(
						"Index Cannot Be Negative",
						nameof(startingIndex));

				this.InitializeAddOrRemove(
					action,
					changedItems,
					startingIndex);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a one-item <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" /> change.</summary>
		/// <param name="action">The action that caused the event. This can only be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" />.</param>
		/// <param name="newItem">The new item that is replacing the original item.</param>
		/// <param name="oldItem">The original item that is replaced.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Replace.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			TValue newItem,
			TValue oldItem)
		{
			if (action != NotifyCollectionChangedAction.Replace)
				throw new ArgumentException(
					"Wrong Action For Ctor (Replace)",
					nameof(action));

			InitializeMoveOrReplace(action, new[]
			{
				newItem
			}, new[]
			{
				oldItem
			}, -1, -1);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a one-item <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" /> change.</summary>
		/// <param name="action">The action that caused the event. This can be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" />.</param>
		/// <param name="newItem">The new item that is replacing the original item.</param>
		/// <param name="oldItem">The original item that is replaced.</param>
		/// <param name="index">The index of the item being replaced.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Replace.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			TValue newItem,
			TValue oldItem,
			int index)
		{
			if (action != NotifyCollectionChangedAction.Replace)
				throw new ArgumentException(
					"Wrong Action For Ctor (Replace)",
					nameof(action));

			int oldStartingIndex = index;
			InitializeMoveOrReplace(action, new[]
			{
				newItem
			}, new[]
			{
				oldItem
			}, index, oldStartingIndex);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a multi-item <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" /> change.</summary>
		/// <param name="action">The action that caused the event. This can only be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" />.</param>
		/// <param name="newItems">The new items that are replacing the original items.</param>
		/// <param name="oldItems">The original items that are replaced.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Replace.</exception>
		/// <exception cref="T:System.ArgumentNullException">If <paramref name="oldItems" /> or <paramref name="newItems" /> is null.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			IList<TValue> newItems,
			IList<TValue> oldItems)
		{
			if (action != NotifyCollectionChangedAction.Replace)
				throw new ArgumentException(
					"Wrong Action For Ctor (Replace)",
					nameof(action));

			newItems.IsNotNull(nameof(newItems));
			oldItems.IsNotNull(nameof(oldItems));

			InitializeMoveOrReplace(
				action,
				newItems,
				oldItems,
				-1,
				-1);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a multi-item <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" /> change.</summary>
		/// <param name="action">The action that caused the event. This can only be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Replace" />.</param>
		/// <param name="newItems">The new items that are replacing the original items.</param>
		/// <param name="oldItems">The original items that are replaced.</param>
		/// <param name="startingIndex">The index of the first item of the items that are being replaced.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Replace.</exception>
		/// <exception cref="T:System.ArgumentNullException">If <paramref name="oldItems" /> or <paramref name="newItems" /> is null.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			IList<TValue> newItems,
			IList<TValue> oldItems,
			int startingIndex)
		{
			if (action != NotifyCollectionChangedAction.Replace)
				throw new ArgumentException(
					"Wrong Action For Ctor (Replace)",
					nameof(action));

			newItems.IsNotNull(nameof(newItems));
			oldItems.IsNotNull(nameof(oldItems));

			InitializeMoveOrReplace(
				action,
				newItems,
				oldItems,
				startingIndex,
				startingIndex);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a one-item <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Move" /> change.</summary>
		/// <param name="action">The action that caused the event. This can only be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Move" />.</param>
		/// <param name="changedItem">The item affected by the change.</param>
		/// <param name="index">The new index for the changed item.</param>
		/// <param name="oldIndex">The old index for the changed item.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Move or <paramref name="index" /> is less than 0.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			TValue changedItem,
			int index,
			int oldIndex)
		{
			if (action != NotifyCollectionChangedAction.Move)
				throw new ArgumentException(
					"Wrong Action For Ctor (Move)",
					nameof(action));

			if (index < 0)
				throw new ArgumentException(
					"Index Cannot Be Negative",
					nameof(index));

			var objArray = new[] { changedItem };

			InitializeMoveOrReplace(
				action,
				objArray,
				objArray,
				index,
				oldIndex);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> class that describes a multi-item <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Move" /> change.</summary>
		/// <param name="action">The action that caused the event. This can only be set to <see cref="F:System.Collections.Specialized.NotifyCollectionChangedAction.Move" />.</param>
		/// <param name="changedItems">The items affected by the change.</param>
		/// <param name="index">The new index for the changed items.</param>
		/// <param name="oldIndex">The old index for the changed items.</param>
		/// <exception cref="T:System.ArgumentException">If <paramref name="action" /> is not Move or <paramref name="index" /> is less than 0.</exception>
		public NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			IList<TValue> changedItems,
			int index,
			int oldIndex)
		{
			if (action != NotifyCollectionChangedAction.Move)
				throw new ArgumentException(
					"Wrong Action For Ctor (Move)",
					nameof(action));

			if (index < 0)
				throw new ArgumentException(
					"Index Cannot Be Negative",
					nameof(index));

			InitializeMoveOrReplace(
				action,
				changedItems,
				changedItems,
				index,
				oldIndex);
		}

		internal NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedAction action,
			IList<TValue> newItems,
			IList<TValue> oldItems,
			int newIndex,
			int oldIndex)
		{
			_action = action;
			_newItems = newItems;

			_oldItems = oldItems;
			_newStartingIndex = newIndex;
			_oldStartingIndex = oldIndex;
		}

		#region Operators
		public static implicit operator NotifyCollectionChangedEventArgs(
			NotifyCollectionChangedEventArgs<TValue> @this)
		{
			switch (@this.Action)
			{
				case NotifyCollectionChangedAction.Add:
					return new NotifyCollectionChangedEventArgs(
						@this.Action,
						@this.NewItems as IList,
						@this.NewStartingIndex);
				case NotifyCollectionChangedAction.Replace:
					return new NotifyCollectionChangedEventArgs(
						@this.Action,
						@this.NewItems,
						@this.OldItems);
				default:
					throw new InvalidEnumArgumentException();
			}
			
		}

		public static implicit operator NotifyCollectionChangedEventArgs<TValue>(
			NotifyCollectionChangedEventArgs @this)
		{
			return new NotifyCollectionChangedEventArgs<TValue>(
				@this.Action,
				@this.NewItems.Cast<TValue>().ToArray(),
				@this.OldItems.Cast<TValue>().ToArray());
		}

		#endregion

		#region Methods
		private void InitializeAddOrRemove(
			NotifyCollectionChangedAction action,
			IList<TValue> changedItems,
			int startingIndex)
		{
			if (action == NotifyCollectionChangedAction.Add)
			{
				InitializeAdd(action, changedItems, startingIndex);
			}
			else
			{
				if (action != NotifyCollectionChangedAction.Remove)
					return;

				InitializeRemove(action, changedItems, startingIndex);
			}
		}

		private void InitializeAdd(
			NotifyCollectionChangedAction action,
			IList<TValue> newItems,
			int newStartingIndex)
		{
			_action = action;
			_newItems = newItems;
			_newStartingIndex = newStartingIndex;
		}

		private void InitializeRemove(
			NotifyCollectionChangedAction action,
			IList<TValue> oldItems,
			int oldStartingIndex)
		{
			_action = action;
			_oldItems = oldItems;
			_oldStartingIndex = oldStartingIndex;
		}

		private void InitializeMoveOrReplace(
			NotifyCollectionChangedAction action,
			IList<TValue> newItems,
			IList<TValue> oldItems,
			int startingIndex,
			int oldStartingIndex)
		{
			InitializeAdd(
				action,
				newItems,
				startingIndex);

			InitializeRemove(
				action,
				oldItems,
				oldStartingIndex);
		}

		#endregion
	}
}