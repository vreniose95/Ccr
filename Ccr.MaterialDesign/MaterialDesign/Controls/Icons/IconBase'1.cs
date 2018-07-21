using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Controls.Icons
{
  public abstract class IconBase
    : Control
  {
    internal abstract void UpdateData();
  }

  // ReSharper disable StaticMemberInGenericType
  public abstract class IconBase<TKind>
    : IconBase
  {
    private static Lazy<IDictionary<TKind, string>> _dataIndex;


    public static readonly DependencyProperty KindProperty = DP.Register(
      new Meta<IconBase<TKind>, TKind>(KindPropertyChangedCallback));


    private static readonly DependencyPropertyKey DataPropertyKey = DP.RegisterReadOnly(
      new Meta<IconBase<TKind>, string>(""));

    public static readonly DependencyProperty DataProperty = DataPropertyKey.DependencyProperty;


    private static readonly DependencyPropertyKey GeometryPropertyKey = DP.RegisterReadOnly(
      new Meta<IconBase<TKind>, Geometry>(Geometry.Empty));

    public static readonly DependencyProperty GeometryProperty = GeometryPropertyKey.DependencyProperty;



    public TKind Kind
    {
      get => (TKind)GetValue(KindProperty);
      set => SetValue(KindProperty, value);
    }

    /// <summary>
    /// Gets the icon path data for the current <see cref="Kind"/>.
    /// </summary>

    public string Data
    {
      get => (string)GetValue(DataProperty);
      private set => SetValue(DataPropertyKey, value);
    }

    [TypeConverter(typeof(GeometryConverter))]
    public Geometry Geometry
    {
      get => (Geometry)GetValue(GeometryProperty);
      protected set => SetValue(GeometryPropertyKey, value);
    }


    protected IconBase(
      [NotNull] Func<IDictionary<TKind, string>> dataIndexFactory)
    {
      dataIndexFactory.IsNotNull(nameof(dataIndexFactory));

      if (_dataIndex == null)
        _dataIndex = new Lazy<IDictionary<TKind, string>>(dataIndexFactory);
    }


    private static void KindPropertyChangedCallback(
      IconBase @this,
      DPChangedEventArgs<TKind> args)
    {
      @this.UpdateData();
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      UpdateData();
    }

    internal override void UpdateData()
    {
      if (!_dataIndex.Value.TryGetValue(Kind, out var data))
      {
        Geometry = Geometry.Empty;
      }
      else
      {
        Data = data;

        if (data == null || data.IsNullOrWhiteSpace())
          Geometry = Geometry.Empty;
        else
        {
          var parsedGeometry = Geometry.Parse(data);
          Geometry = parsedGeometry;
        }
      }
    }
  }
}