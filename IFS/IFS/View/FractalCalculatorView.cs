using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FractalRendererLibrary.Events;
using FractalRendererLibrary.Extensions;
using IFS.Events;

namespace IFS.View
{
    public partial class FractalCalculatorView : UserControl, IFractalCalculatorView
    {
        public event EventHandler CalculatePoints;
        public event EventHandler ClearPoints;
        public event EventHandler ResetControlPanel;
        public event EventHandler CalculateDimension;
        public event EventHandler Edit;
        //public event EventHandler ViewFractal;
        public event EventHandler ChangedUI;
        public event ValidatingEventHandler ValidatingUI;

        private bool _suspendEvents;
        private bool _enableCalculatePoints;
        private bool _enableCalculateDimension;

        public FractalCalculatorView()
        {
            InitializeComponent();
            _pointsToCalulateTb.Validating += new CancelEventHandler(_pointsToCalulateTb_Validating);
            _pointsToCalulateTb.Validated += new EventHandler(_pointsToCalulateTb_Validated);
        }

        public string PointsToCalculate
        {
            get { return _pointsToCalulateTb.Text; }
        }

        public bool EnableCalculatePoints
        {
            get
            {
                return _enableCalculatePoints;
            }
            set
            {
                _enableCalculatePoints = value;
                FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this, ()=>{
                 _calculateBt.Enabled = _enableCalculatePoints; });
            }
        }

        public bool EnableCalculateDimension 
        {
            get
            {
                return _enableCalculateDimension;
            }
            set
            {
                _enableCalculateDimension = value;
                FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this,()=>
                { _calcDimBt.Enabled = _enableCalculateDimension; });
            }
        } 

        public void RefreshView(long pointsToCalculate)
        {
            try
            {
                _suspendEvents = true;
                _pointsToCalulateTb.Text = pointsToCalculate.ToString();
            }
            finally
            {
                _suspendEvents = false;
            }
        }

        public void DisplayDimension(double dimension)
        {
            MessageBox.Show("Dimension of fractal is " + dimension, "Info");
        }

        public void CalculatingPoints()
        {
            UserControlExtension.InvokeInUIThread(this,()=>_calculatingLabel.Text = "Calculating points...");
        }

        public void CalculatedPoints()
        {
            UserControlExtension.InvokeInUIThread(this, () => _calculatingLabel.Text = "");
        }

        private void _calculateBt_Click(object sender, EventArgs e)
        {
            if (CalculatePoints != null)
                CalculatePoints(this, EventArgs.Empty);
        }

        private void _pointsToCalulateTb_Validating(object sender, CancelEventArgs e)
        {
            if (!_suspendEvents)
            {
                if (ValidatingUI != null)
                {
                    ValidatingEventArgs ve = new ValidatingEventArgs();
                    ValidatingUI(this, ve);
                    e.Cancel = ve.Cancel;
                    if (e.Cancel)
                        MessageBox.Show(ve.ValidationMessage, "Error");
                }
            }
        }

        private void _pointsToCalulateTb_Validated(object sender, EventArgs e)
        {
            OnChanged();
        }

        protected virtual void OnChanged()
        {
            if (!_suspendEvents)
            {
                if (ChangedUI != null)
                    ChangedUI(this, EventArgs.Empty);
            }
        }

        private void _resetBt_Click(object sender, EventArgs e)
        {
            if (ResetControlPanel != null)
                ResetControlPanel(this, EventArgs.Empty);
        }

        private void _calcDimBt_Click(object sender, EventArgs e)
        {
            if (CalculateDimension != null)
                CalculateDimension(this, EventArgs.Empty);
        }

        private void _clearPointsBt_Click(object sender, EventArgs e)
        {
            if (ClearPoints != null)
                ClearPoints(this, EventArgs.Empty);
        }

        private void _editBt_Click(object sender, EventArgs e)
        {
            if (Edit != null)
                Edit(this, EventArgs.Empty);
        }
    }
}
