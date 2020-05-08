using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary;
using OpenGLFractalRenderer.View;
using OpenGLFractalRenderer.Renderer;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;
using FractalRendererLibrary.Presenter;
using FractalLibrary.Model;
using FractalRendererLibrary.View;
using FractalRendererLibrary.Renderer;
using OpenGLFractalRenderer.Presenter;
using FractalRendererLibrary.Model;

namespace OpenGLFractalRenderer
{
    public class OpenGLRendererAbstractFactory : IRendererAbstractFactory
    {
        public FractalRendererLibrary.View.IFractalView CreateFractalView()
        {
            return new FractalView();
        }

        public FractalRendererLibrary.Renderer.IFractalRenderer CreateRenderer(FractalRendererLibrary.View.IFractalView fractalView)
        {
            return new OpenTkRenderer(fractalView);
        }

        public bool IsSpecificRendererSupported()
        {
            return true;
        }

        public FractalViewPresenterBase CreateFractalViewPresenter(
          IFractal fractal, IControlPanel controlPanel, IFractalView fractalView,
          IFractalRenderer renderer)
        {
            return new OpenGLFractalViewPresenter(fractal, controlPanel, fractalView, renderer);
        }
    }
}
