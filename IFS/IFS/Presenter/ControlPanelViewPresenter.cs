using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using System.Drawing;
using ValidatorsLibrary.Validators;
using System.ComponentModel;
using FractalLibrary.Model;
using IFS.View;
using FractalRendererLibrary.Model;

namespace IFS.Presenter
{
    class ControlPanelViewPresenter
    {
        private IControlPanel _controlPanel;
        private readonly IControlPanelView _controlPanelView;
        private bool _suspendEvent;

        public ControlPanelViewPresenter(
            IControlPanelView controlPanelView)
        {
            if (controlPanelView == null)
                throw new ArgumentNullException("controlPanelView");
            _controlPanelView = controlPanelView;
            _controlPanelView.ChangedUI += new EventHandler(_controlPanelView_Changed);
        }

        public IControlPanel ControlPanel
        {
            get
            {
                return _controlPanel;
            }
            set
            {
                if (_controlPanel != null)
                {
                    _controlPanel.Changed -= new EventHandler(_controlPanel_Changed);
                    ClearControlPanelView();
                }
                _controlPanel = value;
                if (_controlPanel != null)
                {
                    _controlPanel.Changed += new EventHandler(_controlPanel_Changed);
                    RefreshControlPanelView();
                }
               
            }
        }
        
        public IControlPanelView ControlPanelView
        {
        	get
        	{
        		return _controlPanelView;
        	}
        }

        private void _controlPanelView_Changed(object sender, EventArgs e)
        {
            if(!_suspendEvent)
            {
                if (ControlPanel != null)
                {
                    _suspendEvent = true;
                    _controlPanel.XTranslation = int.Parse(_controlPanelView.XTranslation);
                    _controlPanel.YTranslation = int.Parse(_controlPanelView.YTranslation);
                    _controlPanel.Zoom = int.Parse(_controlPanelView.Zoom);
                    _controlPanel.AnticlockWiseRotation = int.Parse(_controlPanelView.Rotation);
                    PointF zoomPoint = new PointF(float.Parse(_controlPanelView.ZoomPointX), float.Parse(_controlPanelView.ZoomPointY));
                    PointF rotationPoint = new PointF(float.Parse(_controlPanelView.RotationPointX),
                        float.Parse(_controlPanelView.RotationPointY));
                    _controlPanel.ZoomPoint = zoomPoint;
                    _controlPanel.RotationPoint = rotationPoint;
                    _suspendEvent = false;
                }
            }
        }

        private void _controlPanel_Changed(object sender, EventArgs e)
        {
            if (!_suspendEvent)
            {
                _suspendEvent = true;
                RefreshControlPanelView();
                _suspendEvent = false;
            }
        }

        private void ClearControlPanelView()
        {
            _suspendEvent = true;
            ControlPanel dummy = new ControlPanel();
            _controlPanelView.RefreshView(
               dummy.XTranslation,
               dummy.YTranslation,
               dummy.Zoom,
            dummy.AnticlockWiseRotation,
            dummy.ZoomPoint,
            dummy.RotationPoint);
            _suspendEvent = false;
        }

        private void RefreshControlPanelView()
        {
            if (ControlPanel != null)
            {
                _suspendEvent = true;
                _controlPanelView.RefreshView(
                   _controlPanel.XTranslation,
                   _controlPanel.YTranslation,
                   _controlPanel.Zoom,
                _controlPanel.AnticlockWiseRotation,
                _controlPanel.ZoomPoint,
                _controlPanel.RotationPoint);
                _suspendEvent = false;
            }
        }
    }
}
