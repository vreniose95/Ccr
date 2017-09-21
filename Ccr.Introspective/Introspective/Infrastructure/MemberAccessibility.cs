using System.Reflection;

namespace Ccr.Introspective.Infrastructure
{
	public enum MemberAccessibility
	{
		Public		=		BindingFlags.Public,
		NonPublic	=		BindingFlags.NonPublic,
		Any				=		Public | NonPublic
	}
}
