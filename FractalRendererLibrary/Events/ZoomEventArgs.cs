using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FractalRendererLibrary.Events
{
    public delegate void  ZoomEventHandler(object sender, ZoomEventArgs ze);

    public class ZoomEventArgs: EventArgs
    {
        public ZoomEventArgs(Point zoomPoint)
        {
            ZoomPoint = zoomPoint;
        }

        public Point ZoomPoint { get; private set; }
    }
}
