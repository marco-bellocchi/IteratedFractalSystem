using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Model;

namespace FractalDimensionLibrary
{
    public class BoxDimensionCalculatorFactory : IDimensionCalculatorFactory
    {
        public IDimensionCalculator CreateDimensionCalculator(IFractal fractal)
        {
            return new BoxDimensionCalculator(fractal);
        }
    }
}
