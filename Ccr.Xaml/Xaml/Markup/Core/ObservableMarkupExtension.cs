using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Ccr.Std.Core.Extensions;

namespace Ccr.Xaml.Markup.Core
{
  public class ObservableMarkupExtension
    : MarkupExtension,
      INotifyPropertyChanged
  {
    /// <summary>
    /// Notifies subscribers of the property change.
    /// </summary>
    /// <param name="propertyName">
    /// Name of the property.
    /// </param>
    public virtual void NotifyOfPropertyChange(
      string propertyName = null)
    {
     OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

    public void NotifyOfPropertyChange<TProperty>(
	    Expression<Func<TProperty>> property)
    {
      NotifyOfPropertyChange(property.GetMemberInfo().Name);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void OnPropertyChanged(PropertyChangedEventArgs args)
    { 
      PropertyChanged?.Invoke(this, args);
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      throw new NotImplementedException();
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
