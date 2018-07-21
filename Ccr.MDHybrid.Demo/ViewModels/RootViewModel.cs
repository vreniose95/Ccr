using System.Windows.Input;
using System.Windows.Threading;
using Ccr.MaterialDesign;
using Ccr.MaterialDesign.MVVM;
using Ccr.MaterialDesign.Static;

namespace Ccr.MDHybrid.Demo.ViewModels
{
	public class RootViewModel
		: ViewModelBase
	{
	  public RootViewModel()
	  {
	    CardDemoView = new CardDemoViewModel();
    }

	  private CardDemoViewModel cardDemoView;
	  public CardDemoViewModel CardDemoView
	  {
	    get => cardDemoView;
	    set
	    {
	      cardDemoView = value;
	      NotifyOfPropertyChange(() => CardDemoView);
	    }
	  }
    


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

		private Palette materialDesignPalette;
		public Palette MaterialDesignPalette
		{
			get => materialDesignPalette;
			set
			{
				materialDesignPalette = value;
				NotifyOfPropertyChange(() => MaterialDesignPalette);
			}
		}


		//private NavigationViewModel navigationView;
		//public NavigationViewModel NavigationView
		//{
		//	get => navigationView;
		//	set
		//	{
		//		navigationView = value;
		//		NotifyOfPropertyChange(() => NavigationView);
		//	}
		//}

		//public RootViewModel()
		//{
		//	NavigationView = new NavigationViewModel();
		//}

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
		    MaterialDesignPalette = GlobalResources.Palette;

		  });

	}
}
