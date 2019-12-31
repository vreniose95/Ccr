using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ccr.MaterialDesign.CodeEditors
{
	public class LanguageDefaultsColorizationLayer
		: InheritingCodeColorizationLayer<
			GeneralTextColorizationLayer>
	{
		/// <inheritdoc />
		public override string LayerName
		{
			get => $"Language Defaults";
		}


		/// <inheritdoc />
		public override IDictionary<
			Expression<Func<CodeClassification>>,
			Expression<Func<GeneralTextColorizationLayer, CodeClassification>>> InheritanceMaps
		{
			get
			{
				return new Dictionary<
					Expression<Func<CodeClassification>>,
					Expression<Func<GeneralTextColorizationLayer, CodeClassification>>>
				{
					[() => Braces] = t => t.Brace,
					[() => Brackets] = t => t.Brace,
					[() => Comma] = t => t.Brace,
					[() => Dot] = t => t.Brace,
					[() => OperationSign] = t => t.Operator,
					[() => Parenthesis] = t => t.Operator,
					[() => Semicolon] = t => t.Operator,

					[() => ClassName] = t => t.NonStaticClassIdentifier,
					[() => ClassReference] = t => t.NonStaticClassIdentifier,
					[() => InstanceField] = t => t.FieldIdentifier,
					[() => InterfaceMethod] = t => t.MethodIdentifier,
					[() => InterfaceField] = t => t.FieldIdentifier,
					[() => InterfaceName] = t => t.InterfaceIdentifier,
					[() => StaticField] = t => t.FieldIdentifier,
					[() => StaticMethod] = t => t.MethodIdentifier,
				};
			}
		}


		public static CodeClassificationBuilder Builder
		{
			get => new CodeClassificationBuilder();
		}


		[GroupName("Braces and Operators")]
		public virtual CodeClassification Braces { get; set; }

		[GroupName("Braces and Operators")]
		public virtual CodeClassification Brackets { get; set; }

		[GroupName("Braces and Operators")]
		public virtual CodeClassification Comma { get; set; }

		[GroupName("Braces and Operators")]
		public virtual CodeClassification Dot { get; set; }

		[GroupName("Braces and Operators")]
		public virtual CodeClassification OperationSign { get; set; }

		[GroupName("Braces and Operators")]
		public virtual CodeClassification Parenthesis { get; set; }

		[GroupName("Braces and Operators")]
		public virtual CodeClassification Semicolon { get; set; }



		[GroupName("Classes")]
		public virtual CodeClassification ClassName { get; set; }

		[GroupName("Classes")]
		public virtual CodeClassification ClassReference { get; set; }

		[GroupName("Classes")]
		public virtual CodeClassification InstanceField { get; set; }

		[GroupName("Classes")]
		public virtual CodeClassification InstanceMethod { get; set; }

		[GroupName("Classes")]
		public virtual CodeClassification InterfaceField { get; set; }

		[GroupName("Classes")]
		public virtual CodeClassification InterfaceMethod { get; set; }

		[GroupName("Classes")]
		public virtual CodeClassification InterfaceName { get; set; }

		[GroupName("Classes")]
		public virtual CodeClassification StaticField { get; set; }

		[GroupName("Classes")]
		public virtual CodeClassification StaticMethod { get; set; }



		[GroupName("Identifiers")]
		public virtual CodeClassification Constants { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification Default { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification FunctionCall { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification FunctionDeclaration { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification GlobalVaribale { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification Label { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification LocalVariable { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification Parameter { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification PredefinedSymbol { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification ReassignedLocalVariable { get; set; }

		[GroupName("Identifiers")]
		public virtual CodeClassification ReassignedParameter { get; set; }
	}
}