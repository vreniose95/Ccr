using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Infrastructure.Descriptors;
using Ccr.MaterialDesign.Static;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using static System.Windows.FrameworkPropertyMetadataOptions;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
  public static class MDH
  {
    private static readonly Type _type = typeof(MDH);


    private static readonly Dictionary<MaterialIdentity, SolidColorBrush> _registeredIdentities
      = new Dictionary<MaterialIdentity, SolidColorBrush>();
		
    public static readonly DependencyProperty SwatchProperty = DP.Attach(
      _type, new MetaBase<SwatchClassifier>(SwatchClassifier.Blue, onSwatchChanged));

		public static readonly DependencyProperty ThemeProperty = DP.Attach(
      _type, new MetaBase<Swatch>(onThemeChanged, Inherits));

    public static readonly DependencyProperty IdentityProperty = DP.Attach(
      _type, new MetaBase<MaterialIdentity>(null, onIdentityChanged));

    public static readonly DependencyProperty VisualFeedbackProperty = DP.Attach(
      _type, new MetaBase<Brush>(Brushes.Black));//.WithOpacity(.3)));

	  public static readonly DependencyProperty VisualFeedbackDescriptorProperty = DP.Attach(
		  _type, new MetaBase<IMaterialDescriptor>());
		


		
    public static SwatchClassifier GetSwatch(DependencyObject @this)
    {
      return @this.Get<SwatchClassifier>(SwatchProperty);
    }
    public static void SetSwatch(DependencyObject @this, SwatchClassifier value)
    {
      @this.Set(SwatchProperty, value);
    }

    public static Swatch GetTheme(DependencyObject @this)
    {
      return @this.Get<Swatch>(ThemeProperty);
    }
    public static void SetTheme(DependencyObject @this, Swatch value)
    {
      @this.Set(ThemeProperty, value);
    }

    public static MaterialIdentity GetIdentity(
      DependencyObject @this)
    {
      return @this.Get<MaterialIdentity>(IdentityProperty);
    }
    public static void SetIdentity(DependencyObject @this, MaterialIdentity value)
    {
      @this.Set(IdentityProperty, value);
    }

    public static Brush GetVisualFeedback(DependencyObject @this)
    {
      return @this.Get<Brush>(VisualFeedbackProperty);
    }
    public static void SetVisualFeedback(DependencyObject @this, Brush value)
    {
      @this.Set(VisualFeedbackProperty, value);
    }

	  public static IMaterialDescriptor GetVisualFeedbackDescriptor(DependencyObject @this)
	  {
		  return @this.Get<IMaterialDescriptor>(VisualFeedbackDescriptorProperty);
	  }
	  public static void SetVisualFeedbackDescriptor(DependencyObject @this, IMaterialDescriptor value)
	  {
		  @this.Set(VisualFeedbackDescriptorProperty, value);
	  }




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
  }
}
