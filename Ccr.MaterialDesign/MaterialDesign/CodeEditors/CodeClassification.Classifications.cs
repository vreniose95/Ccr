namespace Ccr.MaterialDesign.CodeEditors
{
	public enum ComplexCodeKind
	{
		PlainText,
		Brace,
		Comment,
		NonStaticClassIdentifier,
		StaticClassIdentifier,
		ConstantIdentifier,
		DelegateIdentifier,
		EnumIdentifier,
		EnumMemberIdentifier,
		EventIdentifier,
		ExtensionMethodIdentifier,
		FieldIdentifier,
		InterfaceIdentifier,
		LocalMethodIdentifier,
		MethodIdentifier,
		NamespaceIdentifier,
		ParameterIdentifier,
		PathIdentifier,
		PropertyIdentifier,
		TypeParameterIdentifier,
		ValueTupleComponentIdentifier,
		VariableLocalImmutableIdentifier,
		MutableLocalVariableIdentifier,
		Keyword,
		Number,
		Operator,
		RegexComment,
		RegexGroup,
		RegexIdentifier,
		RegexMatchedSelection,
		RegexMatchedValue,
		RegexSet,
		String,
		StringFormatItem,
		StringVerbatim,
		StringEscapeCharacter1,
		StringEscapeCharacter2,
	}

	public enum CodeKind
	{
		BraceOperator = 1,
		ClassIdentifier = 2,
		ConstantIdentifier = 3,
		DelegateIdentifier = 4,
		EnumIdentifier = 5,
		EventIdentifier = 6,
		FieldIdentifier = 7,
		InterfaceIdentifier = 8,
		MethodIdentifier = 9,
		NamespaceIdentifier = 10,
		ParameterIdentifier = 11,
		PropertyIdentifier = 12,
		TypeParameterIdentifier = 13,
		Keyword = 14,
		Number = 15,
		String = 16,
	}

	public partial class CodeClassification
	{
		public static readonly CodeClassification PlainText2 = Builder
			.WithForeground("#DCDCDC")
			.WithBackground("#080808")
			.IsBold(false)
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification ReSharperParameterIdentifier = Builder
			.WithForeground("#E2DE87")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ArtboardBackground = Builder
			.WithForeground("#02000000")
			.WithBackground("#02000000")
			.IsBold(false)
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification PlainText = Builder
			.WithForeground("#DCDCDC")
			.WithBackground("#080808")
			.IsBold(false)
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification Keyword = Builder
			.WithForeground("#FF00FF")
			.WithBackground("#020202")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification Comment = Builder
			.WithForeground("#A2EB58")
			.WithBackground("#02000000")
			.IsBold(false)
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification ReSharperDeadCode = Builder
			.WithForeground("#A0A464")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperConstantIdentifier = Builder
			.WithForeground("#96B81F")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperEventIdentifier = Builder
			.WithForeground("#9866F4")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperFieldIdentifier = Builder
			.WithForeground("#D8D07A")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperMutableLocalVariableIdentifier = Builder
			.WithForeground("#FF4AA5")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperMethodIdentifier = Builder
			.WithForeground("#EFE138")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperExtensionMethodIdentifier = Builder
			.WithForeground("#1DBEF3")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperOperatorIdentifier = Builder
			.WithForeground("#FFCCFF")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperNamespaceIdentifier = Builder
			.WithForeground("#FE0ACD")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperPathIdentifier = Builder
			.WithForeground("#CF40FF")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperFormatStringItem = Builder
			.WithForeground("#13FDE0")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperStringEscapeCharacter1 = Builder
			.WithForeground("#05A0EB")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperStringEscapeCharacter2 = Builder
			.WithForeground("#1FC5FC")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.Regex)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperRegexSet = Builder
			.WithForeground("#38B8B8")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.Regex)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperRegexGroup = Builder
			.WithForeground("#3838B8")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.Regex)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperRegexIdentifier = Builder
			.WithForeground("#3858B8")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.Regex)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperRegexComment = Builder
			.WithForeground("#8811FF")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.Regex)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperRegexMatchedValue = Builder
			.WithForeground("#3878B8")
			.WithBackground("#164E00")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperRegexMatchedSelection = Builder
			.WithForeground("#3878B8")
			.WithBackground("#4D4D00")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperClassIdentifier = Builder
			.WithForeground("#79C512")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperStaticClassIdentifier = Builder
			.WithForeground("#F349E2")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperStructIdentifier = Builder
			.WithForeground("#FF80FF")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperEnumIdentifier = Builder
			.WithForeground("#9AD040")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperInterfaceIdentifier = Builder
			.WithForeground("#1C94E3")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperDelegateIdentifier = Builder
			.WithForeground("#B15CCD")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperTypeParameterIdentifier = Builder
			.WithForeground("#00FFFF")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification PreprocessorText = Builder
			.WithForeground("#A326FF")
			.WithBackground("#030303")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification String = Builder
			.WithForeground("#ED03B3")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification StringVerbatim = Builder
			.WithForeground("#ED03B3")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification ModuleName = Builder
			.WithForeground("#B838B8")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification StructName = Builder
			.WithForeground("#9838B8")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentAttributeName = Builder
			.WithForeground("#C28D01")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentAttributeQuotes = Builder
			.WithForeground("#C6A800")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentAttributeValue = Builder
			.WithForeground("#C9CE06")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentCDataSection = Builder
			.WithForeground("#CDE023")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentComment = Builder
			.WithForeground("#D8CE12")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentDelimiter = Builder
			.WithForeground("#C0C510")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentEntityReference = Builder
			.WithForeground("#C1C613")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentName = Builder
			.WithForeground("#D2C913")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentProcessingInstruction = Builder
			.WithForeground("#C4D900")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification XMLDocCommentText = Builder
			.WithForeground("#AC8C20")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.XMLDocComment)
			.IsInClassificationScope(ClassificationScope.VisualStudio);




		public static readonly CodeClassification ReSharperPropertyIdentifier = Builder
			.WithForeground("#5FC9FC")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperTupleComponentIdentifier = Builder
			.WithForeground("#EE82EE")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification LineNumberIdentifier = Builder
			.WithForeground("#2B91AF")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification ReSharperBraceOutline = Builder
			.WithForeground("#DDDDDD")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);


		//public static readonly CodeClassification ReSharperTodoItem= Builder
		//  .WithForeground("#")
		//  .WithBackground("#")
		//  .IsBold()
		//  .ClassifiesLanguage(ClassificationLanguage.CSharp)
		//  .IsInClassificationScope(ClassificationScope.ReSharper);

		//public static readonly CodeClassification Comment = Builder.WithForeground("#A2EB58").WithBackground("#02000000").IsBold(false).
		//.ClassifiesLanguage(ClassificationLanguage.CSharp)
		//.IsInClassificationScope(ClassificationScope.VisualStudio);
		//public static readonly CodeClassification Keyword = Builder.WithForeground("#FF00FF").WithBackground("#020202")
		//.IsBold()
		//.ClassifiesLanguage(ClassificationLanguage.CSharp)
		//.IsInClassificationScope(ClassificationScope.VisualStudio);

		//public static readonly CodeClassification CompilerError = Builder.WithForeground("#5555E8").WithBackground("#02000000").IsBold(false).
		//.ClassifiesLanguage(ClassificationLanguage.CSharp)
		//.IsInClassificationScope(ClassificationScope.VisualStudio);

	}
}
