namespace Ccr.Algorithms.Collections
{
	public sealed class SequentialQuad<TValue>
		: SequentialSet<TValue>
	{
		[SequentialSetValue(0)]
		public TValue Value1 { get; }

		[SequentialSetValue(1)]
		public TValue Value2 { get; }

		[SequentialSetValue(2)]
		public TValue Value3 { get; }

		[SequentialSetValue(3)]
		public TValue Value4 { get; }

		public SequentialPair<TValue> Center
		{
			get => new SequentialPair<TValue>(
				Value2,
				Value3);
		}


		public SequentialQuad(
			TValue value1,
			TValue value2,
			TValue value3,
			TValue value4)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
			Value4 = value4;
		}


		public static implicit operator (TValue a, TValue b, TValue c, TValue d)(
			SequentialQuad<TValue> @this)
		{
			return (
				@this.Value1,
				@this.Value2,
				@this.Value3,
				@this.Value4);
		}
	}
}