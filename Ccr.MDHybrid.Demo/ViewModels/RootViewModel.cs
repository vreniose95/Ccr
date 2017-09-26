using System.Windows.Input;
using System.Windows.Media.Media3D;
using Caliburn.Micro;
using Ccr.MaterialDesign;
using Ccr.MaterialDesign.MVVM;

namespace Ccr.MDHybrid.Demo.ViewModels
{
	public class RootViewModel
		: ViewModelBase
	{
		private string testProperty = "Some Nonsense";
		public string TestProperty
		{
			get => testProperty;
			set
			{
				testProperty = value;
				NotifyOfPropertyChange(() => TestProperty);
			}
		}
	

		//private Palette materialPalette;
		//public Palette MaterialPalette
		//{
		//	get => materialPalette;
		//	set
		//	{
		//		materialPalette = value;
		//		NotifyOfPropertyChange(() => MaterialPalette);
		//	}
		//}

		//public RootViewModel()
		//{
		//	MaterialPalette =
		//}

		public ICommand ChangeItCommand => new Command(
			t =>
			{
				TestProperty = "Yuppppppp";
			});

	}
}
