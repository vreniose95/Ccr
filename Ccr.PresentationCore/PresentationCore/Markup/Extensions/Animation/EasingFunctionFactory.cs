using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;

namespace Ccr.PresentationCore.Markup.Extensions.Animation
{
	internal class EasingFunctionFactory
	{
		protected abstract class EasingFunctionTemplateBase
		{
			protected DependencyProperty[] EasingFunctionProperties { get; }

			//protected Func<IEasingFunction, object>[] EasingFunctionFuncMaps { get; }

			protected EasingFunctionTemplateBase(
				params DependencyProperty[] easingFunctionProperties)
			{
				EasingFunctionProperties = easingFunctionProperties;
				//EasingFunctionFuncMaps = new Func<IEasingFunction, object>[];
			}

			public abstract IEasingFunction BuildBase(
				params object[] propertyValues);

		}

		protected class EasingFunctionTemplate<TEasingFunction> : EasingFunctionTemplateBase
			where TEasingFunction : DependencyObject, IEasingFunction, new()
		{
			internal EasingFunctionTemplate(
				params DependencyProperty[] easingFunctionProperties) : base(
						easingFunctionProperties)
			{
			}

			public override IEasingFunction BuildBase(
				params object[] propertyValues)
			{
				return Build(propertyValues);
			}

			public TEasingFunction Build(
				params object[] propertyValues)
			{
				if(propertyValues.Length > EasingFunctionProperties.Length)
					throw new NotSupportedException(
						$"The EasingFunctionTemplate definition type \'{GetType().Name}\' cannot be " +
						$"built with the property value array ({string.Join(", ", propertyValues)}) " +
						$"because the EasingFunctionTemplate defined for the easing function type " +
						$"\'{typeof(TEasingFunction).Name}\' maps {EasingFunctionProperties.Length} properties, " +
						$"but {propertyValues.Length} properties have been provided.");

				var easingFunction = new TEasingFunction();

				var index = 0;
				foreach (var propertyValue in propertyValues)
				{
					var dependencyProperty = EasingFunctionProperties[index];
					var propertyType = dependencyProperty.PropertyType;
					var typeConverter = TypeDescriptor.GetConverter(propertyType);
					var convertedBoxedValue = typeConverter.ConvertFrom(propertyValue);
					var convertedValue = Convert.ChangeType(convertedBoxedValue, propertyType);
					easingFunction.SetValue(dependencyProperty, convertedValue);

					index++;
				}
				return easingFunction;
			}
		}

		protected static Dictionary<EasingType, EasingFunctionTemplateBase> _easingFunctionTemplateMap
			= new Dictionary<EasingType, EasingFunctionTemplateBase>
			{
				[EasingType.Sine] = new EasingFunctionTemplate<SineEase>(),
				[EasingType.Cubic] = new EasingFunctionTemplate<CubicEase>(),
				[EasingType.Quint] = new EasingFunctionTemplate<QuinticEase>(),
				[EasingType.Circ] = new EasingFunctionTemplate<CircleEase>(),
				[EasingType.Quad] = new EasingFunctionTemplate<QuadraticEase>(),
				[EasingType.Quart] = new EasingFunctionTemplate<QuarticEase>(),
				[EasingType.Elastic] = new EasingFunctionTemplate<ElasticEase>(
					ElasticEase.SpringinessProperty,
					ElasticEase.OscillationsProperty),
				[EasingType.Expo] = new EasingFunctionTemplate<ExponentialEase>(
					ExponentialEase.ExponentProperty),
				[EasingType.Back] = new EasingFunctionTemplate<BackEase>(
					BackEase.AmplitudeProperty),
				[EasingType.Bounce] = new EasingFunctionTemplate<BounceEase>(
					BounceEase.BouncinessProperty, 
					BounceEase.BouncesProperty),
			};

		public static IEasingFunction CreateEasingFunction(
			EasingType easingType,
			params object[] propertyValues)
		{
			EasingFunctionTemplateBase easingFunctionTemplateBase;

			if(!_easingFunctionTemplateMap.TryGetValue(easingType, out easingFunctionTemplateBase))
				throw new NotSupportedException(
					$"Could not create an EasingFunction. There is no EasingFunctionTemplate<TEasingFunction> defined " +
					$"in the template map dictionary for the EasingType \'{easingType}\'.");

			var easingFunction = easingFunctionTemplateBase.BuildBase(propertyValues);
			return easingFunction;
		}
	}
}