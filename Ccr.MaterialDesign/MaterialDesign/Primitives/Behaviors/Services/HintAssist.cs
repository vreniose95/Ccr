using System;
using System.Windows;
using Ccr.MaterialDesign.Adapters;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
  public static class HintAssist
  {
    public static Type _type = typeof(HintAssist);

    public static readonly DependencyProperty HintProperty = DP.Attach(_type,
      new MetaBase<string>());

    public static readonly DependencyProperty InputDataAdapterProperty = DP.Attach(_type,
      new MetaBase<TextFieldInputDataAdapter>());



    public static string GetHint(DependencyObject @this)
    {
      return @this.Get<string>(HintProperty);
    }
    public static void SetHint(DependencyObject @this, string value)
    {
      @this.Set(HintProperty, value);
    }
    
    public static TextFieldInputDataAdapter GetInputDataAdapter(
      DependencyObject @this)
    {
      return @this.Get<TextFieldInputDataAdapter>(InputDataAdapterProperty);
    }
    public static void SetInputDataAdapter(
      DependencyObject @this,
      TextFieldInputDataAdapter value)
    {
      @this.Set(InputDataAdapterProperty, value);
    }


  }
}
