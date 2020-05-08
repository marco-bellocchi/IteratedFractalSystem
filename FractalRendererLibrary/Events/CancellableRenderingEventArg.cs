using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalRendererLibrary.Events
{
    public class CancellableRenderingEventArg
    {
        private bool _cancel;

        public void Cancel()
        {
            _cancel = true;
        }

        public bool IsCancelled()
        {
            return _cancel;
        }

    }
}
