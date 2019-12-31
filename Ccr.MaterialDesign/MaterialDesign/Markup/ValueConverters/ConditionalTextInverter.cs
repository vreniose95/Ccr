using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class ConditionalTextInverter
    : XamlConverter<
      SolidColorBrush,
      NullParam,
      SolidColorBrush>
  {
    public override SolidColorBrush Convert(
      SolidColorBrush background, 
      NullParam param)
    {
      var blackDifference = background.Color.Differential(Colors.Black);

      var whiteDifference = background.Color.Differential(Colors.White);

      if (blackDifference > whiteDifference)
        return Brushes.Black;

      return Brushes.White;
    }
  }
}
