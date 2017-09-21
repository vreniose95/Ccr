using System.Diagnostics;
using System.Windows;
using JetBrains.Annotations;
// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public class HostedElement<TElement> 
		: DependencyObject
			where TElement : DependencyObject
	{
		protected TElement _hostElement;
		public TElement HostElement
		{
			get
			{
				return _hostElement;
			}
		}

		public bool IsHosted
		{
			get
			{
				return _hostElement != null;
			}
		}


		public void AttachHost(
			[NotNull] TElement hostElement)
		{
			if (_hostElement != null)
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


		protected virtual void OnHostAttached(DependencyObject host)
		{
		}

		protected virtual void OnHostDetaching(DependencyObject host)
		{
		}

	}
}
