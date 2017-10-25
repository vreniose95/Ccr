using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
