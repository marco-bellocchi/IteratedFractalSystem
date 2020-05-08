using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary;
using GDIFractalRendererLibrary.View;
using GDIFractalRendererLibrary.Renderer;
using GDIFractalRendererLibrary.Presenter;
using FractalRendererLibrary.Presenter;
using FractalLibrary.Model;
using FractalRendererLibrary.View;
using FractalRendererLibrary.Renderer;
using FractalRendererLibrary.Model;

namespace GDIFractalRendererLibrary
{
    public class GDIRendererAbstractFactory : IRendererAbstractFactory
    {
        public FractalRendererLibrary.View.IFractalView CreateFractalView()
        {
            return new FractalView();
        }

        public FractalRendererLibrary.Renderer.IFractalRenderer CreateRenderer(FractalRendererLibrary.View.IFractalView fractalView)
        {
            return new GDIFractalSequentialRenderer(fractalView);
        }

        public bool IsSpecificRendererSupported()
        {
            return true;//Always supported
        }

        public FractalViewPresenterBase CreateFractalViewPresenter(
            IFractal fractal, IControlPanel controlPanel, IFractalView fractalView, 
            IFractalRenderer renderer)
        {
            return new GDIFractalViewPresenter(fractal, controlPanel, fractalView, renderer);
        }
    }
}
