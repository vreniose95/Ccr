namespace Ccr.Data.Common.Domain
{
	public partial class PostNominalSuffix
	{
		public static PostNominalSuffix JurisDoctor = new PostNominalSuffix(01,
			PostNominalSuffixClassification.Law_Suffixes, 
			LinguisticGender.Neuter,
			"JD.");

		public static PostNominalSuffix Esquire = new PostNominalSuffix(02,
			PostNominalSuffixClassification.Law_Suffixes,
			LinguisticGender.Neuter,
			"Esq.");


		public static PostNominalSuffix Doctor_Of_Psychology = new PostNominalSuffix(03,
			PostNominalSuffixClassification.Academic_Suffixes,
			LinguisticGender.Neuter,
			"Psy.D");

		public static PostNominalSuffix Doctor_Of_Philosophy = new PostNominalSuffix(04,
			PostNominalSuffixClassification.Academic_Suffixes,
			LinguisticGender.Neuter,
			"Ph.D");

		public static PostNominalSuffix Doctor_Of_Medicine = new PostNominalSuffix(05,
			PostNominalSuffixClassification.Academic_Suffixes,
			LinguisticGender.Neuter,
			"M.D");


		public static PostNominalSuffix United_States_Army = new PostNominalSuffix(06,
			PostNominalSuffixClassification.Military_Suffixes,
			LinguisticGender.Neuter,
			"USA");

		public static PostNominalSuffix United_States_Army_Reserves = new PostNominalSuffix(07,
			PostNominalSuffixClassification.Military_Suffixes,
			LinguisticGender.Neuter,
			"USAR");

		public static PostNominalSuffix United_States_Navy = new PostNominalSuffix(08,
			PostNominalSuffixClassification.Military_Suffixes,
			LinguisticGender.Neuter,
			"USN");

		public static PostNominalSuffix United_States_Navy_Reserve = new PostNominalSuffix(09,
			PostNominalSuffixClassification.Military_Suffixes,
			LinguisticGender.Neuter,
			"USNR");

		public static PostNominalSuffix United_States_Air_Force = new PostNominalSuffix(10,
			PostNominalSuffixClassification.Military_Suffixes,
			LinguisticGender.Neuter,
			"USAF");

		public static PostNominalSuffix United_States_Marine_Corps = new PostNominalSuffix(11,
			PostNominalSuffixClassification.Military_Suffixes,
			LinguisticGender.Neuter,
			"USMC");

		public static PostNominalSuffix United_States_Coast_Guard = new PostNominalSuffix(12,
			PostNominalSuffixClassification.Military_Suffixes,
			LinguisticGender.Neuter,
			"USCG");

		public static PostNominalSuffix Retired = new PostNominalSuffix(13,
			PostNominalSuffixClassification.Military_Suffixes,
			LinguisticGender.Neuter,
			"(Ret.)");


		public static PostNominalSuffix Junior = new PostNominalSuffix(14,
			PostNominalSuffixClassification.Generational_Western_Suffixes,
			LinguisticGender.Masculine,
			"Jr.");

		public static PostNominalSuffix Senior = new PostNominalSuffix(15,
			PostNominalSuffixClassification.Generational_Western_Suffixes,
			LinguisticGender.Masculine,
			"Jr.");


		public static PostNominalSuffix I = new PostNominalSuffix(16,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"I");

		public static PostNominalSuffix II = new PostNominalSuffix(17,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"II");

		public static PostNominalSuffix III = new PostNominalSuffix(18,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"III");

		public static PostNominalSuffix IV = new PostNominalSuffix(19,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"IV");

		public static PostNominalSuffix V = new PostNominalSuffix(20,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"V");

		public static PostNominalSuffix VI = new PostNominalSuffix(21,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"VI");

		public static PostNominalSuffix VII = new PostNominalSuffix(22,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"VII");

		public static PostNominalSuffix VIII = new PostNominalSuffix(23,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"VIII");

		public static PostNominalSuffix IX = new PostNominalSuffix(24,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"IX");

		public static PostNominalSuffix X = new PostNominalSuffix(25,
			PostNominalSuffixClassification.Generational_Roman_Suffixes,
			LinguisticGender.Masculine,
			"X");

	}
}
