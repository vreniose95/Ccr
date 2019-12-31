using System;
using System.Collections.Generic;
using Ccr.Std.Core.Extensions;

namespace Ccr.Xaml.LogicalTree
{
	// ReSharper disable ConvertToAutoProperty
	// ReSharper disable ConvertPropertyToExpressionBody
	public delegate void ParentChangedHandler<TElement>(
		ITreeNode<TElement> instance,
		ITreeNodeBase parent)
			where TElement
				: ITreeNodeBase;

	public class TreeNode<TElement>
		: TreeNodeBase,
			ITreeNode<TElement>
				where TElement
					: ITreeNodeBase
	{
		/// <summary>
		///		Gets the <see cref="ITreeNodeBase.ParentBase"/> object as a <typeparamref name="TElement"/> object
		/// </summary>
		/// <exception cref="NullReferenceException">
		///		Throws when the <see cref="ITreeNodeBase.ParentBase"/> object is <see langword="null"/>
		/// </exception>
		/// <exception cref="InvalidCastException">
		///		Throws when the <see cref="ITreeNodeBase.ParentBase"/> object is not of type <typeparamref name="TElement"/>
		/// </exception>
		public TElement Parent
		{
			get
			{ 
				if (!_interface.HasParent)
					throw new NullReferenceException(
						$"The \'TreeNode<TElement>\' does not have a registered parent object.");

				if(!(_interface.ParentBase is TElement))
					throw new InvalidCastException(
						$"The \'TreeNode<TElement>\' has a parent of type {_interface.ParentBase.GetType().Name.SQuote()}, " +
						$"which is not valid. The parent object must be of type {typeof(TElement).Name.SQuote()}.");

				return _interface.ParentBase.As<TElement>();
			}
		}

		/// <summary>
		///		Registers the <paramref name="parent"/> parameter as this <see cref="TreeNode{TElement}"/>'s
		///		parent in the XAML logical tree.
		/// </summary>
		/// <param name="parent">
		///		The parent object in the XAML logical tree.
		/// </param>
		public void RegisterParent(TElement parent)
		{
			_interface.RegisterParentBase(parent);
		}

		/// <summary>
		///		Unegisters the <see cref="Parent"/> registered to this <see cref="TreeNode{TElement}"/> if one
		///		currently exists. If no parent is currently registered, the method has no effect.
		/// </summary>
		public void UnregisterParent()
		{
			_interface.UnregisterParentBase();
		}


		/// <summary>
		///		Internally called when a parent node removes the instance of this <see cref="TreeNode{TElement}"/> 
		///		instance by calling the <see cref="UnregisterParent"/> method. This method destructs the
		///		subscriber map, unsubscribing the <see cref="ParentChangedBaseHandler"/> hooks.
		/// </summary>
		protected internal sealed override void OnUnregistered()
		{
			_destructSubscriberMap();
		}


		private readonly Dictionary<ParentChangedHandler<TElement>, ParentChangedBaseHandler>
			_subscriberMap = new Dictionary<ParentChangedHandler<TElement>, ParentChangedBaseHandler>();

		/// <summary>
		///		A managed auto-upcasting generic version of the <see cref="ITreeNodeBase.ParentChangedBase"/> event.
		/// </summary>
		public event ParentChangedHandler<TElement> ParentChanged
		{
			add
			{
				lock (@lock)
				{
					var invoker = new ParentChangedBaseHandler(
						(instance, parent) =>
						{
							value.Invoke(
								(ITreeNode<TElement>)instance,
								(TElement)parent);
						});
					_subscriberMap.Add(value, invoker);

					_interface.ParentChangedBase += invoker;
				}
			}
			remove
			{
				lock (@lock)
				{
					if (!_subscriberMap.TryGetValue(value, out ParentChangedBaseHandler invoker))
						throw new KeyNotFoundException(
							"Cannot find the associated mapping to the non-generic delegate to perform the " +
							"unsubscribe event call for the \'ITreeNodeBase.ParentChangedBase\' event.");

					_interface.ParentChangedBase -= invoker;
				}
			}
		}
		
		/// <summary>
		///		Unsubscribes both the derived generic <see cref="ParentChangedHandler{TElement}"/> callbacks as
		///		well as the base non-generic <see cref="ParentChangedBaseHandler"/> callbacks from the parent 
		///		requesting the unregistration, then destructs the mapping dictionary and Clears the contents.
		/// </summary>
		private void _destructSubscriberMap()
		{
			lock (@lock)
			{
				foreach (var subscriberPair in _subscriberMap)
				{
					ParentChanged -= subscriberPair.Key;
					_interface.ParentChangedBase -= subscriberPair.Value;
				}
				_subscriberMap.Clear();
			}
		}
	}
}
