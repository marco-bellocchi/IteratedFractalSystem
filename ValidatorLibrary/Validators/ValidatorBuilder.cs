using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ValidatorsLibrary.Validators
{
    public class ValidatorBuilder
    {
        private IValidator _head;
        private IValidator _current;

        public ValidatorBuilder(string validatingProperty)
        {
            if (string.IsNullOrEmpty(validatingProperty))
                throw new ArgumentException("string.IsNullOrEmpty(validatingProperty)");
            ValidatingProperty = validatingProperty;
        }

        private string ValidatingProperty { get; set; }

        public ValidatorBuilder CreateTypeValidator<T>(TypeConverter converter)
        {
            TypeValidator<T> validator = new TypeValidator<T>(ValidatingProperty, converter);
            UpdateSuccessor(validator);
            return this;
        }

        public ValidatorBuilder CreateRangeValidator<T>(T from, T to) where T : IComparable
        {
            RangeValidator<T> validator = new RangeValidator<T>(ValidatingProperty, from, to);
            UpdateSuccessor(validator);
            return this;
        }

        public IValidator GetValidator()
        {
            return _head;
        }

        public void AddTo(ValidatorContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            container.AddValidator(GetValidator());
        }

        private void UpdateSuccessor(IValidator successor)
        {
            if(_head == null)
                _head = successor;
            if (_current != null)
                _current.Successor = successor;
            _current = successor;
        }
    }
}
