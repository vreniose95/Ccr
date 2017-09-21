using System;
using Ccr.Core.Extensions;
using Ccr.Introspective.Infrastructure.Context;
using JetBrains.Annotations;
using MemberDescriptor = Ccr.Introspective.Infrastructure.MemberDescriptor;

namespace Ccr.Introspective.Extensions
{
	public static class IntrospectiveContextFieldExtensions
	{
		public static void SetFieldValue<TValue>(
			[NotNull] this IntrospectiveContext @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[NotNull] string fieldName,
			[CanBeNull] TValue value)
		{
			@this.IsNotNull(nameof(@this));
			memberDescriptor.IsNotNull(nameof(memberDescriptor));
			fieldName.IsNotNull(nameof(fieldName));

			var ownerType = @this.GetType();
			var fieldInfo = ownerType.GetField(fieldName, memberDescriptor);

			if (fieldInfo == null)
				throw new MissingMemberException(ownerType.Name, nameof(fieldName));


			var fieldType = fieldInfo.FieldType;
			var valueType = typeof(TValue);

			if (value != null && !valueType.IsValueType)
			{
				var defaultValue = valueType.GetDefaultValue();
			}
			if (value == null || value.GetType().IsValueType)
			{
				fieldInfo.SetValue(@this, null);
			}
			fieldInfo.SetValue(@this, value);
			
			//if (!fieldType.IsAssignableFrom(valueType))
			//var adjustedValue = value;
			//throw new InvalidCastException($"Cannot cast property value \'{returnVal.GetType().Name}\' to {typeof(TResult).Name}");
		}

		public static object GetFieldValue(
			[NotNull] this IntrospectiveContext @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[NotNull] string fieldName)
		{
			return @this.GetFieldValue<object>(
				memberDescriptor,
				fieldName);
		}

		public static TValue GetFieldValue<TValue>(
			[NotNull] this IntrospectiveContext @this,
			[NotNull] MemberDescriptor memberDescriptor,
			[NotNull] string fieldName)
		{
			@this.IsNotNull(nameof(@this));
			memberDescriptor.IsNotNull(nameof(memberDescriptor));
			fieldName.IsNotNull(nameof(fieldName));

			var ownerType = @this.TargetType;
			var fieldInfo = ownerType.GetField(fieldName, memberDescriptor);

			if (fieldInfo == null)
				throw new MissingMemberException(ownerType.Name, nameof(fieldName));


			var fieldType = fieldInfo.FieldType;
			var valueType = typeof(TValue);

			var rawValue = fieldInfo.GetValue(@this.TargetObject);
			return (TValue) rawValue;

			//if (!fieldType.IsAssignableFrom(valueType))
			//var adjustedValue = value;
			//throw new InvalidCastException($"Cannot cast property value \'{returnVal.GetType().Name}\' to {typeof(TResult).Name}");
		}
	}
}
