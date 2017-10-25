
namespace Ccr.Geocoding
{
	public class ComponentFilter
	{
		public string Filter { get; }


		public ComponentFilter(
			string component,
			string value)
		{
			Filter = $"{component}:{value}";
		}
	}
}
