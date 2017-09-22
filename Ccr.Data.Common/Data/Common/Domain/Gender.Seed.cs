namespace Ccr.Data.Common.Domain
{
	public partial class Gender
	{
		public static Gender Unset
			= new Gender(1, "U");

		public static Gender Male
			= new Gender(2, "M");

		public static Gender Female
			= new Gender(3, "F");
	}
}
