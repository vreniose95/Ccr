using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.Core.Numerics.Ranges;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Controls.Icons
{
  public class Icon
	  : Control
	{
		private static Lazy<IDictionary<IconKind, string>> _dataIndex;


		public static readonly DependencyProperty KindProperty = DP.Register(
			new Meta<Icon, IconKind>(iconKindPropertyChangedCallback));
		
		private static readonly DependencyPropertyKey DataPropertyKey = DP.RegisterReadOnly(
			new Meta<Icon, string>(""));
		public static readonly DependencyProperty DataProperty = DataPropertyKey.DependencyProperty;


		private static readonly DependencyPropertyKey GeometryPropertyKey = DP.RegisterReadOnly(
			new Meta<Icon, Geometry>(Geometry.Empty));
		public static readonly DependencyProperty GeometryProperty = GeometryPropertyKey.DependencyProperty;


		public static readonly DependencyProperty FlipProperty = DP.Register(
      new Meta<Icon, IconFlip>(IconFlip.None));

    public static readonly DependencyProperty RotationProperty = DP.Register(
	    new Meta<Icon, double>(0, null, coerceRotationProperty));


    public IconFlip Flip
    {
      get => (IconFlip)GetValue(FlipProperty);
      set => SetValue(FlipProperty, value);
    }

    public double Rotation
    {
      get => (double)GetValue(RotationProperty);
      set => SetValue(RotationProperty, value);
    }

		public IconKind Kind
    {
	    get => (IconKind)GetValue(KindProperty);
	    set => SetValue(KindProperty, value);
    }

    /// <summary>
    ///		Gets the icon path data for the current <see cref="Kind"/>.
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


    protected Icon(
	    [NotNull] Func<IDictionary<IconKind, string>> dataIndexFactory)
    {
	    dataIndexFactory.IsNotNull(nameof(dataIndexFactory));

	    if (_dataIndex == null)
		    _dataIndex = new Lazy<IDictionary<IconKind, string>>(dataIndexFactory);
    }

    public Icon()
	    : this(
		    () => IconDataFactory.Create)
    {
    }

		static Icon()
    {
	    ControlExtensions.OverrideStyleKey<Icon>();

	    OpacityProperty.OverrideMetadata(
		    typeof(Icon),
		    new UIPropertyMetadata(1.0,
			    onOpacityChangedCallback));
    }

		
    public override void OnApplyTemplate()
    {
	    base.OnApplyTemplate();
	    UpdateData();
    }

    internal void UpdateData()
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
		
    private static void iconKindPropertyChangedCallback(
	    Icon @this,
	    DPChangedEventArgs<IconKind> args)
    {
	    @this.UpdateData();
    }

		private static double coerceRotationProperty(
      Icon @this,
      double baseValue)
    {
      return baseValue.Constrain(new DoubleRange(0d, 360d));
      //TODO
      /*eturn baseValue.Constrain((0d, 360d));*/
    }

    private static void onOpacityChangedCallback(
      DependencyObject @this,
      DependencyPropertyChangedEventArgs args)
    {

    }
  }
}
