namespace Ccr.Xaml.LogicalTree
{
	public interface ITreeNodeBase
	{
		bool HasParent { get; }

		ITreeNodeBase ParentBase { get; }

		event ParentChangedBaseHandler ParentChangedBase;

		void RegisterParentBase(ITreeNodeBase parent);

		void UnregisterParentBase();
	}
}
