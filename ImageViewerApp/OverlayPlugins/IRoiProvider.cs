using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewerApp.OverlayPlugins
{
    internal interface IRoiProvider
    {
        RectangleF GetROI { get; }
        Rectangle GetROIInt { get; }
    }
}
