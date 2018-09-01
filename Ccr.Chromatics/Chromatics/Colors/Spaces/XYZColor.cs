using System;
using System.Collections.Generic;
using Ccr.Chromatics.Colors.Infrastructure;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Chromatics.Colors.Spaces
{
  /// <inheritdoc cref="IVectorColorSpace"/>
  /// <summary>
  ///   The CIE 1931 XYZ color space
  /// </summary>
  public struct XYZColor
    : IVectorColorSpace,
      IEquatable<XYZColor>
  {
    #region Properties
    /// <summary>
    ///   Value indicating the X channel value for the <see cref="XYZColor"/>
    /// </summary>
    /// <remarks>
    ///   This value must be between [0.00 to 1.00], inclusively.
    /// </remarks>
    public double X { get; }

    /// <summary>
    ///   Value indicating the Y channel value for the <see cref="XYZColor"/>
    /// </summary>
    /// <remarks>
    ///   This value must be between [0.00 to 1.00], inclusively.
    /// </remarks>
    public double Y { get; }

    /// <summary>
    ///   Value indicating the Z channel value for the <see cref="XYZColor"/>
    /// </summary>
    /// <remarks>
    ///   This value must be between [0.00 to 1.00], inclusively.
    /// </remarks>
    public double Z { get; }


    /// <summary>
    ///   Gets the <see cref="ColorChannelVector"/> for this <see cref="XYZColor"/>
    ///   instance that represents a vector <see cref="IReadOnlyList{T}"/>, where T
    ///   is <see cref="double"/>. This vector contains the values for the color channel
    ///   values [] { <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/> }.
    /// </summary>
    public ColorChannelVector ColorChannelVector
    {
      get => new ColorChannelVector(X, Y, Z);
    }

    #endregion


    #region Constructors
    /// <summary>
    ///   Creates an instance of the <see cref="XYZColor"/> struct with the color
    ///   channel <see cref="double"/> argument values <paramref name="x"/>,
    ///   <paramref name="y"/>, and <paramref name="z"/>.
    /// </summary>
    /// <param name="x">
    ///   Value indicating the X channel value for the <see cref="XYZColor"/>.
    ///   This value must be between [0.00 to 1.00], inclusively.
    /// </param>
    /// <param name="y">
    ///   Value indicating the Y channel value for the <see cref="XYZColor"/>.
    ///   This value must be between [0.00 to 1.00], inclusively.
    /// </param>
    /// <param name="z">
    ///   Value indicating the Z channel value for the <see cref="XYZColor"/>.
    ///   This value must be between [0.00 to 1.00], inclusively.
    /// </param>
    public XYZColor(
      double x,
      double y,
      double z)
    {
      x.ThrowIfNotWithin((0d, 1d), nameof(x));
      y.ThrowIfNotWithin((0d, 1d), nameof(y));
      z.ThrowIfNotWithin((0d, 1d), nameof(z));

      X = x;
      Y = y;
      Z = z;
    }

    /// <inheritdoc/>
    /// <summary>
    ///   Creates an instance of the <see cref="XYZColor"/> struct from an instance of the
    ///   <see cref="ColorChannelVector"/> class, which must hold 3 dimensions, in the order
    ///   [] { <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/> }.
    /// </summary>
    /// <param name="colorChannelVector">
    ///   An instance of the <see cref="ColorChannelVector"/> class, which must hold 3
    ///   dimensions, in the order [] { <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/> }.
    /// </param>
    public XYZColor(
      ColorChannelVector colorChannelVector)
      : this(
        colorChannelVector[0],
        colorChannelVector[1],
        colorChannelVector[2])
    {
    }

    #endregion


    #region Methods
    /// <summary>
    ///   Converts this <see cref="XYZColor"/> instance to its <see cref="string"/> representation.
    /// </summary>
    /// <returns>
    ///   Returns the <see cref="string"/> representation of this <see cref="XYZColor"/> instance.
    /// </returns>
    public override string ToString()
    {
      return $"XYZColor [X={X:0.##} Y={Y:0.##} Z={Z:0.##}]";
    }

    #endregion


    #region Equality
    /// <inheritdoc cref="object"/>
    public override bool Equals(object obj)
    {
      return obj is XYZColor color && Equals(color);
    }

    /// <inheritdoc cref="object"/>
    public bool Equals(XYZColor other)
    {
      return X.Equals(other.X) &&
             Y.Equals(other.Y) &&
             Z.Equals(other.Z);
    }

    /// <inheritdoc cref="object"/>
    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = X.GetHashCode();
        hashCode = (hashCode * 397) ^ Y.GetHashCode();
        hashCode = (hashCode * 397) ^ Z.GetHashCode();
        return hashCode;
      }
    }

    #endregion


    #region Operators
    /// <inheritdoc cref="object"/>
    public static bool operator ==(
      XYZColor left,
      XYZColor right)
    {
      return Equals(left, right);
    }

    /// <inheritdoc cref="object"/>
    public static bool operator !=(
      XYZColor left,
      XYZColor right)
    {
      return !Equals(left, right);
    }

    #endregion

  }
}