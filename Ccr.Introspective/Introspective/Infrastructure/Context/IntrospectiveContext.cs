using System;

namespace Ccr.Introspective.Infrastructure.Context
{
	public abstract class IntrospectiveContext
	{
		protected internal abstract Type TargetType { get; }

		protected internal abstract object TargetObject { get; }
	}
}
