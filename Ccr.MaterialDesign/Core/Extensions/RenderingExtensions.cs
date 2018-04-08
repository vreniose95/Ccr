using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Ccr.Core.Extensions
{
  public static class RenderingExtensions
  {
    public static Size EstimateLabelRenderSize(FontFamily fontFamily, double fontSize, string content = "Fq")
    {
      var defaultPadding = new Thickness(5);
      return EstimateTextRenderSize(fontFamily, fontSize, defaultPadding, content);
    }
    public static Size EstimateLabelRenderSize(FontFamily fontFamily, double fontSize, Thickness padding, string content = "Fq")
    {
      return EstimateTextRenderSize(fontFamily, fontSize, padding, content);
    }
    public static Size EstimateTextRenderSize(FontFamily fontFamily, double fontSize, string content = "Fq")
    {
      return EstimateTextRenderSize(fontFamily, fontSize, new Thickness(0), content);
    }
    public static Size EstimateTextRenderSize(FontFamily fontFamily, double fontSize, Thickness padding, string content = "Fq")
    {
      var formattedText = new FormattedText(content, CultureInfo.GetCultureInfo("en-us"),
                                            FlowDirection.LeftToRight, new Typeface(fontFamily.ToString()), fontSize, Brushes.Black);
      return new Size(formattedText.Width + padding.Left + padding.Right, formattedText.Height + padding.Top + padding.Bottom);
    }
  }
}
