using System.Windows.Media;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.CodeEditors
{
	public static class CodeClassificationBuilderExtensions
	{
		public static CodeClassificationBuilder WithForeground(
			this CodeClassificationBuilder @this,
			Color foregroundColor)
		{
			return @this.As<ICodeClassificationBuilder>()
			            .WithForeground(foregroundColor);
		}

		public static CodeClassificationBuilder WithForeground(
			this CodeClassificationBuilder @this,
			string foregroundColorHex)
		{
			return @this.As<ICodeClassificationBuilder>()
			            .WithForeground(foregroundColorHex);
		}


		public static CodeClassificationBuilder WithBackground(
			this CodeClassificationBuilder @this,
			Color backgroundColor)
		{
			return @this.As<ICodeClassificationBuilder>()
			            .WithBackground(backgroundColor);
		}

		public static CodeClassificationBuilder WithBackground(
			this CodeClassificationBuilder @this,
			string backgroundColorHex)
		{
			return @this.As<ICodeClassificationBuilder>()
			            .WithBackground(backgroundColorHex);
		}

		
		public static CodeClassificationBuilder IsBold(
			this CodeClassificationBuilder @this,
			bool isBold = true)
		{
			return @this.As<ICodeClassificationBuilder>()
			            .IsBold(isBold);
		}


		public static CodeClassificationBuilder IsInClassificationScope(
			this CodeClassificationBuilder @this,
			ClassificationScope scope)
		{
			return @this.As<ICodeClassificationBuilder>()
			            .IsInClassificationScope(scope);
		}

		public static CodeClassificationBuilder ClassifiesLanguage(
			this CodeClassificationBuilder @this,
			ClassificationLanguage language)
		{
			return @this.As<ICodeClassificationBuilder>()
			            .ClassifiesLanguage(language);
		}

		//public static CodeClassificationBuilder Classification(
		//	this CodeClassificationBuilder @this,
		//	ClassificationScope scope)
		//{
		//	return @this.As<ICodeClassificationBuilder>()
		//	            .Classification(scope);
		//}
	}
}