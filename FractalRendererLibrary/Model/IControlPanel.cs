using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FractalRendererLibrary.Model
{
    public interface IControlPanel
    {
        event EventHandler Changed;
        RectangleF Rectangle{get;set;}
        int XTranslation{get;set;}
        int YTranslation{get;set;}
        float Zoom{get;set;}
        PointF ZoomPoint{get;set;}
        int AnticlockWiseRotation{get;set;}
        PointF RotationPoint{get;set;}

        void BeginTransaction();
        void CommitTransaction();
        void Reset();
    }
}
