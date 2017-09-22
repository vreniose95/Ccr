namespace Ccr.Data.Common.Domain
{
	public partial class HonorificPrefix
	{
		public static HonorificPrefix Mister = new HonorificPrefix(01,
			HonorificPrefixClassification.Courtesy_Titles,
			LinguisticGender.Masculine,
			"Mr.");

		public static HonorificPrefix Missus = new HonorificPrefix(02,
			HonorificPrefixClassification.Courtesy_Titles,
			LinguisticGender.Feminine,
			"Mrs.");

		public static HonorificPrefix Miss = new HonorificPrefix(03,
			HonorificPrefixClassification.Courtesy_Titles,
			LinguisticGender.Feminine,
			"Ms.");

		public static HonorificPrefix Sir = new HonorificPrefix(04,
			HonorificPrefixClassification.Courtesy_Titles,
			LinguisticGender.Masculine,
			"Sir");

		public static HonorificPrefix Madam = new HonorificPrefix(04,
			HonorificPrefixClassification.Courtesy_Titles,
			LinguisticGender.Feminine,
			"Madam");


		public static HonorificPrefix Doctor = new HonorificPrefix(05,
			HonorificPrefixClassification.Academic_and_Professional_Titles,
			LinguisticGender.Neuter,
			"Dr.");

		public static HonorificPrefix Professor = new HonorificPrefix(06,
			HonorificPrefixClassification.Academic_and_Professional_Titles,
			LinguisticGender.Neuter,
			"Prof.");


		public static HonorificPrefix Officer = new HonorificPrefix(07,
			HonorificPrefixClassification.Formal_Titles,
			LinguisticGender.Neuter,
			"Ofc.");

		public static HonorificPrefix Sergeant = new HonorificPrefix(08,
			HonorificPrefixClassification.Formal_Titles,
			LinguisticGender.Neuter,
			"Sgt.");


		public static HonorificPrefix Lieutenant = new HonorificPrefix(09,
			HonorificPrefixClassification.Military_and_Law_Enforcement_Titles,
			LinguisticGender.Neuter,
			"Lt.");

		public static HonorificPrefix Commander = new HonorificPrefix(10,
			HonorificPrefixClassification.Military_and_Law_Enforcement_Titles,
			LinguisticGender.Neuter,
			"Cdr.");

		public static HonorificPrefix Captain = new HonorificPrefix(11,
			HonorificPrefixClassification.Military_and_Law_Enforcement_Titles,
			LinguisticGender.Neuter,
			"Cpt.");

		public static HonorificPrefix General = new HonorificPrefix(12,
			HonorificPrefixClassification.Military_and_Law_Enforcement_Titles,
			LinguisticGender.Neuter,
			"Ltg.");
	}
}