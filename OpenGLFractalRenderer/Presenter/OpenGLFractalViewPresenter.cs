using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.Presenter;
using FractalLibrary.Model;
using FractalRendererLibrary.View;
using FractalRendererLibrary.Renderer;
using FractalRendererLibrary.Model;

namespace OpenGLFractalRenderer.Presenter
{
    public class OpenGLFractalViewPresenter : FractalViewPresenterBase
    {
        public OpenGLFractalViewPresenter(
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
                _controlPanel.Zoom += 50;
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
