using Ccr.MaterialDesign.Controls.Icons;

namespace Ccr.MDHybrid.Demo.Models
{
	public class ExpanderItemSelection
	{
		public IconKind Icon { get; set; }

		public string Title { get; set; }


		public ExpanderItemSelection()
		{
		}

		public ExpanderItemSelection(
		  IconKind icon,
		  string title)
		{
			Icon = icon;
			Title = title;
		}
	}
}
