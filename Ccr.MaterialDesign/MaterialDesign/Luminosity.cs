using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.Core.Numerics;
using Ccr.MaterialDesign.Markup.TypeConverters;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign
{
  public partial class Luminosity
  {
    public static readonly Luminosity P050 = Define();
    public static readonly Luminosity P100 = Define();
    public static readonly Luminosity P200 = Define();
    public static readonly Luminosity P300 = Define();
    public static readonly Luminosity P400 = Define();
    public static readonly Luminosity P500 = Define();
    public static readonly Luminosity P600 = Define();
    public static readonly Luminosity P700 = Define();
    public static readonly Luminosity P800 = Define();
    public static readonly Luminosity P900 = Define();
    public static readonly Luminosity A100 = Define();
    public static readonly Luminosity A200 = Define();
    public static readonly Luminosity A400 = Define();
    public static readonly Luminosity A700 = Define();


  }
  [TypeConverter(typeof(LuminosityConverter))]
  public partial class Luminosity
    : IComparable,
      IComparable<Luminosity>
  {
    private static readonly IList<int> _normalLuminosities
      = new List<int>
      {
        050,
        100,
        200,
        300,
        400,
        500,
        600,
        700,
        800,
        900
      };

    private static readonly IList<int> _normalAccentLuminosities
      = new List<int>
      {
        100,
        200,
        400,
        700
      };



    public int LuminosityIndex { get; }

    public bool IsAccent { get; }


    public bool IsNormalLuminosity
    {
      get => IsAccent 
        ? _normalAccentLuminosities.Contains(LuminosityIndex) 
        : _normalLuminosities.Contains(LuminosityIndex); 
    }

    internal Luminosity() { }

    public Luminosity(
      int luminosityIndex,
      bool isAccent) : this()
    {
      if (luminosityIndex.IsNotWithin((0, 1000)))
        throw new ArgumentOutOfRangeException(
          nameof(luminosityIndex),
          luminosityIndex,
          $"Luminosity value is not valid. Must be between 0 and 1000, inclusively.");

      LuminosityIndex = luminosityIndex;
      IsAccent = isAccent;
    }


    public override bool Equals(object obj)
    {
      if (!(obj is Luminosity))
        return false;

      return this == (Luminosity)obj;
    }

    protected bool Equals(
      [NotNull] Luminosity other)
    {
      return LuminosityIndex == other.LuminosityIndex
        && IsAccent == other.IsAccent;
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (LuminosityIndex * 397) ^ IsAccent.GetHashCode();
      }
    }

    public int CompareTo(object obj)
    {
      if (obj is Luminosity)
        return CompareTo(obj.As<Luminosity>());

      throw new ArgumentException();
    }

    public int CompareTo(Luminosity other)
    {
      return LuminosityIndex.CompareTo(other.LuminosityIndex);
    }

    public static bool operator ==(
      [NotNull] Luminosity a,
      [NotNull] Luminosity b)
    {
      return a.LuminosityIndex == b.LuminosityIndex
             && a.IsAccent == b.IsAccent;
    }


    public static bool operator !=(
      [NotNull] Luminosity a,
      [NotNull] Luminosity b)
    {
      return a.LuminosityIndex != b.LuminosityIndex
             || a.IsAccent != b.IsAccent;
    }

    public static bool operator <(
      [NotNull] Luminosity a,
      [NotNull] Luminosity b)
    {
      return a.LuminosityIndex < b.LuminosityIndex;
    }

    public static bool operator >(
      [NotNull] Luminosity a,
      [NotNull] Luminosity b)
    {
      return a.LuminosityIndex > b.LuminosityIndex;
    }


    public static bool operator <=(
      [NotNull] Luminosity a,
      [NotNull] Luminosity b)
    {
      return a.LuminosityIndex <= b.LuminosityIndex;
    }

    public static bool operator >=(
      [NotNull] Luminosity a,
      [NotNull] Luminosity b)
    {
      return a.LuminosityIndex >= b.LuminosityIndex;
    }

    public static Luminosity Define(
      [CallerMemberName] string memberName = "")
    {
      return Parse(memberName);
    }

    public static Luminosity Parse(
      string luminosityStr = "")
    {
      var originalStr = luminosityStr;

      var isAccent = luminosityStr.StartsWith("A");

      if (isAccent)
        luminosityStr = luminosityStr.Substring(1);

      if (luminosityStr.StartsWith("P"))
      {
        isAccent = false;
        luminosityStr = luminosityStr.Substring(1);
      }

      if (!int.TryParse(luminosityStr, out var _index))
      {
        throw new FormatException(
          $"Could not parse \'Luminosity\' object from the text {originalStr.Quote()} " +
          $"because {luminosityStr.Quote()} cannot ne parsed into type \'int\'. ");
      }

      return new Luminosity(_index, isAccent);
    }

    public override string ToString()
    {
      return $"{(IsAccent ? "A" : "P")}{LuminosityIndex:000}";
    }
  }
}

//if (!memberName.StartsWith("A"))
//{
//  if (!int.TryParse(memberName, out var _index))
//  {
//    throw new FormatException(
//      $"Could not parse \'Luminosity\' object from the text {memberName.Quote()} " +
//      $"because {memberName.Quote()} cammpt ne parsed into type \'int\'. ");
//  }
//  return new Luminosity(_index, false);
//}
//else
//{
//  var indexStr = memberName.Substring(1);
//  if (!int.TryParse(indexStr, out var _index))
//  {
//    throw new FormatException(
//      $"Could not parse \'Luminosity\' object from the text {memberName.Quote()} " +
//      $"because {indexStr.Quote()} cammpt ne parsed into type \'int\'. ");
//  }
//  return new Luminosity(_index, true);
//}