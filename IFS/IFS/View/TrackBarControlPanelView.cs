/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 01/08/2014
 * Time: 21:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FractalRendererLibrary.Events;
using IFS.Events;

namespace IFS.View
{
	/// <summary>
	/// Description of ControlPanelView.
	/// </summary>
	public partial class TrackBarControlPanelView : 
        UserControl,IControlPanelView
	{
        public event EventHandler ChangedUI;
        public event ValidatingEventHandler ValidatingUI;
        private bool _suspendEvent;
        private bool _clicked;
        private int? _oldValueTrackBar;

		public TrackBarControlPanelView()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        public UserControl UserControl { get { return this; } }

        private void InitializeValidationEvents()
        {
        }

        private void _xTranslationTb_Scroll(object sender, EventArgs e)
        {
            if (_clicked)
                return;
            OnChanged();
        }

        private void _yTranslationTb_Scroll(object sender, EventArgs e)
        {
            if (_clicked)
                return;
            OnChanged();
        }

        private void _zoomTb_Scroll(object sender, EventArgs e)
        {
            if (_clicked)
                return;
            OnChanged();
        }

        private void _rotationTb_Scroll(object sender, EventArgs e)
        {
            if (_clicked)
                return;
            OnChanged();
        }

        public string XTranslation
        {
            get { return _xTranslationTb.Value.ToString(); }
        }

        public string YTranslation
        {
            get { return _yTranslationTb.Value.ToString(); }
        }

        public string Zoom
        {
            get { return _zoomTb.Value.ToString(); }
        }

        public string RotationPointX { get { return _rotationXTb.Text; } }

        public string RotationPointY { get { return _rotationYTb.Text; } }

        public string ZoomPointX { get { return _zoomXTb.Text; } }

        public string ZoomPointY { get { return _zoomYTb.Text; } }

        public string Rotation
        {
            get { return _rotationTb.Value.ToString(); }
        }

        public void RefreshView(int x, int y, float zoom, int rotation, PointF zoomPoint, PointF rotPoint)
        {
            try
            {
                _suspendEvent = true;
                _xTranslationTb.Value = x;
                _yTranslationTb.Value = y;
                _zoomTb.Value = (int)zoom;
                _rotationTb.Value = rotation;
                _zoomXTb.Text = zoomPoint.X.ToString();
                _zoomYTb.Text = zoomPoint.Y.ToString();
                _rotationXTb.Text = rotPoint.X.ToString();
                _rotationYTb.Text = rotPoint.Y.ToString();
            }
            finally
            {
                _suspendEvent = false;
            }
        }

        private void _xTranslationTb_MouseDown(object sender, MouseEventArgs e)
        {
            _clicked = true;
            _oldValueTrackBar = _xTranslationTb.Value;
        }

        private void _xTranslationTb_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_clicked)
                return;
            _clicked = false;
            CancelEventArgs ce = new CancelEventArgs();
            ValidatingFieldHandler(sender, ce);
            if (ce.Cancel)
            {
                _xTranslationTb.Value = _oldValueTrackBar.Value;
                return;
            }
            OnChanged();
        }

        private void _yTranslationTb_MouseDown(object sender, MouseEventArgs e)
        {
            _clicked = true;
            _oldValueTrackBar = _xTranslationTb.Value;
        }

        private void _yTranslationTb_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_clicked)
                return;
            _clicked = false;
            CancelEventArgs ce = new CancelEventArgs();
            ValidatingFieldHandler(sender, ce);
            if (ce.Cancel)
            {
                _yTranslationTb.Value = _oldValueTrackBar.Value;
                return;
            }
            OnChanged();
        }

        private void _zoomTb_MouseDown(object sender, MouseEventArgs e)
        {
            _clicked = true;
            _oldValueTrackBar = _xTranslationTb.Value;
        }

        private void _zoomTb_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_clicked)
                return;
            _clicked = false;
            CancelEventArgs ce = new CancelEventArgs();
            ValidatingFieldHandler(sender, ce);
            if (ce.Cancel)
            {
                _zoomTb.Value = _oldValueTrackBar.Value;
                return;
            }
            OnChanged();
        }

        private void _rotationTb_MouseDown(object sender, MouseEventArgs e)
        {
            _clicked = true;
            _oldValueTrackBar = _xTranslationTb.Value;
        }

        private void _rotationTb_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_clicked)
                return;
            _clicked = false;
            CancelEventArgs ce = new CancelEventArgs();
            ValidatingFieldHandler(sender, ce);
            if (ce.Cancel)
            {
                _rotationTb.Value = _oldValueTrackBar.Value;
                return;
            }
            OnChanged();
        }

        protected virtual void OnChanged()
        {
            if (!_suspendEvent)
            {
                if (ChangedUI != null)
                    ChangedUI(this, EventArgs.Empty);
            }
        }

        private void ValidatingFieldHandler(object sender, CancelEventArgs e)
        {
            if (!_suspendEvent)
            {
                _suspendEvent = true;
                ValidatingEventArgs vea = new ValidatingEventArgs();
                OnValidatingField(vea);
                e.Cancel = vea.Cancel;
                if (vea.Cancel)
                    MessageBox.Show(vea.ValidationMessage, "Error");
                _suspendEvent = false;
            }
        }

        private void ValidatedFieldHandler(object sender, EventArgs e)
        {
                OnChanged();
        }

        protected virtual void OnValidatingField(ValidatingEventArgs e)
        {
                if (ValidatingUI != null)
                    ValidatingUI(this, e);
        }
    }
}
