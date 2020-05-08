using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using FractalLibrary.Model;
using IFS.View;

namespace IFS.Presenter
{
    public class FractalDataGridViewPresenter
    {
        private IFractal _fractal;
        private readonly IFractalDataGridView _fractalDataGridView;

        public FractalDataGridViewPresenter(IFractalDataGridView fractalDataGridView)
        {
            if (fractalDataGridView == null)
                throw new ArgumentNullException("fractalDataGridView");
            _fractalDataGridView = fractalDataGridView;
        }

        public IFractal Fractal
        {
            get
            {
                return _fractal;
            }
            set
            {
                if (_fractal != null)
                {
                    _fractal.PointsChanged -= new EventHandler(_fractal_PointsChanged);
                    ClearDataGridView();
                }
                _fractal = value;
                if (_fractal != null)
                {
                    _fractal.PointsChanged += new EventHandler(_fractal_PointsChanged);
                    RefreshDataGridView();
                }
              
            }
        }

        public IFractalDataGridView FractalDataGridView
        {
            get
            {
                return _fractalDataGridView;
            }
        }

        private void ClearDataGridView()
        {
            _fractalDataGridView.Refresh(new List<System.Drawing.PointF>());
        }

        private void RefreshDataGridView()
        {
            _fractalDataGridView.Refresh(_fractal.Points);
        }

        private void _fractal_PointsChanged(object sender, EventArgs e)
        {
            _fractalDataGridView.Refresh(_fractal.Points);
        }
    }
}
