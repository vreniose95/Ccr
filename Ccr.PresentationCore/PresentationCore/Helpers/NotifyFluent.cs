using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using Ccr.Std.Core.Extensions;

namespace Ccr.PresentationCore.Helpers
{
	public abstract class NotifyFluent
		: INotifyPropertyChanged
	{
		////TODO why doesnt this work? does this class need to be abstract?
		//private static readonly DependencyObject DesignerModeDO = new DependencyObject();
		//public bool IsInDesignMode => DesignerProperties.GetIsInDesignMode(DesignerModeDO);


		private static bool? _isInDesignMode;

		public event PropertyChangedEventHandler PropertyChanged;


		/// <summary>
		/// Gets a value indicating whether the control is in design mode (running in Blend
		/// or Visual Studio).
		/// </summary>
		public static bool IsInDesignModeStatic
		{
			get
			{
				if (_isInDesignMode.HasValue)
					return _isInDesignMode.Value;

				var prop = DesignerProperties.IsInDesignModeProperty;

				_isInDesignMode = (bool)DependencyPropertyDescriptor
					.FromProperty(prop, typeof(FrameworkElement))
					.Metadata.DefaultValue;

				return _isInDesignMode.Value;
			}
		}


		/// <summary>
		///		Notifies subscribers of the property change.
		/// </summary>
		/// <param name="propertyName">
		///		Name of the property.
		/// </param>
		public virtual void NotifyOfPropertyChange(
			string propertyName = null)
		{
			RaisePropertyChanged(
				new PropertyChangedEventArgs(
					propertyName));
		}

		public void NotifyOfPropertyChange<TProperty>(
			Expression<Func<TProperty>> property)
		{
			NotifyOfPropertyChange(
				property.GetMemberInfo().Name);
		}



		public void RaisePropertyChanged(
			PropertyChangedEventArgs args)
		{
			PropertyChanged?.Invoke(
				this,
				new PropertyChangedEventArgs(
					args.PropertyName));
		}
	}



	//public abstract class NotifyFluent
	//  : INotifyPropertyChangedEx
	//{
	//  public event PropertyChangedEventHandler PropertyChanged;


	//  public void RaisePropertyChanged(
	//    IPropertyChangedEventArgs args)
	//  {
	//    PropertyChanged?.Invoke(
	//      this,
	//      new PropertyChangedEventArgs(
	//        args.PropertyName));
	//  }
	//}
}