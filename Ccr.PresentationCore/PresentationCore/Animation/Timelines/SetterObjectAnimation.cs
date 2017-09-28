using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace Ccr.PresentationCore.Animation.Timelines
{
	//TODO IDEA: look into Custom TypeDescriptors, could be used for TypeConverter injection?
	//[XamlSetMarkupExtension(nameof(ReceiveMarkupExtension))]
	//[XamlSetTypeConverter(nameof(ReceiveTypeConverter))]
	//[ContentProperty(nameof(Value))]
	public partial class SetterObjectAnimation : ObjectAnimationBase
	{
		//private object _value = DependencyProperty.UnsetValue;
		////private DependencyProperty _property;
		////private object _unresolvedProperty;
		////private object _unresolvedValue;

		////private ITypeDescriptorContext _typeDescriptorContext;
		////private CultureInfo _typeConverterCultureInfo;

		////private bool _deferMarkupExtensionResolve;
		////private object _targetObject;
		////private XamlSetMarkupExtensionEventArgs _eventArgs;


		//[DependsOn("Storyboard.TargetName")]
		//[DependsOn("Storyboard.TargetProperty")]
		//[Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
		//[TypeConverter(typeof(SetterTriggerConditionValueConverter))]
		//public object Value
		//{
		//	get { return _value; }
		//	set
		//	{
		//		if (value == DependencyProperty.UnsetValue)
		//			throw new ArgumentException("SetterObjectAnimation's Value property cannot be set Unset.");
		//		if (value is Expression)
		//			throw new ArgumentException("Expressions cannot be used with SetterObjectAnimation's Value property.");
		//		_value = value;
		//	}
		//}

		protected override Freezable CreateInstanceCore()
		{
			var n = new SetterObjectAnimation
			{
				_unresolvedValue = _unresolvedValue,
				_deferValueResolution = _deferValueResolution,
				_resolvedValue = _resolvedValue,
				//Value = Value
			};
			return n;
		}

		//protected override void CloneCore(Freezable sourceFreezable)
		//{
		//	base.CloneCore(sourceFreezable);
		//}

		//protected override bool FreezeCore(bool isChecking)
		//{
		//	return base.FreezeCore(isChecking);
		//}

		//protected override void CloneCurrentValueCore(Freezable sourceFreezable)
		//{
		//	base.CloneCurrentValueCore(sourceFreezable);
		//}

		//protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		//{
		//	base.OnPropertyChanged(e);
		//}

		protected override object GetCurrentValueCore(object defaultOriginValue, object defaultDestinationValue,
																									AnimationClock animationClock)
		{
			return Value;
			//if (animationClock.CurrentTime >= BeginTime)
			//{
			//	return Value;
			//}
			//return defaultOriginValue;
		}
	}
	public partial class SetterObjectAnimation : ISupportInitialize
	{
		protected object _unresolvedValue;
		protected bool _deferValueResolution;

		private object _resolvedValue;
		protected object ResolvedValue
		{
			get
			{
				return _resolvedValue;
			}
			set
			{
				_deferValueResolution = true;
				_resolvedValue = value;
			}
		}

		public object Value
		{
			set
			{
				_unresolvedValue = value;
				_resolvedValue = null;
				OnValueSet();
			}
			get { return _resolvedValue; }
		}

		protected void OnValueSet()
		{
			var s = GetTargetPropertyType();
			if (s == null)
			{

			}
		}

		public new Type TargetPropertyType
		{
			get
			{
				var propertyType = GetTargetPropertyType();
				if (propertyType == null)
					return base.TargetPropertyType;
				return propertyType;
			}
		}

		protected Type GetTargetPropertyType()
		{
			var targetPropertyPath = Storyboard.GetTargetProperty(this);
			if (targetPropertyPath == null || targetPropertyPath == DependencyProperty.UnsetValue)
			{
				return null;
				//	throw new NotImplementedException();
			}
			switch (targetPropertyPath.Path)
			{
				case "IsHitTestVisible":
					return typeof(bool);

				case "Visibility":
					return typeof(Visibility);

				default:
					return null;
			}
		}

		public void BeginInit()
		{
			//var tpt = GetTargetPropertyType();
			//if (tpt == null)
			//{

			//}
		}

		public void EndInit()
		{
			var targetPropertyType = GetTargetPropertyType();
			if (targetPropertyType == null)
			{
				_deferValueResolution = true;
				return;
			}
			_deferValueResolution = false;

			var typeConverter = TypeDescriptor.GetConverter(targetPropertyType);
			//if (typeConverter == null)
			//{
			//	//TODO ??
			//	_deferValueResolution = true;
			//	return;
			//}
			ResolvedValue = typeConverter.ConvertFrom(_unresolvedValue);
		}

		//protected void AttemptResolveIterationTargetPropertyInfo()
		//{
		//	_deferIterationTargetReflect = false;
		//	if (AssociatedObject == null || IterationTargetPropertyName == null || AnimationTemplate == null)
		//	{
		//		_deferIterationTargetReflect = true;
		//		return;
		//	}
		//	var associatedObjectType = AssociatedObject.GetType();
		//	var propertyInfo = associatedObjectType.GetProperty(IterationTargetPropertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

		//	if (propertyInfo == null)
		//	{
		//		throw new MissingMemberException(associatedObjectType.Name, IterationTargetPropertyName);
		//	}
		//	_propertyInfo = propertyInfo;
		//}

		//protected void AttemptResolveIterationTarget()
		//{
		//	var reflectedValue = _propertyInfo.GetValue(AssociatedObject);

		//	var enumerableTarget = reflectedValue as IEnumerable;
		//	if (enumerableTarget == null)
		//		throw new NotSupportedException($"Target reflected value must be IEnumerable. Type \'{reflectedValue.GetType()}\' is not valid.");

		//	ResolvedIterationTarget = enumerableTarget;
		//}
	}
}