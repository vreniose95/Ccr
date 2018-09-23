using System;
using System.Collections.Generic;

namespace Ccr.Core.Collections
{
	[Serializable]
  public struct BijectiveIsomorphicMorphism<TA, TB>
    : IBijectiveMorphism<TA, TB>
  {
    public TA A { get; }

    public TB B { get; }


    public BijectiveIsomorphicMorphism<TB, TA> InverseMorphism
    {
      get => new BijectiveIsomorphicMorphism<TB, TA>(B, A);
    }

    IBijectiveMorphism<TB, TA> IBijectiveMorphism<TA, TB>.BijectiveInverse
    {
      get => InverseMorphism;
    }

    IIsomorphicMorphism<TB, TA> IIsomorphicMorphism<TA, TB>.IsomorphicInverse
    {
      get => InverseMorphism;
    }


    public BijectiveIsomorphicMorphism(TA a, TB b)
    {
      A = a;
      B = b;
    }


    public static implicit operator KeyValuePair<TA, TB>(
      BijectiveIsomorphicMorphism<TA, TB> @this)
    {
      return new KeyValuePair<TA, TB>(
        @this.A,
        @this.B);
    }

    public static implicit operator BijectiveIsomorphicMorphism<TA, TB>(
      KeyValuePair<TA, TB> @this)
    {
      return new BijectiveIsomorphicMorphism<TA, TB>(
        @this.Key,
        @this.Value);
    }


    public TB Evaluate(TA a)
    {
      return B;
    }

    public TA EvaluateInverse(TB b)
    {
      return A;
    }

    public override string ToString()
    {
      return $"[{A}, {B}]";
    }
  }
}