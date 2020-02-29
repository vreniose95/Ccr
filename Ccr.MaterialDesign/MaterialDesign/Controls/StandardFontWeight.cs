using System.Windows;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.Controls
{
	public class StandardFontWeight
	{
		private static readonly FontWeightConverter _converter = new FontWeightConverter();


		public string FontWeightName { get; }

		public FontWeight FontWeight { get; }

		
		public static readonly StandardFontWeight Normal = new StandardFontWeight("Normal");


		private StandardFontWeight(
			string fontWeightName)
		{
			FontWeightName = fontWeightName.EnforceNotNull(nameof(fontWeightName));
			FontWeight = _converter.ConvertFrom(fontWeightName)
				.As<FontWeight>();
		}
	}
}