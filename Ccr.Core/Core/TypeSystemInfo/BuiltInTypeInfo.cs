using System;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Core.TypeSystemInfo
{
  public abstract class BuiltInTypeInfo
  {
    [NotNull]
    public Type SystemType { get; }


    protected BuiltInTypeInfo(
      [NotNull] Type systemType)
    {
      systemType.IsNotNull(nameof(systemType));
      SystemType = systemType;
    }
  }
}
