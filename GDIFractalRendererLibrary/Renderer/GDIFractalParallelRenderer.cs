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
	/// <summary>
	/// Description of FractalRenderer.
	/// </summary>
	/// 
    public class GDIFractalParallelRenderer : GDIFractalRendererBase
	{
		public GDIFractalParallelRenderer(IFractalView fractalView):base(fractalView)
		{
		}

        protected override void DrawFractalPoints(Brush brush, 
            ITransformation transformation, RectangleF viewPort, IFractal fractal, Graphics g, CancellableRenderingEventArg cancellableArg)
        {
            //Less memory used, transforming and painting
            //foreach (var point in fractal.Points)
            //{
            //    if (cancellableArg.IsCancelled())
            //        return;
            //    PointF p = transformation.Apply(point);
            //    if (rectangle.Contains(p))
            //        g.FillRectangle(brush, p.X, p.Y, 2, 2);
            //}
            //Parallelize this
            DateTime start = DateTime.Now;
            var resultCollection = new ConcurrentBag<PointF>();
            var points = fractal.Points;
            Parallel.ForEach(fractal.Points, (point) =>
            {
                resultCollection.Add(transformation.Apply(point));
            });

            DateTime stop = DateTime.Now;
            TimeSpan ts = stop - start;
            LoggerProvider.Instance.Trace(fractal.Name + ": " + points.Count + "->" + ts.TotalMilliseconds);
            foreach (var p in resultCollection)
            {
                if (cancellableArg.IsCancelled())
                    return;
                if (viewPort.Contains(p))
                    g.FillRectangle(brush, p.X, p.Y, 1, 1);
            }
        }
    }
}
