using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using ValidatorsLibrary.Validators;
using System.ComponentModel;
using System.Threading.Tasks;
using FractalLibrary.Model;
using IFS.View;
using FractalRendererLibrary.Model;

namespace IFS.Presenter
{
    class FractalCalculatorViewPresenter
    {
        private readonly IFractal _fractal;
        private readonly IDimensionCalculatorFactory _dimensionCalculatorFactory;
        private readonly IFractalCalculatorView _fractalCalculatorView;
        private readonly IControlPanel _controlPanel;
        private IValidator _viewValidator;

        public FractalCalculatorViewPresenter(IFractal fractal,
            IDimensionCalculatorFactory dimensionCalculatorFactory, 
            IFractalCalculatorView fractalCalculatorView, 
            IControlPanel controlPanel)
        {
            if (fractal == null)
                throw new ArgumentNullException("fractal");
            if (dimensionCalculatorFactory == null)
                throw new ArgumentNullException("dimensionCalculatorFactory");
            if (fractalCalculatorView == null)
                throw new ArgumentNullException("fractalCalculatorView");
            if (controlPanel == null)
                throw new ArgumentNullException("controlPanel");
            _fractal = fractal;
            _dimensionCalculatorFactory = dimensionCalculatorFactory;
            _fractalCalculatorView = fractalCalculatorView;
            _controlPanel = controlPanel;

            _fractalCalculatorView.ClearPoints += new EventHandler(_fractalCalculatorView_ClearPoints);
            _fractalCalculatorView.CalculatePoints += new EventHandler(_fractalCalculatorView_CalculatePoints);
            _fractalCalculatorView.ResetControlPanel += new EventHandler(_fractalCalculatorView_ResetControlPanel);
            _fractalCalculatorView.CalculateDimension += new EventHandler(_fractalCalculatorView_CalculateDimension);
            _fractalCalculatorView.ValidatingUI += new Events.ValidatingEventHandler(_fractalCalculatorView_Validating);
            
            InitValidators();
        }

        public IFractalCalculatorView FractalCalculatorView
        {
            get
            {
                return _fractalCalculatorView;
            }
        }

        private void _fractalCalculatorView_ClearPoints(object sender, EventArgs e)
        {
            long pointsToCalculate = long.Parse(_fractalCalculatorView.PointsToCalculate);
            Task task = Task.Factory.StartNew(() =>
            {
                _fractal.Clear();
            });
        }

        public void CalculatePoints()
        {
            long pointsToCalculate = long.Parse(_fractalCalculatorView.PointsToCalculate);           
            Task task = Task.Factory.StartNew(() =>
            {
                _fractalCalculatorView.CalculatingPoints();
                _fractal.CalculatePoints(pointsToCalculate);
                _fractalCalculatorView.CalculatedPoints();
            });
        }

        public void CalculateDimension()
        {
            var UISyncContext = TaskScheduler.FromCurrentSynchronizationContext();
            _fractalCalculatorView.EnableCalculateDimension = false;
            double dim = -1;
            Task task = Task.Factory.StartNew(() =>
            {
                var dimensionCalculator = _dimensionCalculatorFactory.CreateDimensionCalculator(_fractal);
                dim = dimensionCalculator.CalculateDimension();
            }).ContinueWith((previousTask) =>
            {
                if (FractalCalculatorView != null)
                {
                    _fractalCalculatorView.DisplayDimension(dim);
                    _fractalCalculatorView.EnableCalculateDimension = true;
                }
            }, UISyncContext);
        }

        public void ResetControlPanel()
        {
            _controlPanel.Reset();
        }

        private void InitValidators()
        {
            var container = new ValidatorContainer();
            new ValidatorBuilder("PointsToCalculate").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(1, 10000000).AddTo(container);

            _viewValidator = container;
        }

        private void _fractalCalculatorView_Validating(object sender, Events.ValidatingEventArgs e)
        {
            IFractalCalculatorView fractalCalculatorView = sender as IFractalCalculatorView;
            if (fractalCalculatorView == null)
                throw new ApplicationException("fractalCalculatorView == null");
            if (_fractalCalculatorView != fractalCalculatorView)
                throw new ApplicationException("_fractalCalculatorView != fractalCalculatorView");
            _viewValidator.Validate(_fractalCalculatorView);
            if (!_viewValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _viewValidator.ErrorMessage;
                return;
            }
        }

        private void _fractalCalculatorView_CalculatePoints(object sender, EventArgs e)
        {
            CalculatePoints();
        }

        private void _fractalCalculatorView_ResetControlPanel(object sender, EventArgs e)
        {
            ResetControlPanel();
        }

        private void _fractalCalculatorView_CalculateDimension(object sender, EventArgs e)
        {
            CalculateDimension();
        }
    }
}
