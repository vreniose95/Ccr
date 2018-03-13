using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ccr.MaterialDesign.MVVM;

namespace Ccr.MDHybrid.Demo.Views
{
  /// <summary>
  /// Interaction logic for Calc.xaml
  /// </summary>
  public partial class Calc : Window
  {
    public Calc()
    {
      InitializeComponent();
      DataContext = new CalcViewModel();
    }
  }
  public class CalcViewModel
    : ViewModelBase
  {
    public ICommand CalculatorButtonClickCommand => new Command(
      t =>
      {
        
      });
  }
}
