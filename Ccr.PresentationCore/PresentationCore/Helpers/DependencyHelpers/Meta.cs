using System.Runtime.CompilerServices;
using System.Windows;
using Ccr.Core.Extensions;
// ReSharper disable ConvertToAutoPropertyWhenPossible
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable ConvertToAutoProperty

namespace Ccr.PresentationCore.Helpers.DependencyHelpers
{
	/// <summary>
	/// A generic wrapper class for the <see cref="FrameworkPropertyMetadata"/> framework class. 
	/// </summary>
	/// <typeparam name="TOwner">
	/// The type of the owner class that the dependency property is to be registered to.
	/// </typeparam>
	/// <typeparam name="TValue">
	/// The backing value type for the dependency property.
	/// </typeparam>
	public class Meta<TOwner, TValue>
		where TOwner : DependencyObject
	{
		#region Fields
		/// <summary>
		/// The equivelent <see cref="FrameworkPropertyMetadata"/> value. 
		/// </summary>
		private FrameworkPropertyMetadata _frameworkPropertyMetdata;

		/// <summary>
		/// Backing value holding the default value of the dependency property.
		/// </summary>
		private readonly TValue _defaultValue;
		/// <summary>
		/// Backing value holding a reference to a <see cref="T:System.Windows.PropertyChangedCallback"/> 
		/// implementation specified in this metadata. 
		/// </summary>
		private readonly PropertyChange<TOwner, TValue> _propertyChangedCallback;
		/// <summary>
		/// Backing value holding a reference to a <see cref="T:System.Windows.CoerceValueCallback"/> 
		/// implementation specified in this metadata. 
		/// </summary>
		private readonly PropertyCoerce<TOwner, TValue> _coerceValueCallback;
		/// <summary>
		/// Backing value holding the <see cref="FrameworkPropertyMetadataOptions"/> options
		/// for the dependency property.
		/// </summary>
		private readonly FrameworkPropertyMetadataOptions _optionFlags = FrameworkPropertyMetadataOptions.None;

		#endregion

		#region Properties
		/// <summary>
		/// Gets the default value of the dependency property.
		/// </summary>
		public TValue DefaultValue
		{
			get
			{
				return _defaultValue;
			}
		}
		///<summary>
		/// Gets a reference to a <see cref="T:System.Windows.PropertyChangedCallback"/> implementation 
		/// specified in this metadata.
		/// </summary>
		public PropertyChange<TOwner, TValue> PropertyChangedCallback
		{
			get
			{
				return _propertyChangedCallback;
			}
		}
		/// <summary>
		/// Gets a reference to a <see cref="T:System.Windows.CoerceValueCallback"/> 
		/// implementation specified in this metadata.
		/// </summary>
		public PropertyCoerce<TOwner, TValue> CoerceValueCallback
		{
			get
			{
				return _coerceValueCallback;
			}
		}
		/// <summary>
		/// Specifies the types of framework-level property behavior that pertain to a particular 
		/// dependency property in the Windows Presentation Foundation (WPF) property system.
		/// </summary>
		public FrameworkPropertyMetadataOptions OptionFlags
		{
			get
			{
				return _optionFlags;
			}
		}

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Meta()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with a specified 
		/// default value for the dependency property that the resulting produced framework metadata 
		/// will be applied to.
		/// </summary>
		/// <param name="defaultValue">
		/// The default value to specify for dependency property of the type <typeparamref name="TValue"/>
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Meta(
			TValue defaultValue)
		{
			_defaultValue = defaultValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with the 
		/// specified <see cref="PropertyChange{TOwner,TValue}"/> callback implementation reference.
		/// </summary>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Meta(PropertyChange<TOwner, TValue> propertyChangedCallback)
		{
			_propertyChangedCallback = propertyChangedCallback;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with
		/// a specified default value and <see cref="PropertyChange{TOwner,TValue}"/> callback implementation 
		/// reference for the dependency property that the resulting produced framework metadata will be applied to.
		/// </summary>
		/// <param name="defaultValue">
		/// The default value to specify for dependency property of the type <typeparamref name="TValue"/>
		/// </param>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Meta(
			TValue defaultValue,
			PropertyChange<TOwner, TValue> propertyChangedCallback)
		{
			_defaultValue = defaultValue;
			_propertyChangedCallback = propertyChangedCallback;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with
		/// a specified default value and <see cref="PropertyChange{TOwner,TValue}"/> callback implementation 
		/// reference for the dependency property that the resulting produced framework metadata will be applied to.
		/// </summary>
		/// <param name="defaultValue">
		/// The default value to specify for dependency property of the type <typeparamref name="TValue"/>
		/// </param>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		/// <param name="propertyCoerceCallback">
		/// Referened to a handler implementation that is to be called by the property system calls
		/// <see cref="DependencyObject.CoerceValue(DependencyProperty)"/> against the property.
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Meta(
			TValue defaultValue,
			PropertyChange<TOwner, TValue> propertyChangedCallback,
			PropertyCoerce<TOwner, TValue> propertyCoerceCallback)
		{
			_defaultValue = defaultValue;
			_propertyChangedCallback = propertyChangedCallback;
			_coerceValueCallback = propertyCoerceCallback;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with
		/// a <see cref="PropertyChange{TOwner,TValue}"/> callback implementation and a
		/// <see cref="PropertyCoerce{TOwner,TValue}"/> callback implementation, but no 
		/// default value for the dependency property's effective value.
		/// </summary>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		/// <param name="propertyCoerceCallback">
		/// Referened to a handler implementation that is to be called by the property system calls
		/// <see cref="DependencyObject.CoerceValue(DependencyProperty)"/> against the property.
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Meta(
			PropertyChange<TOwner, TValue> propertyChangedCallback,
			PropertyCoerce<TOwner, TValue> propertyCoerceCallback)
		{
			_propertyChangedCallback = propertyChangedCallback;
			_coerceValueCallback = propertyCoerceCallback;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with
		/// a specified default value and <see cref="PropertyChange{TOwner,TValue}"/> callback implementation 
		/// reference for the dependency property that the resulting produced framework metadata will be applied to.
		/// </summary>
		/// <param name="defaultValue">
		/// The default value to specify for dependency property of the type <typeparamref name="TValue"/>
		/// </param>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		/// <param name="propertyCoerceCallback">
		/// Referened to a handler implementation that is to be called by the property system calls
		/// <see cref="DependencyObject.CoerceValue(DependencyProperty)"/> against the property.
		/// </param>
		/// <param name="optionsFlags">
		/// Metadata for the associated dependency property, specifically framework-specific property system
		/// characteristics a
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Meta(
			TValue defaultValue,
			PropertyChange<TOwner, TValue> propertyChangedCallback,
			PropertyCoerce<TOwner, TValue> propertyCoerceCallback,
			FrameworkPropertyMetadataOptions optionsFlags)
		{
			_defaultValue = defaultValue;
			_propertyChangedCallback = propertyChangedCallback;
			_coerceValueCallback = propertyCoerceCallback;
			_optionFlags = optionsFlags;
		}

		#endregion

		#region Operator
		/// <summary>
		/// Implicit operator to converts this instance of the <see cref="Meta{TOwner,TValue}"/> 
		/// class to the framework equivalent <see cref="FrameworkPropertyMetadata"/> object
		/// </summary>
		/// <param name="this">
		/// A framework equivalent <see cref="FrameworkPropertyMetadata"/> object 
		/// </param>
		public static implicit operator FrameworkPropertyMetadata(
			Meta<TOwner, TValue> @this)
		{
			return @this._frameworkPropertyMetdata ??
						 (@this._frameworkPropertyMetdata = @this.toFrameworkPropertyMetadata());
		}

		#endregion

		#region Methods
		/// <summary>
		/// Converts this instance of the <see cref="Meta{TOwner,TValue}"/> class to the framework
		/// equivalent <see cref="FrameworkPropertyMetadata"/> object
		/// </summary>
		/// <returns>
		/// A framework equivalent <see cref="FrameworkPropertyMetadata"/> object 
		/// </returns>
		private FrameworkPropertyMetadata toFrameworkPropertyMetadata()
		{
			return new FrameworkPropertyMetadata(
				_defaultValue,
				_optionFlags,
				_propertyChangedCallback.TryInvoke,
				_coerceValueCallback.TryInvoke);
		}

		#endregion
	}

	public class MetaBase<TValue>
		: Meta<DependencyObject, TValue>
	{

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetaBase()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with a specified 
		/// default value for the dependency property that the resulting produced framework metadata 
		/// will be applied to.
		/// </summary>
		/// <param name="defaultValue">
		/// The default value to specify for dependency property of the type <typeparamref name="TValue"/>
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetaBase(
			TValue defaultValue) : base (
				defaultValue)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with the 
		/// specified <see cref="PropertyChange{TOwner,TValue}"/> callback implementation reference.
		/// </summary>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetaBase(
			PropertyChange<DependencyObject, TValue> propertyChangedCallback) : base(
				propertyChangedCallback)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with
		/// a specified default value and <see cref="PropertyChange{TOwner,TValue}"/> callback implementation 
		/// reference for the dependency property that the resulting produced framework metadata will be applied to.
		/// </summary>
		/// <param name="defaultValue">
		/// The default value to specify for dependency property of the type <typeparamref name="TValue"/>
		/// </param>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetaBase(
			TValue defaultValue,
			PropertyChange<DependencyObject, TValue> propertyChangedCallback) : base(
				defaultValue,
				propertyChangedCallback)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with
		/// a specified default value and <see cref="PropertyChange{TOwner,TValue}"/> callback implementation 
		/// reference for the dependency property that the resulting produced framework metadata will be applied to.
		/// </summary>
		/// <param name="defaultValue">
		/// The default value to specify for dependency property of the type <typeparamref name="TValue"/>
		/// </param>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		/// <param name="propertyCoerceCallback">
		/// Referened to a handler implementation that is to be called by the property system calls
		/// <see cref="DependencyObject.CoerceValue(DependencyProperty)"/> against the property.
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetaBase(
			TValue defaultValue,
			PropertyChange<DependencyObject, TValue> propertyChangedCallback,
			PropertyCoerce<DependencyObject, TValue> propertyCoerceCallback) : base(
				defaultValue,
				propertyChangedCallback,
				propertyCoerceCallback)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with
		/// a <see cref="PropertyChange{TOwner,TValue}"/> callback implementation and a
		/// <see cref="PropertyCoerce{TOwner,TValue}"/> callback implementation, but no 
		/// default value for the dependency property's effective value.
		/// </summary>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		/// <param name="propertyCoerceCallback">
		/// Referened to a handler implementation that is to be called by the property system calls
		/// <see cref="DependencyObject.CoerceValue(DependencyProperty)"/> against the property.
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetaBase(
			PropertyChange<DependencyObject, TValue> propertyChangedCallback,
			PropertyCoerce<DependencyObject, TValue> propertyCoerceCallback) : base(
				propertyChangedCallback,
				propertyCoerceCallback)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Meta{TOwner,TValue}"/> class with
		/// a specified default value and <see cref="PropertyChange{TOwner,TValue}"/> callback implementation 
		/// reference for the dependency property that the resulting produced framework metadata will be applied to.
		/// </summary>
		/// <param name="defaultValue">
		/// The default value to specify for dependency property of the type <typeparamref name="TValue"/>
		/// </param>
		/// <param name="propertyChangedCallback">
		/// Reference to a handler implementation that is to be called by the property system whenever
		/// the effective value of the dependency property changes.
		/// </param>
		/// <param name="propertyCoerceCallback">
		/// Referened to a handler implementation that is to be called by the property system calls
		/// <see cref="DependencyObject.CoerceValue(DependencyProperty)"/> against the property.
		/// </param>
		/// <param name="optionsFlags">
		/// Metadata for the associated dependency property, specifically framework-specific property system
		/// characteristics a
		/// </param>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetaBase(
			TValue defaultValue,
			PropertyChange<DependencyObject, TValue> propertyChangedCallback,
			PropertyCoerce<DependencyObject, TValue> propertyCoerceCallback,
			FrameworkPropertyMetadataOptions optionsFlags) : base(
				defaultValue,
				propertyChangedCallback,
				propertyCoerceCallback,
				optionsFlags)
		{
		}

		#endregion
	}
}
/*	
 *	TValue defaultValue = default(TValue),
 *	
 *	private object _defaultValueFactory;

		private Type _defaultValueFactoryInternalTypeRef;
		protected Type defaultValueFactoryInternalTypeRef
		{
			get
			{
				return _defaultValueFactoryInternalTypeRef ?? 
					(_defaultValueFactoryInternalTypeRef = )
			}
		}
*/


