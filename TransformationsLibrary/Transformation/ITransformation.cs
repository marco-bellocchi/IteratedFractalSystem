using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public interface ITransformation
    {
        PointF Apply(PointF toTransform); 
    }
}
