using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ValidatorsLibrary.Validators
{
    public class ValidatorContainer: IValidator
    {
        private readonly List<IValidator> _validators = new List<IValidator>();

        public string ErrorMessage
        {
            get;
            private set;
        }

        public string ValidatingProperty { get; private set; }

        public IValidator Successor { get; set; }

        public bool IsValid
        {
            get;
            protected set;
        }
        public void AddValidator(IValidator validator)
        {
            if (validator == null)
                throw new ArgumentNullException("validator");
            _validators.Add(validator);
        }

        public void Validate(object value)
        {
            IsValid = false;
            foreach (var validator in _validators)
            {
                PropertyInfo pi = value.GetType().GetProperty(validator.ValidatingProperty);
                if(pi == null)
                    throw new ApplicationException("pi == null");
                if(!pi.CanRead)
                    throw new ApplicationException("!pi.CanRead");
                object propertyValue = pi.GetValue(value, null);
                if (propertyValue == null)
                    throw new ApplicationException("Trying to validate");
                validator.Validate(propertyValue);
                if (!validator.IsValid)
                {
                    IsValid = false;
                    ErrorMessage = validator.ErrorMessage;
                    return;
                }
            }
            IsValid = true;
        }
    }
}
