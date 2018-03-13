using System;
using System.Windows;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.Core.Numerics.Ranges;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Controls.Icons
{
  public class Icon
    : IconBase<IconKind>
  {
    public static readonly DependencyProperty FlipProperty = DP.Register(
      new Meta<Icon, IconFlip>(IconFlip.None));

    public static readonly DependencyProperty RotationProperty = DP.Register(
        new Meta<Icon, double>(0, null, coerceRotationProperty));


    public IconFlip Flip
    {
      get => (IconFlip)GetValue(FlipProperty);
      set => SetValue(FlipProperty, value);
    }
    public double Rotation
    {
      get => (double)GetValue(RotationProperty);
      set => SetValue(RotationProperty, value);
    }



    static Icon()
    {
      ControlExtensions.OverrideStyleKey<Icon>();
      OpacityProperty.OverrideMetadata(
        typeof(Icon),
        new UIPropertyMetadata(1.0,
          onOpacityChangedCallback));
    }


    private static double coerceRotationProperty(
      Icon @this,
      double baseValue)
    {
      return baseValue.Constrain(new DoubleRange(0d, 360d));
      //TODO
      /*eturn baseValue.Constrain((0d, 360d));*/
    }

    private static void onOpacityChangedCallback(
      DependencyObject @this,
      DependencyPropertyChangedEventArgs args)
    {
      throw new NotImplementedException();
    }


    public Icon() : base(
          () => IconDataFactory.Create)
    {
    }
  }
}
