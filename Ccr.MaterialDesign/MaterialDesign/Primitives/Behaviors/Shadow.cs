using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
  public static class Shadow
  {
    private static IDictionary<double, DropShadowEffect> _cacheMap
      = new Dictionary<double, DropShadowEffect>();


    internal static class ShadowInterpolator
    {
      private const double opacity = .42;
      private static readonly Color shadowColor = Colors.Black;

   
      public static DropShadowEffect Interpolate(
        double level)
      {
        var blur = calculateBlur(level);
        var depth = calculateDepth(level);

        return new DropShadowEffect
        {
          BlurRadius = blur,
          ShadowDepth = depth,
          Direction = 270,
          Color = shadowColor,
          Opacity = opacity
        };
      }

      private static double calculateDepth(
        double x)
      {
        const double a = .124;
        const double b = -1.5833333333;
        const double c = 7.625;
        const double d = -13.166666667;
        const double e = 8;

        return a * x.Power(4) + b * x.Power(3) + c * x.Power(2) + d * x + e;
      }

      private static double calculateBlur(
        double x)
      {
        const double a = -.333333333;
        const double b = 4.357142857;
        const double c = -8.30952381;
        const double d = 9.4;

        return a * x.Power(3) + b * x.Power(2) + c * x + d;
      }

    }
    private static readonly Type _type = typeof(Shadow);

    public static readonly DependencyProperty LevelProperty = DP.Attach(
      _type, new MetaBase<double?>(null, onShadowLevelChanged));


    public static double GetLevel(DependencyObject i) => i.Get<double>(LevelProperty);
    public static void SetLevel(DependencyObject i, double v) => i.Set(LevelProperty, v);


    public static readonly DependencyProperty ShadowCacheModeProperty = DP.Attach(
      typeof(Shadow),
      new MetaBase<CacheMode>(
        new BitmapCache
        {
          EnableClearType = false,
          RenderAtScale = 1,
          SnapsToDevicePixels = false
        }, FrameworkPropertyMetadataOptions.Inherits));


    public static CacheMode GetShadowCacheModeProperty(DependencyObject i
      ) => i.Get<CacheMode>(LevelProperty);

    public static void SetShadowCacheModeProperty(DependencyObject i, CacheMode v) 
      => i.Set(LevelProperty, v);



    //private static bool shadowLevelPropertyValidator(
    //  double? value)
    //{
    //  if (!value.HasValue)
    //    return true;

    //  return value.Value >= 0;
    //}

    private static void onShadowLevelChanged(
      DependencyObject @this,
      DPChangedEventArgs<double?> args)
    {
      if (@this is UIElement uiElement)
      {
        if (args.NewValue >= 0)
        {
          var shadow = getDropShadowEffect(args.NewValue.Value);//ShadowInterpolator.Interpolate(args.NewValue.Value);
          uiElement.Effect = shadow;
        }
        else
        {
          uiElement.Effect = null;
        }
      }
    }

    private static DropShadowEffect getDropShadowEffect(
      double shadowLevel)
    {
      if (_cacheMap.TryGetValue(
        shadowLevel, 
        out var dropShadowEffect))
        return dropShadowEffect;

      dropShadowEffect = ShadowInterpolator
        .Interpolate(shadowLevel);

      _cacheMap.Add(
        shadowLevel,
        dropShadowEffect);

      return dropShadowEffect;
    }
  }
}
