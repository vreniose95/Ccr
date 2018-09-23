using System.ComponentModel;

namespace Ccr.PresentationCore.Helpers
{
  public abstract class NotifyFluent
    : INotifyPropertyChangedEx
  {
    public event PropertyChangedEventHandler PropertyChanged;


    public void RaisePropertyChanged(
      IPropertyChangedEventArgs args)
    {
      PropertyChanged?.Invoke(
        this,
        new PropertyChangedEventArgs(
          args.PropertyName));
    }
  }
}