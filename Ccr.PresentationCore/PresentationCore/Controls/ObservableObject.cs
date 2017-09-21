using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

// ReSharper disable ArrangeAccessorOwnerBody

namespace Ccr.PresentationCore.Controls
{
	public class ObservableObject : INotifyPropertyChanged
	{
		//private static DependencyObject _designerMode;
		//protected static DependencyObject DesignerMode
		//{
		//	get { return _designerMode ?? (_designerMode = new DependencyObject()); }
		//}

		//public static bool IsInDesignMode
		//{
		//	get { return DesignerProperties.GetIsInDesignMode(DesignerMode); }
		//}

		private static bool? _isInDesignMode;


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
				
				_isInDesignMode= (bool)DependencyPropertyDescriptor.FromProperty(
					DesignerProperties.IsInDesignModeProperty, typeof(FrameworkElement))
						.Metadata.DefaultValue;

				return _isInDesignMode.Value;
			}
		}

		public void NotifyOfPropertyChange<TProperty>(
			Expression<Func<TProperty>> property)
		{
			OnPropertyChanged(property.GetMemberInfo().Name);
		}


		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged(
			[CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
