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
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace OpenGLFractalRenderer.View
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
        private bool _loaded;

        public FractalView()
        {
            InitializeComponent();
            _glControl.Resize += new EventHandler(_glControl_Resize);
            _glControl.Paint += new PaintEventHandler(_rendererPanel_Paint);
        }

        public UserControl View { get { return this; } }

        public Rectangle DrawableRectangle
        {
            get
            {
                return _glControl.DisplayRectangle;
            }
        }

        public Graphics CreateViewGraphic()
        {
            throw new NotSupportedException("CreateViewGraphic"); ;
        }

        public void RefreshScreen()
        {
            FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this, () =>
            {
                Invalidate(true);
            });
        }

        public void SetNumOfCalculatedPoints(int numOfPoints)
        {
            FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this, () =>
            {
                _pointsLb.Text = numOfPoints.ToString();
            });
        }

        public void SetSimilarityDimension(string dimension)
        {
            FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this, () =>
            {
                _dimLb.Text = dimension.ToString();
            });
        }

        private void _rendererPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!_loaded)
                return;
            if (_glControl != null)
            {
                _glControl.MakeCurrent();
                if (PaintView != null)
                    PaintView(this, e);
                _glControl.SwapBuffers();
            }
        }

        private void _glControl_Resize(object sender, EventArgs e)
        {
            if(_loaded)
                GL.Viewport(0, 0, _glControl.Width, _glControl.Height);
        }

        private void _glControl_Load(object sender, EventArgs e)
        {
            //GL.ClearColor(Color.SkyBlue);
            SetupViewport();
            _loaded = true;
        }

        private void SetupViewport()
        {
            int w = _glControl.Width;
            int h = _glControl.Height;
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        private void _rendererPanel_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            _translating = false;
            Point point = _glControl.PointToClient(Cursor.Position);
            OnZoomIn(point);
        }

        private void _rendererPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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

        private void _rendererPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_translating)
                Cursor = Cursors.Hand;
        }

        private void _glControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            _translating = true;
            _initialPoint = e.Location;
        }

        protected virtual void OnZoomIn(Point point)
        {
            if (ZoomIn != null)
                ZoomIn(this, new ZoomEventArgs(point));
        }

        protected virtual void OnTranslating()
        {
            int translateX = _finalPoint.X - _initialPoint.X;
            int translateY =  _initialPoint.Y - _finalPoint.Y;
            if (Translating != null)
                Translating(this,
                    new TranslatingEventArgs(translateX, translateY));
        }
    }
}
