using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using FractalRendererLibrary.Renderer;
using System.Drawing;
using FractalRendererLibrary.Extensions;
using FractalLibrary.Model;
using TransformationsLibrary.Transformation;
using FractalRendererLibrary.Events;
using FractalRendererLibrary.Presenter;
using FractalRendererLibrary.Model;

namespace GDIFractalRendererLibrary.Presenter
{
    public class GDIFractalViewPresenter : FractalViewPresenterBase
    {
        public GDIFractalViewPresenter(
            IFractal fractal,
            IControlPanel controlPanel,
            IFractalView fractalView,
            IFractalRenderer renderer):base(fractal,controlPanel,fractalView,renderer)
         {}

        protected override void ZoomIn(object sender, FractalRendererLibrary.Events.ZoomEventArgs ze)
        {
            try
            {
                _controlPanel.BeginTransaction();
                ITransformation fromPixelTransformation = _controlPanel.CreateInverseTransformation();
                PointF toScreen = fromPixelTransformation.Apply(ze.ZoomPoint);

                _controlPanel.XTranslation = ze.ZoomPoint.X;
                _controlPanel.YTranslation = ze.ZoomPoint.Y;
                //PointF currentZoomPoint = toPixelTransformation.Apply(_controlPanel.ZoomPoint);
                _controlPanel.Zoom += 50;
                _controlPanel.ZoomPoint = toScreen;// new System.Drawing.PointF(ze.ZoomPoint.X, ze.ZoomPoint.Y);
            }
            finally
            {
                _controlPanel.CommitTransaction();
            }
        }

        protected override void Translate(object sender, FractalRendererLibrary.Events.TranslatingEventArgs ze)
        {
            try
            {
                _controlPanel.BeginTransaction();
                _controlPanel.XTranslation += ze.XTranslation;
                _controlPanel.YTranslation += ze.YTranslation;
            }
            finally
            {
                _controlPanel.CommitTransaction();
            }
        }
    }
}
