using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using FractalRendererLibrary.Renderer;
using FractalRendererLibrary.Presenter;
using FractalLibrary.Model;
using FractalRendererLibrary.Model;

namespace FractalRendererLibrary
{
    public interface IRendererAbstractFactory
    {
        bool IsSpecificRendererSupported();
        IFractalView CreateFractalView();
        IFractalRenderer CreateRenderer(IFractalView fractalView);
        FractalViewPresenterBase CreateFractalViewPresenter(
            IFractal fractal,
            IControlPanel controlPanel,
            IFractalView fractalView,
            IFractalRenderer renderer);
    }
}
