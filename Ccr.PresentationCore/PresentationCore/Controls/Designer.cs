using System;
using System.Collections.Generic;
using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.WinCore.Derived;

namespace Ccr.PresentationCore.Controls
{
	public class Designer
	{
		private static readonly Dictionary<Viewport, Size> _viewportMap = new Dictionary<Viewport, Size>
		{
			[Viewport.VGA] = new Size(640, 480),
			[Viewport.PAL] = new Size(768, 576),
			[Viewport.WVGA] = new Size(854, 480),
			[Viewport.WSVGA] = new Size(1024, 600),
			[Viewport.XGA] = new Size(1024, 768),
			[Viewport.SVGA] = new Size(800, 600),
			[Viewport.HD720] = new Size(1280, 720),
			[Viewport.WXGA] = new Size(1280, 800),
			[Viewport.WXGAPLUS] = new Size(1440, 900),
			[Viewport.WSXGAPLUS] = new Size(1680, 1050),
			[Viewport.HD1080] = new Size(1920, 1080),
			[Viewport.SXGA] = new Size(1280, 1024),
			[Viewport.SXGAPLUS] = new Size(1400, 1050),
			[Viewport.UXGA] = new Size(1600, 1200),
			[Viewport.HD2K] = new Size(2048, 1080),
			[Viewport.HD2K] = new Size(2048, 1080),
			[Viewport.QXGA] = new Size(2048, 1536),
			[Viewport.WUXGA] = new Size(1920, 1200),
			[Viewport.UWHD] = new Size(2560, 1080),
			[Viewport.WQHD] = new Size(2560, 1440),
			[Viewport.WQXGA] = new Size(2560, 1600),
			[Viewport.UWQHD] = new Size(3440, 1440),
			[Viewport.UHD1] = new Size(3840, 2160),
			[Viewport.UHD4K] = new Size(4096, 2160),
			[Viewport.UHD8K] = new Size(7680, 4320),
			//TODO which iphone rev? 
			//[Viewport.iPhone] = new Size(1334, 750)
		};

		public static readonly DependencyProperty ViewportProperty = DP.Attach(typeof(Designer),
			new MetaBase<Viewport>(Viewport.NONE, onViewportChanged));

		public static readonly DependencyProperty OrientationProperty = DP.Attach(typeof(Designer), 
			new MetaBase<PageOrientation>(PageOrientation.Landscape, onOrientationChanged));

		public static readonly DependencyProperty CompensateForWindowsToolbarProperty = DP.Attach(typeof(Designer), 
			new MetaBase<bool>(false, onCompensateForWindowsToolbarChanged));

		public static readonly DependencyProperty VisibilityProperty = DP.Attach(typeof(Designer), 
			new MetaBase<Visibility>(Visibility.Visible, onVisibilityChanged));


		public static Viewport GetViewport(DependencyObject i) => i.Get<Viewport>(ViewportProperty);
		public static void SetViewport(DependencyObject i, Viewport v) => i.Set(ViewportProperty, v);

		public static bool GetCompensateForWindowsToolbar(DependencyObject i) => i.Get<bool>(CompensateForWindowsToolbarProperty);
		public static void SetCompensateForWindowsToolbar(DependencyObject i, bool v) => i.Set(CompensateForWindowsToolbarProperty, v);

		public static PageOrientation GetOrientation(DependencyObject i) => i.Get<PageOrientation>(OrientationProperty);
		public static void SetOrientation(DependencyObject i, PageOrientation v) => i.Set(OrientationProperty, v);

		public static Visibility GetVisibility(DependencyObject i) => i.Get<Visibility>(VisibilityProperty);
		public static void SetVisibility(DependencyObject i, Visibility v) => i.Set(VisibilityProperty, v);



		private static void onViewportChanged(
			DependencyObject @this,
			DPChangedEventArgs<Viewport> args)
		{
			var _pageOrientation = GetOrientation(@this);
			var _compensateForWindowsToolbar = GetCompensateForWindowsToolbar(@this);
			var _viewport = GetViewport(@this);

			onPageLayoutCompute(
				@this,
				_viewport,
				_pageOrientation,
				_compensateForWindowsToolbar);
		}

		private static void onOrientationChanged(
			DependencyObject @this,
			DPChangedEventArgs<PageOrientation> args)
		{
			var _pageOrientation = GetOrientation(@this);
			var _compensateForWindowsToolbar = GetCompensateForWindowsToolbar(@this);
			var _viewport = GetViewport(@this);

			onPageLayoutCompute(
				@this,
				_viewport,
				_pageOrientation,
				_compensateForWindowsToolbar);

		}

		private static void onCompensateForWindowsToolbarChanged(
			DependencyObject @this,
			DPChangedEventArgs<bool> args)
		{
			var _pageOrientation = GetOrientation(@this);
			var _compensateForWindowsToolbar = GetCompensateForWindowsToolbar(@this);
			var _viewport = GetViewport(@this);

			onPageLayoutCompute(
				@this,
				_viewport,
				_pageOrientation,
				_compensateForWindowsToolbar);
		}

		private static void onVisibilityChanged(
			DependencyObject @this,
			DPChangedEventArgs<Visibility> args)
		{
			var _pageOrientation = GetOrientation(@this);
			var _compensateForWindowsToolbar = GetCompensateForWindowsToolbar(@this);
			var _viewport = GetViewport(@this);

			onPageLayoutCompute(
				@this,
				_viewport,
				_pageOrientation,
				_compensateForWindowsToolbar);
		}

		
		private static void onPageLayoutCompute(
			DependencyObject _dependencyObject,
			Viewport _viewport,
			PageOrientation _pageOrientation,
			bool _compensateForWindowsToolbar)
		{
			//if (!LinqEntityViewModel.IsInDesignModeStatic)
			//	return;

			var frameworkElement = _dependencyObject as FrameworkElement;
			if (frameworkElement == null)
				throw new ArgumentException(
					$"Parameter \'_dependencyObject\' must be not null and of type \'FrameworkElement\'.",
					nameof(_dependencyObject));

			if (_viewport == Viewport.NONE)
			{
				frameworkElement.SetValue(
					FrameworkElement.WidthProperty,
					DependencyProperty.UnsetValue);

				frameworkElement.SetValue(
					FrameworkElement.HeightProperty,
					DependencyProperty.UnsetValue);

				return;
			}
			var associatedSize = _viewportMap[_viewport];

			var subtractHeight = _compensateForWindowsToolbar 
				? __WIN32_SHELL_TASKBAR.I.Size.Height : 0;

			if (_pageOrientation == PageOrientation.Landscape)
			{
				frameworkElement.Width = associatedSize.Width;
				frameworkElement.Height = getValidLength(associatedSize.Height - subtractHeight);
			}
			else
			{
				frameworkElement.Width = associatedSize.Height;
				frameworkElement.Height = getValidLength(associatedSize.Width - subtractHeight);
			}
		}


		private static double getValidLength(
			double targetLength)
		{
			return targetLength < 0
				? 0 
				: targetLength;
		}
	}
}
