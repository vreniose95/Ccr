using System;
using System.ComponentModel;
using System.Windows.Media;
using Ccr.MaterialDesign.Markup.TypeConverters;
using Ccr.Std.Core.Extensions;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	[TypeConverter(typeof(MaterialDescriptorConverter))]
	public abstract class AbstractMaterialDescriptor
    : IMaterialDescriptor
  {
    private double opacity = 1.0;
    public double Opacity
    {
      get => opacity;
      set
      {
        if (value.IsNotWithin((0d, 1d)))
          throw new ArgumentOutOfRangeException(
            nameof(value),
            value,
            $"The {nameof(value).SQuote()} parameter must be between 0 and 1, inclusively.");

        opacity = value;
      }
    }

		public abstract SolidColorBrush GetMaterial(
		  Swatch swatch);
	}
}
