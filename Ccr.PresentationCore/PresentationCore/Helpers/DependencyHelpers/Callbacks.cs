using System.Windows;
namespace Ccr.PresentationCore.Helpers.DependencyHelpers
{
	public delegate void PropertyChange<in TOwner, TValue>(
		TOwner @this, 
		DPChangedEventArgs<TValue> args)
			where TOwner : DependencyObject;

	public delegate TValue PropertyCoerce<in TOwner, TValue>(
		TOwner @this, 
		TValue baseValue)
			where TOwner : DependencyObject;

	public delegate bool PropertyValidate<in TValue>(
		TValue value);
}
