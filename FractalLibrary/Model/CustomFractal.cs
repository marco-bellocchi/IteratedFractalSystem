using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Transformations;

namespace FractalLibrary.Model
{
    public class CustomFractal: FractalBase
    {
        public CustomFractal(string name, 
            List<IFractalTransformation> fractalTransformations): base(name)
        {
            if (fractalTransformations == null || fractalTransformations.Count == 0)
                throw new ArgumentException("fractalTransformations == null || fractalTransformations.Count == 0");
            foreach (var transformation in fractalTransformations)
                AddTransformation(transformation);
        }

        public override double? ExactDimension
        {
            get { return null; }
        }
    }
}
