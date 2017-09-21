using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Markup;
using Ccr.Core.Extensions;
using Ccr.Introspective.Extensions;
using JetBrains.Annotations;
using MemberDescriptor = Ccr.Introspective.Infrastructure.MemberDescriptor;

namespace Ccr.Xaml.Markup.TypeConverterInjection
{
	public static class TypeConverterInjectionCore
	{
		public static void HandleMarkupExtensionTypeConverterInject(
			[NotNull] object targetObject, 
			[NotNull] XamlSetMarkupExtensionEventArgs eventArgs)
		{
			targetObject.IsNotNull(nameof(targetObject));
			eventArgs.IsNotNull(nameof(eventArgs));
			
			var injectedTypeConverterAttribute = eventArgs
				.Member
				.UnderlyingMember
				.GetCustomAttribute<InjectTypeConverterAttribute>();

			if (injectedTypeConverterAttribute != null)
			{
				var converterType = Type.GetType(
					injectedTypeConverterAttribute.AssemblyQualifiedTypeName);

				if (converterType == null)
					throw new TypeLoadException(
						$"Type reference cannot be loaded from the assembly qualified type name " +
						$"\'{injectedTypeConverterAttribute.AssemblyQualifiedTypeName}\'. The " +
						$"TypeConverter type cannot be injected.");

				var converterInstanceBoxed = converterType
					.Reflect()
					.CreateInstance(MemberDescriptor.Any);

				var converterInstance = converterInstanceBoxed as TypeConverter;
				if (converterInstance == null)
					throw new NotSupportedException(
						$"The type \'{converterInstanceBoxed.GetType().Name}\' is not a valid " +
						$"type to use in this context. Injected Xaml markup type converters must " +
						$"derive from the framework type \'System.ComponentModel.TypeConverter\'.");

				if (eventArgs.Value.GetType().Name == "TypeConverterMarkupExtension")
				{
					eventArgs.Value
						.Reflect()
						.SetFieldValue(MemberDescriptor.Any, "_converter", converterInstance);

					eventArgs.Handled = true;
				}
				var unresolvedValue = eventArgs.Value;
				if (eventArgs.Value.GetType().Name == "TypeConverterMarkupExtension")
				{
					unresolvedValue = eventArgs.Value
						.Reflect()
						.GetFieldValue(MemberDescriptor.Any, "_value");
				}

				var convertedValue = converterInstance.ConvertFrom(unresolvedValue);

				if (convertedValue == null)
					throw new NullReferenceException(nameof(convertedValue));

				var memberInvoker = eventArgs.Member.Invoker;
				memberInvoker.SetValue(targetObject, convertedValue);

				eventArgs.Handled = true;
			}

			//if (eventArgs.MarkupExtension is )
		}

		

	}
}
/*
 * 
 * 		public static void HandlePropertySet(
			[NotNull] object targetObject,
			[NotNull] XamlSetTypeConverterEventArgs eventArgs)
		{
			targetObject.IsNotNull("targetObject");
			eventArgs.IsNotNull("eventArgs");
			

			var injectedTypeConverterAttributes = eventArgs.Member.UnderlyingMember
				.GetCustomAttributes(typeof(InjectTypeConverterAttribute), true)
				.OfType<InjectTypeConverterAttribute>()
				.ToArray();

			if (injectedTypeConverterAttributes.Any())
			{
				if (injectedTypeConverterAttributes.Length > 1)
					throw new NotSupportedException("Multiple \'InjectTypeConverterAttribute\' attributes discovered.");

				var injectedTypeConverterAttribute = injectedTypeConverterAttributes.Single();

				var converterType = Type.GetType(injectedTypeConverterAttribute.AssemblyQualifiedTypeName);
				if (converterType == null)
					throw new TypeLoadException("Injected type converter type cannot be resolved.");

				var constructor = converterType.GetConstructor(new Type[] { });
				if (constructor == null)
					throw new NotSupportedException("Injected type converter constructor must have a parameterless constructor.");

				var converterTypeInstance = constructor.Invoke(new object[] { });

				var converter = converterTypeInstance as TypeConverter;
				if (converter == null)
					throw new Exception($"Type \'{converterTypeInstance.GetType().Name}\' not valid. Must be of type \'TypeConverter\'.");

				var convertedValue = converter.ConvertFrom(eventArgs.Value);

				if (convertedValue == null)
					throw new NullReferenceException(nameof(convertedValue));

				var inv = eventArgs.Member.Invoker;
				inv.SetValue(targetObject, convertedValue);

				eventArgs.Handled = true;
			}
		}


		public static void HandlePropertySetFromMarkupExtension(
			object targetObject, XamlSetMarkupExtensionEventArgs eventArgs)
		{
			if (targetObject == null)
				throw new ArgumentNullException(nameof(targetObject));
			if (eventArgs == null)
				throw new ArgumentNullException(nameof(eventArgs));


			var injectedTypeConverterAttributes = eventArgs.Member.UnderlyingMember
				.GetCustomAttributes(typeof(InjectTypeConverterAttribute), true)
				.OfType<InjectTypeConverterAttribute>()
				.ToArray();

			if (injectedTypeConverterAttributes.Any())
			{
				if (injectedTypeConverterAttributes.Length > 1)
					throw new NotSupportedException("Multiple \'InjectTypeConverterAttribute\' attributes discovered.");

				var injectedTypeConverterAttribute = injectedTypeConverterAttributes.Single();

				var converterType = Type.GetType(injectedTypeConverterAttribute.AssemblyQualifiedTypeName);
				if (converterType == null)
					throw new TypeLoadException("Injected type converter type cannot be resolved.");

				var constructor = converterType.GetConstructor(new Type[] { });
				if (constructor == null)
					throw new NotSupportedException("Injected type converter constructor must have a parameterless constructor.");

				var converterTypeInstance = constructor.Invoke(new object[] { });

				var converter = converterTypeInstance as TypeConverter;
				if (converter == null)
					throw new Exception($"Type \'{converterTypeInstance.GetType().Name}\' not valid. Must be of type \'TypeConverter\'.");

				var unresolvedValue = eventArgs.Value;
				if (eventArgs.Value.GetType().Name == "TypeConverterMarkupExtension")
				{
					unresolvedValue = eventArgs.Value.GetFieldValue<object>("_value");
				}

				var convertedValue = converter.ConvertFrom(unresolvedValue);

				if (convertedValue == null)
					throw new NullReferenceException(nameof(convertedValue));

				var inv = eventArgs.Member.Invoker;
				inv.SetValue(targetObject, convertedValue);

				eventArgs.Handled = true;
			}

			//if (eventArgs.MarkupExtension is )
		}*/

