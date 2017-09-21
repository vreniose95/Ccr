using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
	public static class EnumExtensions
	{
		public static Dictionary<int, string> ToDictionary(
			this Enum @this)
		{
			var _type = @this.GetType();

			return Enum.GetValues(
					_type)
				.Cast<int>()
				.ToDictionary(
					t => t,
					t => Enum.GetName(_type, t));
		}

		public static IEnumerable<T> GetValues<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<T>();
		}

		public static TUnderlyingType Add<TUnderlyingType>(
			this Enum @this,
			TUnderlyingType newItem)
		{
			var _type = @this.GetType();
			
			var runtimeTypeManipulator = 
				new EnumRuntimeTypeManipulator(
					_type,
					typeof(TUnderlyingType));

			throw new NotImplementedException();
		}

		public static bool Remove<TUnderlyingType>(
			this Enum @this,
			TUnderlyingType newItem)
		{
			var _type = @this.GetType();
			//var parsedItem = new ValueParser()
			throw new NotImplementedException();
		}


		internal class EnumRuntimeTypeManipulator
		{
			private Type _enumType;
			private Type _underlyingType;


			[NotNull]
			internal Type EnumType
			{
				[NotNull] get => _enumType;
				[NotNull]
				set
				{
					value.IsNotNull(nameof(value));

					if (!value.GetTypeInfo().IsEnum)
						throw new ArgumentException(
							$"The Type {value.FormatName().SQuote()} cannot be " +
							$"assigned to property \'EnumType\' because it is not " +
							$"an enumeration type.");

					_enumType = value;
				}

			}

			internal Type UnderlyingType
			{
				[NotNull] get => _underlyingType;
				[NotNull]
				set
				{
					value.IsNotNull(nameof(value));

					if (!value.IsIntegralType())
						throw new ArgumentException(
							$"The Type {value.FormatName().SQuote()} cannot be " +
							$"assigned to property \'UnderlyingType\' because it is not " +
							$"an integral type.");

					_underlyingType = value;
				}
			}


			public EnumRuntimeTypeManipulator(
				Type enumType,
				Type underlyingType)
			{
				EnumType = enumType;
				UnderlyingType = underlyingType;
			}
		}

		internal class EnumRuntimeTypeManipulator<TEnumType>
			: EnumRuntimeTypeManipulator
		{
			public EnumRuntimeTypeManipulator() : base(
				typeof(TEnumType),
				Enum.GetUnderlyingType(typeof(TEnumType)))
			{
			}

			public EnumRuntimeTypeManipulator(
				Type underlyingType) : base(
					typeof(TEnumType),
					underlyingType)
			{
			}
		}

		internal class EnumRuntimeTypeManipulator<TEnumType, TUnderlyingType>
			: EnumRuntimeTypeManipulator
		{
			public EnumRuntimeTypeManipulator() : base(
				typeof(TEnumType),
				typeof(TUnderlyingType))
			{
			}
		}
	}
}
