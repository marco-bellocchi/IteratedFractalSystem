using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FractalRendererLibrary.Events;
using IFS.Events;

namespace IFS.View
{
    public partial class NumbersControlPanelView :
        UserControl, IControlPanelView
    {
        public event EventHandler ChangedUI;
        public event ValidatingEventHandler ValidatingUI;

        public NumbersControlPanelView()
        {
            InitializeComponent();
        }

        public string XTranslation { get { return _xTranslationTb.Text; } }

        public string YTranslation { get { return this._yTranslationTb.Text; } }

        public string Zoom { get { return _zoomTb.Text; } }

        public string Rotation { get { return _rotationTb.Text; } }

        public string RotationPointX { get { return _rotationXTb.Text; } }

        public string RotationPointY { get { return _rotationYTb.Text; } }

        public string ZoomPointX { get { return _zoomXTb.Text; } }

        public string ZoomPointY { get { return _zoomYTb.Text; } }

        public UserControl UserControl { get { return this; } }

        public void RefreshView(int x, int y, float zoom, int rotation, PointF zoomPoint, PointF rotPoint)
        {
            _xTranslationTb.Text = x.ToString();
            _yTranslationTb.Text = y.ToString();
            _zoomTb.Text = zoom.ToString();
            _rotationTb.Text = rotation.ToString();
            _zoomXTb.Text = zoomPoint.X.ToString();
            _zoomYTb.Text = zoomPoint.Y.ToString();
            _rotationXTb.Text = rotPoint.X.ToString();
            _rotationYTb.Text = rotPoint.Y.ToString();
        }

        private void _applyBt_Click(object sender, EventArgs e)
        {
            OnChanged();
        }

        private void ValidatingFieldHandler(object sender, CancelEventArgs e)
        {
            ValidatingEventArgs vea = new ValidatingEventArgs();
            OnValidatingField(vea);
            e.Cancel = vea.Cancel;
            if (vea.Cancel)
                MessageBox.Show(vea.ValidationMessage, "Error");
        }

        private void ValidatedFieldHandler(object sender, EventArgs e)
        {
            //OnChanged();
        }

        protected virtual void OnChanged()
        {
            if (ChangedUI != null)
                ChangedUI(this, EventArgs.Empty);
        }

        protected virtual void OnValidatingField(ValidatingEventArgs e)
        {
            if (ValidatingUI != null)
                ValidatingUI(this, e);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


    }
}
