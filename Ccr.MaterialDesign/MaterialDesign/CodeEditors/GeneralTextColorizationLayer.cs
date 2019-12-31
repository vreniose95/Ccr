namespace Ccr.MaterialDesign.CodeEditors
{
	public class GeneralTextColorizationLayer
		: CodeColorizationLayer
	{
		/// <inheritdoc />
		public override string LayerName
		{
			get => $"General Text";
		}

		public virtual CodeClassification PlainText
		{
			get => CodeClassification.PlainText;
		}
		
		public virtual CodeClassification Brace
		{
			get => CodeClassification.ReSharperOperatorIdentifier; // wrong
		}

		public virtual CodeClassification Comment
		{
			get => CodeClassification.Comment;
		}

		public virtual CodeClassification NonStaticClassIdentifier
		{
			get => CodeClassification.ReSharperClassIdentifier;
		}

		public virtual CodeClassification StaticClassIdentifier
		{
			get => CodeClassification.ReSharperStaticClassIdentifier;
		}

		public virtual CodeClassification ConstantIdentifier
		{
			get => CodeClassification.ReSharperConstantIdentifier;
		}

		public virtual CodeClassification DelegateIdentifier
		{
			get => CodeClassification.ReSharperDelegateIdentifier;
		}

		public virtual CodeClassification EnumIdentifier
		{
			get => CodeClassification.ReSharperEnumIdentifier;
		}

		public virtual CodeClassification EnumMemberIdentifier
		{
			get => CodeClassification.ReSharperMethodIdentifier;
		}

		public virtual CodeClassification EventIdentifier
		{
			get => CodeClassification.ReSharperEventIdentifier;
		}

		public virtual CodeClassification ExtensionMethodIdentifier
		{
			get => CodeClassification.ReSharperExtensionMethodIdentifier;
		}

		public virtual CodeClassification FieldIdentifier
		{
			get => CodeClassification.ReSharperFieldIdentifier;
		}

		public virtual CodeClassification InterfaceIdentifier
		{
			get => CodeClassification.ReSharperInterfaceIdentifier;
		}

		public virtual CodeClassification LocalMethodIdentifier
		{
			get => CodeClassification.ReSharperMethodIdentifier;
		}

		public virtual CodeClassification MethodIdentifier
		{
			get => CodeClassification.ReSharperMethodIdentifier;
		}

		public virtual CodeClassification NamespaceIdentifier
		{
			get => CodeClassification.ReSharperNamespaceIdentifier;
		}

		public virtual CodeClassification ParameterIdentifier
		{
			get => CodeClassification.ReSharperParameterIdentifier;
		}

		public virtual CodeClassification PathIdentifier
		{
			get => CodeClassification.ReSharperPathIdentifier;
		}

		public virtual CodeClassification PropertyIdentifier
		{
			get => CodeClassification.ReSharperPropertyIdentifier;
		}

		public virtual CodeClassification TypeParameterIdentifier
		{
			get => CodeClassification.ReSharperTypeParameterIdentifier;
		}

		public virtual CodeClassification ValueTupleComponentIdentifier
		{
			get => CodeClassification.ReSharperTupleComponentIdentifier;
		}

		public virtual CodeClassification VariableLocalImmutableIdentifier
		{
			get => CodeClassification.ReSharperMutableLocalVariableIdentifier; //wrong?
		}

		public virtual CodeClassification MutableLocalVariableIdentifier
		{
			get => CodeClassification.ReSharperMutableLocalVariableIdentifier;
		}

		public virtual CodeClassification Keyword
		{
			get => CodeClassification.Keyword;
		}

		public virtual CodeClassification Number
		{
			get => CodeClassification.ReSharperOperatorIdentifier;//wrong
		}

		public virtual CodeClassification Operator
		{
			get => CodeClassification.ReSharperOperatorIdentifier;
		}

		public virtual CodeClassification RegexComment
		{
			get => CodeClassification.ReSharperRegexComment;
		}

		public virtual CodeClassification RegexGroup
		{
			get => CodeClassification.ReSharperRegexGroup;
		}

		public virtual CodeClassification RegexIdentifier
		{
			get => CodeClassification.ReSharperRegexIdentifier;
		}
		
		public virtual CodeClassification RegexMatchedSelection
		{
			get => CodeClassification.ReSharperRegexMatchedSelection;
		}

		public virtual CodeClassification RegexMatchedValue
		{
			get => CodeClassification.ReSharperRegexMatchedValue;
		}

		public virtual CodeClassification RegexSet
		{
			get => CodeClassification.ReSharperRegexSet;
		}

		public virtual CodeClassification String
		{
			get => CodeClassification.StringVerbatim;
		}

		public virtual CodeClassification StringFormatItem
		{
			get => CodeClassification.ReSharperFormatStringItem;
		}

		public virtual CodeClassification StringVerbatim
		{
			get => CodeClassification.StringVerbatim;
		}

		public virtual CodeClassification StringEscapeCharacter1
		{
			get => CodeClassification.ReSharperStringEscapeCharacter1;
		}

		public virtual CodeClassification StringEscapeCharacter2
		{
			get => CodeClassification.ReSharperStringEscapeCharacter1;
		}

	//	public virtual CodeClassification TodoItem { get => CodeClassification.}

	}
}