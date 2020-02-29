using System.Windows.Media;

namespace Ccr.MaterialDesign.Static
{
  public static class Text
  {
    public static class Fonts
    {
      private static readonly FontFamilyConverter ffc = new FontFamilyConverter();


      public static FontFamily TimesNewRoman
      {
	      get => (FontFamily) ffc.ConvertFromString("Times New Roman");
      }

      public static FontFamily Roboto
      {
	      get => (FontFamily) ffc.ConvertFromString("Roboto");
      }
    }
  }
}