using System;
using System.Collections.Generic;
using Ccr.MaterialDesign.MVVM;
using JetBrains.Annotations;

namespace Ccr.MDHybrid.Demo.ViewModels
{
	public class ShowMediaEntry
	{
		public int ShowMediaEntryID { get; set; }


		public int? ShowID { get; set; }
		//[CanBeNull, ForeignKey("ShowID")]
		//public virtual Show Show { get; set; }


		public DateTime AirDate { get; set; }

		public string Title { get; set; }

		public string Subtitle { get; set; }

		public int? ShowNumber { get; set; }

		public string ShowIdentifier { get; set; }


		public string EmbeddedContentSourceUrl { get; set; }


		//public int? EmbeddedContentSourceID { get; set; }
		//[CanBeNull, ForeignKey("EmbeddedContentSourceID")]
		//public virtual EmbeddedContentSource EmbeddedContentSource { get; set; }


		//public virtual ICollection<GuestAppearance> GuestAppearances { get; set; }

		//public virtual ICollection<ShowMediaSegmentContentTag> ContentSegmentTags { get; set; }

		//public virtual ICollection<ShowMediaSegmentComment> ShowMediaSegmentComments { get; set; }




		public ShowMediaEntry()
		{
			//GuestAppearances = new HashSet<GuestAppearance>();
			//ContentSegmentTags = new HashSet<ShowMediaSegmentContentTag>();
		}
	}

	public class ButtonViewModel
		: ViewModelBase
	{
		
	}
}
