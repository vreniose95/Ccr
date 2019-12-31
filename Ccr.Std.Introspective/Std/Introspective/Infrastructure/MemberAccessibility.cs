using System.Reflection;

namespace Ccr.Std.Introspective.Infrastructure
{
	public enum MemberAccessibility
	{
		Public =	BindingFlags.Public,
		NonPublic	=	BindingFlags.NonPublic,
		Any =	Public | NonPublic
	}
}
