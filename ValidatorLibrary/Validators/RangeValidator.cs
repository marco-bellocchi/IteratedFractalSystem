using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidatorsLibrary.Validators
{
    public class RangeValidator<T> : ValidatorBase where T : IComparable
    {
        private T _from;
        private T _to;

        public RangeValidator(string validatingProperty, T from, T to):base(validatingProperty)
        {
            _from = from;
            _to = to;
        }

        protected override object ValidateInternal(object value)
        {
            IsValid = false;
            T val = (T)value;
            if (_from.CompareTo(val) == 1 ||
                _to.CompareTo(val) == -1)
            {
                IsValid = false;
                ErrorMessage =
                    string.Format("The number should be between {0} and {1}!", _from, _to);
            }
            else
                IsValid = true;
            return val;
        }
    }
}
