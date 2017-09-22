namespace Ccr.Data.Common.Domain
{
	public partial class LinguisticGender
	{
		public static LinguisticGender Neuter
			= new LinguisticGender(1, "N");

		public static LinguisticGender Masculine
			= new LinguisticGender(2, "M");

		public static LinguisticGender Feminine
			= new LinguisticGender(3, "F");
	}
}
