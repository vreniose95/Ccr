using System;
using System.ComponentModel;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.MaterialDesign.Markup.TypeConverters;

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

		public abstract MaterialBrush GetMaterial(
		  Swatch swatch);
	}
}
