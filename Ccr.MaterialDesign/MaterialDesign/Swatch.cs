using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Markup;
using System.Windows.Media;
using Ccr.Algorithms.Collections;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.Xaml.Collections;

// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.MaterialDesign
{
  [DictionaryKeyProperty(nameof(SwatchClassifier))]
  public class Swatch
    : HostedElement<Palette>,
      IList,
      IList<MaterialBrush>,
      ISupportInitialize
  {

    private readonly ReactiveCollection<MaterialBrush> _primaries
      = new ReactiveCollection<MaterialBrush>();

    private readonly ReactiveCollection<MaterialBrush> _accents
      = new ReactiveCollection<MaterialBrush>();

    private List<MaterialBrush> _materials;



    public MaterialBrush ExemplarHue
    {
      get
      {
        if (_primaries.Count >= 10)
          return _primaries[6];

        return null;
      }
    }

    public SwatchClassifier SwatchClassifier { get; set; }


    public IReadOnlyCollection<MaterialBrush> Primaries
    {
      get { return _primaries; }
    }

    public IReadOnlyCollection<MaterialBrush> Accents
    {
      get { return _accents; }
    }

    public IReadOnlyCollection<MaterialBrush> Materials
    {
      get
      {
        if (_materials != null)
          return _materials;

        return _primaries
          .Concat(_accents)
          .ToArray();
      }
    }

    private MaterialBrush _lowPrimaryBounds;
    internal MaterialBrush LowPrimaryBounds
    {
      get => _lowPrimaryBounds
             ?? (_lowPrimaryBounds = new MaterialBrush
             {
               Identity = new MaterialIdentity(SwatchClassifier, false, new Luminosity(0, false)),
               Color = Colors.Black
             });
    }

    private MaterialBrush _highPrimaryBounds;
    internal MaterialBrush HighPrimaryBounds
    {
      get => _highPrimaryBounds
             ?? (_highPrimaryBounds = new MaterialBrush
             {
               Identity = new MaterialIdentity(SwatchClassifier, false, new Luminosity(1000, false)),
               Color = Colors.White
             });
    }
    private MaterialBrush _lowAccentBounds;
    internal MaterialBrush LowAccentBounds
    {
      get => _lowAccentBounds
             ?? (_lowAccentBounds = new MaterialBrush
             {
               Identity = new MaterialIdentity(SwatchClassifier, true, new Luminosity(0, true)),
               Color = Colors.Black
             });
    }

    private MaterialBrush _highAccentBounds;
    internal MaterialBrush HighAccentBounds
    {
      get => _highAccentBounds
             ?? (_highAccentBounds = new MaterialBrush
             {
               Identity = new MaterialIdentity(SwatchClassifier, true, new Luminosity(1000, true)),
               Color = Colors.White
             });
    }



    public Swatch()
    {
      _primaries.CollectionChangedGeneric += onPrimariesCollectionChanged;
      _materials = new List<MaterialBrush>();
    }



    public MaterialBrush GetMaterial(
      Luminosity luminosity)
    {
      var brushRange = GetRange(luminosity);

      var range = (
        (double)brushRange.low.Identity.Luminosity.LuminosityIndex,
        (double)brushRange.high.Identity.Luminosity.LuminosityIndex);

      var index = (double)luminosity.LuminosityIndex;
      var progression = index.LinearMap(range, (0d, 100d));

      //var s = new SequentialQuad<MaterialBrush>()


      return new MaterialBrush
      {
        Identity = new MaterialIdentity(SwatchClassifier, luminosity.IsAccent, luminosity),
        Color = brushRange.low
      };
    }


    private (MaterialBrush low, MaterialBrush high) GetRange(
      Luminosity luminosity)
    {
      if (luminosity.IsAccent)
      {
        var lowBounds = LowAccentBounds;

        foreach (var accentBrush in Accents
          .OrderBy(t => t.Identity.Luminosity))
        {
          if (luminosity < accentBrush.Identity.Luminosity)
          {
            return (lowBounds, accentBrush);
          }
          lowBounds = accentBrush;
        }
        return (lowBounds, HighAccentBounds);
      }
      else
      {
        var lowBounds = LowPrimaryBounds;

        foreach (var primaryBrush in Primaries
          .OrderBy(t => t.Identity.Luminosity))
        {
          if (luminosity < primaryBrush.Identity.Luminosity)
          {
            return (lowBounds, primaryBrush);
          }
          lowBounds = primaryBrush;
        }
        return (lowBounds, HighPrimaryBounds);
      }
    }


    private void onPrimariesCollectionChanged(
      IReactiveCollection<MaterialBrush> sender,
      NotifyCollectionChangedEventArgs<MaterialBrush> args)
    {
      switch (args.Action)
      {
        case NotifyCollectionChangedAction.Add:
          {
            args.NewItems.ForEach(t => t.AttachHost(this));

            var newItemsCount = args.NewItems.Count;
            var targetPrimariesCount = Primaries.Count;
            var insertionPosition = targetPrimariesCount - newItemsCount;

            _materials.InsertRange(insertionPosition, args.NewItems);

            break;
          }
        case NotifyCollectionChangedAction.Remove:
          {
            args.OldItems.ForEach(t => t.DetachHost());
            args.NewItems.ForEach(t => t.AttachHost(this));

            var oldItemsCount = args.OldItems.Count;
            var targetPrimariesCount = Primaries.Count;

            _materials.RemoveRange(targetPrimariesCount, oldItemsCount);

            break;
          }
        case NotifyCollectionChangedAction.Replace:
          {
            args.OldItems.ForEach(t => t.DetachHost());
            args.NewItems.ForEach(t => t.AttachHost(this));

            var newItemsCount = args.NewItems.Count;
            var oldItemsCount = args.OldItems.Count;
            var targetPrimariesCount = Primaries.Count;

            var insertionPosition = targetPrimariesCount - newItemsCount;

            _materials.RemoveRange(targetPrimariesCount, oldItemsCount);
            _materials.InsertRange(insertionPosition, args.NewItems);

            break;
          }
        case NotifyCollectionChangedAction.Move:
          {
            break;
          }
        case NotifyCollectionChangedAction.Reset:
          {
            args.OldItems.ForEach(t => t.DetachHost());

            _materials.Clear();
            break;
          }
        default:
          throw new InvalidEnumArgumentException();
      }
    }

    public IEnumerator<MaterialBrush> GetEnumerator()
    {
      return Materials.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    void ICollection.CopyTo(
      Array array,
      int index)
    {
      _materials
        .ToArray()
        .CopyTo(
          array,
          index);
    }

    bool ICollection<MaterialBrush>.Remove(
      MaterialBrush item)
    {
      throw new NotImplementedException();
    }

    public int Count
    {
      get => _materials.Count;
    }

    bool ICollection<MaterialBrush>.IsReadOnly
    {
      get { return false; }
    }
    int ICollection.Count
    {
      get => Materials.Count;
    }
    object ICollection.SyncRoot
    {
      get => Materials.ToArray().SyncRoot;
    }
    bool ICollection.IsSynchronized
    {
      get => true;
    }
    int IList.Add(object value)
    {
      Add(value.As<MaterialBrush>());
      return Count;
    }

    bool IList.Contains(object value)
    {
      return Contains(value.As<MaterialBrush>());
    }

    public void Add(MaterialBrush item)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));

      item.AttachHost(this);

      if (item.Identity.IsAccent)
        _accents.Add(item);
      else
        _primaries.Add(item);
    }

    void ICollection<MaterialBrush>.Clear()
    {
      throw new NotSupportedException();
    }

    public bool Contains(MaterialBrush item)
    {
      return Materials.Contains(item);
    }

    void ICollection<MaterialBrush>.CopyTo(
      MaterialBrush[] array,
      int arrayIndex)
    {
      Materials
        .ToArray()
        .CopyTo(array, arrayIndex);
    }

    void IList.Clear()
    {
      throw new NotSupportedException();
    }

    int IList.IndexOf(object value)
    {
      return IndexOf(value.As<MaterialBrush>());
    }

    void IList.Insert(int index, object value)
    {
      throw new NotSupportedException();
    }

    void IList.Remove(object value)
    {
      throw new NotSupportedException();
    }

    public int IndexOf(MaterialBrush item)
    {
      return _materials.IndexOf(item);
    }

    void IList<MaterialBrush>.Insert(int index, MaterialBrush item)
    {
      throw new NotSupportedException();
    }

    void IList<MaterialBrush>.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }

    public MaterialBrush this[int index]
    {
      get { return _materials[index]; }
      set { throw new NotImplementedException(); }
    }

    void IList.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }

    object IList.this[int index]
    {
      get { return this[index]; }
      set { throw new NotSupportedException(); }
    }

    bool IList.IsReadOnly
    {
      get => !_isInitializing;
    }

    bool IList.IsFixedSize
    {
      get => false;
    }

    private bool _isInitializing;
    void ISupportInitialize.BeginInit()
    {
      _isInitializing = true;
    }
    void ISupportInitialize.EndInit()
    {
      _isInitializing = false;
    }
  }
}
