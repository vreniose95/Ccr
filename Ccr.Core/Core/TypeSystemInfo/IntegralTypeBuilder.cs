using System;
using System.Runtime.InteropServices;
using Ccr.Core.Extensions;

namespace Ccr.Core.TypeSystemInfo
{
	internal static class IntegralTypeBuilder
	{
		private const string minValueFieldName = "MinValue";

		private const string maxValueFieldName = "MaxValue";

		

		private static IntegralTypeValueRange buildValueRange(
			Type systemType)
		{
			var minValue = systemType
				.GetField(minValueFieldName)
				.GetValue(null)
				.IsOfType<long>();

			var maxValue = systemType
				.GetField(maxValueFieldName)
				.GetValue(null)
				.IsOfType<ulong>();

			var valueRange = new IntegralTypeValueRange(
				minValue,
				maxValue);

			return valueRange;
		}

		private static IntegralTypeSize buildTypeSize(
			Type systemType)
		{
			var minValue = systemType
				.GetField(minValueFieldName)
				.GetValue(null)
				.IsOfType<long>();

			var signedness = minValue == 0
				? Signedness.Unsigned
				: Signedness.Signed;

			var byteSize = Marshal.SizeOf(systemType);
			var bits = byteSize * 8;

			var integralTypeSize = new IntegralTypeSize(
				signedness,
				bits);

			return integralTypeSize;
		}



		public static IntegralTypeInfo Build(
			Type systemType)
		{
			if(!IntegralTypeReference.IsIntegralType(systemType))
				throw new ArgumentException(
					$"{systemType.Name.SQuote()} is not valid for the argument systemType " +
					$"for an \'IntegralType\' because it is not an integral type.");

			var valueRange = buildValueRange(systemType);
			var integralTypeSize = buildTypeSize(systemType);

			return new IntegralTypeInfo(
				systemType,
				valueRange,
				integralTypeSize);
		}

		public static IntegralTypeInfo Build<TSystemType>()
			where TSystemType : struct
		{
			return Build(typeof(TSystemType));
		}
	}
}
/*		public static IntegralTypeInfo Build1<TSystemType>()
			where TSystemType : struct
		{
			var systemType = typeof(TSystemType);

			var minValue = systemType
				.GetField(minValueFieldName)
				.GetValue(null)
				.IsOfType<long>();

			var maxValue = systemType
				.GetField(maxValueFieldName)
				.GetValue(null)
				.IsOfType<ulong>();

			var valueRange = new IntegralTypeValueRange(
				minValue,
				maxValue);


			var signedness = minValue == 0
				? Signedness.Unsigned
				: Signedness.Signed;

			var byteSize = Marshal.SizeOf<TSystemType>();
			var bits = byteSize * 8;

			var integralTypeSize = new IntegralTypeSize(
				signedness,
				bits);


			return new IntegralTypeInfo(
				systemType,
				valueRange,
				integralTypeSize);
		}*/
