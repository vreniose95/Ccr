using System;
using System.Runtime.InteropServices;
using Ccr.Std.Core.Extensions;

namespace Ccr.Std.Core.TypeSystemInfo.NonIntegralTypes
{
  //internal class NonIntegralTypeBuilder
  //  : BuiltInTypeBuilder<>
  //{
  //  protected internal override BuiltInTypeInfo BuildBase(
  //    Type systemType)
  //  {

  //  }
  //}

  internal static class NonIntegralTypeBuilder
	{
		private const string minValueFieldName = "MinValue";

		private const string maxValueFieldName = "MaxValue";
		
    
		public static NonIntegralTypeInfo Build(
			Type systemType)
		{
			if (!TypeReference.IsNonIntegralType(systemType))
				throw new ArgumentException(
					$"{systemType.Name.SQuote()} is not valid for the argument systemType " +
					$"for an \'NonIntegralType\' because it is not a non-integral type.");

			var valueRange = buildValueRange(systemType);
			var nonIntegralTypeSize = buildTypeSize(systemType);

			return new NonIntegralTypeInfo(
				systemType,
				valueRange,
				nonIntegralTypeSize);
		}

		public static NonIntegralTypeInfo Build<TSystemType>()
			where TSystemType
        : struct
		{
			return Build(typeof(TSystemType));
		}

		private static NonIntegralTypeValueRange buildValueRange(
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

			var valueRange = new NonIntegralTypeValueRange(
				minValue,
				maxValue,
        systemType);

			return valueRange;
		}


		private static NonIntegralTypeSizeInfo buildTypeSize(
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

			var integralTypeSize = new NonIntegralTypeSizeInfo(
				signedness,
				bits);

			return integralTypeSize;
		}



	}
}
