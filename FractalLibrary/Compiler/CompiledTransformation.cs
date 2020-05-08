using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransformationsLibrary.Transformation;

namespace FractalLibrary.Transformations
{
    public class CompiledTransformation
    {
        private readonly double _from;
        private readonly double _to;
        private readonly ITransformation _transformation;

        internal CompiledTransformation(double from, double to, ITransformation transformation)
        {
            _from = from;
            _to = to;
            _transformation = transformation;
        }

        internal ITransformation Transformation { get { return _transformation; } }

        internal bool IsInRange(double value)
        {
            return value >= _from && value < _to;
        }
    }
}
