using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ccr.Xaml.Collections;

namespace Ccr.MaterialDesign.DesignTime.Infrastructure
{
  public interface ISwatch
  {
    
  }
  public interface IPalette
    : IList<ISwatch>
  {
    //IReactiveCollection<>
  }
}
