using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FractalRendererLibrary.Events;

namespace IFS.View
{
    public interface IControlPanelView : IView
    {
        string XTranslation { get; }

        string YTranslation { get; }

        string Zoom { get; }

        string Rotation { get; }

        string RotationPointX { get; }

        string RotationPointY { get; }

        string ZoomPointX { get; }

        string ZoomPointY { get; }

        void RefreshView(int x, int y, float zoom, int rotation, PointF zoomPoint, PointF rotPoint);
    }
}
