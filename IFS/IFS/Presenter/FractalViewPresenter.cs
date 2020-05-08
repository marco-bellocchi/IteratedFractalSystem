//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using FractalRendererLibrary.View;
//using FractalRendererLibrary.Renderer;
//using System.Drawing;
//using FractalRendererLibrary.Extensions;
//using FractalLibrary.Model;
//using TransformationsLibrary.Transformation;
//using FractalRendererLibrary.Events;
//using FractalRendererLibrary.Model;

//namespace IFS.Presenter
//{
//    class FractalViewPresenter
//    {
//        private readonly IFractal _fractal;
//        private readonly IControlPanel _controlPanel;
//        private readonly IFractalView _fractalView;
//        private readonly IFractalRenderer _renderer;

//        public FractalViewPresenter(
//            IFractal fractal,
//            IControlPanel controlPanel,
//            IFractalView fractalView,
//            IFractalRenderer renderer)
//        {
//            if (fractal == null)
//                throw new ArgumentNullException("fractal");
//            if (controlPanel == null)
//                throw new ArgumentNullException("controlPanel");
//            if (renderer == null)
//                throw new ArgumentNullException("renderer");
//            _fractal = fractal;
//            _controlPanel = controlPanel;
//            _fractalView = fractalView;
//            _renderer = renderer;
//            _fractal.PointsChanged += new EventHandler(_fractal_PointsChanged);
//            _fractalView = fractalView;
//            _fractalView.PaintView += new System.Windows.Forms.PaintEventHandler(_fractalView_Paint);
//            _fractalView.Resize += new EventHandler(_fractalView_Resize);
//            _fractalView.ZoomIn += new ZoomEventHandler(_fractalView_ZoomIn);
//            _fractalView.Translating += new TranslatingEventHandler(_fractalView_Translating);
//            _fractalView.SetNumOfCalculatedPoints(_fractal.Points.Count);
//            if (_fractal.ExactDimension.HasValue)
//                _fractalView.SetSimilarityDimension(_fractal.ExactDimension.Value.ToString());
//        }

//        public IFractalView FractalView
//        {
//            get
//            {
//                return _fractalView;
//            }
//            //set
//            //{
//            //    if (_fractalView != null)
//            //    {
//            //        _fractalView.PaintView -= new System.Windows.Forms.PaintEventHandler(_fractalView_Paint);
//            //        _fractalView.Resize -= new EventHandler(_fractalView_Resize);
//            //        _fractalView.ZoomIn -= new ZoomEventHandler(_fractalView_ZoomIn);
//            //        _fractalView.Translating -= new TranslatingEventHandler(_fractalView_Translating);
//            //    }
//            //    _fractalView = value;
//            //    if (_fractalView != null)
//            //    {
//            //        _fractalView.PaintView += new System.Windows.Forms.PaintEventHandler(_fractalView_Paint);
//            //        _fractalView.Resize += new EventHandler(_fractalView_Resize);
//            //        _fractalView.ZoomIn += new ZoomEventHandler(_fractalView_ZoomIn);
//            //        _fractalView.Translating += new TranslatingEventHandler(_fractalView_Translating);
//            //        _fractalView.SetNumOfCalculatedPoints(_fractal.Points.Count);
//            //        if (_fractal.ExactDimension.HasValue)
//            //            _fractalView.SetSimilarityDimension(_fractal.ExactDimension.Value.ToString());
//            //    }
//            //}
//        }

//        private void _fractalView_Resize(object sender, EventArgs e)
//        {
//            _controlPanel.Rectangle = _fractalView.DrawableRectangle;
//        }

//        private void _controlPanel_Changed(object sender, EventArgs e)
//        {
//            _fractalView.RefreshScreen();
//        }

//        private void _fractal_PointsChanged(object sender, EventArgs e)
//        {
//            _fractalView.SetNumOfCalculatedPoints(_fractal.Points.Count);
//            _fractalView.RefreshScreen();
//        }

//        private void _fractalView_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
//        {
//            _renderer.Render(_fractal, _controlPanel);
//        }

//        private void _fractalView_ZoomIn(object sender, ZoomEventArgs ze)
//        {
//            try
//            {
//                _controlPanel.BeginTransaction();
//                ITransformation fromPixelTransformation = _controlPanel.CreateInverseTransformation();
//                PointF toScreen = fromPixelTransformation.Apply(ze.ZoomPoint);

//                _controlPanel.XTranslation = ze.ZoomPoint.X;
//                _controlPanel.YTranslation = ze.ZoomPoint.Y;
//                //PointF currentZoomPoint = toPixelTransformation.Apply(_controlPanel.ZoomPoint);
//                _controlPanel.Zoom += 50;
//                _controlPanel.ZoomPoint = toScreen;// new System.Drawing.PointF(ze.ZoomPoint.X, ze.ZoomPoint.Y);
//            }
//            finally
//            {
//                _controlPanel.CommitTransaction();
//            }
//        }


//        private void _fractalView_Translating(object sender, TranslatingEventArgs ze)
//        {
//            try
//            {
//                _controlPanel.BeginTransaction();
//                _controlPanel.XTranslation +=ze.XTranslation;
//                _controlPanel.YTranslation += ze.YTranslation;
//            }
//            finally
//            {
//                _controlPanel.CommitTransaction();
//            }
//        }
//    }
//}
