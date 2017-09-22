namespace Ccr.Data.Common.Domain
{
	public partial class HonorificPrefixClassification
	{
		/// <summary>
		/// Courtesy Titles are titles that do not have legal significance but
		/// rather is used through custom or courtesy.
		/// </summary>
		public static HonorificPrefixClassification Courtesy_Titles
			= new HonorificPrefixClassification(01);

		public static HonorificPrefixClassification Formal_Titles
			= new HonorificPrefixClassification(02);

		public static HonorificPrefixClassification Academic_and_Professional_Titles
			= new HonorificPrefixClassification(03);

		public static HonorificPrefixClassification Relgious_Titles
			= new HonorificPrefixClassification(04);

		public static HonorificPrefixClassification Military_and_Law_Enforcement_Titles
			= new HonorificPrefixClassification(05);
	}
}
