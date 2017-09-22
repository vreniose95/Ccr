namespace Ccr.Data.Common.Domain
{
	public partial class Predirectional
	{
		public static Predirectional North
			= new Predirectional(01, "N", DirectionType.Cardinal);

		public static Predirectional Northeast
			= new Predirectional(02, "NE", DirectionType.Ordinal);

		public static Predirectional East
			= new Predirectional(03, "E", DirectionType.Cardinal);

		public static Predirectional Southeast
			= new Predirectional(04, "SE", DirectionType.Ordinal);

		public static Predirectional South
			= new Predirectional(05, "S", DirectionType.Cardinal);

		public static Predirectional Southwest
			= new Predirectional(06, "SW", DirectionType.Ordinal);

		public static Predirectional West
			= new Predirectional(07, "W", DirectionType.Cardinal);

		public static Predirectional Northwest
			= new Predirectional(08, "NW", DirectionType.Ordinal);
	}
}