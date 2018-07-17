using System;
using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Markup.Extensions
{
  //public static class XMDH
  //{
  //  private static readonly Type _type = typeof(XMDH);
    
    
  //  public static readonly DependencyProperty SetProperty = DP.Attach(_type,
  //    new MetaBase<SwatchClassifier>(
  //      SwatchClassifier.Teal,
  //      onSetPropertyChangeCallback));


  //  public static readonly DependencyProperty SwatchProperty = DP.Attach(_type,
  //    new MetaBase<Swatch>(
  //      (Swatch)null,
  //      FrameworkPropertyMetadataOptions.Inherits));


  //  public static SwatchClassifier GetSet(
  //    DependencyObject @this)
  //  {
  //    return @this.Get<SwatchClassifier>(SetProperty);
  //  }
  //  public static void SetSet(
  //    DependencyObject @this, 
  //    SwatchClassifier value)
  //  {
  //    @this.Set(SetProperty, value);
  //  }

  //  public static Swatch GetSwatch(
  //    DependencyObject @this)
  //  {
  //    return @this.Get<Swatch>(SwatchProperty);
  //  }
  //  public static void SetSwatch(
  //    DependencyObject @this,
  //    Swatch value)
  //  {
  //    @this.Set(SwatchProperty, value);
  //  }


  //  //private static bool onSetPropertyValidateCallback(
  //  //  SwatchClassifier value)
  //  //{
  //  //  return Enum.IsDefined(typeof(SwatchClassifier), value);
  //  //}
  //  private static void onSetPropertyChangeCallback(
  //    DependencyObject @this,
  //    DPChangedEventArgs<SwatchClassifier> args)
  //  {
  //    var swatch = Static
  //      .GlobalResources
  //      .Palette
  //      .GetSwatch(
  //        args.NewValue);

  //    SetSwatch(@this, swatch);
  //  }
  //}
}
