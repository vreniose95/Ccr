using System;
using Ccr.Core.Extensions;
using JetBrains.Annotations;
using NUnit.Framework;
using static Ccr.Core.Tests._GenericTypes;

namespace Ccr.Core.Tests
{
  internal static class _GenericTypes
  {

    internal static Type _0Args = typeof(__0GenericArgs);

    [UsedImplicitly]
    internal class __0GenericArgs
      : __0Interface
    {
    }
    [UsedImplicitly]
    internal class __1GenericArgs<
      [UsedImplicitly] TArg1>
        : __0GenericArgs,
          __IArg1PropertyInterface<TArg1>
    {
      private TArg1 _arg1;

      public TArg1 Arg1
      {
        get => _arg1;
        set => _arg1 = value;
      }

      object __IArg1BasePropertyInterface.Arg1Base
      {
        get => Arg1;
        set
        {
          var val = value.As<TArg1>();
          Arg1 = val;
        }
      }

      public __1GenericArgs(
        TArg1 arg1)
      {
        _arg1 = arg1;
      }
      
    }
    [UsedImplicitly]
    internal class __2GenericArgs<
      [UsedImplicitly] TArg1,
      [UsedImplicitly] TArg2>
        : __1GenericArgs<TArg1>,
          __IArg2PropertyInterface<TArg2>
    {
      private TArg2 _arg2;

      public TArg2 Arg2
      {
        get => _arg2;
        set => _arg2 = value;
      }

      object __IArg2BasePropertyInterface.Arg2Base
      {
        get => Arg2;
        set
        {
          var val = value.As<TArg2>();
          Arg2 = val;
        }
      }

      public __2GenericArgs(
        TArg1 arg1,
        TArg2 arg2)
          : base(
            arg1)
      {
        _arg2 = arg2;
      }

    }
    [UsedImplicitly]
    internal class __3GenericArgs<
      [UsedImplicitly] TArg1,
      [UsedImplicitly] TArg2,
      [UsedImplicitly] TArg3>
      : __2GenericArgs<TArg1, TArg2>,
        __IArg3PropertyInterface<TArg3>
    {
      private TArg3 _arg3;

      public TArg3 Arg3
      {
        get => _arg3;
        set => _arg3 = value;
      }

      object __IArg3BasePropertyInterface.Arg3Base
      {
        get => Arg3;
        set
        {
          var val = value.As<TArg3>();
          Arg3 = val;
        }
      }

      public __3GenericArgs(
        TArg1 arg1,
        TArg2 arg2,
        TArg3 arg3)
          : base(
            arg1,
            arg2)
      {
        _arg3 = arg3;
      }
    }


    internal interface __0Interface
    {
      
    }
    internal interface __IArg1BasePropertyInterface
    {
      object Arg1Base { get; set; }
    }
    internal interface __IArg1PropertyInterface<TArg>
      : __IArg1BasePropertyInterface
    {
      TArg Arg1 { get; set; }
    }

    internal interface __IArg2BasePropertyInterface
    {
      object Arg2Base { get; set; }
    }
    internal interface __IArg2PropertyInterface<TArg>
      : __IArg2BasePropertyInterface
    {
      TArg Arg2 { get; set; }
    }

    internal interface __IArg3BasePropertyInterface
    {
      object Arg3Base { get; set; }
    }
    internal interface __IArg3PropertyInterface<TArg>
      : __IArg3BasePropertyInterface
    {
      TArg Arg3 { get; set; }
    }

  }
  [TestFixture]
  public class TypeExtensionsTests
  {
    [Test]
    public void can_identify_generic_type()
    {
      Assert.True(typeof(__1GenericArgs<byte>).IsGenericOf(typeof(__1GenericArgs<>)));

      Assert.True(typeof(__2GenericArgs<byte, string>).IsGenericOf(typeof(__2GenericArgs<,>)));

      Assert.True(typeof(__3GenericArgs<char, int, long>).IsGenericOf(typeof(__3GenericArgs<,,>)));


      Assert.True(typeof(__1GenericArgs<byte>).HasGenericArgs(typeof(byte)));

      Assert.True(typeof(__2GenericArgs<byte, string>).HasGenericArgs(typeof(byte), typeof(string)));

      Assert.True(typeof(__3GenericArgs<char, int, long>).HasGenericArgs(typeof(char), typeof(int), typeof(long)));



      Assert.True(typeof(__3GenericArgs<bool, float, decimal>).Implements<__0Interface>());

      Assert.True(typeof(__3GenericArgs<bool, float, decimal>).Implements<__IArg1BasePropertyInterface>());

      Assert.True(typeof(__3GenericArgs<bool, float, decimal>).Implements<__IArg1PropertyInterface<bool>>());
    }

  }
}
