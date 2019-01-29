using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
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
    private static Luminosity[] _normalLuminosities;

    private static readonly int[] _normalPrimaryLuminosities = {
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

    private static readonly int[] _normalAccentLuminosities = {
        100,
        200,
        400,
        700
      };
    

    public static IReadOnlyList<Luminosity> NormalLuminosities
    {
      get => _normalLuminosities
             ?? (_normalLuminosities = _normalPrimaryLuminosities
               .Select(t => new Luminosity(t, true))
               .Concat(
                 _normalAccentLuminosities
                   .Select(t => new Luminosity(t, false))
                   .ToArray())
               .ToArray());
    }
    

    public int LuminosityIndex { get; }

    public bool IsAccent { get; }
    
    public bool IsNormalLuminosity
    {
      get => NormalLuminosities != null 
             && NormalLuminosities
               .Where(
                 t => t.IsAccent == IsAccent)
               .Count(
                 t => t.LuminosityIndex == LuminosityIndex) == 1;
    }


    private Luminosity() { }

    public Luminosity(
      int luminosityIndex,
      bool isAccent)
        : this()
    {
      if (luminosityIndex.IsNotWithin((0, 999)))
        throw new ArgumentOutOfRangeException(
          nameof(luminosityIndex),
          luminosityIndex,
          "Luminosity value is not valid. Must be between 0 and 999, inclusively.");

      LuminosityIndex = luminosityIndex;
      IsAccent = isAccent;
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


    public override bool Equals(
      object obj)
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

    public int CompareTo(
      object obj)
    {
      if (obj is Luminosity luminosity)
        return CompareTo(luminosity);

      throw new ArgumentException();
    }

    public int CompareTo(
      Luminosity other)
    {
      return LuminosityIndex
        .CompareTo(
          other.LuminosityIndex);
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
      if (!int.TryParse(luminosityStr, out var index))
      {
        throw new FormatException(
          $"Could not parse \'Luminosity\' object from the text {originalStr.Quote()} " +
          $"because {luminosityStr.Quote()} cannot ne parsed into type \'int\'. ");
      }
      return new Luminosity(index, isAccent);
    }

    public override string ToString()
    {
      return $"{(IsAccent ? "A" : "P")}{LuminosityIndex:000}";
    }
  }
}
