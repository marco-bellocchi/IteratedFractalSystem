using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public class Rotation : TransformationBase
    {
        private readonly PointF _rotationPoint;
        private readonly float _angle;

        public Rotation(ITransformation transformation,
            PointF rotationPoint, float angle)
            : base(transformation)
        {
            _rotationPoint = rotationPoint;
            _angle = angle;
        }

        public override PointF Apply(PointF pointToRotate)
        {
            pointToRotate = base.Apply(pointToRotate);
            //Before rotating, translate to (0,0) based on rotation point
            float x = pointToRotate.X - _rotationPoint.X;
            float y = pointToRotate.Y - _rotationPoint.Y;
            //Rotate
            float rotatedX = x *
                (float)Math.Cos(_angle * Math.PI / 180.0) -
                y *
                (float)Math.Sin(_angle * Math.PI / 180.0);
            float rotatedY = x *
                (float)Math.Sin(_angle * Math.PI / 180.0)
                + y *
                (float)Math.Cos(_angle * Math.PI / 180.0);
            //Re translate
            rotatedX += _rotationPoint.X;
            rotatedY += _rotationPoint.Y;
            return new PointF(rotatedX, rotatedY);
        }
    }
}
