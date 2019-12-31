using System;
using Caliburn.Micro;
using Ccr.MDHybrid.Demo.ViewModels;
using System.Collections.Generic;
using System.Windows;

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
          { "WindowState" , WindowState.Maximized }
        };

      DisplayRootViewFor<RootViewModel>(settings);
    }
  }
}