using System;

namespace Ccr.Algorithms.Collections
{
  [AttributeUsage(AttributeTargets.Property)]
  public class SequentialSetValueAttribute
    : Attribute
  {
    public int Index { get; }

    public SequentialSetValueAttribute(
      int index)
    {
      Index = index;
    }
  }
}