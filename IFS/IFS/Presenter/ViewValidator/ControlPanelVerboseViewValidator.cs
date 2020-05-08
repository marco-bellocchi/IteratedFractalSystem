using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using ValidatorsLibrary.Validators;
using System.ComponentModel;
using IFS.View;

namespace IFS.Presenter.ViewValidator
{
    class ControlPanelVerboseViewValidator : ControlPanelViewValidatorBase
    {
        private IValidator _translationXValidator;
        private IValidator _translationYValidator;
        private IValidator _rotationValueValidator;
        private IValidator _zoomValueValidator;
        private IValidator _rotationXValidator;
        private IValidator _rotationYValidator;
        private IValidator _zoomXValidator;
        private IValidator _zoomYValidator;

        public ControlPanelVerboseViewValidator(IControlPanelView controlPanelView) :
            base(controlPanelView)
        {
            InitValidators();
        }

        protected override void InitValidators()
        {
            _translationXValidator = new ValidatorBuilder("XTranslation").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(-1000, 1000).GetValidator();

            _translationYValidator = new ValidatorBuilder("YTranslation").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(-1000, 1000).GetValidator();

            _rotationValueValidator = new ValidatorBuilder("Rotation").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(-360, 360).GetValidator();

            _zoomValueValidator = new ValidatorBuilder("Zoom").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(1, 100000).GetValidator();

            _rotationXValidator = new ValidatorBuilder("RotationPointX").
                CreateTypeValidator<float>(TypeDescriptor.GetConverter(typeof(float))).GetValidator();
            _rotationYValidator = new ValidatorBuilder("RotationPointY").
                CreateTypeValidator<float>(TypeDescriptor.GetConverter(typeof(float))).GetValidator();

            _zoomXValidator = new ValidatorBuilder("ZoomPointX").
                CreateTypeValidator<float>(TypeDescriptor.GetConverter(typeof(float))).GetValidator();

            _zoomYValidator = new ValidatorBuilder("ZoomPointY").
                CreateTypeValidator<float>(TypeDescriptor.GetConverter(typeof(float))).GetValidator();

        }

        protected override void Validating(object sender, Events.ValidatingEventArgs e)
        {
            IControlPanelView controlPanelView = sender as IControlPanelView;
            if (controlPanelView == null)
                throw new ApplicationException("view == null || view != controlPanelView");

            _translationXValidator.Validate(controlPanelView.XTranslation);
            if (!_translationXValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _translationXValidator.ErrorMessage;
                return;
            }
            _translationYValidator.Validate(controlPanelView.YTranslation);
            if (!_translationYValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _translationYValidator.ErrorMessage;
                return;
            }
            this._rotationValueValidator.Validate(controlPanelView.Rotation);
            if (!_rotationValueValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _rotationValueValidator.ErrorMessage;
                return;
            }
            this._rotationXValidator.Validate(controlPanelView.RotationPointX);
            if (!_rotationXValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _rotationXValidator.ErrorMessage;
                return;
            }
            this._rotationYValidator.Validate(controlPanelView.RotationPointY);
            if (!_rotationYValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _rotationYValidator.ErrorMessage;
                return;
            }
            this._zoomValueValidator.Validate(controlPanelView.Zoom);
            if (!_zoomValueValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _zoomValueValidator.ErrorMessage;
                return;
            }
            this._zoomXValidator.Validate(controlPanelView.ZoomPointX);
            if (!_zoomXValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _zoomXValidator.ErrorMessage;
                return;
            }
            this._zoomYValidator.Validate(controlPanelView.ZoomPointY);
            if (!_zoomYValidator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _zoomYValidator.ErrorMessage;
                return;
            }
        }
    }
}
