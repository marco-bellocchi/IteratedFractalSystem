using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ValidatorsLibrary.Validators
{
    public class TypeValidator<T> : ValidatorBase
    {
        private TypeConverter _converter;

        public TypeValidator(string validatingProperty, TypeConverter converter):base(validatingProperty)
        {
            _converter = converter;
        }

        protected override object ValidateInternal(object value)
        {
            IsValid = false;
            T validatedValue = default(T);
            if (!_converter.CanConvertFrom(value.GetType()))
            {
                if (value.GetType() != typeof(T))
                {
                    ErrorMessage = "Expecting a type of " + typeof(T);
                    IsValid = false;
                }
                else
                {
                    validatedValue = (T)value;
                    IsValid = true;
                }
            }
            else if (_converter.IsValid(value))
            {
                validatedValue = (T)_converter.ConvertFrom(value);
                IsValid = true;
            }
            else
            {
                ErrorMessage = "Expecting a type of " + typeof(T);
                IsValid = false;
            }
            return validatedValue;
        }
    }
}
