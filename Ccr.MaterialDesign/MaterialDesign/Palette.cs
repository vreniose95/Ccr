using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Xaml.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Ccr.PresentationCore.Layout;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign
{
  //[DictionaryKeyProperty()]
  [ContentProperty(nameof(Swatches))]
  public class Palette
    : Freezable,
      IList<Swatch>
  //IPalette
  {
    public static readonly DependencyProperty SwatchesProperty = DP.Register(
      new Meta<Palette, ReactiveCollection<Swatch>>());

    public ReactiveCollection<Swatch> Swatches
    {
      get
      {
        var currentValue = GetValue(SwatchesProperty) as ReactiveCollection<Swatch>;
        if (currentValue != null)
          return currentValue;

        var newValue = new ReactiveCollection<Swatch>();
        newValue.CollectionChangedGeneric += onSwatchCollectionChange;
        SetValue(SwatchesProperty, newValue);

        return newValue;
      }
      set => SetValue(SwatchesProperty, value);
    }


    public Palette()
    {
      //Swatches = new ReactiveCollection<Swatch>();
      //Swatches.CollectionChangedGeneric += onSwatchCollectionChange;
    }


    public void Proc()
    {
      foreach (var swatch in Swatches)
      {
        foreach (var primary in swatch.Primaries)
        {
          //var color = primary.Color;

        }

      }
    }

    public static Swatch Interpolate(
      Percentage progression)
    {
      throw new Exception();
    }

    public MaterialBrush LookupNearestVector(
      SolidColorBrush solidColorBrush)
    {
      throw new NotImplementedException();
    }

    private void onSwatchCollectionChange(
        IReactiveCollection<Swatch> sender,
        NotifyCollectionChangedEventArgs<Swatch> args)
    {
      switch (args.Action)
      {
        case NotifyCollectionChangedAction.Add:
          args.NewItems.ForEach(t => t.AttachHost(this));
          break;

        case NotifyCollectionChangedAction.Replace:
          args.OldItems.ForEach(t => t.DetachHost());
          args.NewItems.ForEach(t => t.AttachHost(this));
          break;

        case NotifyCollectionChangedAction.Remove:
        case NotifyCollectionChangedAction.Reset:
          args.NewItems.ForEach(t => t.DetachHost());
          break;

        case NotifyCollectionChangedAction.Move:
          break;

        default:
          throw new ArgumentOutOfRangeException(
            );
      }
    }

    protected override Freezable CreateInstanceCore()
    {
      return new Palette();
    }


    public IEnumerator<Swatch> GetEnumerator()
    {
      return Swatches.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public void Add(Swatch item)
    {
      Swatches.Add(item);
    }

    void ICollection<Swatch>.Clear()
    {
      Swatches.Clear();
    }

    public bool Contains(Swatch item)
    {
      return Swatches.Contains(item);
    }

    void ICollection<Swatch>.CopyTo(Swatch[] array, int arrayIndex)
    {
      throw new NotImplementedException();
    }

    bool ICollection<Swatch>.Remove(Swatch item)
    {
      throw new NotImplementedException();
    }

    public int Count
    {
      get => Swatches.Count;
    }

    bool ICollection<Swatch>.IsReadOnly
    {
      get => true;
    }

    public int IndexOf(Swatch item)
    {
      return Swatches.IndexOf(item);
    }

    public void Insert(int index, Swatch item)
    {
      Swatches.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
      Swatches.RemoveAt(index);
    }

    public Swatch this[int index]
    {
      get => Swatches[index];
      set => Swatches[index] = value;
    }

    public Swatch GetSwatch(
      SwatchClassifier classifier)
    {
      var swatch = Swatches
        .Single(t => t.SwatchClassifier == classifier);

      return swatch;
    }
  }
}
