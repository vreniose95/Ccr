using System;
using Ccr.Std.Core.Extensions;

namespace Ccr.Xaml.LogicalTree
{
	// ReSharper disable ConvertToAutoProperty
	// ReSharper disable ConvertPropertyToExpressionBody
	public delegate void ParentChangedBaseHandler(
		ITreeNodeBase instance,
		ITreeNodeBase parent);

	public abstract class TreeNodeBase
		: ITreeNodeBase
	{
		/// <summary>
		///		Holds a reference to the instance to the parent <see cref="ITreeNodeBase"/> in the
		///		XAML logical tree.
		/// </summary>
		protected ITreeNodeBase _parentBase;

		/// <summary>
		///		A lock object for use in explicitly implemented interface events.
		/// </summary>
		protected readonly object @lock = new object();

		/// <summary>
		///		Gets the current instance of the <see cref="TreeNode{TElement}"/>	object as 
		///		an <see cref="ITreeNodeBase"/> interface to fluently access explicitly 
		///		implemented non-generic interface members.
		/// </summary>
		protected ITreeNodeBase _interface => this;


		/// <summary>
		///		Checks if the <see cref="ITreeNodeBase.ParentBase"/> has been set through the 
		///		<see cref="ITreeNodeBase.RegisterParentBase"/> method.
		/// </summary>
		bool ITreeNodeBase.HasParent
		{
			get => _parentBase != null;
		}

		/// <summary>
		///		Holds an instance to the parent <see cref="ITreeNodeBase"/> in the XAML logical tree.
		/// </summary>
		ITreeNodeBase ITreeNodeBase.ParentBase
		{
			get => _parentBase;
		}

		private event ParentChangedBaseHandler _parentChangedBaseImpl;

		/// <summary>
		///		Explicit implementation of <see cref="ITreeNodeBase.ParentChangedBase"/> event.
		/// </summary>
		event ParentChangedBaseHandler ITreeNodeBase.ParentChangedBase
		{
			add
			{
				lock (@lock) { _parentChangedBaseImpl += value; }
			}
			remove
			{
				lock (@lock) { _parentChangedBaseImpl -= value; }
			}
		}

		/// <summary>
		///		Registers the <paramref name="parent"/> object as this <see cref="TreeNodeBase"/>'s
		///		parent in the XAML logical tree. 
		/// </summary>
		/// <param name="parent">
		///		The parent <see cref="ITreeNodeBase"/> to register as this <see cref="TreeNodeBase"/>'s 
		///		logical parent.
		/// </param>
		/// <exception cref="InvalidOperationException">
		///		Thrown when a parent object registration is attempted when another object is already
		///		registered as the <see cref="TreeNodeBase"/>'s logical parent.
		/// </exception>
		/// <event cref="_parentChangedBaseImpl">
		///		This event is raised when a parent object is registered as the logical parent.
		/// </event>
		void ITreeNodeBase.RegisterParentBase(ITreeNodeBase parent)
		{
			if (ReferenceEquals(parent, _interface.ParentBase))
				return;

			if (_interface.HasParent)
				throw new InvalidOperationException(
					$"{nameof(TreeNodeBase).SQuote()} cannot host multiple parent objects at once.")
				{
					Data = {
						["FailedParentRegistration"] = parent,
						["ExistingParentObject"] = _interface.ParentBase
					}
				};
			_parentBase = parent;
			_parentChangedBaseImpl?.Invoke(this, _parentBase);
			OnRegistered(_parentBase);
		}

		/// <summary>
		///		Detatches the <see cref="ITreeNodeBase.ParentBase"/> parent, if any is attached
		/// </summary>
		/// <event cref="_parentChangedBaseImpl">
		///		This event is raised when the parent object is successfully removed.
		/// </event>
		void ITreeNodeBase.UnregisterParentBase()
		{
			if (!_interface.HasParent)
				return;

			OnUnregistering(_interface.ParentBase);
			_parentChangedBaseImpl?.Invoke(this, _parentBase);
			_parentBase = null;
			_parentChangedBaseImpl = null;
			OnUnregistered();
		}

		/// <summary>
		///		This method is called when a parent object is successfully registered.
		/// </summary>
		protected virtual void OnRegistered(object parent) { }

		/// <summary>
		///		This method is called just prior to a parent being unregistered.
		/// </summary>
		protected virtual void OnUnregistering(object parent) { }

		/// <summary>
		///		This method is called directly after a parent object is successfully unregistered
		/// </summary>
		protected internal abstract void OnUnregistered();

		#region IGNORE
		/*
		internal static TreeNodeBase CreateServiceImplementation()
		{
			return new TreeNodeBaseImpl();
		}
		
		private sealed class TreeNodeBaseImpl
			: TreeNodeBase
		{

		}*/
		#endregion
	}
}
