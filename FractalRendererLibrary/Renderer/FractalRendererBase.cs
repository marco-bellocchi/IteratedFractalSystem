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
using FractalLibrary.Model;
using FractalRendererLibrary.Model;

namespace FractalRendererLibrary.Renderer
{
    /// <summary>
    /// Description of FractalRenderer.
    /// </summary>
    /// 
    public abstract class FractalRendererBase : IFractalRenderer, IDisposable
    {
        protected readonly RendererThread _rendererThread;
        protected readonly IFractalView _fractalView;
        private bool _disposed;

        public FractalRendererBase(IFractalView fractalView)
        {
            if (fractalView == null)
                throw new ArgumentNullException("fractalView");
            _fractalView = fractalView;
            _rendererThread = new RendererThread();
        }

        public abstract void Render(IFractal fractal, IControlPanel controlPanel);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _rendererThread.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
