

/*   BracesAndOperators {
		Braces,
		Brackets,
		Comma,
		Dot,
		OperationSign,
		Parenthesis,
		Semicolon }
Classes {
		ClassName,
		ClassReference,
		InstanceField,
		InstanceMethod,
		InterfaceField,
		InterfaceMethod,
		InterfaceName,
		StaticField,
		StaticMethod }
Identifiers {
		Constants,
		Default,
		FunctionCall,
		FunctionDeclaration,
		GlobalVaribale,
		Label,
		LocalVariable,
		Parameter,
		PredefinedSymbol,
		ReassignedLocalVariable,
		ReassignedParameter }*/


namespace Ccr.MaterialDesign.CodeEditors
{
	//public static class CodeClassificationExtensions
	//{
	//	public static CodeClassification IsInClassificationScope(
	//		this CodeClassification @this,
	//		ClassificationScope scope)
	//	{
	//		return @this;
	//	}

	//	public static CodeClassification ClassifiesLanguage(
	//		this CodeClassification @this,
	//		ClassificationLanguage language)
	//	{
	//		return @this;
	//	}
	//}


	/*		public static readonly CodeClassification CompilerError = Builder
			.WithForeground("#5555E8")
			.WithBackground("#02000000")
			.IsBold(false)
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification DifferentContent = Builder
			.WithForeground("#0014E5")
			.WithBackground("#FFFFFF")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification IdenticalContent = Builder
			.WithForeground("#000000")
			.WithBackground("#FFFFFF")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification SourceOnly = Builder
			.WithForeground("#000000")
			.WithBackground("#FFFFFF")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification TargetOnly = Builder
			.WithForeground("#000000")
			.WithBackground("#FFFFFF")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification NotDownloaded = Builder
			.WithForeground("#999999")
			.WithBackground("#FFFFFF")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification EvenRowItems = Builder
			.WithForeground("#000000")
			.WithBackground("#FFFFFF")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification OddRowItems = Builder
			.WithForeground("#000000")
			.WithBackground("#FFFFFF")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);
					
		public static readonly CodeClassification ReSharperCurrentLineHighlight = Builder
			.WithForeground("#11FF88")
			.WithBackground("#000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		
		public static readonly CodeClassification ReSharperCodeAnalysisErrorMarkerOnErrorStripe = Builder
			.WithForeground("#0040FF")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperCodeAnalysisWarningMarkerOnErrorStripe = Builder
			.WithForeground("#11C4FF")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperCodeAnalysisSuggestionMarkerOnErrorStripe = Builder
			.WithForeground("#1188FF")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperBoxingOccurrence = Builder
			.WithForeground("#EC80D9")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperHeapAllocation = Builder
			.WithForeground("#FF8811")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperTemplateEditorCSharpKeyword = Builder
			.WithForeground("#DF2FDB")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperASPNETMVCAction = Builder
			.WithForeground("#2893F2")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperASPNETMVCArea = Builder
			.WithForeground("#79EB12")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperASPNETMVCController = Builder
			.WithForeground("#A4A727")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperASPNETMVCView = Builder
			.WithForeground("#EC87F8")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperASPNETMVCViewComponent = Builder
			.WithForeground("#E35391")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperASPNETRunAtAttribute = Builder
			.WithForeground("#1AC8C8")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);
		 
		//public static readonly CodeClassification ReSharperParameterIdentifier = Builder.WithForeground("#E2DE87").WithBackground("#01000001")
		//.IsBold()
		//.ClassifiesLanguage(ClassificationLanguage.CSharp)
		//.IsInClassificationScope(ClassificationScope.ReSharper);


		
		public static readonly CodeClassification ReSharperInjectedLanguageBackground = Builder
			.WithForeground("#BAC03F")
			.WithBackground("#3C3C3C")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperILQualifiedName = Builder
			.WithForeground("#2666DD")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);

		public static readonly CodeClassification ReSharperCompletionReplacementRange = Builder
			.WithForeground("#11FFFF")
			.WithBackground("#008080")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.ReSharper);
			
		public static readonly CodeClassification RoslynActiveStatementTag = Builder
			.WithForeground("#00FF00")
			.WithBackground("#003500")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);


				public static readonly CodeClassification RegularExpressionClassificationFormat = Builder
			.WithForeground("#2752FC")
			.WithBackground("#01000001")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.Regex)
			.IsInClassificationScope(ClassificationScope.VisualStudio);

		public static readonly CodeClassification SymbolDefinitionClassificationFormat = Builder
			.WithForeground("#B83838")
			.WithBackground("#02000000")
			.IsBold()
			.ClassifiesLanguage(ClassificationLanguage.CSharp)
			.IsInClassificationScope(ClassificationScope.VisualStudio);
		 */

	public class CodeTheme
	{
		/*
		 public static readonly CodeClassification Artboard Background = Builder.WithForeground("#02000000").WithBackground("#02000000").IsBold(false).ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
		 public static readonly CodeClassification Plain Text = Builder.WithForeground("#DCDCDC").WithBackground("#080808").IsBold(false).ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
		 public static readonly CodeClassification Keyword = Builder.WithForeground("#FF00FF").WithBackground("#020202").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
		 public static readonly CodeClassification Comment = Builder.WithForeground("#A2EB58").WithBackground("#02000000").IsBold(false).ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
		 public static readonly CodeClassification compiler error = Builder.WithForeground("#5555E8").WithBackground("#02000000").IsBold(false).ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);

							public static readonly CodeClassification Different content = Builder.WithForeground("#0014E5").WithBackground("#FFFFFF").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification Identical content = Builder.WithForeground("#000000").WithBackground("#FFFFFF").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification Source Only = Builder.WithForeground("#000000").WithBackground("#FFFFFF").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification Target Only = Builder.WithForeground("#000000").WithBackground("#FFFFFF").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification Not Downloaded = Builder.WithForeground("#999999").WithBackground("#FFFFFF").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification Even Row Items = Builder.WithForeground("#000000").WithBackground("#FFFFFF").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification Odd Row Items = Builder.WithForeground("#000000").WithBackground("#FFFFFF").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Current Line Highlight = Builder.WithForeground("#11FF88").WithBackground("#000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Dead Code = Builder.WithForeground("#A0A464").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Code Analysis Error Marker on Error Stripe = Builder.WithForeground("#0040FF").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Code Analysis Warning Marker on Error Stripe = Builder.WithForeground("#11C4FF").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Code Analysis Suggestion Marker on Error Stripe = Builder.WithForeground("#1188FF").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Boxing Occurrence = Builder.WithForeground("#EC80D9").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Heap Allocation = Builder.WithForeground("#FF8811").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Template Editor C# Keyword = Builder.WithForeground("#DF2FDB").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper ASP.NET MVC Action = Builder.WithForeground("#2893F2").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper ASP.NET MVC Area = Builder.WithForeground("#79EB12").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper ASP.NET MVC Controller = Builder.WithForeground("#A4A727").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper ASP.NET MVC View = Builder.WithForeground("#EC87F8").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper ASP.NET MVC View Component = Builder.WithForeground("#E35391").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper ASP.NET RunAt attribute = Builder.WithForeground("#1AC8C8").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Constant Identifier = Builder.WithForeground("#96B81F").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Event Identifier = Builder.WithForeground("#9866F4").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Field Identifier = Builder.WithForeground("#D8D07A").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Parameter Identifier = Builder.WithForeground("#E2DE87").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Mutable Local Variable Identifier = Builder.WithForeground("#FF4AA5").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Method Identifier = Builder.WithForeground("#EFE138").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Extension Method Identifier = Builder.WithForeground("#1DBEF3").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Operator Identifier = Builder.WithForeground("#FFCCFF").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Namespace Identifier = Builder.WithForeground("#FE0ACD").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Path Identifier = Builder.WithForeground("#CF40FF").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Format String Item = Builder.WithForeground("#13FDE0").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper String Escape Character 1 = Builder.WithForeground("#05A0EB").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper String Escape Character 2 = Builder.WithForeground("#1FC5FC").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Regex Set = Builder.WithForeground("#38B8B8").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Regex Group = Builder.WithForeground("#3838B8").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Regex Identifier = Builder.WithForeground("#3858B8").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Regex Comment = Builder.WithForeground("#8811FF").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Regex Matched Value = Builder.WithForeground("#3878B8").WithBackground("#164E00").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Regex Matched Selection = Builder.WithForeground("#3878B8").WithBackground("#4D4D00").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Injected Language Background = Builder.WithForeground("#BAC03F").WithBackground("#3C3C3C").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper IL Qualified Name = Builder.WithForeground("#2666DD").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Completion Replacement Range = Builder.WithForeground("#11FFFF").WithBackground("#008080").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Class Identifier = Builder.WithForeground("#79C512").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Static Class Identifier = Builder.WithForeground("#F349E2").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Struct Identifier = Builder.WithForeground("#FF80FF").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Enum Identifier = Builder.WithForeground("#9AD040").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Interface Identifier = Builder.WithForeground("#1C94E3").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Delegate Identifier = Builder.WithForeground("#B15CCD").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification ReSharper Type Parameter Identifier = Builder.WithForeground("#00FFFF").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification RoslynActiveStatementTag = Builder.WithForeground("#00FF00").WithBackground("#003500").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification preprocessor text = Builder.WithForeground("#A326FF").WithBackground("#030303").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification string - verbatim = Builder.WithForeground("#ED03B3").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification module name = Builder.WithForeground("#B838B8").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification struct name = Builder.WithForeground("#9838B8").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - attribute name = Builder.WithForeground("#C28D01").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - attribute quotes = Builder.WithForeground("#C6A800").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - attribute value = Builder.WithForeground("#C9CE06").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - cdata section = Builder.WithForeground("#CDE023").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - comment = Builder.WithForeground("#D8CE12").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - delimiter = Builder.WithForeground("#C0C510").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - entity reference = Builder.WithForeground("#C1C613").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - name = Builder.WithForeground("#D2C913").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - processing instruction = Builder.WithForeground("#C4D900").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification xml doc comment - text = Builder.WithForeground("#AC8C20").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification RegularExpressionClassificationFormat = Builder.WithForeground("#2752FC").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification JadeVariableFormatDefinition = Builder.WithForeground("#FF8080").WithBackground("#01000001").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification Comment = Builder.WithForeground("#A2EB58").WithBackground("#02000000").IsBold(false).ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification Keyword = Builder.WithForeground("#FF00FF").WithBackground("#020202").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification SymbolDefinitionClassificationFormat = Builder.WithForeground("#B83838").WithBackground("#02000000").IsBold().ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);
							public static readonly CodeClassification compiler error = Builder.WithForeground("#5555E8").WithBackground("#02000000").IsBold(false).ClassifiesLanguage(ClassificationLanguage.CSharp).IsInClassificationScope(ClassificationScope.VisualStudio);*/
	}


}

///// <inheritdoc />
//public override IDictionary<
//	Expression<Func<CodeClassification>>, 
//	Expression<Func<CodeClassification>>> InheritanceMaps
//{
//	get => throw new NotImplementedException();
//}


///// <inheritdoc />
//protected override void ConfigureInheritance()
//{
//	//this.Link2(() => Dot, t => t.DefaultText);

//	//this.Link(t => t.DefaultText, x => x.)
//	//this.AddInheritanceConfigurationMap(
//	//	t => t.DefaultText, t => t.);
//}









//protected abstract void ConfigureInheritance();
//{
//	addInheritanceConfigurationMap(
//		t => t.)
//}


//protected void Link<TAncestor>(
//	Expression<Func<TBase, TAncestor>> _mapping,
//	Expression<Func<TAncestor, TBase>> _reverseMapping)
//		where TAncestor
//			: InheritingCodeColorizationLayer<TBase>
//{

//}
//protected void Link2<TAncestor>(
//	Expression<Func<TAncestor>> _reverseMapping,
//	Expression<Func<TAncestor, TBase>> _mapping)
//		where TAncestor
//			: InheritingCodeColorizationLayer<TBase>
//{

//}
//protected void LinkAncestor(
//	Expression<Action<LanguageDefaultsColorizationLayer.CodeColorization>> _mapping,
//	Expression<Func<TBaseCodeColorizationLayer, LanguageDefaultsColorizationLayer.CodeColorization>> _mappingr)
//{

//}

//protected void AddInheritanceConfigurationMap(
//	Expression<Func<TBaseCodeColorizationLayer, LanguageDefaultsColorizationLayer.CodeColorization>> _mapping,
//	Expression<Func<TBaseCodeColorizationLayer, LanguageDefaultsColorizationLayer.CodeColorization>> _mappingr)
//{

//}



//public abstract IDictionary<
//	Expression<Func<CodeClassification>>,
//		Expression<Func<CodeClassification>>> InheritanceMaps{ get; }







/*	public enum ClassificationLanguage
{
	CSharp,
	XMLDocComment,
	Regex,
	IL,
	XML,
	XAML,
}

[Flags]
public enum CodeClassificationKind
{
	Language_CSharp,
	Language_IL,
	Language_XML,
	Language_XMLDocComment,
	Language_Regex,

	Scope_VisualStudio,
	Scope_ReSharper,

	CodeKind_Identifier,
	CodeKind_EscapeChar
}*/




//public enum TextAbstraction
//{
//	BackgroundInReadonlyFiles,
//	DefaultText,
//	DeletedText,
//	FoldedText,
//	FoldedTextWithHighlighting,
//	ReadonlyFragmentBackground,
//	SoftWrapSign,
//	WhiteSpace
//}

//public enum LanguageDefaults_BracesAndOperators
//{
//	Braces,
//	Brackets,
//	Comma,
//	Dot,
//	OperationSign,
//	Parenthesis,
//	Semicolon
//}

//public enum LanguageDefaults_Classes
//{
//	ClassName,
//	CaseeReference,
//	InstanceField,
//	InstanceMethod,
//	InterfaceField,
//	InterfaceMethod,
//	InterfaceName,
//	StaticField,
//	StaticMethod
//}

//public enum LanguageDefaults_Comments
//{
//	BlockComment,
//	DocComment,
//	DocCommentMarkup,
//	DocCommentTag,
//	DocCommentTagName,
//	DocCommentText,
//	LineComment
//}

//public enum LanguageDefaults_Identifiers
//{
//	Constants,
//	Default,
//	FunctionCall,
//	FunctionDeclaration,
//	GlobalVaribale,
//	Label,
//	LocalVariable,
//	Parameter,
//	PredefinedSymbol,
//	ReassignedLocalVariable,
//	ReassignedParameter
//}