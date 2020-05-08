using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using IFS.View;

namespace IFS.Presenter.ViewValidator
{
    public abstract class ControlPanelViewValidatorBase
    {
        private IControlPanelView _controlPanelView;

        protected ControlPanelViewValidatorBase(IControlPanelView controlPanelView)
        {
            if(controlPanelView == null)
                throw new ArgumentNullException("controlPanelView");
            _controlPanelView = controlPanelView;
            InitValidators();
            _controlPanelView.ValidatingUI += new Events.ValidatingEventHandler(Validating);
        }

        public IControlPanelView ControlPanelView
        {
            get
            {
                return _controlPanelView;
            }
            set
            {
                _controlPanelView = value;
            }
        }

        protected abstract void InitValidators();

        protected abstract void Validating(object sender, Events.ValidatingEventArgs e);

    }
}
