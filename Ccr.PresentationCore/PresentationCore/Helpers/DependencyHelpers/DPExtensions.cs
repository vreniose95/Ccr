using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ccr.Core.Extensions;

namespace Ccr.PresentationCore.Helpers.DependencyHelpers
{
  public static class DPExtensions
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DependencyProperty Add<TOwner, TValue>(
      this DependencyProperty @this,
      Meta<TOwner, TValue> meta,
      DPExtOptions options = DPExtOptions.None)
        where TOwner
          : DependencyObject
    {
      return @this.AddOwner(
        typeof(TOwner), 
        new FrameworkPropertyMetadata(
          options == DPExtOptions.ForceManualInherit 
            ? @this.DefaultMetadata.DefaultValue 
            : meta.DefaultValue, 
          meta.OptionFlags,
            (obj, args) =>
            {
              //return true;
              meta.PropertyChangedCallback.Invoke(
                obj.As<TOwner>(),
                new DPChangedEventArgs<TValue>(
                  args.Property.As<DependencyProperty>(),
                  args.NewValue.As<TValue>(),
                  args.NewValue.As<TValue>()));
            },
          (obj, baseValue) =>
          {
            return baseValue;
            meta.CoerceValueCallback(
              obj.As<TOwner>(),
              baseValue.As<TValue>());
          }));
    }
  
  }
}
