using System;
using System.Runtime.InteropServices;
using Ccr.Std.Core.Extensions;

namespace Ccr.Std.Core.TypeSystemInfo.IntegralTypes
{
	internal static class IntegralTypeBuilder
	{
		private const string minValueFieldName = "MinValue";

		private const string maxValueFieldName = "MaxValue";


		public static IntegralTypeInfo Build(
			Type systemType)
		{
			if (!IntegralTypeReference.IsIntegralType(systemType))
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

		private static IntegralTypeValueRange buildValueRange(
			Type systemType)
		{
			var minValue = systemType
				.GetField(minValueFieldName)
				.GetValue(null)
				.To<long>();

			var maxValue = systemType
				.GetField(maxValueFieldName)
				.GetValue(null)
				.To<ulong>();

			var valueRange = new IntegralTypeValueRange(
				minValue,
				maxValue, 
        systemType);

			return valueRange;
		}

		private static IntegralTypeSizeInfo buildTypeSize(
			Type systemType)
		{
			var minValue = systemType
				.GetField(minValueFieldName)
				.GetValue(null)
				.To<long>();

			var signedness = minValue == 0
				? Signedness.Unsigned
				: Signedness.Signed;

			var byteSize = Marshal.SizeOf(systemType);
			var bits = byteSize * 8;

			var integralTypeSize = new IntegralTypeSizeInfo(
				signedness,
				bits);

			return integralTypeSize;
		}
	}
}