using System;

namespace Ccr.Core.Extensions
{
  public static class MathExtensions
  {
    #region Absolute Value Extension Methods
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

    #endregion

    #region Trigonometry Functions and Variants
    /// <inheritdoc cref="Math.Sin(double)"/>
    public static double Sin(
      this double @this)
    {
      return Math.Sin(@this);
    }

    /// <inheritdoc cref="Math.Sinh(double)"/>
    public static double HyperbolicSin(
      this double @this)
    {
      return Math.Sinh(@this);
    }

    /// <inheritdoc cref="Math.Asin(double)"/>
    public static double Asin(
      this double @this)
    {
      return Math.Asin(@this);
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

    /// <inheritdoc cref="Math.Acos(double)"/>
    public static double Acos(
      this double @this)
    {
      return Math.Acos(@this);
    }


    /// <inheritdoc cref="Math.Tan(double)"/>
    public static double Tan(
      this double @this)
    {
      return Math.Tan(@this);
    }
    /// <inheritdoc cref="Math.Tanh(double)"/>
    public static double HyperbolicTan(
      this double @this)
    {
      return Math.Tanh(@this);
    }

    /// <inheritdoc cref="Math.Atan(double)"/>
    public static double Atan(
      this double @this)
    {
      return Math.Atan(@this);
    }

    #endregion

    #region Floor and Ceiling Functions
    /// <inheritdoc cref="Math.Ceiling(double)"/>
    public static double Ceiling(
      this double @this)
    {
      return Math.Ceiling(@this);
    }

    /// <inheritdoc cref="Math.Ceiling(decimal)"/>
    public static decimal Ceiling(
      this decimal @this)
    {
      return Math.Ceiling(@this);
    }


    /// <inheritdoc cref="Math.Floor(double)"/>
    public static double Floor(
      this double @this)
    {
      return Math.Floor(@this);
    }

    /// <inheritdoc cref="Math.Floor(decimal)"/>
    public static decimal Floor(
      this decimal @this)
    {
      return Math.Floor(@this);
    }

    #endregion

    #region Rounding Functions
    /// <inheritdoc cref="Math.Round(double)"/>
    public static double Round(
      this double @this)
    {
      return Math.Round(@this);
    }

    /// <inheritdoc cref="Math.Round(double,int)"/>
    public static double Round(
      this double @this,
      int digits)
    {
      return Math.Round(@this);
    }

    /// <inheritdoc cref="Math.Round(double,MidpointRounding)"/>
    public static double Round(
      this double @this,
      MidpointRounding mode)
    {
      return Math.Round(
        @this,
        mode);
    }

    /// <inheritdoc cref="Math.Round(double,int,MidpointRounding)"/>
    public static double Round(
      this double @this,
      int digits,
      MidpointRounding mode)
    {
      return Math.Round(
        @this,
        digits,
        mode);
    }


    /// <inheritdoc cref="Math.Round(decimal)"/>
    public static decimal Round(
      this decimal @this)
    {
      return Math.Round(@this);
    }

    /// <inheritdoc cref="Math.Round(decimal,int)"/>
    public static decimal Round(
      this decimal @this,
      int digits)
    {
      return Math.Round(@this);
    }

    /// <inheritdoc cref="Math.Round(decimal,MidpointRounding)"/>
    public static decimal Round(
      this decimal @this,
      MidpointRounding mode)
    {
      return Math.Round(
        @this,
        mode);
    }

    /// <inheritdoc cref="Math.Round(decimal,int,MidpointRounding)"/>
    public static decimal Round(
      this decimal @this,
      int digits,
      MidpointRounding mode)
    {
      return Math.Round(
        @this,
        digits,
        mode);
    }

    #endregion

    #region Truncation Functions
    /// <inheritdoc cref="Math.Truncate(decimal)"/>
    public static decimal Truncate(
      this decimal @this)
    {
      return Math.Truncate(@this);
    }

    /// <inheritdoc cref="Math.Truncate(double)"/>
    public static double Truncate(
      this double @this)
    {
      return Math.Truncate(@this);
    }

    #endregion

    #region Exponentially Related Functions
    /// <inheritdoc cref="Math.Exp(double)"/>
    public static double Exp(
      this double @this)
    {
      return Math.Exp(@this);
    }

    /// <inheritdoc cref="Math.Pow(double,double)"/>
    public static double Power(
      this double @this,
      double power)
    {
      return Math.Pow(
        @this,
        power);
    }
    /// <inheritdoc cref="Math.Sqrt(double)"/>
    public static double Sqrt(
      this double @this)
    {
      return Math.Sqrt(@this);
    }

    #endregion

    #region Logarithmically Related Functions
    /// <inheritdoc cref="Math.Log(double)"/>
    public static double Log(
      this double @this)
    {
      return Math.Log(@this);
    }

    /// <inheritdoc cref="Math.Log10(double)"/>
    public static double Log10(
      this double @this)
    {
      return Math.Log10(@this);
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

    #endregion

    #region Integral Multiplication/Division and Remainder/Quotient Functions
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

    /// <inheritdoc cref="Math.IEEERemainder(double,double)"/>
    public static double IEEERemainder(
      this double @this,
      double dividend)
    {
      return Math.IEEERemainder(
        @this,
        dividend);
    }

    #endregion

  }
}
