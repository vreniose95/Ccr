using System;
using System.Runtime.CompilerServices;
using System.Windows;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.PresentationCore.Helpers.DependencyHelpers
{
	/// <summary>
	/// Helper methods for <see cref="DependencyProperty"/> registration that leverage generics and 
	/// the <see cref="CallerMemberNameAttribute"/> to simplify registration code and eliminate
	/// the need for parameter type casting in callbacks, coercion, and validation.
	/// 
	/// Generic delegate wrappers:
	/// 
	/// <list type="table">
	///		<listheader>
	///			<term>Framework Type</term>
	///			<description>The Generic Equivelent</description>
	///		</listheader>
	///		<item>
	///			<term>FrameworkPropertyMetadata</term>
	///			<description>
	///				<see cref="Meta{TOwner,TValue}"/>		
	///			</description>
	///		</item>
	///		<item>
	///			<term>PropertyChangedCallback</term>
	///			<description>
	///				<see cref="PropertyChange{TOwner,TValue}"/>		
	///			</description>
	///		</item>
	///		<item>
	///			<term>CoerceValueCallback</term>
	///			<description>
	///				<see cref="PropertyCoerce{TOwner,TValue}"/>		
	///			</description>
	///		</item>
	///		<item>
	///			<term>ValidateValueCallback</term>
	///			<description>
	///				<see cref="PropertyValidate{TValue}"/>		
	///			</description>
	///		</item>
	/// </list>
	/// </summary>
	public static class DP
	{
		public static TValue Get<TValue>(
			this DependencyObject @this,
			DependencyProperty dependencyProperty)
		{
			if (@this == null)
				throw new ArgumentNullException(
					nameof(@this),
					$"Get dependency property \'{dependencyProperty.Name}\' value failed. " +
					$"Object cannot be null.");

			return (TValue)@this.GetValue(dependencyProperty);
		}
		public static void Set<TValue>(
			this DependencyObject @this,
			DependencyProperty dependencyProperty,
			TValue value)
		{
			if (@this == null)
				throw new ArgumentNullException(
					nameof(@this),
					$"Set dependency property \'{dependencyProperty.Name}\' value failed. " +
					$"Object cannot be null.");

			@this.SetValue(dependencyProperty, value);
		}

		#region Constants
		private const string dependencyPropertyFieldSuffix = "Property";

		private const string dependencyPropertyKeyFieldSuffix = "PropertyKey";

		#endregion

		#region Methods
		/// <summary>
		/// Registers a <see cref="DependencyProperty"/> using the generic dependency property system
		/// </summary>
		/// <typeparam name="TOwner">
		/// The owner type that the property is being registered to. This type must inherit <see cref="DependencyObject"/>
		/// </typeparam>
		/// <typeparam name="TValue">
		/// The value type of the property being registered
		/// </typeparam>
		/// <param name="meta">
		/// An instance of the <see cref="Meta{TOwner,TValue}"/> generic <see cref="FrameworkPropertyMetadata"/> 
		/// wrapper class used to provide default values, callbacks, and metadata flags
		/// </param>
		/// <param name="validation">
		/// Property validation callback
		/// </param>
		/// <param name="autoFieldName">
		/// The name of the DependencyProperty field being assigned to passed by the compiler
		/// </param>
		/// <returns>
		/// A <see cref="DependencyProperty"/> registered to the owner class <typeparamref name="TOwner"/>
		/// with the value of type <typeparamref name="TValue"/>
		/// </returns>
		[NotNull]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static DependencyProperty Register<TOwner, TValue>(
			[NotNull] Meta<TOwner, TValue> meta,
			[CanBeNull] PropertyValidate<TValue> validation = null,
			[NotNull, CallerMemberName] string autoFieldName = "")
				where TOwner : DependencyObject
		{
			meta.IsNotNull(nameof(meta));
			autoFieldName.IsNotNull(nameof(autoFieldName));

			return DependencyProperty.Register(
				GetPropertyName(autoFieldName),
				typeof(TValue),
				typeof(TOwner),
				meta,
				validation.TryInvoke);
		}

		/// <summary>
		/// Registers a ReadOnly <see cref="DependencyProperty"/> using the generic dependency property system
		/// </summary>
		/// <typeparam name="TOwner">
		/// The owner type that the property is being registered to. This type must inherit <see cref="DependencyObject"/>
		/// </typeparam>
		/// <typeparam name="TValue">
		/// The value type of the property being registered
		/// </typeparam>
		/// <param name="meta">
		/// An instance of the <see cref="Meta{TOwner,TValue}"/> generic <see cref="FrameworkPropertyMetadata"/> 
		/// wrapper class used to provide default values, callbacks, and metadata flags
		/// </param>
		/// <param name="validation">
		/// Property validation callback
		/// </param>
		/// <param name="autoFieldName">
		/// The name of the DependencyProperty field being assigned to passed by the compiler
		/// </param>
		/// <returns>
		/// A <see cref="DependencyPropertyKey"/> containing a reference to the registered <see cref="DependencyProperty"/> 
		/// through the <see cref="DependencyPropertyKey.DependencyProperty"/> property registered to the owner class 
		/// <typeparamref name="TOwner"/> with the value of type <typeparamref name="TValue"/>
		/// </returns>
		[NotNull]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static DependencyPropertyKey RegisterReadOnly<TOwner, TValue>(
			[NotNull] Meta<TOwner, TValue> meta,
			[CanBeNull] PropertyValidate<TValue> validation = null,
			[NotNull, CallerMemberName] string autoFieldName = "")
				where TOwner : DependencyObject
		{
			meta.IsNotNull(nameof(meta));
			autoFieldName.IsNotNull(nameof(autoFieldName));

			return DependencyProperty.RegisterReadOnly(
				GetReadOnlyPropertyName(autoFieldName),
				typeof(TValue),
				typeof(TOwner),
				meta,
				validation.TryInvoke);
		}

		/// <summary>
		/// Registers an Attached DependencyProperty using the generic dependency property system
		/// </summary>
		/// <typeparam name="TOwner">
		/// The owner type that the property is being registered to. This type is not required to inherit from 
		/// <see cref="DependencyObject"/> as it registers an attached <see cref="DependencyProperty"/>
		/// </typeparam>
		/// <typeparam name="TValue">
		/// The value type of the property being registered
		/// </typeparam>
		/// <param name="meta">
		/// An instance of the <see cref="Meta{TOwner,TValue}"/> generic <see cref="FrameworkPropertyMetadata"/> 
		/// wrapper class used to provide default values, callbacks, and metadata flags
		/// </param>
		/// <param name="validation">
		/// Property validation callback
		/// </param>
		/// <param name="autoFieldName">
		/// The name of the DependencyProperty field being assigned to passed by the compiler
		/// </param>
		/// <returns>
		/// A <see cref="DependencyPropertyKey"/> registered to the owner class <typeparamref name="TOwner"/>
		/// with the value of type <typeparamref name="TValue"/>
		/// </returns>
		[NotNull]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static DependencyProperty Attach<TValue>(//		public static DependencyProperty<TValue> Attach<TValue>(
			Type owner,
			[NotNull] Meta<DependencyObject, TValue> meta,
			[CanBeNull] PropertyValidate<TValue> validation = null,
			[NotNull, CallerMemberName] string autoFieldName = "")
		{
			meta.IsNotNull(nameof(meta));
			autoFieldName.IsNotNull(nameof(autoFieldName));

			return DependencyProperty.RegisterAttached(
				GetPropertyName(autoFieldName),
				typeof(TValue),
				owner,
				meta,
				validation.TryInvoke);
		}

		/// <summary>
		/// Adds a DependencyProperty owner to a DependencyObject class using the generic dependency property system
		/// </summary>
		/// <typeparam name="TOwner">
		/// The owner type that the property is being registered to. This type must inherit <see cref="DependencyObject"/>
		/// </typeparam>
		/// <typeparam name="TValue">
		/// The type of the property being registered
		/// </typeparam>
		/// <param name="property">
		/// DependencyProperty to Add
		/// </param>
		/// <param name="meta">
		/// An instance of the <see cref="Meta{TOwner,TValue}"/> generic <see cref="FrameworkPropertyMetadata"/> 
		/// wrapper class used to provide default values, callbacks, and metadata flags
		/// </param>
		/// <returns>
		/// A <see cref="DependencyPropertyKey"/> registered to the owner class <typeparamref name="TOwner"/>
		/// with the value of type <typeparamref name="TValue"/>
		/// </returns>
		[NotNull]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static DependencyProperty Add<TOwner, TValue>(
			[NotNull] DependencyProperty property,
			[NotNull] Meta<TOwner, TValue> meta)
				where TOwner : DependencyObject
		{
			meta.IsNotNull(nameof(meta));
			property.IsNotNull(nameof(property));

			return property.AddOwner(
				typeof(TOwner),
				meta);
		}

		/// <summary>
		/// Gets the formatted <see cref="DependencyProperty"/> name
		/// </summary>
		/// <param name="fieldName">
		/// The <see cref="DependencyProperty"/> field name
		/// </param>
		/// <returns>
		/// Formatted string indicating the dependency property name
		/// </returns>
		[NotNull]
		private static string GetPropertyName(
			[NotNull] string fieldName)
		{
			fieldName.IsNotNull(nameof(fieldName));

			if (!fieldName.EndsWith(dependencyPropertyFieldSuffix))
				throw new ArgumentException(
					$"The DependencyProperty field name \'{fieldName}\' parameter \'{nameof(fieldName)}\' is not valid. " +
					$"The value must be in \"{{name}}{dependencyPropertyFieldSuffix}\" naming convension.",
					nameof(fieldName));

			var propertyNameLength = fieldName.Length - dependencyPropertyFieldSuffix.Length;
			var propertyName = fieldName.Substring(0, propertyNameLength);
			return propertyName;
		}

		/// <summary>
		/// Gets the formatted <see cref="DependencyProperty"/> name from the
		/// associated <see cref="DependencyPropertyKey"/>'s field name
		/// </summary>
		/// <param name="fieldName">
		/// The <see cref="DependencyPropertyKey"/> field name
		/// </param>
		/// <returns>
		/// Formatted string indicating the dependency property name
		/// </returns>
		[NotNull]
		private static string GetReadOnlyPropertyName(
			[NotNull] string fieldName)
		{
			fieldName.IsNotNull(nameof(fieldName));

			if (!fieldName.EndsWith(dependencyPropertyKeyFieldSuffix))
				throw new ArgumentException(
					$"The DependencyPropertyKey field name value \'{fieldName}\' parameter \'{nameof(fieldName)}\' is not valid. " +
					$"The value must be in \"{{name}}{dependencyPropertyKeyFieldSuffix}\" naming convension.",
					nameof(fieldName));

			var propertyNameLength = fieldName.Length - dependencyPropertyFieldSuffix.Length;
			var propertyName = fieldName.Substring(0, propertyNameLength);
			return propertyName;
		}

		#endregion

	}
}
