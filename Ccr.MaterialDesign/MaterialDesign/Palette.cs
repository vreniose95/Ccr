using System.Collections.Specialized;
using System.Windows;
using System.Windows.Markup;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Xaml.Collections;

namespace Ccr.MaterialDesign
{
	[ContentProperty(nameof(Swatches))]
	public class Palette : Freezable
	{
		public static readonly DependencyProperty SwatchesProperty = DP.Register(
			new Meta<Palette, ReactiveCollection<Swatch>>());

		public ReactiveCollection<Swatch> Swatches
		{
			get => (ReactiveCollection<Swatch>) GetValue(SwatchesProperty);
			set => SetValue(SwatchesProperty, value);
		}

		public Palette()
		{
			Swatches = new ReactiveCollection<Swatch>();
			Swatches.CollectionChangedGeneric += onSwatchCollectionChange;
		}

		private void onSwatchCollectionChange(
			IReactiveCollection<Swatch> sender, 
			NotifyCollectionChangedEventArgs<Swatch> args)
		{
			if (args.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (var item in args.NewItems)
				{
					item.AttachHost(this);
				}
			}
			else if (args.Action == NotifyCollectionChangedAction.Remove
			         || args.Action == NotifyCollectionChangedAction.Reset)
			{
				foreach (var item in args.NewItems)
				{
					item.DetachHost();
				}
			}
			
		}

		protected override Freezable CreateInstanceCore()
		{
			return new Palette();
		}
	}
}
