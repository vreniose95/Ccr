namespace Ccr.PresentationCore.Helpers
{
	internal static class BoolBoxes
	{
		internal static object TrueBox = true;
		internal static object FalseBox = false;

		internal static object Box(bool value)
		{
			return value ? TrueBox 
				: FalseBox;
		}
	}
}
