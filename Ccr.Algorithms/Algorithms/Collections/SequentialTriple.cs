namespace Ccr.Algorithms.Collections
{
	public sealed class SequentialTriple<TValue>
		: SequentialSet<TValue>
	{
		[SequentialSetValue(0)]
		public TValue Value1 { get; }

		[SequentialSetValue(1)]
		public TValue Value2 { get; }

		[SequentialSetValue(2)]
		public TValue Value3 { get; }


		public SequentialTriple(
			TValue value1,
			TValue value2,
			TValue value3)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
		}


		public static implicit operator (TValue a, TValue b, TValue c)(
			SequentialTriple<TValue> @this)
		{
			return (
				@this.Value1,
				@this.Value2,
				@this.Value3);
		}


		public SequentialQuad<TValue> PrependValue(
			TValue firstValue)
		{
			return new SequentialQuad<TValue>(
				firstValue,
				Value1,
				Value2,
				Value3);
		}

		public SequentialQuad<TValue> AppendValue(
			TValue lastValue)
		{
			return new SequentialQuad<TValue>(
				Value1,
				Value2,
				Value3,
				lastValue);
		}
	}
}