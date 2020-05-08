using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransformationsLibrary.Transformation;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public class Scale : TransformationBase
    {
        private readonly float _scaleX;
        private readonly float _scaleY;

        public Scale(ITransformation transformation, float scaleX, float scaleY):base(transformation)
        {
            _scaleX = scaleX;
            _scaleY = scaleY;
        }

        public override PointF Apply(PointF pointToScale)
        {
            pointToScale = base.Apply(pointToScale);
            float scaleX = pointToScale.X * _scaleX;
            float scaleY = pointToScale.Y * _scaleY;
            return new PointF(scaleX, scaleY);
        }
    }
}
