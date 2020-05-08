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
using FractalRendererLibrary.Extensions;
using FractalRendererLibrary.Events;
using FractalRendererLibrary.Model;

namespace GDIFractalRendererLibrary.Renderer
{
    /// <summary>
    /// Description of FractalRenderer.
    /// </summary>
    /// 
    public abstract class GDIFractalRendererBase : FractalRendererBase
    {
        protected GDIFractalRendererBase(IFractalView fractalView)
            : base(fractalView)
        {
        }

        public override void Render(IFractal fractal, IControlPanel controlPanel)
        {
            //Copy for the closure
            RectangleF rectangle = controlPanel.Rectangle;
            PointF rotationPoint = controlPanel.RotationPoint;
            PointF zoomPoint = controlPanel.ZoomPoint;

            ITransformation transformation = controlPanel.CreateTransformation();
            _rendererThread.Enqueue((cancellableArg) =>
            {
                try
                {
                    using (Graphics g = _fractalView.CreateViewGraphic())
                    {
                        g.Clear(Color.White);
                        using (Brush brush = new SolidBrush(Color.Yellow))
                        {
                            PointF p = transformation.Apply(zoomPoint);
                            g.FillRectangle(brush, p.X, p.Y, 5, 5);
                        }
                        using (Brush brush = new SolidBrush(Color.Orange))
                        {
                            PointF p = transformation.Apply(rotationPoint);
                            g.FillRectangle(brush, p.X, p.Y, 5, 5);
                        }
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            DrawFractalPoints(brush, transformation, rectangle, fractal, g, cancellableArg);
                        }
                        using (Brush brush = new SolidBrush(Color.Green))
                        {
                            PointF p = transformation.Apply(zoomPoint);
                            g.FillRectangle(brush, p.X, p.Y, 5, 5);
                        }
                        using (Brush brush = new SolidBrush(Color.DarkOrange))
                        {
                            PointF p = transformation.Apply(rotationPoint);
                            g.FillRectangle(brush, p.X, p.Y, 5, 5);
                        }
                    }
                }
                catch (Exception e)//Catching exception in case the view is closed while still drawing in the panel
                {
                }
            });
        }

        protected abstract void DrawFractalPoints(Brush brush,
            ITransformation transformation, RectangleF viewPort, IFractal fractal, Graphics g, CancellableRenderingEventArg cancellableArg);
    }
}
