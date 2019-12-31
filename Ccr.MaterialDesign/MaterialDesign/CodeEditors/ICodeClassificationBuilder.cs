using System.Windows.Media;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.CodeEditors
{
	internal interface ICodeClassificationBuilder
	{
		CodeClassificationBuilder WithForeground(
			Color foregroundColor);

		CodeClassificationBuilder WithForeground(
			[NotNull] string foregroundColorHex);


		CodeClassificationBuilder WithBackground(
			Color backgroundColor);

		CodeClassificationBuilder WithBackground(
			[NotNull] string backgroundColorHex);


		CodeClassificationBuilder IsBold(
			bool isBold = false);


		CodeClassificationBuilder IsInClassificationScope(
			ClassificationScope scope);

		CodeClassificationBuilder ClassifiesLanguage(
			ClassificationLanguage language);
	}
}