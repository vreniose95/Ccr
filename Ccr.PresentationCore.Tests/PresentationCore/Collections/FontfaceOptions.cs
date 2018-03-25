using System.Windows.Media;

namespace Ccr.PresentationCore.Collections
{
  public sealed partial class FontfaceOptions
    : ValueEnum<(
      Color background,
      Color foreground,
      double fontSize)>
  {
    
    public static FontfaceOptions BadFontface
      = new FontfaceOptions(
          Colors.Red, Colors.DimGray, 14d);

    public static FontfaceOptions LameFontface
      = new FontfaceOptions(
        Colors.Yellow, Colors.DarkBlue, 16d);

    public static FontfaceOptions AverageFontface
      = new FontfaceOptions(
        Colors.Orange, Colors.Blue, 18d);

    public static FontfaceOptions GreatFontface
      = new FontfaceOptions(
        Colors.LimeGreen, Colors.Black, 20d);

    public static FontfaceOptions OutstandingFontface
      = new FontfaceOptions(
        Colors.Aqua, Colors.Purple, 20d);
  }
}
