using System;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.Introspective.Infrastructure.Context
{
	public class IntrospectiveInstanceContext : IntrospectiveContext
	{
		private readonly object _targetObject;

		private Type _targetType;
		

		protected internal override Type TargetType
		{
			get
			{
				return _targetType ?? (
					_targetType = _targetObject.GetType());
			}
		}

		protected internal override object TargetObject => _targetObject;
		

		public IntrospectiveInstanceContext(
			[NotNull] object targetObject)
		{
			targetObject.IsNotNull(nameof(targetObject));

			_targetObject = targetObject;
		}
	}
}
