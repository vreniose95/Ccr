using System;
using System.Windows;
using System.Windows.Media;
using Ccr.Std.Core.Extensions;

namespace Ccr.PresentationCore.Helpers
{
  public static class CcrVisualTreeHelpers
  {
    public static TParent FindParent<TParent>(
      this DependencyObject @this) 
        where TParent
          : DependencyObject
    {
      return @this.FindParent(
        typeof(TParent)).As<TParent>();
    }

    public static DependencyObject FindParent(
      this DependencyObject @this,
      Type parentType)
    {
      var parent = VisualTreeHelper
        .GetParent(
          @this);

      if (parent == null)
        throw new InvalidOperationException(
          $"");

      while (!parent.GetType().IsAssignableFrom(parentType))
      {
        parent = VisualTreeHelper.GetParent(
          parent);

        if (parent == null)
          throw new InvalidOperationException(
            $"");
      }

      return parent;
    }


    public static DependencyObject FindParent(this FrameworkElement i, Type ofType, int level = 0)
    {
      var isTypeUnspecified = ofType == null;
      if (level < 0)
        throw new ArgumentOutOfRangeException(nameof(level), "Level parameter must be greater than or equal to 0.");

      var currentNode = VisualTreeHelper.GetParent(i);
      while (level >= 0)
      {
        while (isTypeUnspecified || !ofType.IsInstanceOfType(currentNode))
        {
          if (currentNode == null)
          {
            throw new ArgumentNullException(nameof(currentNode));
          }
          var lastNode = currentNode;
          currentNode = VisualTreeHelper.GetParent(currentNode);
          if (currentNode == null)
          {
            currentNode = LogicalTreeHelper.GetParent(lastNode);
          }
        }
        level--;
      }
      return currentNode;
    }
  }
}
