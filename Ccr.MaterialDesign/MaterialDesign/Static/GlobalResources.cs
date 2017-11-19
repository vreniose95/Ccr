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
		private static ResourceProvider _paletteResourceProvider;


		private static Palette _materialDesignPalette;
	  public static Palette MaterialDesignPalette
		{
			get => _materialDesignPalette ??
						 _paletteResourceProvider.Get<Palette>("MDH.Palette");
		}

		static GlobalResources()
		{
			var _palletResourceUri = PackUriBuilder.Build(
				"Ccr.MDHybrid",
				"MDHybrid/Themes/MDHybrid.Palette.xaml");

			_paletteResourceProvider = new ResourceProvider(
				_palletResourceUri);
      //"pack://application:,,,/Material;component/MDHybrid/Themes/MDHybrid.Palette.xaml");
      //"pack://application:,,,/Ccr.MDHybrid;component/MDHybrid/Themes/MDHybrid.Palette.xaml"
      /*				return new Uri(
					$"{packPrefix}{_assemblyName}{component}{_assemblyName}/{_componentPath}",
					UriKind.RelativeOrAbsolute);
			}*/
    }
  }
}
