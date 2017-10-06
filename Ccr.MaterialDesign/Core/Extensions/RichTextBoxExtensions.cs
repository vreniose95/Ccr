using System.Windows.Controls;
using System.Windows.Documents;

namespace Ccr.Core.Extensions
{
	public static class RichTextBoxExtensions
	{
		public static string GetAllText(
			this RichTextBox @this)
		{
			var fullTextRange = new TextRange(
				@this.Document.ContentStart,
				@this.Document.ContentEnd);

			return fullTextRange.Text;
		}
	}
}
