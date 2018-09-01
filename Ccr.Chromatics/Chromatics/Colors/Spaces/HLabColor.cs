using System;
using System.Collections.Generic;
using Ccr.Chromatics.Colors.Infrastructure;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Chromatics.Colors.Spaces
{
  /// <inheritdoc cref="IVectorColorSpace"/>
  /// <summary>
  ///   The Hunter Lab color space.
  /// </summary>
  public struct HLabColor
    : IVectorColorSpace,
      IEquatable<HLabColor>
  {
    #region Fields
    /// <summary>
    ///   The default <see cref="XYZColor"/> WhitePoint Illuminant that is used when 
    ///   creating an instance of the <see cref="HLabColor"/> struct when the WhitePoint
    ///   parameter is not provided explicitly through the constructor argument.
    /// </summary>
    private static readonly XYZColor _defaultWhitePoint = Illuminants.C;

    #endregion


    #region Properties
    /// <summary>
    ///   Value indicating the Lightness channel value for the <see cref="HLabColor"/>
    /// </summary>
    /// <remarks>
    ///   This value must be between [0.00 to 100.00], inclusively.
    /// </remarks>
    public double L { get; }

    /// <summary>
    ///   Value indicating the A channel value for the <see cref="HLabColor"/>
    /// </summary>
    /// <remarks>
    ///   This value must be between [-100.00 to 100.00], inclusively.
    ///   Negative values indicate Green, while positive values indicate Magenta.
    /// </remarks>
    public double A { get; }

    /// <summary>
    ///   Value indicating the B channel value for the <see cref="HLabColor"/>
    /// </summary>
    /// <remarks>
    ///   This value must be between [-100.00 to 100.00], inclusively.
    ///   Negative values indicate Blue, while positive values indicate Yellow.
    /// </remarks>
    public double B { get; }


    /// <summary>
    ///   Value indicating the WhitePoint value for the <see cref="HLabColor"/>
    /// </summary>
    public XYZColor WhitePoint { get; }

    /// <summary>
    ///   Gets the <see cref="ColorChannelVector"/> for this <see cref="HLabColor"/>
    ///   instance that represents a vector <see cref="IReadOnlyList{T}"/>, where T
    ///   is <see cref="double"/>. This vector contains the values for the color channel
    ///   values [] { <see cref="L"/>, <see cref="A"/>, <see cref="B"/> }.
    /// </summary>
    public ColorChannelVector ColorChannelVector
    {
      get => new ColorChannelVector(L, A, B);
    }

    #endregion


    #region Constructors
    /// <inheritdoc/>
    /// <summary>
    ///   Creates an instance of the <see cref="HLabColor"/> struct with the color
    ///   channel <see cref="double"/> argument values <paramref name="l"/>,
    ///   <paramref name="a"/>, and <paramref name="b"/>.
    /// </summary>
    /// <param name="l">
    ///   Value indicating the Lightness (L) channel value for the <see cref="HLabColor"/>.
    ///   This value must be between [0.00 to 100.00], inclusively.
    /// </param>
    /// <param name="a">
    ///   Value indicating the A channel value for the <see cref="HLabColor"/>.
    ///   This value must be between [-100.00 to 100.00], inclusively.
    /// </param>
    /// <param name="b">
    ///   Value indicating the B channel value for the <see cref="HLabColor"/>.
    ///   This value must be between [-100.00 to 100.00], inclusively.
    /// </param>
    /// <remarks>
    ///   This constructor has no <see cref="XYZColor"/> parameter for the
    ///   <see cref="WhitePoint"/> property, and will use the value of the static readonly 
    ///   <see cref="_defaultWhitePoint"/> field.
    /// </remarks>
    public HLabColor(
      double l,
      double a,
      double b)
        : this(
          l,
          a,
          b,
          _defaultWhitePoint)
    {
    }

    /// <summary>
    ///   Creates an instance of the <see cref="HLabColor"/> struct with the color
    ///   channel <see cref="double"/> argument values <paramref name="l"/>,
    ///   <paramref name="a"/>, and <paramref name="b"/>, with an additional parameter
    ///   for specifying the <paramref name="whitePoint"/> for this instance.
    /// </summary>
    /// <param name="l">
    ///   Value indicating the Lightness (L) channel value for the <see cref="HLabColor"/>.
    ///   This value must be between [0.00 to 100.00], inclusively.
    /// </param>
    /// <param name="a">
    ///   Value indicating the A channel value for the <see cref="HLabColor"/>.
    ///   This value must be between [-100.00 to 100.00], inclusively.
    /// </param>
    /// <param name="b">
    ///   Value indicating the B channel value for the <see cref="HLabColor"/>.
    ///   This value must be between [-100.00 to 100.00], inclusively.
    /// </param>
    /// <param name="whitePoint">
    ///   A <see cref="XYZColor"/> value indicating the <see cref="Illuminant"/> which
    ///   indicates the reference white point for this instance.
    /// </param>
    public HLabColor(
      double l,
      double a,
      double b,
      XYZColor whitePoint)
    {
      l.ThrowIfNotWithin((0, 100), nameof(l));
      a.ThrowIfNotWithin((-100, 100), nameof(a));
      b.ThrowIfNotWithin((-100, 100), nameof(b));

      L = l;
      A = a;
      B = b;

      WhitePoint = whitePoint;
    }

    /// <inheritdoc/>
    /// <summary>
    ///   Creates an instance of the <see cref="HLabColor"/> struct from an instance of the
    ///   <see cref="ColorChannelVector"/> class, which must hold 3 dimensions, in the order
    ///   [] { <see cref="L"/>, <see cref="A"/>, <see cref="B"/> }.
    /// </summary>
    /// <param name="colorChannelVector">
    ///   An instance of the <see cref="ColorChannelVector"/> class, which must hold 3
    ///   dimensions, in the order [] { <see cref="L"/>, <see cref="A"/>, <see cref="B"/> }.
    /// </param>
    public HLabColor(
      ColorChannelVector colorChannelVector)
        : this(
          colorChannelVector,
          _defaultWhitePoint)
    {
    }

    /// <inheritdoc/>
    /// <summary>
    ///   Creates an instance of the <see cref="HLabColor"/> struct from an instance of the
    ///   <see cref="ColorChannelVector"/> class, which must hold 3 dimensions, in the order
    ///   [] { <see cref="L"/>, <see cref="A"/>, <see cref="B"/> }.
    /// </summary>
    /// <param name="colorChannelVector">
    ///   An instance of the <see cref="ColorChannelVector"/> class, which must hold 3
    ///   dimensions, in the order [] { <see cref="L"/>, <see cref="A"/>, <see cref="B"/> }.
    /// </param>
    /// <param name="whitePoint">
    ///   A <see cref="XYZColor"/> value indicating the <see cref="Illuminant"/> which
    ///   indicates the reference white point for this instance.
    /// </param>
    public HLabColor(
      ColorChannelVector colorChannelVector,
      XYZColor whitePoint)
        : this(
          colorChannelVector[0],
          colorChannelVector[1],
          colorChannelVector[2],
          whitePoint)
    {
    }

    #endregion


    #region Methods
    /// <summary>
    ///   Converts this <see cref="HLabColor"/> instance to its <see cref="string"/> representation.
    /// </summary>
    /// <returns>
    ///   Returns the <see cref="string"/> representation of this <see cref="HLabColor"/> instance.
    /// </returns>
    public override string ToString()
    {
      return $"HLabColor [L={L:0.##} A={A:0.##} B={B:0.##}]";
    }

    #endregion


    #region Equality
    /// <inheritdoc cref="object"/>
    public override bool Equals(object obj)
    {
      return obj is HLabColor color && Equals(color);
    }

    /// <inheritdoc cref="object"/>
    public bool Equals(HLabColor other)
    {
      return L.Equals(other.L) &&
             A.Equals(other.A) &&
             B.Equals(other.B);
    }

    /// <inheritdoc cref="object"/>
    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = L.GetHashCode();
        hashCode = (hashCode * 397) ^ A.GetHashCode();
        hashCode = (hashCode * 397) ^ B.GetHashCode();
        return hashCode;
      }
    }

    #endregion


    #region Operators
    /// <inheritdoc cref="object"/>
    public static bool operator ==(
      HLabColor left,
      HLabColor right)
    {
      return Equals(left, right);
    }

    /// <inheritdoc cref="object"/>
    public static bool operator !=(
      HLabColor left,
      HLabColor right)
    {
      return !Equals(left, right);
    }

    #endregion
    
  }
}