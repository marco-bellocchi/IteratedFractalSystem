/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 01/08/2014
 * Time: 00:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace FractalRendererLibrary.Model
{
    /// <summary>
    /// Description of RenderStatus.
    /// </summary>
    public class ControlPanel : IControlPanel
    {
        private RectangleF _rectangle;
        private int _xTranslation = 0;
        private int _yTranslation = 0;
        private float _zoom = 10;
        private PointF _zoomPoint = new PointF(0, 0);
        private int _rotation = 0;
        private PointF _rotationPoint = new PointF(0, 0);

        private bool _suspendEvents;

        public event EventHandler Changed;

        public RectangleF Rectangle
        {
            get { return _rectangle; }
            set
            {
                if (_rectangle != value)
                {
                    _rectangle = value;
                    OnChanged();
                }
            }
        }

        public int XTranslation
        {
            get { return _xTranslation; }
            set
            {
                if (_xTranslation != value)
                {
                    _xTranslation = value;
                    OnChanged();
                }
            }
        }
        public int YTranslation
        {
            get { return _yTranslation; }
            set
            {
                if (_yTranslation != value)
                {
                    _yTranslation = value; OnChanged();
                }
            }
        }
        public float Zoom
        {
            get { return _zoom; }
            set
            {
                if (_zoom != value)
                {
                    _zoom = value; OnChanged();
                }
            }
        }

        public PointF ZoomPoint
        {
            get
            {
                return _zoomPoint;
            }
            set
            {
                if (_zoomPoint != value)
                {
                    _zoomPoint = value; OnChanged();
                }
            }
        }

        public int AnticlockWiseRotation
        {
            get { return _rotation; }
            set
            {
                if (_rotation != value)
                {
                    _rotation = value; OnChanged();
                }
            }
        }

        public PointF RotationPoint
        {
            get
            {
                return _rotationPoint;
            }
            set
            {
                if (_rotationPoint != value)
                {
                    _rotationPoint = value; OnChanged();
                }
            }
        }

        public void BeginTransaction()
        {
            _suspendEvents = true;
        }

        public void CommitTransaction()
        {
            _suspendEvents = false;
            OnChanged();
        }

        public void Reset()
        {
            _xTranslation = 0;
            _yTranslation = 0;
            _zoom = 10;
            _zoomPoint = new PointF(0, 0);
            _rotation = 0;
            _rotationPoint = new PointF(0, 0);
            OnChanged();
        }

        protected virtual void OnChanged()
        {
            if (!_suspendEvents)
            {
                if (Changed != null)
                    Changed(this, EventArgs.Empty);
            }
        }
    }
}
