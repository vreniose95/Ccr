using System;
using Ccr.Introspective.Infrastructure.Context;

namespace Ccr.Introspective.Extensions
{
	public static class IntrospectiveExtensions
	{
		public static IntrospectiveContext Reflect(
			this object @this)
		{
			var context = @this as Type;
			if (context != null)
				return new IntrospectiveStaticContext(context);

			return new IntrospectiveInstanceContext(@this);
		}
		public static IntrospectiveStaticContext Reflect(
			this Type @this)
		{
				return new IntrospectiveStaticContext(@this);
		}


		//public static IntrospectiveStaticContext<TValue> Reflect<TValue>(
		//	this TValue @this)
		//{
		//	return new IntrospectiveStaticContext<TValue>();
		//}




	}
}
