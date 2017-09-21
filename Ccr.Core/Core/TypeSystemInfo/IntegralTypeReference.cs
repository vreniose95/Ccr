using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ccr.Core.Extensions;

namespace Ccr.Core.TypeSystemInfo
{
	public class IntegralTypeReference
	{
		private static readonly Type[] _integralTypesArray = {
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


		private static ReadOnlyCollection<Type> _integralTypes;
		public static IReadOnlyCollection<Type> IntegralTypes
		{
			get => _integralTypes ?? (
				       _integralTypes
					       = new ReadOnlyCollection<Type>(
						       _integralTypesArray));
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


		public static bool IsIntegralType(
			Type systemType)
		{
			return IntegralTypes
				.Contains(systemType);
		}


		//public static IntegralType[] IntegralTypeArray = {
		//		new IntegralType(typeof(sbyte), new IntegralTypeValueRange(-128, 127), new IntegralTypeSize(Signedness.Signed, 8)),
		//		IntegralTypeBuilder.Build<sbyte>(),


		//	};

	}
}
