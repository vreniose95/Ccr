using System.ComponentModel;

namespace Ccr.PresentationCore.Helpers
{
  public interface INotifyPropertyChangedEx
    : INotifyPropertyChanged
  {
    void RaisePropertyChanged(
      IPropertyChangedEventArgs args);
  }
}