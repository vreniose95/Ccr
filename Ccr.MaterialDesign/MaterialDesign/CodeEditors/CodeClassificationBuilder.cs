using System.Windows.Media;
using Ccr.Std.Core.Extensions;
using Ccr.Std.Core.FluentBuilder;

namespace Ccr.MaterialDesign.CodeEditors
{
	public class CodeClassificationBuilder
		: IFluentBuilder<CodeClassification>,
			ICodeClassificationBuilder
	{
		private static readonly ColorConverter _colorConverter = new ColorConverter();


		private bool? _isBold;
		private Color? _foregroundColor;
		private Color? _backgroundColor;
		private ClassificationScope? _scope;
		private ClassificationLanguage? _language;


		CodeClassificationBuilder ICodeClassificationBuilder.WithForeground(
			Color foregroundColor)
		{
			_foregroundColor.EnsureNotAssigned(nameof(foregroundColor));
			_foregroundColor = foregroundColor;

			return this;
		}

		CodeClassificationBuilder ICodeClassificationBuilder.WithForeground(
			string foregroundColorHex)
		{
			var foregroundColor = _colorConverter.ConvertFrom(foregroundColorHex).As<Color>();
			return this.As<ICodeClassificationBuilder>().WithForeground(foregroundColor);
		}

		CodeClassificationBuilder ICodeClassificationBuilder.WithBackground(
			Color backgroundColor)
		{
			_backgroundColor.EnsureNotAssigned(nameof(backgroundColor));
			_backgroundColor = backgroundColor;

			return this;
		}

		CodeClassificationBuilder ICodeClassificationBuilder.WithBackground(
			string backgroundColorHex)
		{
			var backgroundColor = _colorConverter.ConvertFrom(backgroundColorHex).As<Color>();
			return this.As<ICodeClassificationBuilder>().WithBackground(backgroundColor);
		}

		CodeClassificationBuilder ICodeClassificationBuilder.IsBold(
			bool isBold)
		{
			_isBold.EnsureNotAssigned(nameof(isBold));
			_isBold = isBold;

			return this;
		}

		CodeClassificationBuilder ICodeClassificationBuilder.IsInClassificationScope(
			ClassificationScope scope)
		{
			_scope.EnsureNotAssigned(nameof(scope));
			_scope = scope;

			return this;
		}

		CodeClassificationBuilder ICodeClassificationBuilder.ClassifiesLanguage(
			ClassificationLanguage language)
		{
			_language.EnsureNotAssigned(nameof(language));
			_language = language;

			return this;
		}



		public static implicit operator CodeClassification(
			CodeClassificationBuilder @this)
		{
			return @this.Build();
		}

		
		/// <inheritdoc />
		public CodeClassification Build()
		{
			var foregroundColor = _foregroundColor.EnsureAssigned(nameof(_foregroundColor));
			var backgroundColor = _backgroundColor.EnsureAssigned(nameof(_backgroundColor));
			var isBold = _isBold.EnsureAssigned(nameof(_isBold)); 
			var scope = _scope.EnsureAssigned(nameof(_scope));
			var language = _language.EnsureAssigned(nameof(_language));

			return new CodeClassification(
				"",
				foregroundColor,
				backgroundColor, 
				isBold,
				scope,
				language);
		}
	}
}