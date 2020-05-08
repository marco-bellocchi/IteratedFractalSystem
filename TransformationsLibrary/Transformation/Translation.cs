using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public class Translation : TransformationBase
    {
        private readonly float _xTranslation;
        private readonly float _yTranslation;

        public Translation(ITransformation transformation,
            float xTranslation, float yTranslation)
            : base(transformation)
        {
            _xTranslation = xTranslation;
            _yTranslation = yTranslation;
        }

        public override PointF Apply(PointF pointToTranslate)
        {
            pointToTranslate = base.Apply(pointToTranslate);
            float x = pointToTranslate.X + _xTranslation;
            float y = pointToTranslate.Y + _yTranslation;
            return new PointF(x, y);
        }
    }

}
