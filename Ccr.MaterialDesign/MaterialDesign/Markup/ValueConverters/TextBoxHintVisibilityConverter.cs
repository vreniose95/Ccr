using System.Windows;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{ 
public class TextBoxHintVisibilityConverter 
    : XamlConverter<
      string, 
      bool, 
      NullParam, 
      Visibility>
{
  public override Visibility Convert(
    string text, 
    bool focused,
    NullParam param)
  {
    if (focused)
      return Visibility.Hidden;

    return string.IsNullOrWhiteSpace(text) 
        ? Visibility.Visible 
        : Visibility.Hidden;
  }
}
}
