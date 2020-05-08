using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidatorsLibrary.Validators;
using System.ComponentModel;
using FractalRendererLibrary.View;
using IFS.View;

namespace IFS.Presenter.ViewValidator
{
    class ControlPanelSlimViewValidator : ControlPanelViewValidatorBase
    {
        private IValidator _validator;

        public ControlPanelSlimViewValidator(IControlPanelView controlPanelView):
            base(controlPanelView)
        {
            InitValidators();
        }

        protected override void InitValidators()
        {
            ValidatorContainer container = new ValidatorContainer();
            _validator = container;
            /*_translationXValidator = */
            new ValidatorBuilder("XTranslation").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(-10000, 10000).AddTo(container);

            /*_translationYValidator = */
            new ValidatorBuilder("YTranslation").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(-10000, 10000).AddTo(container);

            /*_rotationValueValidator = */
            new ValidatorBuilder("Rotation").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(-360, 360).AddTo(container);

            /*_zoomValueValidator = */
            new ValidatorBuilder("Zoom").
                CreateTypeValidator<int>(TypeDescriptor.GetConverter(typeof(int))).
                CreateRangeValidator<int>(1, 1000000).AddTo(container);

            /*_rotationXValidator = */
            new ValidatorBuilder("RotationPointX").
                CreateTypeValidator<float>(TypeDescriptor.GetConverter(typeof(float))).AddTo(container);

            /*  _rotationYValidator = */
            new ValidatorBuilder("RotationPointY").
                CreateTypeValidator<float>(TypeDescriptor.GetConverter(typeof(float))).AddTo(container);

            /*_zoomXValidator = */
            new ValidatorBuilder("ZoomPointX").
                CreateTypeValidator<float>(TypeDescriptor.GetConverter(typeof(float))).AddTo(container);

            /*_zoomYValidator = */
            new ValidatorBuilder("ZoomPointY").
                CreateTypeValidator<float>(TypeDescriptor.GetConverter(typeof(float))).AddTo(container);

        }

        protected override void Validating(object sender, Events.ValidatingEventArgs e)
        {
            IControlPanelView view = sender as IControlPanelView;
            if (view == null)
                throw new ApplicationException("view == null");

            _validator.Validate(view);
            if (!_validator.IsValid)
            {
                e.Cancel = true;
                e.ValidationMessage = _validator.ErrorMessage;
            }
        }
    }
}
