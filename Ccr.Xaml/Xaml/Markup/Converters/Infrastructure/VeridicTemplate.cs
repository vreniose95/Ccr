using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccr.Xaml.Markup.Converters.Infrastructure
{
  public class VeridicBinding<TValue>
   : IReadOnlyList<TValue>
  {
    public IEnumerator<TValue> GetEnumerator()
    {
      throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public int Count => throw new NotImplementedException();
    public TValue this[int index] => throw new NotImplementedException();
  }
}
