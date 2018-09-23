using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Ccr.Std.Extensions;
using Ccr.Std.Introspective.Extensions;
using MemberDescriptor = Ccr.Std.Introspective.Infrastructure.MemberDescriptor;

namespace Ccr.PresentationCore.Markup
{
	public class DesignTimeResourceDictionary
		: ResourceDictionary
	{
		private readonly ObservableCollection<ResourceDictionary> _existingDictionaries
			= new DesignTimeCollection<ResourceDictionary>();

		private class DesignTimeCollection<TValue>
			: ObservableCollection<TValue>
		{
			protected override void InsertItem(int index, TValue item)
			{
				if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
				{
					base.InsertItem(index, item);
				}
			}
		}

		public DesignTimeResourceDictionary()
		{
			 this.Reflect()
				.SetFieldValue(
					MemberDescriptor.NonPublic,
					"_mergedResources",
					_existingDictionaries);
		}
	}
}
