using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
  public class TooltipPositioningService
    : HostedElement<FrameworkElement>
  {
    protected override void OnHostAttached(DependencyObject host)
    {
      base.OnHostAttached(host);
      host.As<Border>().MouseDown += OnMouseDown;

    }

    private void OnMouseDown(object Sender, MouseButtonEventArgs MouseButtonEventArgs)
    {
      var mousePosition = new Point(2, 2);

      HostElement.LayoutTransform 
        = new TranslateTransform(
          -mousePosition.X, 
          -mousePosition.Y);
    }
  }
}
