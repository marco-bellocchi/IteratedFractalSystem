using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Model
{
    public interface IDimensionCalculatorFactory
    {
        IDimensionCalculator CreateDimensionCalculator(IFractal fractal);
    }
}
