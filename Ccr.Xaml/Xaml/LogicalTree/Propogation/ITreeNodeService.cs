namespace Ccr.Xaml.LogicalTree
{
	public interface ITreeNodeService<TElement> 
		where TElement
			: ITreeNodeBase
	{
		TreeNode<TElement> TreeNode { get; } 
	}
}
