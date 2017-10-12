using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Markup;
using Ccr.Core.Extensions;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.PresentationCore.Layout;
using Ccr.Xaml.Collections;

namespace Ccr.MaterialDesign
{
	[ContentProperty(nameof(Swatches))]
	public class Palette
		: Freezable
	{
		private readonly Dictionary<object, Swatch> _mapping
			= new Dictionary<object, Swatch>();
		public static readonly DependencyProperty SwatchesProperty = DP.Register(
			new Meta<Palette, ReactiveCollection<Swatch>>());

		public ReactiveCollection<Swatch> Swatches
		{
			get => (ReactiveCollection<Swatch>)GetValue(SwatchesProperty);
			set => SetValue(SwatchesProperty, value);
		}

		public Palette()
		{
			Swatches = new ReactiveCollection<Swatch>();
			Swatches.CollectionChangedGeneric += onSwatchCollectionChange;
		}

		//public static Swatch Interpolate(Percentage progression)
		//{

		//}

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
	}
}
