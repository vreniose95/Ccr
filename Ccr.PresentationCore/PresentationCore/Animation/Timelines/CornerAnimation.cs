using System;
using System.Windows;
using System.Windows.Media.Animation;
using Ccr.Std.Introspective.Extensions;
using Ccr.Std.Introspective.Infrastructure;
using Ccr.PresentationCore.Helpers;
using Ccr.Std.Extensions;

namespace Ccr.PresentationCore.Animation.Timelines
{
	public class CornerAnimation 
		: CornerAnimationBase
	{
		private CornerRadius[] _keyValues;
		private AnimationMode _AnimationMode;
		private bool _isAnimationFunctionValid;
		

		public static readonly DependencyProperty FromProperty;

		public static readonly DependencyProperty ToProperty;

		public static readonly DependencyProperty ByProperty;

		public static readonly DependencyProperty EasingFunctionProperty;


		internal void ReflSetValueInternal(
			DependencyProperty property,
			object value)
		{
			//TODO xzthis.TryInvokeInternalMethod<DependencyProperty, object>("SetValueInternal", property, value);
		}

		public CornerRadius? From
		{
			get
			{
				return (CornerRadius?)GetValue(FromProperty);
			}
			set
			{
				this.ReflSetValueInternal(FromProperty, value);
			}
		}

		public CornerRadius? To
		{
			get
			{
				return (CornerRadius?)GetValue(ToProperty);
			}
			set
			{
				this.ReflSetValueInternal(ToProperty, value);
			}
		}

		public CornerRadius? By
		{
			get
			{
				return (CornerRadius?)GetValue(ByProperty);
			}
			set
			{
				this.ReflSetValueInternal(ByProperty, value);
			}
		}

		public IEasingFunction EasingFunction
		{
			get
			{
				return (IEasingFunction)GetValue(EasingFunctionProperty);
			}
			set
			{
				this.ReflSetValueInternal(EasingFunctionProperty, value);
			}
		}

		public bool IsAdditive
		{
			get
			{
				return (bool)GetValue(IsAdditiveProperty);
			}
			set
			{
				this.ReflSetValueInternal(IsAdditiveProperty, BoolBoxes.Box(value));
			}
		}

		public bool IsCumulative
		{
			get
			{
				return (bool)GetValue(IsCumulativeProperty);
			}
			set
			{
				this.ReflSetValueInternal(IsCumulativeProperty, BoolBoxes.Box(value));
			}
		}

		static CornerAnimation()
		{
			var propertyType = typeof(CornerRadius?);
			var ownerType = typeof(CornerAnimation);
			PropertyChangedCallback propertyChangedCallback = AnimationFunction_Changed;
			ValidateValueCallback validateValueCallback = ValidateFromToOrByValue;
			FromProperty = DependencyProperty.Register("From", propertyType, ownerType, 
				new PropertyMetadata(null, propertyChangedCallback), validateValueCallback);
			ToProperty = DependencyProperty.Register("To", propertyType, ownerType, new PropertyMetadata(null, propertyChangedCallback), validateValueCallback);
			ByProperty = DependencyProperty.Register("By", propertyType, ownerType, new PropertyMetadata(null, propertyChangedCallback), validateValueCallback);
			EasingFunctionProperty = DependencyProperty.Register("EasingFunction", typeof(IEasingFunction), ownerType);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Windows.Media.Animation.ThicknessAnimation"/> class.
		/// </summary>
		public CornerAnimation()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Windows.Media.Animation.ThicknessAnimation"/> class that animates to the specified value over the specified duration. The starting value for the animation is the base value of the property being animated or the output from another animation.
		/// </summary>
		/// <param name="toValue">The destination value of the animation. </param><param name="duration">The length of time the animation takes to play from start to finish, once. See the <see cref="P:System.Windows.Media.Animation.Timeline.Duration"/> property for more information.</param>
		public CornerAnimation(
			CornerRadius toValue,
			Duration duration)
      : this()
    {
			To = toValue;
			Duration = duration;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Windows.Media.Animation.ThicknessAnimation"/> class that animates to the specified value over the specified duration and has the specified fill behavior. The starting value for the animation is the base value of the property being animated or the output from another animation.
		/// </summary>
		/// <param name="toValue">The destination value of the animation. </param><param name="duration">The length of time the animation takes to play from start to finish, once. See the <see cref="P:System.Windows.Media.Animation.Timeline.Duration"/> property for more information.</param><param name="fillBehavior">Specifies how the animation behaves when it is not active.</param>
		public CornerAnimation(CornerRadius toValue, Duration duration, FillBehavior fillBehavior)
      : this()
    {
			this.To = new CornerRadius?(toValue);
			this.Duration = duration;
			this.FillBehavior = fillBehavior;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Windows.Media.Animation.ThicknessAnimation"/> class that animates from the specified starting value to the specified destination value over the specified duration.
		/// </summary>
		/// <param name="fromValue">The starting value of the animation.</param><param name="toValue">The destination value of the animation. </param><param name="duration">The length of time the animation takes to play from start to finish, once. See the <see cref="P:System.Windows.Media.Animation.Timeline.Duration"/> property for more information.</param>
		public CornerAnimation(CornerRadius fromValue, CornerRadius toValue, Duration duration)
      : this()
    {
			this.From = new CornerRadius?(fromValue);
			this.To = new CornerRadius?(toValue);
			this.Duration = duration;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Windows.Media.Animation.ThicknessAnimation"/> class that animates from the specified starting value to the specified destination value over the specified duration and has the specified fill behavior.
		/// </summary>
		/// <param name="fromValue">The starting value of the animation.</param><param name="toValue">The destination value of the animation. </param><param name="duration">The length of time the animation takes to play from start to finish, once. See the <see cref="P:System.Windows.Media.Animation.Timeline.Duration"/> property for more information.</param><param name="fillBehavior">Specifies how the animation behaves when it is not active.</param>
		public CornerAnimation(CornerRadius fromValue, CornerRadius toValue, Duration duration, FillBehavior fillBehavior)
      : this()
    {
			this.From = new CornerRadius?(fromValue);
			this.To = new CornerRadius?(toValue);
			this.Duration = duration;
			this.FillBehavior = fillBehavior;
		}

		/// <summary>
		/// Creates a modifiable clone of this <see cref="T:System.Windows.Media.Animation.ThicknessAnimation"/>, making deep copies of this object's values. When copying dependency properties, this method copies resource references and data bindings (but they might no longer resolve) but not animations or their current values.
		/// </summary>
		/// 
		/// <returns>
		/// A modifiable clone of the current object. The cloned object's <see cref="P:System.Windows.Freezable.IsFrozen"/> property will be false even if the source's <see cref="P:System.Windows.Freezable.IsFrozen"/> property was true.
		/// </returns>
		public new CornerAnimation Clone()
		{
			return (CornerAnimation)base.Clone();
		}

		/// <summary>
		/// Creates a new instance of the <see cref="T:System.Windows.Media.Animation.ThicknessAnimation"/>.
		/// </summary>
		/// 
		/// <returns>
		/// The new instance.
		/// </returns>
		protected override Freezable CreateInstanceCore()
		{
			return new CornerAnimation();
		}

		/// <summary>
		/// Calculates a value that represents the current value of the property being animated, as determined by the <see cref="T:System.Windows.Media.Animation.ThicknessAnimation"/>.
		/// </summary>
		/// 
		/// <returns>
		/// The calculated value of the property, as determined by the current animation.
		/// </returns>
		/// <param name="defaultOriginValue">The suggested origin value, used if the animation does not have its own explicitly set start value.</param><param name="defaultDestinationValue">The suggested destination value, used if the animation does not have its own explicitly set end value.</param><param name="animationClock">An <see cref="T:System.Windows.Media.Animation.AnimationClock"/> that generates the <see cref="P:System.Windows.Media.Animation.Clock.CurrentTime"/> or <see cref="P:System.Windows.Media.Animation.Clock.CurrentProgress"/> used by the animation.</param>
		protected override CornerRadius GetCurrentValueCore(CornerRadius defaultOriginValue, CornerRadius defaultDestinationValue, AnimationClock animationClock)
		{
			if (!this._isAnimationFunctionValid)
				this.ValidateAnimationFunction();
			double num1 = animationClock.CurrentProgress.Value;
			IEasingFunction easingFunction = this.EasingFunction;
			if (easingFunction != null)
				num1 = easingFunction.Ease(num1);
			var from = new CornerRadius();
			var to = new CornerRadius();
			var thickness1 = new CornerRadius();
			var thickness2 = new CornerRadius();
			bool flag1 = false;
			bool flag2 = false;
			switch (this._AnimationMode)
			{
				case AnimationMode.Automatic:
					from = defaultOriginValue;
					to = defaultDestinationValue;
					flag1 = true;
					flag2 = true;
					break;
				case AnimationMode.From:
					from = this._keyValues[0];
					to = defaultDestinationValue;
					flag2 = true;
					break;
				case AnimationMode.To:
					from = defaultOriginValue;
					to = this._keyValues[0];
					flag1 = true;
					break;
				case AnimationMode.By:
					to = this._keyValues[0];
					thickness2 = defaultOriginValue;
					flag1 = true;
					break;
				case AnimationMode.FromTo:
					from = this._keyValues[0];
					to = this._keyValues[1];
					if (this.IsAdditive)
					{
						thickness2 = defaultOriginValue;
						flag1 = true;
						break;
					}
					break;
				case AnimationMode.FromBy:
					from = this._keyValues[0];
					to = AnimationHelpers.AddCornerRadius(this._keyValues[0], this._keyValues[1]);
					if (this.IsAdditive)
					{
						thickness2 = defaultOriginValue;
						flag1 = true;
						break;
					}
					break;
			}
			if (flag1 && !AnimationHelpers.IsValidAnimationValueCornerRadius(defaultOriginValue))
				throw new InvalidOperationException("Animation_Invalid_DefaultValue");
			if (flag2 && !AnimationHelpers.IsValidAnimationValueCornerRadius(defaultDestinationValue))
				throw new InvalidOperationException("Animation_Invalid_DefaultValue");
			if (this.IsCumulative)
			{
				int? currentIteration = animationClock.CurrentIteration;
				int num2 = 1;
				double factor = (double)(currentIteration.HasValue ? new int?(currentIteration.GetValueOrDefault() - num2) : new int?()).Value;
				if (factor > 0.0)
					thickness1 = AnimationHelpers.ScaleCornerRadius(AnimationHelpers.SubtractCornerRadius(to, from), factor);
			}
			return AnimationHelpers.AddCornerRadius(thickness2, AnimationHelpers.AddCornerRadius(thickness1, AnimationHelpers.InterpolateCornerRadius(from, to, num1)));
		}

		private void ValidateAnimationFunction()
		{
			this._AnimationMode = AnimationMode.Automatic;
			this._keyValues = (CornerRadius[])null;
			if (this.From.HasValue)
			{
				if (this.To.HasValue)
				{
					this._AnimationMode = AnimationMode.FromTo;
					this._keyValues = new CornerRadius[2];
					this._keyValues[0] = this.From.Value;
					this._keyValues[1] = this.To.Value;
				}
				else if (this.By.HasValue)
				{
					this._AnimationMode = AnimationMode.FromBy;
					this._keyValues = new CornerRadius[2];
					this._keyValues[0] = this.From.Value;
					this._keyValues[1] = this.By.Value;
				}
				else
				{
					this._AnimationMode = AnimationMode.From;
					this._keyValues = new CornerRadius[1];
					this._keyValues[0] = this.From.Value;
				}
			}
			else if (this.To.HasValue)
			{
				this._AnimationMode = AnimationMode.To;
				this._keyValues = new CornerRadius[1];
				this._keyValues[0] = this.To.Value;
			}
			else if (this.By.HasValue)
			{
				this._AnimationMode = AnimationMode.By;
				this._keyValues = new CornerRadius[1];
				this._keyValues[0] = this.By.Value;
			}
			this._isAnimationFunctionValid = true;
		}

		private const string propertyChangedMethod = "PropertyChanged";

		private static void AnimationFunction_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var thicknessAnimation = (CornerAnimation)d;
			int num = 0;
			thicknessAnimation._isAnimationFunctionValid = num != 0;
			DependencyProperty property = e.Property;
			thicknessAnimation
				.Reflect()
				.InvokeMethod(MemberDescriptor.NonPublic, propertyChangedMethod, property);

			//TryInvokeInternalMethod(propertyChangedMethod, property))
			//{
			//	throw new MissingMethodException(nameof(CornerAnimation), propertyChangedMethod);
			//}
			//thicknessAnimation.PropertyChanged(property);
		}

		private static bool ValidateFromToOrByValue(object value)
		{
			CornerRadius? nullable = (CornerRadius?)value;
			if (nullable.HasValue)
				return AnimationHelpers.IsValidAnimationValueCornerRadius(nullable.Value);
			return true;
		}
	}
}
