using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public class DoNothingTransformation : ITransformation
    {
        public PointF Apply(PointF toTransform)
        {
            return new PointF(toTransform.X, toTransform.Y);
        }
    }
}
