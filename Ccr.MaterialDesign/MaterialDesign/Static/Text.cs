using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ccr.MaterialDesign.Static
{
  public static class Text
  {
    public static class Fonts
    {
      private static readonly FontFamilyConverter ffc = new FontFamilyConverter();

      internal static FontFamily TimesNewRoman => (FontFamily) ffc.ConvertFromString("Times New Roman");
      public static FontFamily Roboto => (FontFamily) ffc.ConvertFromString("Roboto");
    }
  }
}