using System.Windows;
using Ccr.Core.Extensions;

namespace Ccr.PresentationCore.Helpers.DependencyHelpers
{
	/// <summary>
	/// A wrapper struct for <see cref="DependencyPropertyChangedEventArgs"/> that provides
	/// data on the various <see cref="DependencyProperty"/> property changed events
	/// </summary>
	/// <typeparam name="TValue">
	/// The value type of the <see cref="DependencyProperty"/> 
	/// </typeparam>
	public struct DPChangedEventArgs<TValue>
	{
		#region Properties
		/// <summary>
		/// The dependency property whose value changed
		/// </summary>
		public DependencyProperty Property { get; }

		/// <summary>
		/// The old value of the property
		/// </summary>
		public TValue OldValue { get; }

		/// <summary>
		/// The new value of the property
		/// </summary>
		public TValue NewValue { get; }

		#endregion


		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="DPChangedEventArgs{TValue}"/> class
		/// </summary>
		/// <param name="property">
		/// The dependency property whose value has changed
		/// </param>
		/// <param name="oldValue">
		/// The value of the property before the change
		/// </param>
		/// <param name="newValue">
		/// The value of the property after the change
		/// </param>
		public DPChangedEventArgs(
			DependencyProperty property, 
			TValue oldValue,
			TValue newValue)
		{
			Property = property;
			OldValue = oldValue;
			NewValue = newValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DPChangedEventArgs{TValue}"/> class
		/// from an instance of the non-generic struct <see cref="DependencyPropertyChangedEventArgs"/>
		/// </summary>
		/// <param name="args">
		/// The instance of the non-generic <see cref="DependencyPropertyChangedEventArgs"/> struct
		/// to be converted to the generic wrapper class<see cref="DPChangedEventArgs{TValue}"/> class
		/// </param>
		public DPChangedEventArgs(
			DependencyPropertyChangedEventArgs args) : this(
				args.Property,
				args.OldValue.AsOrDefault<TValue>(),
				args.NewValue.AsOrDefault<TValue>())
		{
		}

		#endregion
	}
}
