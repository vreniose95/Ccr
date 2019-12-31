using System;
using System.Collections.Generic;

namespace Ccr.Std.Core.Collections
{
	[Serializable]
	public struct BijectiveHomomorphicMorphism<T>
		: IBijectiveHomomorphicMorphism<T>
	{
		public T A { get; }

		public T B { get; }


		public BijectiveHomomorphicMorphism<T> InverseMorphism
		{
			get => new BijectiveHomomorphicMorphism<T>(B, A);
		}

		IBijectiveMorphism<T, T> IBijectiveMorphism<T, T>.BijectiveInverse
		{
			get => InverseMorphism;
		}

		IIsomorphicMorphism<T, T> IIsomorphicMorphism<T, T>.IsomorphicInverse
		{
			get => InverseMorphism;
		}

		IBijectiveHomomorphicMorphism<T> IBijectiveHomomorphicMorphism<T>.BijectiveHomomorphicInverse
		{
			get => InverseMorphism;
		}

		public BijectiveHomomorphicMorphism(T a, T b)
		{
			A = a;
			B = b;
		}


		public static implicit operator KeyValuePair<T, T>(
			BijectiveHomomorphicMorphism<T> @this)
		{
			return new KeyValuePair<T, T>(
				@this.A,
				@this.B);
		}

		public static implicit operator BijectiveHomomorphicMorphism<T>(
			KeyValuePair<T, T> @this)
		{
			return new BijectiveHomomorphicMorphism<T>(
				@this.Key,
				@this.Value);
		}


		public T Evaluate(T a)
		{
			return B;
		}

		public T EvaluateInverse(T b)
		{
			return A;
		}

		public override string ToString()
		{
			return $"[{A}, {B}]";
		}
	}
}