using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public class Affine : TransformationBase
    {
        private float _cell_11;
        private float _cell_12;
        private float _cell_21;
        private float _cell_22;
        private float _translationX;
        private float _translationY;

        public Affine(ITransformation transformation, float cell_11, float cell_12, 
            float cell_21, float cell_22, float translationX, float translationY)
            : base(transformation)
        {
            _cell_11 = cell_11;
            _cell_12 = cell_12;
            _cell_21 = cell_21;
            _cell_22 = cell_22;
            _translationX = translationX;
            _translationY = translationY;
        }

        public override PointF Apply(PointF startingPoint)
        {
            startingPoint = base.Apply(startingPoint);
            float x = startingPoint.X * _cell_11 + startingPoint.Y * _cell_12 + _translationX;
            float y = startingPoint.X * _cell_21 + startingPoint.Y * _cell_22 + _translationY;
            return new PointF(x, y);
        }
    }
}
