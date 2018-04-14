using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Static;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using static System.Windows.FrameworkPropertyMetadataOptions;

namespace Ccr.MaterialDesign.Primitives
{
  public class MaterialDesign
  {
    private static readonly Type _type = typeof(MaterialDesign);


    public static readonly DependencyProperty SwatchProperty = DP.Attach(_type,
      new MetaBase<SwatchClassifier>(SwatchClassifier.Blue, onSwatchChanged));

    public static SwatchClassifier GetSwatch(DependencyObject i) => i.Get<SwatchClassifier>(SwatchProperty);
    public static void SetSwatch(DependencyObject i, SwatchClassifier v) => i.Set(SwatchProperty, v);



    public static readonly DependencyProperty ThemeProperty = DP.Attach(_type,
      new MetaBase<Swatch>(onThemeChanged, Inherits));

    public static Swatch GetTheme(DependencyObject i) => i.Get<Swatch>(ThemeProperty);
    public static void SetTheme(DependencyObject i, Swatch v) => i.Set(ThemeProperty, v);



    private static void onThemeChanged(
      DependencyObject @this,
      DPChangedEventArgs<Swatch> args)
    {
    }

    private static void onSwatchChanged(
      DependencyObject @this,
      DPChangedEventArgs<SwatchClassifier> args)
    {
      var swatch = GlobalResources
        .Palette
        .GetSwatch(
          args.NewValue);

      SetTheme(@this, swatch);
    }



    private static readonly Dictionary<MaterialIdentity, SolidColorBrush> _registeredIdentities
      = new Dictionary<MaterialIdentity, SolidColorBrush>();


    public static readonly DependencyProperty IdentityProperty = DP.Attach(
      _type, new MetaBase<MaterialIdentity>(null, onIdentityChanged));


    private static void onIdentityChanged(
      DependencyObject @this,
      DPChangedEventArgs<MaterialIdentity> args)
    {
      if (args.NewValue != null)
      {
        if (!_registeredIdentities.ContainsKey(args.NewValue))
          _registeredIdentities.Add(
            args.NewValue,
            @this.As<SolidColorBrush>());

      }
    }


    public static MaterialIdentity GetIdentity(
      DependencyObject @this)
    {
      return @this.Get<MaterialIdentity>(
        IdentityProperty);
    }

    public static void SetIdentity(
      DependencyObject @this,
      MaterialIdentity value)
    {
      @this.Set(
        IdentityProperty,
        value);
    }




    public static readonly DependencyProperty VisualFeedbackProperty = DP.Attach(
      _type, new MetaBase<Brush>(Brushes.Black.WithOpacity(.3)));

    public static Brush GetVisualFeedback(DependencyObject i) => i.Get<Brush>(VisualFeedbackProperty);
    public static void SetVisualFeedback(DependencyObject i, Brush v) => i.Set(VisualFeedbackProperty, v);
  }
}
