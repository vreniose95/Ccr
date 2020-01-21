using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Ccr.PresentationCore.Helpers;

namespace Ccr.MaterialDesign.Static
{
	public static class PaletteResources
	{
		public static readonly SolidColorBrush White000 = Brushes.White;
		public static readonly SolidColorBrush Black000 = Brushes.Black;
		public static readonly SolidColorBrush Transparent000 = Brushes.Transparent;

		private static Swatch _red;
		private static Swatch _pink;
		private static Swatch _purple;
		private static Swatch _deepPurple;
		private static Swatch _indigo;
		private static Swatch _blue;
		private static Swatch _lightBlue;
		private static Swatch _cyan;
		private static Swatch _teal;
		private static Swatch _green;
		private static Swatch _lightGreen;
		private static Swatch _lime;
		private static Swatch _yellow;
		private static Swatch _amber;
		private static Swatch _orange;
		private static Swatch _deepOrange;
		private static Swatch _brown;
		private static Swatch _grey;
		private static Swatch _blueGrey;
		private static Swatch _transparent;


		public static Swatch Red
		{
			get => _red ?? (_red = GlobalResources.Palette.GetSwatch(SwatchClassifier.Red));
		}

		public static Swatch Pink
		{
			get => _pink ?? (_pink = GlobalResources.Palette.GetSwatch(SwatchClassifier.Pink));
		}

		public static Swatch Purple
		{
			get => _purple ?? (_purple = GlobalResources.Palette.GetSwatch(SwatchClassifier.Purple));
		}

		public static Swatch DeepPurple
		{
			get => _deepPurple ?? (_deepPurple = GlobalResources.Palette.GetSwatch(SwatchClassifier.DeepPurple));
		}

		public static Swatch Indigo
		{
			get => _indigo ?? (_indigo = GlobalResources.Palette.GetSwatch(SwatchClassifier.Indigo));
		}

		public static Swatch Blue
		{
			get => _blue ?? (_blue = GlobalResources.Palette.GetSwatch(SwatchClassifier.Blue));
		}

		public static Swatch LightBlue
		{
			get => _lightBlue ?? (_lightBlue = GlobalResources.Palette.GetSwatch(SwatchClassifier.LightBlue));
		}

		public static Swatch Cyan
		{
			get => _cyan ?? (_cyan = GlobalResources.Palette.GetSwatch(SwatchClassifier.Cyan));
		}
		
		public static Swatch Teal
		{
			get => _teal ?? (_teal = GlobalResources.Palette.GetSwatch(SwatchClassifier.Teal));
		}

		public static Swatch Green
		{
			get => _green ?? (_green = GlobalResources.Palette.GetSwatch(SwatchClassifier.Green));
		}

		public static Swatch LightGreen
		{
			get => _lightGreen ?? (_lightGreen = GlobalResources.Palette.GetSwatch(SwatchClassifier.LightGreen));
		}

		public static Swatch Lime
		{
			get => _lime ?? (_lime = GlobalResources.Palette.GetSwatch(SwatchClassifier.Lime));
		}

		public static Swatch Yellow
		{
			get => _yellow ?? (_yellow = GlobalResources.Palette.GetSwatch(SwatchClassifier.Yellow));
		}

		public static Swatch Amber
		{
			get => _amber ?? (_amber = GlobalResources.Palette.GetSwatch(SwatchClassifier.Amber));
		}

		public static Swatch Orange
		{
			get => _orange ?? (_orange = GlobalResources.Palette.GetSwatch(SwatchClassifier.Orange));
		}

		public static Swatch DeepOrange
		{
			get => _deepOrange ?? (_deepOrange = GlobalResources.Palette.GetSwatch(SwatchClassifier.DeepOrange));
		}

		public static Swatch Brown
		{
			get => _brown ?? (_brown = GlobalResources.Palette.GetSwatch(SwatchClassifier.Brown));
		}

		public static Swatch Grey
		{
			get => _grey ?? (_grey = GlobalResources.Palette.GetSwatch(SwatchClassifier.Grey));
		}

		public static Swatch BlueGrey
		{
			get => _blueGrey ?? (_blueGrey = GlobalResources.Palette.GetSwatch(SwatchClassifier.BlueGrey));
		}

		//public static Swatch Transparent
		//{
		//	get => _transparent ?? (_transparent = GlobalResources.Palette.GetSwatch(SwatchClassifier.Transparent));
		//}




		//public static Swatch Blue => ResourceProvider.Get<Swatch>();
		//public static Swatch LightBlue => ResourceProvider.Get<Swatch>();
		//public static Swatch Cyan => ResourceProvider.Get<Swatch>();
		//public static Swatch Teal => ResourceProvider.Get<Swatch>();
		//public static Swatch Green => ResourceProvider.Get<Swatch>();
		//public static Swatch LightGreen => ResourceProvider.Get<Swatch>();
		//public static Swatch Lime => ResourceProvider.Get<Swatch>();
		//public static Swatch Yellow => ResourceProvider.Get<Swatch>();
		//public static Swatch Amber => ResourceProvider.Get<Swatch>();
		//public static Swatch Orange => ResourceProvider.Get<Swatch>();
		//public static Swatch DeepOrange => ResourceProvider.Get<Swatch>();
		//public static Swatch Brown => ResourceProvider.Get<Swatch>();
		//public static Swatch Grey => ResourceProvider.Get<Swatch>();
		//public static Swatch BlueGrey => ResourceProvider.Get<Swatch>();
		//public static Swatch Transparent => ResourceProvider.Get<Swatch>();

		public static ReadOnlyCollection<Swatch> RecommendedThemeSets = new ReadOnlyCollection<Swatch>(
			new List<Swatch>
			{
				Red, Pink, Purple, DeepPurple, Indigo, Blue, LightBlue, BlueGrey, Teal, Green, Orange, DeepOrange
			});

	}
	//Red, Pink, Purple, DeepPurple, Indigo, Blue, LightBlue, Cyan, Teal, Green, Orange, DeepOrange


}
