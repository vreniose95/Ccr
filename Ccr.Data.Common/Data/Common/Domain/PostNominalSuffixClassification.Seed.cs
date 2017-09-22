namespace Ccr.Data.Common.Domain
{
	public partial class PostNominalSuffixClassification
	{
		public static PostNominalSuffixClassification Academic_Suffixes
			= new PostNominalSuffixClassification(01);
		
		public static PostNominalSuffixClassification Law_Suffixes
			= new PostNominalSuffixClassification(02);

		public static PostNominalSuffixClassification Generational_Western_Suffixes
			= new PostNominalSuffixClassification(03);

		public static PostNominalSuffixClassification Generational_Roman_Suffixes
			= new PostNominalSuffixClassification(04);

		public static PostNominalSuffixClassification Military_Suffixes
			= new PostNominalSuffixClassification(05);

	}
}
