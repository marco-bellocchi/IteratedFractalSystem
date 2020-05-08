using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Model;

namespace FractalLibrary.Events
{
    public class FractalEventArgs : EventArgs
    {
        private readonly IFractal _fractal;

        public FractalEventArgs(IFractal fractal)
        {
            if (fractal == null)
                throw new ArgumentNullException("fractal");
            _fractal = fractal;
        }

        public IFractal Fractal { get { return _fractal; } }
    }
}
