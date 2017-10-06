namespace Ccr.Xaml.LogicalTree.Propogation
{
	public interface ITreeNodeService<TElement> 
		where TElement
			: ITreeNodeBase
	{
		TreeNode<TElement> TreeNode { get; } 
	}
}
