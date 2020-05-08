using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidatorsLibrary.Validators
{
    public abstract class ValidatorBase : IValidator
    {
        protected ValidatorBase(string validatingProperty)
        {
            if (string.IsNullOrEmpty(validatingProperty))
                throw new ArgumentNullException("string.IsNullOrEmpty(validatingProperty)");
            ValidatingProperty = validatingProperty;
        }

        public string ErrorMessage
        {
            get;
            protected set;
        }

        public string ValidatingProperty { get; private set; }

        public IValidator Successor { get; set; }

        public bool IsValid
        {
            get;
            protected set;
        }

        public void Validate(object value)
        {
            object transformedValue = ValidateInternal(value);
            if (IsValid && Successor != null)
            {
                Successor.Validate(transformedValue);
                IsValid = Successor.IsValid;
                ErrorMessage = Successor.ErrorMessage;
            }
        }

        protected abstract object ValidateInternal(object value);
    }
}
