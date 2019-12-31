using System;
using System.Windows;
using System.Windows.Media;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
  public static class IconAssist
  {
    private static readonly Type _type = typeof(IconAssist);


    public static readonly DependencyProperty ScaleProperty = DP.Attach(
      _type, new MetaBase<double>(1d, onScaleChanged));
		
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


		private static void onScaleChanged(
	    DependencyObject @this,
	    DPChangedEventArgs<double> args)
    {
	    if (!(@this is FrameworkElement frameworkElement))
		    throw new NotSupportedException(
			    $"The Dependency Property '{nameof(IconAssist)}.{nameof(ScaleProperty)}' cannot be used " +
			    $"on an element type {@this.GetType().Name.SQuote()}, as it does not derive from the base " +
			    $"element type {typeof(FrameworkElement).Name.SQuote()}.");

	    var scaleTransform = new ScaleTransform(args.NewValue, args.NewValue, .5, .5);
	    frameworkElement.RenderTransformOrigin = new Point(.5, .5);

	    if (frameworkElement.RenderTransform != null)
	    {
		    var originalTransform = frameworkElement.RenderTransform;
		    var transformGroup = new TransformGroup
		    {
			    Children = new TransformCollection
			    {
				    originalTransform,
				    scaleTransform
			    }
		    };
		    frameworkElement.RenderTransform = transformGroup;
	    }
	    else
	    {
		    frameworkElement.RenderTransform = scaleTransform;
	    }
    }
	}
}
