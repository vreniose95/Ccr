namespace Ccr.Introspective.Infrastructure
{
	public partial class MemberDescriptor
	{
		public static MemberDescriptor Public = new MemberDescriptor(MemberAccessibility.Public);

		public static MemberDescriptor NonPublic = new MemberDescriptor(MemberAccessibility.NonPublic);

		public static MemberDescriptor PublicStatic = new MemberDescriptor(MemberAccessibility.Public, MemberScope.Static);

		public static MemberDescriptor NonPublicStatic = new MemberDescriptor(MemberAccessibility.NonPublic, MemberScope.Static);

		public static MemberDescriptor AnyStatic = new MemberDescriptor(MemberAccessibility.Any, MemberScope.Static);

		public static MemberDescriptor Any = new MemberDescriptor(MemberAccessibility.Any, MemberScope.Any);


		public static MemberDescriptor PublicIgnoreCase = new MemberDescriptor(MemberAccessibility.Public, caseInsensitive: true);

		public static MemberDescriptor NonPublicIgnoreCase = new MemberDescriptor(MemberAccessibility.NonPublic, caseInsensitive: true);

		public static MemberDescriptor PublicStaticIgnoreCase = new MemberDescriptor(MemberAccessibility.Public, MemberScope.Static, true);

		public static MemberDescriptor NonPublicStaticIgnoreCase = new MemberDescriptor(MemberAccessibility.NonPublic, MemberScope.Static, true);

		public static MemberDescriptor AnyStaticIgnoreCase = new MemberDescriptor(MemberAccessibility.Any, MemberScope.Static, true);

		public static MemberDescriptor AnyIgnoreCase = new MemberDescriptor(MemberAccessibility.Any, MemberScope.Any, true);
	}
}
