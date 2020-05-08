using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IFS.Events
{
    public delegate void ValidatingEventHandler(object sender, ValidatingEventArgs e);

    public class ValidatingEventArgs : CancelEventArgs
    {

        public ValidatingEventArgs()
            : base()
        {
            //ValidatingField = validatingField;
        }

        public ValidatingEventArgs(bool cancelled):base(cancelled)
        {
            //ValidatingField = validatingField;
        }

        //public string ValidatingField { get; private set; }

        public string ValidationMessage { get; set; }
    }
}
