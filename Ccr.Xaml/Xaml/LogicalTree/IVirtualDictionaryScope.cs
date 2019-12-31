namespace Ccr.Xaml.LogicalTree
{
  public interface IVirtualDictionaryScope
  {
    
  }

  public interface IDictionaryLeaf
  {
    IVirtualDictionaryScope CurrentLeafScope { get; }
  }

  public interface ILeafedDictionary
  {
    
  }
}
