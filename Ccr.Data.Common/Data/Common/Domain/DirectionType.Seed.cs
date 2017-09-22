namespace Ccr.Data.Common.Domain
{
	public partial class DirectionType
	{
		public static DirectionType Cardinal
			= new DirectionType(01);

		public static DirectionType Ordinal
			= new DirectionType(02);
	}
}