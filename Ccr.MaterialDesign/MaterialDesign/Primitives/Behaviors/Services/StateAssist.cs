
using System.Windows;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public class StateAssist
	{
		public static readonly DependencyProperty State1Property = DependencyProperty.RegisterAttached(
				"State1",
				typeof(string),
				typeof(StateAssist),
				new UIPropertyMetadata(null, State1Changed));

		public static string GetState1(DependencyObject obj)
			=> (string)obj.GetValue(State1Property);

		public static void SetState1(DependencyObject obj, string value)
			=> obj.SetValue(State1Property, value);

		internal static void State1Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}


		public static readonly DependencyProperty State2Property = DependencyProperty.RegisterAttached(
				"State2",
				typeof(string),
				typeof(StateAssist),
				new UIPropertyMetadata(null, State2Changed));

		public static string GetState2(DependencyObject obj)
			=> (string)obj.GetValue(State2Property);

		public static void SetState2(DependencyObject obj, string value)
			=> obj.SetValue(State2Property, value);

		internal static void State2Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}

		public static readonly DependencyProperty State3Property = DependencyProperty.RegisterAttached(
				"State3",
				typeof(string),
				typeof(StateAssist),
				new UIPropertyMetadata(null, State3Changed));

		public static string GetState3(DependencyObject obj)
			=> (string)obj.GetValue(State3Property);

		public static void SetState3(DependencyObject obj, string value)
			=> obj.SetValue(State3Property, value);

		internal static void State3Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}

		public static readonly DependencyProperty State4Property = DependencyProperty.RegisterAttached(
			"State4",
			typeof(string),
			typeof(StateAssist),
			new UIPropertyMetadata(null, State4Changed));

		public static string GetState4(DependencyObject obj)
			=> (string)obj.GetValue(State4Property);

		public static void SetState4(DependencyObject obj, string value)
			=> obj.SetValue(State4Property, value);

		internal static void State4Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}
		public static readonly DependencyProperty State5Property = DependencyProperty.RegisterAttached(
			"State5",
			typeof(string),
			typeof(StateAssist),
			new UIPropertyMetadata(null, State5Changed));

		public static string GetState5(DependencyObject obj)
			=> (string)obj.GetValue(State5Property);

		public static void SetState5(DependencyObject obj, string value)
			=> obj.SetValue(State5Property, value);

		internal static void State5Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}


		public static readonly DependencyProperty State6Property = DependencyProperty.RegisterAttached(
			"State6",
			typeof(string),
			typeof(StateAssist),
			new UIPropertyMetadata(null, State6Changed));

		public static string GetState6(DependencyObject obj)
			=> (string)obj.GetValue(State6Property);

		public static void SetState6(DependencyObject obj, string value)
			=> obj.SetValue(State6Property, value);

		internal static void State6Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}


		public static readonly DependencyProperty State7Property = DependencyProperty.RegisterAttached(
			"State7",
			typeof(string),
			typeof(StateAssist),
			new UIPropertyMetadata(null, State7Changed));

		public static string GetState7(DependencyObject obj)
			=> (string)obj.GetValue(State7Property);

		public static void SetState7(DependencyObject obj, string value)
			=> obj.SetValue(State7Property, value);

		internal static void State7Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}


		public static readonly DependencyProperty State8Property = DependencyProperty.RegisterAttached(
			"State8",
			typeof(string),
			typeof(StateAssist),
			new UIPropertyMetadata(null, State8Changed));

		public static string GetState8(DependencyObject obj)
			=> (string)obj.GetValue(State8Property);

		public static void SetState8(DependencyObject obj, string value)
			=> obj.SetValue(State8Property, value);

		internal static void State8Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}


		public static readonly DependencyProperty State9Property = DependencyProperty.RegisterAttached(
			"State9",
			typeof(string),
			typeof(StateAssist),
			new UIPropertyMetadata(null, State9Changed));

		public static string GetState9(DependencyObject obj)
			=> (string)obj.GetValue(State9Property);

		public static void SetState9(DependencyObject obj, string value)
			=> obj.SetValue(State9Property, value);

		internal static void State9Changed(DependencyObject target, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != null)
				VisualStateManager.GoToState((FrameworkElement)target, (string)args.NewValue, true);
		}
	}
}
