using System;
using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
  public static class IconAssist
  {
    private static readonly Type _type = typeof(IconAssist);


    public static readonly DependencyProperty ScaleProperty = DP.Attach(
      _type, new MetaBase<double>(1d));

    public static readonly DependencyProperty RotationProperty = DP.Attach(
      _type, new MetaBase<double>(0d));



    public static double GetScale(DependencyObject @this)
    {
      return @this.Get<double>(ScaleProperty);
    }
    public static void SetScale(DependencyObject @this, double value)
    {
      @this.Set(ScaleProperty, value);
    }

    public static double GetRotation(DependencyObject @this)
    {
      return @this.Get<double>(RotationProperty);
    }
    public static void SetRotation(DependencyObject @this, double value)
    {
      @this.Set(RotationProperty, value);
    }

  }
}
