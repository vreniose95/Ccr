using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;
using Ccr.Std.Core.Extensions;

namespace Ccr.PresentationCore.Animation.Templating
{
	public abstract class StoryboardTemplate
		: Storyboard,
			ISupportInitializeNotification
	{
		static StoryboardTemplate()
		{
			TargetNameProperty.OverrideMetadata(typeof(StoryboardTemplate),
				new FrameworkPropertyMetadata(onTargetNameChanged));
		}

		private bool _isInitializeHooked;
		private static void onTargetNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var storyboardTemplate = o.As<StoryboardTemplate>();
			if (storyboardTemplate.IsInitialized)
			{
				storyboardTemplate.GenerateStoryboardTree();
				return;
			}
			if (storyboardTemplate._isInitializeHooked)
				return;
			storyboardTemplate.Initialized += (s, args) =>
			{
				storyboardTemplate.GenerateStoryboardTree();
			};
			storyboardTemplate._isInitializeHooked = true;
		}

		protected void GenerateStoryboardTree()
		{
			var rootStoryboard = GenerateStoryboardTreeImpl();
			Children = new TimelineCollection { rootStoryboard };
		}

		protected abstract Storyboard GenerateStoryboardTreeImpl();


		public bool IsInitialized { get; private set; }
		public event EventHandler Initialized;

		public void BeginInit()
		{
			IsInitialized = false;
		}

		public void EndInit()
		{
			IsInitialized = true;
			Initialized?.Invoke(this, EventArgs.Empty);
		}
	}
}
