/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 01/08/2014
 * Time: 21:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FractalRendererLibrary.Events;
using FractalRendererLibrary.View;

namespace GDIFractalRendererLibrary.View
{
	/// <summary>
	/// Description of FractalPanel.
	/// </summary>
    /// 
    public partial class FractalView : UserControl, IFractalView
	{
        public event PaintEventHandler PaintView;
        public event ZoomEventHandler ZoomIn;
        public event TranslatingEventHandler Translating; 

        private bool _translating;
        private Point _initialPoint;
        private Point _finalPoint;

		public FractalView()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);
            //Utility.RendererHelper.SetDoubleBuffered(this);

            _rendererPanel.Resize += new EventHandler(_rendererPanel_Resize);
            _rendererPanel.Paint += new PaintEventHandler(_rendererPanel_Paint);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        public UserControl View { get { return this; } }

        public Rectangle DrawableRectangle
        {
            get
            {
                return _rendererPanel.DisplayRectangle;
            }
        }

        public Graphics CreateViewGraphic()
        {
            return _rendererPanel.CreateGraphics();
        }

        public void RefreshScreen()
        {
            FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this,()=>{
                Invalidate(true);
            });
        }

        public void SetNumOfCalculatedPoints(int numOfPoints)
        {
            FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this,()=>
            {
                 _numOfPointsLb.Text = numOfPoints.ToString();
            });
        }

        public void SetSimilarityDimension(string dimension)
        {
            FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this, () =>
            {
                this._fractalDimLb.Text = dimension.ToString();
            });
        }

        private void _rendererPanel_Paint(object sender, PaintEventArgs e)
        {
            if (PaintView != null)
                PaintView(this, e);
        }

        private void _rendererPanel_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            _translating = false;
            Point point = _rendererPanel.PointToClient(Cursor.Position);
            OnZoomIn(point);
        }

        private void _rendererPanel_Resize(object sender, EventArgs e)
        {
            _rendererPanel.Invalidate();
        }

        private void _rendererPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            _translating = true;
            _initialPoint = e.Location;
        }

        private void _rendererPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_translating)
            {
                _translating = false;
                _finalPoint = e.Location;
                if (_finalPoint != _initialPoint)
                {
                    OnTranslating();
                    Cursor = Cursors.Default;
                }
            }
        }

        protected virtual void OnZoomIn(Point point)
        {
            if (ZoomIn != null)
                ZoomIn(this, new ZoomEventArgs(point));
        }

        protected virtual void OnTranslating()
        {
            int translateX = _finalPoint.X - _initialPoint.X;
            int translateY = _finalPoint.Y - _initialPoint.Y;
            if (Translating != null)
                Translating(this,
                    new TranslatingEventArgs(translateX, translateY));
        }

        private void _rendererPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_translating)
                Cursor = Cursors.Hand;
        }
	}
}
