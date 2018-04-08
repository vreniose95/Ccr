using System;

namespace Ccr.Core.Extensions
{
  public static class MathExtensions
  {
    /// <inheritdoc cref="Math.Abs(sbyte)"/>
    public static sbyte Abs(
      this sbyte @this)
    {
      return Math.Abs(@this);
    }

    /// <inheritdoc cref="Math.Abs(short)"/>
    public static short Abs(
      this short @this)
    {
      return Math.Abs(@this);
    }

    /// <inheritdoc cref="Math.Abs(int)"/>
    public static int Abs(
      this int @this)
    {
      return Math.Abs(@this);
    }

    /// <inheritdoc cref="Math.Abs(long)"/>
    public static long Abs(
      this long @this)
    {
      return Math.Abs(@this);
    }

    /// <inheritdoc cref="Math.Abs(float)"/>
    public static float Abs(
      this float @this)
    {
      return Math.Abs(@this);
    }

    /// <inheritdoc cref="Math.Abs(double)"/>
    public static double Abs(
      this double @this)
    {
      return Math.Abs(@this);
    }

    /// <inheritdoc cref="Math.Abs(decimal)"/>
    public static decimal Abs(
      this decimal @this)
    {
      return Math.Abs(@this);
    }


    /// <inheritdoc cref="Math.Acos(double)"/>
    public static double Acos(
      this double @this)
    {
      return Math.Acos(@this);
    }

    /// <inheritdoc cref="Math.Asin(double)"/>
    public static double Asin(
      this double @this)
    {
      return Math.Asin(@this);
    }

    /// <inheritdoc cref="Math.Atan(double)"/>
    public static double Atan(
      this double @this)
    {
      return Math.Atan(@this);
    }



    /// <inheritdoc cref="Math.Ceiling(decimal)"/>
    public static decimal Ceiling(
      this decimal @this)
    {
      return Math.Ceiling(@this);
    }

    /// <inheritdoc cref="Math.Ceiling(double)"/>
    public static double Ceiling(
      this double @this)
    {
      return Math.Ceiling(@this);
    }


    /// <inheritdoc cref="Math.Cos(double)"/>
    public static double Cos(
      this double @this)
    {
      return Math.Cos(@this);
    }

    /// <inheritdoc cref="Math.Cosh(double)"/>
    public static double HyperbolicCos(
      this double @this)
    {
      return Math.Cosh(@this);
    }


    /// <inheritdoc cref="Math.Floor(decimal)"/>
    public static decimal Floor(
      this decimal @this)
    {
      return Math.Floor(@this);
    }

    /// <inheritdoc cref="Math.Floor(double)"/>
    public static double Floor(
      this double @this)
    {
      return Math.Floor(@this);
    }



    /// <inheritdoc cref="Math.Sin(double)"/>
    public static double Sin(
      this double @this)
    {
      return Math.Sin(@this);
    }

    /// <inheritdoc cref="Math.Tan(double)"/>
    public static double Tan(
      this double @this)
    {
      return Math.Tan(@this);
    }

    /// <inheritdoc cref="Math.Sinh(double)"/>
    public static double HyperbolicSin(
      this double @this)
    {
      return Math.Sinh(@this);
    }

    /// <inheritdoc cref="Math.Sinh(double)"/>
    public static double HyperbolicTan(
      this double @this)
    {
      return Math.Tanh(@this);
    }





    /// <inheritdoc cref="Math.Log(double,double)"/>
    public static double Log(
      this double @this,
      double newBase)
    {
      return Math.Log(
        @this,
        newBase);
    }

    /// <inheritdoc cref="Math.BigMul(int,int)"/>
    public static long BigMul(
      this int @this,
      int value)
    {
      return Math.BigMul(
        @this,
        value);
    }

    /// <inheritdoc cref="Math.DivRem(int,int,out int)"/>
    public static int DivRem(
      this int @this,
      int value,
      out int result)
    {
      return Math.DivRem(
        @this,
        value,
        out result);
    }

    /// <inheritdoc cref="Math.DivRem(long,long,out long)"/>
    public static long DivRem(
      this long @this,
      long value,
      out long result)
    {
      return Math.DivRem(
        @this,
        value,
        out result);
    }


  }
}
