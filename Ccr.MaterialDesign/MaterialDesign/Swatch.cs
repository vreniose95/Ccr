using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.Core.Numerics.Ranges;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.Xaml.Collections;

// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.MaterialDesign
{
  //[DictionaryKeyProperty(nameof(SwatchClassifier))]
  public class Swatch
    : HostedElement<Palette>,
      IList,
      IList<MaterialBrush>,
      IReadOnlyDictionary<Luminosity, MaterialBrush>,
      ISupportInitialize
  {
    #region Inner Collections
    private readonly ReactiveCollection<MaterialBrush> _primaries
      = new ReactiveCollection<MaterialBrush>();

    private readonly ReactiveCollection<MaterialBrush> _accents
      = new ReactiveCollection<MaterialBrush>();

    private readonly List<MaterialBrush> _materials;

    #endregion


    #region Fields
    internal MaterialBrush LowPrimaryBounds = new MaterialBrush(
      Brushes.Black,
      new MaterialIdentity(
        SwatchClassifier.Grey,
        new Luminosity(000, false)));

    internal MaterialBrush LowAccentBounds = new MaterialBrush(
      Brushes.Black,
      new MaterialIdentity(
        SwatchClassifier.Grey,
        new Luminosity(000, true)));

    internal MaterialBrush HighPrimaryBounds = new MaterialBrush(
      Brushes.White,
      new MaterialIdentity(
        SwatchClassifier.Grey,
        new Luminosity(999, false)));

    internal MaterialBrush HighAccentBounds = new MaterialBrush(
      Brushes.White,
      new MaterialIdentity(
        SwatchClassifier.Grey,
        new Luminosity(999, true)));

    #endregion


    #region Properties
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
      get => _primaries;
    }

    public IReadOnlyCollection<MaterialBrush> Accents
    {
      get => _accents;
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

    public IReadOnlyDictionary<Luminosity, MaterialBrush> LuminosityMaterialMap
    {
      get => Materials
        .ToDictionary(
          t => t.Identity.Luminosity,
          t => t);
    }

    #endregion


    #region Constructors
    public Swatch()
    {
      _primaries.CollectionChangedGeneric += onPrimariesCollectionChanged;
      _accents.CollectionChangedGeneric += onAccentsCollectionChanged;

      _materials = new List<MaterialBrush>();
    }

    internal Swatch(
      IEnumerable<MaterialBrush> brushes)
        : this()
    {
      foreach (var brush in brushes)
      {
        Add(brush);
      }
    }

    #endregion


    public MaterialBrush GetMaterial(
      Luminosity luminosity)
    {
      if (TryGetValue(luminosity, out var definedMaterialBrush))
      {
        return definedMaterialBrush;
      }

      var brushRange = GetRange(luminosity);

      var range = new DoubleRange(
        brushRange
          .low
          .Identity
          .Luminosity
          .LuminosityIndex,
        brushRange
          .high
          .Identity
          .Luminosity
          .LuminosityIndex);

      var index = (double)luminosity.LuminosityIndex;

      var progression = index.LinearMap(range, (0d, 1d));
      //var s = new SequentialQuad<MaterialBrush>()

      var interpolated = brushRange
        .low
        .Brush
        .Interpolate(
          brushRange
            .high
            .Brush,
          progression);

      //throw new NotImplementedException();

			if (!MaterialBrush.TryCreateFromBrush(interpolated, out var materialBrush))
			{
				throw new NotImplementedException();
				//Identity = new MaterialIdentity(SwatchClassifier, luminosity.IsAccent, luminosity),
    //    Color = interpolated

			}
			return materialBrush;
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
            args.NewItems.ForEach(
                t => t.AttachHost(this));

            var newItemsCount = args.NewItems.Count;
            var targetPrimariesCount = Primaries.Count;
            var insertionPosition = targetPrimariesCount - newItemsCount;

            _materials.InsertRange(insertionPosition, args.NewItems);
            break;
          }
        case NotifyCollectionChangedAction.Remove:
          {
            args.OldItems.ForEach(
              t => t.DetachHost());

            args.NewItems.ForEach(
              t => t.AttachHost(this));

            var oldItemsCount = args.OldItems.Count;
            var targetPrimariesCount = Primaries.Count;

            _materials.RemoveRange(targetPrimariesCount, oldItemsCount);
            break;
          }
        case NotifyCollectionChangedAction.Replace:
          {
            args.OldItems.ForEach(
              t => t.DetachHost());

            args.NewItems.ForEach(
              t => t.AttachHost(this));

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
            foreach (var primary in args.OldItems)
            {
              primary.DetachHost();
              _materials.Remove(primary);
            }
            break;
          }
        default:
          throw new InvalidEnumArgumentException();
      }
    }

    private void onAccentsCollectionChanged(
      IReactiveCollection<MaterialBrush> sender,
      NotifyCollectionChangedEventArgs<MaterialBrush> args)
    {
      switch (args.Action)
      {
        case NotifyCollectionChangedAction.Add:
          {
            args.NewItems.ForEach(
              t => t.AttachHost(this));

            var newItemsCount = args.NewItems.Count;
            var targetAccentsCount = Accents.Count;
            var insertionPosition = targetAccentsCount - newItemsCount;

            _materials.InsertRange(insertionPosition, args.NewItems);
            break;
          }
        case NotifyCollectionChangedAction.Remove:
          {
            args.OldItems.ForEach(
              t => t.DetachHost());

            args.NewItems.ForEach(
              t => t.AttachHost(this));

            var oldItemsCount = args.OldItems.Count;
            var targetAccentsCount = Accents.Count;

            _materials.RemoveRange(targetAccentsCount, oldItemsCount);
            break;
          }
        case NotifyCollectionChangedAction.Replace:
          {
            args.OldItems.ForEach(
              t => t.DetachHost());

            args.NewItems.ForEach(
              t => t.AttachHost(this));

            var newItemsCount = args.NewItems.Count;
            var oldItemsCount = args.OldItems.Count;
            var targetAccentsCount = Accents.Count;

            var insertionPosition = targetAccentsCount - newItemsCount;

            _materials.RemoveRange(targetAccentsCount, oldItemsCount);
            _materials.InsertRange(insertionPosition, args.NewItems);

            break;
          }
        case NotifyCollectionChangedAction.Move:
          {
            break;
          }
        case NotifyCollectionChangedAction.Reset:
          {
            foreach (var accent in args.OldItems)
            {
              accent.DetachHost();
              _materials.Remove(accent);
            }
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
      get => !_isInitializing;
    }


    public void Add(MaterialBrush item)
    {
      item.IsNotNull(nameof(item));

      if (item.Identity.IsAccent)
        _accents.Add(item);
      else
        _primaries.Add(item);
    }

    void ICollection<MaterialBrush>.Clear()
    {
      throw new NotSupportedException();
    }

    public bool Contains(
      MaterialBrush item)
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
      get => _materials[index];
      set { throw new NotImplementedException(); }
    }


		#region Standard Swatch Luminosities
		public MaterialBrush P050
		{
			get => GetMaterial(Luminosity.P050);
		}

		public MaterialBrush P100
		{
			get => GetMaterial(Luminosity.P100);
		}

		public MaterialBrush P200
		{
			get => GetMaterial(Luminosity.P200);
		}

		public MaterialBrush P300
		{
			get => GetMaterial(Luminosity.P300);
		}

		public MaterialBrush P400
		{
			get => GetMaterial(Luminosity.P400);
		}

		public MaterialBrush P500
		{
			get => GetMaterial(Luminosity.P500);
		}

		public MaterialBrush P600
		{
			get => GetMaterial(Luminosity.P600);
		}

		public MaterialBrush P700
		{
			get => GetMaterial(Luminosity.P700);
		}

		public MaterialBrush P800
		{
			get => GetMaterial(Luminosity.P800);
		}

		public MaterialBrush P900
		{
			get => GetMaterial(Luminosity.P900);
		}


		public MaterialBrush A100
		{
			get => GetMaterial(Luminosity.A100);
		}

		public MaterialBrush A200
		{
			get => GetMaterial(Luminosity.A200);
		}

		public MaterialBrush A400
		{
			get => GetMaterial(Luminosity.A400);
		}

		public MaterialBrush A700
		{
			get => GetMaterial(Luminosity.A700);
		}



		public MaterialBrush PrimaryHueLight
		{
			get => P200;
		}

		public MaterialBrush PrimaryHueLightForeground
		{
			get => P200.ForegroundMaterial;
		}

		public MaterialBrush PrimaryHueMid
		{
			get => P500;
		}

		public MaterialBrush PrimaryHueMidForeground
		{
			get => P500.ForegroundMaterial;
		}

		public MaterialBrush PrimaryHueDark
		{
			get => P700;
		}

		public MaterialBrush PrimaryHueDarkForeground
		{
			get => P700.ForegroundMaterial;
		}


		#endregion


		#region IReadOnlyDictionary implementation
		IEnumerator<KeyValuePair<Luminosity, MaterialBrush>> IEnumerable<KeyValuePair<Luminosity, MaterialBrush>>.GetEnumerator()
    {
      return LuminosityMaterialMap.GetEnumerator();
    }
    public bool ContainsKey(Luminosity key)
    {
      return LuminosityMaterialMap.ContainsKey(key);
    }

    public bool TryGetValue(Luminosity key, out MaterialBrush value)
    {
      return LuminosityMaterialMap.TryGetValue(key, out value);
    }

    public IEnumerable<Luminosity> Keys
    {
      get => Materials.Select(t => t.Identity.Luminosity);
    }
    public IEnumerable<MaterialBrush> Values
    {
      get => Materials;
    }

    public MaterialBrush this[Luminosity luminosity]
    {
      get
      {
        if (!LuminosityMaterialMap.TryGetValue(luminosity, out var materialBrush))
          throw new NotSupportedException();

        return materialBrush;
      }
    }

    #endregion


    #region IList implementation
    void IList.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }

    object IList.this[int index]
    {
      get => this[index];
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

    void IList.Clear()
    {
      throw new NotSupportedException();
    }

    int IList.IndexOf(object value)
    {
      switch (value)
      {
        case SolidColorBrush scb:
          if (!MaterialBrush.TryCreateFromBrush(scb, out var mb))
            throw new NotSupportedException();
          return IndexOf(mb);

        case MaterialBrush mbr:
          return IndexOf(mbr);

      }
      throw new NotSupportedException();
    }

    void IList.Insert(int index, object value)
    {
      throw new NotSupportedException();
    }

    void IList.Remove(object value)
    {
      throw new NotSupportedException();
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
      switch (value)
      {
        case SolidColorBrush scb:
          if (!MaterialBrush.TryCreateFromBrush(scb, out var mb))
            throw new NotSupportedException();
          Add(mb);
          return Count;

        case MaterialBrush mbr:
          Add(mbr);
          return Count;

      }
      throw new NotSupportedException();
    }

    bool IList.Contains(object value)
    {
      return Contains(value.As<MaterialBrush>());
    }

    #endregion


    #region ISupportInitialize implementation
    private bool _isInitializing;

    void ISupportInitialize.BeginInit()
    {
      _isInitializing = true;
    }

    void ISupportInitialize.EndInit()
    {
      _isInitializing = false;
    }

    #endregion





    private MaterialBrush buildMaterialBrush(object value)
    {
      switch (value)
      {
        case SolidColorBrush solidColorBrush:
          {
            if (MaterialBrush.TryCreateFromBrush(solidColorBrush, out var materialBrush))
              return materialBrush;

            return new MaterialBrush(
              solidColorBrush,
              new MaterialIdentity(
                SwatchClassifier,
                new Luminosity(0, false)));
          }
        case MaterialBrush materialBrush:
          {
            return materialBrush;
          }
        default:
          {
            throw new NotSupportedException();
          }
      }
    }


    public static Swatch Create(
      params MaterialBrush[] _materials)
    {
      var _classifier = _materials[0]
        .Identity
        .SwatchClassifier;

      return new Swatch(_materials)
      {
        SwatchClassifier = _classifier,
      };
    }

  }
}
