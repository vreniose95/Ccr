using System;

namespace Ccr.Std.Introspective.Infrastructure.Context
{
	public abstract class IntrospectiveContext
	{
		protected internal abstract Type TargetType { get; }

		protected internal abstract object TargetObject { get; }
	}
}
