using System.ComponentModel;

namespace Ccr.PresentationCore.Helpers
{
  /// <inheritdoc cref="IPropertyChangedEventArgs" />
  /// <summary>
  ///   A wrapper struct for <see cref="T:System.Windows.DependencyProperty" /> that provides
  ///   data on the various <see cref="T:System.Windows.DependencyProperty" /> property changed events
  /// </summary>
  /// <typeparam name="TProperty">
  ///   The value type of the <see cref="T:System.Windows.DependencyPropertyChangedEventArgs" /> 
  /// </typeparam>
  public struct PropertyChangedEventArgs<TProperty>
    : IPropertyChangedEventArgs
  {
    #region Properties
    /// <summary>
    ///   The dependency property whose value changed
    /// </summary>
    public string PropertyName { get; }

    /// <summary>
    ///   The base old value of the property
    /// </summary>
    object IPropertyChangedEventArgs.OldValueBase
    {
      get => OldValue;
    }
    
    /// <summary>
    ///   The base new value of the property
    /// </summary>
    object IPropertyChangedEventArgs.NewValueBase
    {
      get => NewValue;
    }
    
    /// <summary>
    /// The old value of the property
    /// </summary>
    public TProperty OldValue { get; }

    /// <summary>
    /// The new value of the property
    /// </summary>
    public TProperty NewValue { get; }

    #endregion


    #region Constructors
    /// <summary>
    ///   Initializes a new instance of <see cref="PropertyChangedEventArgs{TProperty}"/>
    /// </summary>
    /// <param name="propertyName">
    ///   The dependency property whose value has changed
    /// </param>
    /// <param name="oldValue">
    ///   The value of the property before the change
    /// </param>
    /// <param name="newValue">
    ///   The value of the property after the change
    /// </param>
    public PropertyChangedEventArgs(
      string propertyName,
      TProperty oldValue,
      TProperty newValue)
    {
      PropertyName = propertyName;
      OldValue = oldValue;
      NewValue = newValue;
    }

    /// <inheritdoc />
    /// <summary>
    ///   Initializes a new instance of the <see cref="T:Ccr.PresentationCore.Helpers.PropertyChangedEventArgs`1" /> class
    ///   from an instance of the non-generic struct <see cref="T:System.Windows.DependencyPropertyChangedEventArgs" />
    /// </summary>
    /// <param name="args">
    ///   The instance of the non-generic <see cref="T:System.Windows.DependencyPropertyChangedEventArgs" /> struct
    ///   to be converted to the generic wrapper clas s<see cref="T:Ccr.PresentationCore.Helpers.PropertyChangedEventArgs`1" /> 
    /// </param>
    /// <param name="oldValue">
    ///   The value of the property before the change
    /// </param>
    /// <param name="newValue">
    ///   The value of the property after the change
    /// </param>
    public PropertyChangedEventArgs(
      PropertyChangedEventArgs args,
      TProperty oldValue,
      TProperty newValue)
        : this(
          args.PropertyName,
          oldValue,
          newValue)
    {
    }

    #endregion
		
  }
}