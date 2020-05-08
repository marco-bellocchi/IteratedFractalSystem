using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ValidatorsLibrary.Validators
{
    public interface IValidator
    {
        string ErrorMessage{get;}
        string ValidatingProperty { get; }//For dynamic binding 
        IValidator Successor { get; set; }//Chain of Responsability
        bool IsValid{get;}
        void Validate(object value);
    }
}
