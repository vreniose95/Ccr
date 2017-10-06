namespace Ccr.Xaml.LogicalTree
{
	public interface ITreeNode<TElement>
		: ITreeNodeBase
			where TElement
				: ITreeNodeBase
	{
		TElement Parent { get; }

		event ParentChangedHandler<TElement> ParentChanged;

		void RegisterParent(TElement parent);

		void UnregisterParent();
	}
}
