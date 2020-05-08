using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Model;
using FractalRendererLibrary.View;
using FractalRendererLibrary.Renderer;
using FractalRendererLibrary.Events;
using FractalRendererLibrary.Model;

namespace FractalRendererLibrary.Presenter
{
    public abstract class FractalViewPresenterBase
    {
        protected readonly IFractal _fractal;
        protected readonly IControlPanel _controlPanel;
        protected readonly IFractalView _fractalView;
        protected readonly IFractalRenderer _renderer;

        protected FractalViewPresenterBase(
            IFractal fractal,
            IControlPanel controlPanel,
            IFractalView fractalView,
            IFractalRenderer renderer)
        {
            if (fractal == null)
                throw new ArgumentNullException("fractal");
            if (controlPanel == null)
                throw new ArgumentNullException("controlPanel");
            if (fractalView == null)
                throw new ArgumentNullException("fractalView");
            if (renderer == null)
                throw new ArgumentNullException("renderer");
            _fractal = fractal;
            _controlPanel = controlPanel;
            _fractalView = fractalView;
            _renderer = renderer;
            _fractal.PointsChanged += new EventHandler(_fractal_PointsChanged);
            _controlPanel.Changed += new EventHandler(_controlPanel_Changed);
            _fractalView.PaintView += new System.Windows.Forms.PaintEventHandler(_fractalView_Paint);
            _fractalView.Resize += new EventHandler(_fractalView_Resize);
            _fractalView.ZoomIn += new ZoomEventHandler(_fractalView_ZoomIn);
            _fractalView.Translating += new TranslatingEventHandler(_fractalView_Translating);
            _fractalView.SetNumOfCalculatedPoints(_fractal.Points.Count);
            if (_fractal.ExactDimension.HasValue)
                _fractalView.SetSimilarityDimension(_fractal.ExactDimension.Value.ToString());
        }

        private void _fractalView_Resize(object sender, EventArgs e)
        {
            _controlPanel.Rectangle = _fractalView.DrawableRectangle;
        }

        private void _controlPanel_Changed(object sender, EventArgs e)
        {
            _fractalView.RefreshScreen();
        }

        private void _fractal_PointsChanged(object sender, EventArgs e)
        {
            _fractalView.SetNumOfCalculatedPoints(_fractal.Points.Count);
            _fractalView.RefreshScreen();
        }

        private void _fractalView_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _renderer.Render(_fractal, _controlPanel);
        }

        private void _fractalView_ZoomIn(object sender, ZoomEventArgs ze)
        {
            ZoomIn(sender, ze);
        }

        private void _fractalView_Translating(object sender, TranslatingEventArgs ze)
        {
            Translate(sender, ze);
        }

        protected abstract void ZoomIn(object sender, ZoomEventArgs ze);

        protected abstract void Translate(object sender, TranslatingEventArgs ze);
    }
}
