using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
  public static class TooltipPositioningAssist
  {
    public static readonly DependencyProperty PositioningServiceProperty 
      = DependencyProperty.RegisterAttached(
        "PositioningService",
        typeof(TooltipPositioningService),
        typeof(TooltipPositioningAssist), 
      new PropertyMetadata(onPositioningServiceChanged));

    

    public static TooltipPositioningService GetPositioningService(DependencyObject @this)
    {
      return @this.Get<TooltipPositioningService>(PositioningServiceProperty);
    }

    public static void SetPositioningService(DependencyObject @this, TooltipPositioningService value)
    {
      @this.Set(PositioningServiceProperty, value);
    }

    private static void onPositioningServiceChanged(
      DependencyObject @this,
      DependencyPropertyChangedEventArgs args)
    {
      var frameworkElement = @this as FrameworkElement;
      if (frameworkElement == null)
        throw new NotSupportedException(
          $"The \'TooltipPositioningAssist.PositioningService\' property cannot be set on the " +
          $"element type \'{@this.GetType().Name}\' because \'HostedElement<TElement>\'-based " +
          $"services require the host element to derive from \'FrameworkElement\'.");

      var newTrackingService = args.NewValue as TooltipPositioningService;
      var oldTrackingService = args.OldValue as TooltipPositioningService;

      oldTrackingService?.DetachHost();
      newTrackingService?.AttachHost(frameworkElement);
    }
  }
}
