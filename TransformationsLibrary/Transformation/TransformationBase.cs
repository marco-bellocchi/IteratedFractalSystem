using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public abstract class TransformationBase : ITransformation
    {
        protected readonly ITransformation _transformation;

        protected TransformationBase(ITransformation transformation)
        {
            if (transformation == null)
                throw new ArgumentNullException("transformation");
            _transformation = transformation;
        }

        public virtual PointF Apply(PointF point)
        {
            return _transformation.Apply(point);
        }
    }

   
}
