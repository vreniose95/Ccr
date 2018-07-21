using System.Windows;
using System.Windows.Media;
using Ccr.MaterialDesign;
using Ccr.MaterialDesign.Primitives.Behaviors;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
  public static class SolidColorBrushExtensions
  {
    [CanBeNull]
    public static MaterialIdentity GetIdentity(
      [NotNull] this SolidColorBrush @this)
    {
      @this.IsNotNull(nameof(@this));

      var boxedValue = @this.GetValue(MDH.IdentityProperty);
      var identity = boxedValue as MaterialIdentity;

      if (boxedValue == null
          || boxedValue == DependencyProperty.UnsetValue
          || identity == null)
      {
        return null;
      }

      return identity;
    }

    [CanBeNull]
    public static SolidColorBrush SetIdentity(
      [NotNull] this SolidColorBrush @this,
      [CanBeNull] MaterialIdentity materialIdentity)
    {
      @this.IsNotNull(nameof(@this));

      if ((@this.CanFreeze && @this.IsFrozen) || @this.IsSealed)
      {
        //@this.Changed += (s, args) =>
        //{

        //};
        var cloned = @this.Clone();

        cloned.SetValue(
          MDH.IdentityProperty,
          materialIdentity);

        cloned.Freeze();

        return cloned;
      }
      else
      {
        //@this.Changed += (s, args) =>
        //{

        //};

        var existingIdentity = @this.GetIdentity();
        if (existingIdentity != null)
        {
          if (!existingIdentity.Equals(materialIdentity))
          {

          }
        }
        @this.SetValue(
          MDH.IdentityProperty,
          materialIdentity);

        if (@this.CanFreeze)
        {
          @this.Freeze();
        }

        return @this;
      }
    }
  }
}