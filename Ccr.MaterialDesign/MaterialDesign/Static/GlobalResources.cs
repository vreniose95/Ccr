using System;
using Ccr.PresentationCore.Helpers;

namespace Ccr.MaterialDesign.Static
{
	public class GlobalResources
	{
		internal class PackUriBuilder
		{
			protected const string packPrefix = "pack://application:,,,/";
			protected const string component = ";component/";


			internal static Uri Build(
				string _assemblyName,
				string _componentPath)
			{
				return new Uri(
					$"{packPrefix}{_assemblyName}{component}/{_componentPath}",
					UriKind.RelativeOrAbsolute);
			}

		}
		private static readonly ResourceProvider _paletteResourceProvider;


	  private static Palette _palette;
	  public static Palette Palette
		{
			get => _palette
        ?? (_palette = 
			       _paletteResourceProvider
              .Get<Palette>("MDH.Palette"));
		}

		static GlobalResources()
		{
			var _palletResourceUri = PackUriBuilder.Build(
				"Ccr.MDHybrid",
				"MDHybrid/Themes/Generic.xaml");

			_paletteResourceProvider = new ResourceProvider(
				_palletResourceUri);
    }
  }
}
