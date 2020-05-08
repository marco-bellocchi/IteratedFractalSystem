/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 31/07/2014
 * Time: 23:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FractalRendererLibrary.View;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Logger;
using FractalLibrary.Model;
using TransformationsLibrary.Transformation;
using FractalRendererLibrary.Renderer;
using FractalRendererLibrary.Events;

namespace GDIFractalRendererLibrary.Renderer
{
    class GDIFractalSequentialRenderer: GDIFractalRendererBase
	{
        public GDIFractalSequentialRenderer(IFractalView fractalView)
            : base(fractalView)
		{
		}

        protected override void DrawFractalPoints(Brush brush,
           ITransformation transformation, RectangleF viewPort, IFractal fractal, Graphics g, CancellableRenderingEventArg cancellableArg)
        {
            //Less memory used, transforming and painting
            try
            {
                foreach (var point in fractal.Points)
                {
                    if (cancellableArg.IsCancelled())
                        return;
                    PointF p = transformation.Apply(point);
                    if (viewPort.Contains(p))
                        g.FillRectangle(brush, p.X, p.Y, 1, 1);
                }
            }
            catch (Exception e)//If closing the view while still drawing, 
            {
            }
        }
    }
}
