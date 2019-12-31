using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class DownloadAttributeExtensions
	{
		public static void AddDownload(
			this ISupportsDownloadAttribute tag, 
			string newFileName)
		{
			tag.AddAttribute("download", newFileName);
		}
	}
}