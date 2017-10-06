using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ccr.Core.TypeSystemInfo.IntegralTypes;
// ReSharper disable ArrangeAccessorOwnerBody

namespace Ccr.Core.TypeSystemInfo
{
	public class TypeReference
	{
		private static readonly Type[] _referenceTypesArray = {
			typeof(bool),
#if !IS_CHAR_INTEGRAL_TYPE
			typeof(char),
#endif
			typeof(string)
		};

		internal static readonly Type[] _integralTypesArray = {
			typeof(sbyte),
			typeof(byte),
#if IS_CHAR_INTEGRAL_TYPE
			typeof(char),
#endif
			typeof(short),
			typeof(ushort),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong)

		};
		internal static readonly Type[] _nonIntegralTypesArray = {
			typeof(float),
			typeof(double),
			typeof(decimal)
		};



		private static ReadOnlyCollection<Type> _referenceTypes;
		public static IReadOnlyCollection<Type> ReferenceTypes
		{
			get => _referenceTypes ?? (
							 _referenceTypes
								 = new ReadOnlyCollection<Type>(
									 _referenceTypesArray));
		}


		private static ReadOnlyCollection<Type> _integralTypes;
		public static IReadOnlyCollection<Type> IntegralTypes
		{
			get => _integralTypes ?? (
							 _integralTypes
								 = new ReadOnlyCollection<Type>(
									 _integralTypesArray));
		}

		private static ReadOnlyCollection<Type> _nonIntegralTypes;
		public static IReadOnlyCollection<Type> NonIntegralTypes
		{
			get => _nonIntegralTypes ?? (
							 _nonIntegralTypes
								 = new ReadOnlyCollection<Type>(
									 _integralTypesArray));
		}

		private static ReadOnlyCollection<Type> _builtInTypes;
		public static IReadOnlyCollection<Type> BuiltInTypes
		{
			get => _builtInTypes ?? (
							 _builtInTypes
								 = new ReadOnlyCollection<Type>(
									 ReferenceTypes
										.Concat(IntegralTypes)
										.Concat(NonIntegralTypes)
										.ToArray()));
		}


		private static ReadOnlyCollection<IntegralTypeInfo> _referenceTypeInfos;
		public static IReadOnlyCollection<IntegralTypeInfo> ReferenceTypeInfos
		{
			get => _referenceTypeInfos ?? (
				       _referenceTypeInfos
								 = new ReadOnlyCollection<IntegralTypeInfo>(
									 IntegralTypes
										 .Select(IntegralTypeBuilder.Build)
										 .ToArray()));
		}


		private static ReadOnlyCollection<IntegralTypeInfo> _integralTypeInfos;
		public static IReadOnlyCollection<IntegralTypeInfo> IntegralTypeInfos
		{
			get => _integralTypeInfos ?? (
							 _integralTypeInfos
								 = new ReadOnlyCollection<IntegralTypeInfo>(
									 IntegralTypes
										 .Select(IntegralTypeBuilder.Build)
										 .ToArray()));
		}

	}
}
