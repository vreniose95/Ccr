using System.Reflection;

namespace Ccr.Introspective.Infrastructure
{
	/// <summary>
	/// Defines the declaration scope of the member (Static, Instance, or Any)
	/// </summary>
	public enum MemberScope
	{
		Instance	=		BindingFlags.Instance,
		Static		=		BindingFlags.Static,
		Any				=		Instance | Static
	}
}
