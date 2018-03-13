using System;
using System.Windows;
using System.Windows.Controls;
using Ccr.Core.Extensions;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Controls
{
  public class Card
    : ContentControl
  {
    public static readonly DependencyProperty CornerRadiusProperty = DP.Register(
      new Meta<Card, double>(2d));

    public double CornerRadius
    {
      get => (double) GetValue(CornerRadiusProperty);
      set => SetValue(CornerRadiusProperty, value);
    }
    

    static Card()
    {
      ControlExtensions.OverrideStyleKey<Card>();
    }

  }
}
