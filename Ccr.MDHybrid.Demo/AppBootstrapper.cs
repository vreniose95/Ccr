using Ccr.MDHybrid.Demo.ViewModels;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;

namespace Ccr.MDHybrid.Demo
{
  public class AppBootstrapper
    : BootstrapperBase
  {
    public AppBootstrapper()
    {
      Initialize();
    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
      var settings = new Dictionary<string, object>
        {
          { "SizeToContent", SizeToContent.Manual },
          { "WindowState" , WindowState.Maximized },
          { "WindowStyle", WindowStyle.None }
        };

      DisplayRootViewFor<RootViewModel>(settings);
    }
  }

}
