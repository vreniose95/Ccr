using System;
using Ccr.Xaml.Collections;

namespace Ccr.Xaml.LogicalTree.Propogation.Collections
{
  public class TreeNodeCollectionBase
    : ReactiveCollection<ITreeNodeBase>,
      ITreeNodeBase
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

    public bool HasParent
    {
      get => _parentBase != null;
    }

    public ITreeNodeBase ParentBase
    {
      get => _parentBase;
    }


    public event ParentChangedBaseHandler ParentChangedBase;

    public void RegisterParentBase(ITreeNodeBase parent)
    {
      throw new NotImplementedException();
    }

    public void UnregisterParentBase()
    {
      throw new NotImplementedException();
    }
  }
}
