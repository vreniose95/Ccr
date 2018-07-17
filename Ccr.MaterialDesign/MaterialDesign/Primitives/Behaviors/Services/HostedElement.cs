using System.Diagnostics;
using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using JetBrains.Annotations;
// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public class HostedElement<TElement> 
		: DependencyObject
			where TElement 
			  : DependencyObject
	{
		protected TElement _hostElement;

		public TElement HostElement
		{
			get => _hostElement;
		}


	  public static readonly DependencyProperty InheritanceContextModeProperty = DP.Register(
	    new Meta<HostedElement<TElement>, bool>());

	  public bool InheritanceContextMode
	  {
	    get => (bool) GetValue(InheritanceContextModeProperty);
	    set => SetValue(InheritanceContextModeProperty, value);
	  }

		public bool IsHosted
		{
			get => _hostElement != null;
		}


		public void AttachHost(
			[NotNull] TElement hostElement)
		{
			if (IsHosted)
				Debug.WriteLine("already has a host element");

			_hostElement = hostElement;
			OnHostAttached(_hostElement);
		}

		public void DetachHost()
		{
			if (_hostElement == null)
			{
				Debug.WriteLine("no hosted element to detach.");
				return;
			}

			OnHostDetaching(_hostElement);
			_hostElement = null;
		}


		protected virtual void OnHostAttached(
		  DependencyObject host)
		{
		}

		protected virtual void OnHostDetaching(
		  DependencyObject host)
		{
		}

	}
}
