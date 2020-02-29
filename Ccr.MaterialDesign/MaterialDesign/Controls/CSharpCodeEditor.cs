using System.Windows.Controls;
using System.Windows.Documents;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.CodeEditors;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.Controls
{
	public class CSharpCodeEditor
		: Control
	{
		private RichTextBox _richTextBox;
		private Paragraph _paragraph;

		static CSharpCodeEditor()
		{
			ControlExtensions.OverrideStyleKey<CSharpCodeEditor>();
		}


		/// <inheritdoc />
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_richTextBox = GetTemplateChild("PART_RichTextBox").As<RichTextBox>();

			_paragraph = new Paragraph();
			_richTextBox.Document = new FlowDocument(_paragraph)
			{
				
			};
		}


		private void writeLexeme(string lexeme, CodeClassification classification)
		{
			var inline = new Run(lexeme)
			{
				Foreground = classification.ForegroundBrush,
				Background = classification.BackgroundBrush,
				FontWeight = StandardFontWeight.Normal.FontWeight 
			};
			_paragraph.Inlines.Add(inline);
		}
	}
}
