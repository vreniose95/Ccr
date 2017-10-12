using System.Windows.Controls;
using Ccr.Core.Extensions;

namespace Ccr.MaterialDesign.Controls
{
    public class Icon
        : Control
    {
        static Icon()
        {
            ControlExtensions.OverrideStyleKey<Icon>();
        }
    }
}
