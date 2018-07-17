using System;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Std.Core.TypeSystemInfo
{
  internal abstract class BuiltInTypeBuilder
  {
    protected const string minValueFieldName = "MinValue";

    protected const string maxValueFieldName = "MaxValue";


    protected internal abstract BuiltInTypeInfo BuildBase(
      [NotNull] Type systemType);
  }

  internal abstract class BuiltInTypeBuilder<TTypeInfo>
    : BuiltInTypeBuilder
      where TTypeInfo
        : BuiltInTypeInfo
  {
    internal TTypeInfo Build<TSystemType>()
      where TSystemType
        : struct
    {
      return BuildBase(
        typeof(TSystemType))
          .As<TTypeInfo>();
    }
    protected abstract TTypeInfo BuildImpl<TSystemType>();
  }
}
