using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using FPMO = System.Windows.FrameworkPropertyMetadataOptions;

namespace Ccr.MaterialDesign.Primitives.Infrastructure
{
	public class CcrControl
		: Control
	{
		#region Fields
		public const FPMO FXR = FPMO.AffectsRender;
		public const FPMO FXM = FPMO.AffectsMeasure;
		public const FPMO FXA = FPMO.AffectsArrange;
		public const FPMO INH = FPMO.Inherits;

		#endregion

		protected internal TChild GetTemplateChild<TChild>(
			[NotNull] string name)
			where TChild : DependencyObject
		{
			var templateChild = GetTemplateChild(name)
			  .AsOrDefault<TChild>();

			if (templateChild == null)
				throw new NotSupportedException(
					$"The template child with the name={name.Quote()} could not be found in the current " +
					$"custom control type {typeof(CcrControl).Name.SQuote()}'s control template.");

			return templateChild;
		}


		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			var type = GetType();
			var fields = type.GetFields(
				BindingFlags.Instance | BindingFlags.NonPublic);

			foreach (var field in fields)
			{
				var fieldName = field.Name;
				var fieldType = field.FieldType;

				if (field.GetCustomAttribute<AutoTemplatePartAttribute>(true) != null)
				{
					var templatePart = GetTemplateChild(fieldName);
					var convertedPart = Convert.ChangeType(templatePart, fieldType);

					field.SetValue(this, convertedPart);
				}
			}
		}


		protected static void OverrideDefaultStyleKey<TValue>()
			where TValue : DependencyObject
		{
			DefaultStyleKeyProperty
				.OverrideMetadata(typeof(TValue),
					new FrameworkPropertyMetadata(
						typeof(TValue)));
		}
	}
}
