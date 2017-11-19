using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Controls.Icons
{
  public abstract class IconBase<TKind>
    : IconBase
  {
    private static Lazy<IDictionary<TKind, string>> _dataIndex;


    public static readonly DependencyProperty KindProperty = DP.Register(
      new Meta<IconBase<TKind>, TKind>(KindPropertyChangedCallback));

    protected static readonly DependencyPropertyKey DataPropertyKey = DP.RegisterReadOnly(
      new Meta<IconBase<TKind>, string>(""));

    // ReSharper disable once StaticMemberInGenericType
    public static readonly DependencyProperty DataProperty = DataPropertyKey.DependencyProperty;



    public TKind Kind
    {
      get => (TKind) GetValue(KindProperty);
      set => SetValue(KindProperty, value);
    }

    /// <summary>
    /// Gets the icon path data for the current <see cref="Kind"/>.
    /// </summary>
    [TypeConverter(typeof(GeometryConverter))]
    public string Data
    {
      get => (string) GetValue(DataProperty);
      private set => SetValue(DataPropertyKey, value);
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
      string data = null;
      _dataIndex.Value?.TryGetValue(Kind, out data);
      Data = data;
    }
  }
}