using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Ccr.MaterialDesign.CodeEditors
{
	public partial class CodeClassification
	{
		public string ClassificationName { get; }

		public string IdentifierName { get; }

		public Color Foreground { get; }

		public Color Background { get; }

		public SolidColorBrush ForegroundBrush { get; }

		public SolidColorBrush BackgroundBrush { get; }

		public bool IsBold { get; }

		public ClassificationScope Scope { get; }

		public ClassificationLanguage Language { get; }


		public static CodeClassificationBuilder Builder
		{
			get => new CodeClassificationBuilder();
		}


		internal CodeClassification(
			string classificationName,
			Color foreground,
			Color background,
			bool isBold,
			ClassificationScope scope,
			ClassificationLanguage language,
			[CallerMemberName] string identifier = "")
		{
			ClassificationName = classificationName;
			Foreground = foreground;
			Background = background;
			ForegroundBrush = new SolidColorBrush(Foreground);
			BackgroundBrush = new SolidColorBrush(Background);
			IsBold = isBold;
			Scope = scope;
			Language = language;
			IdentifierName = identifier;
		}
	}
}