using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Ccr.PresentationCore.Collections
{
  public sealed partial class FontfaceOptions
  {
    #region Ctor

    private FontfaceOptions(
      Color background,
      Color foreground,
      double fontSize,
      [CallerMemberName] string fieldName = "",
      [CallerLineNumber] double line = 0)
      : base(
        (background, foreground, fontSize),
        fieldName,
        line)
    {
    }

    #endregion
  }
}