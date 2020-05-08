using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public class TransformationBuilder
    {
        private ITransformation _toReturn;

        public TransformationBuilder()
        {
            _toReturn = new DoNothingTransformation();
        }

        public TransformationBuilder Translate(
            float translateX,
            float translateY)
        {
            _toReturn = new Translation(_toReturn, translateX, translateY);
            return this;
        }

        public TransformationBuilder Rotate(
            PointF rotationPoint,
            float rotationAngle
            )
        {
            _toReturn = new Rotation(_toReturn, rotationPoint, rotationAngle);
            return this;
        }

        public TransformationBuilder Zoom(
            PointF zoomPoint,
            float zoomValue)
        {
            _toReturn = new Zoom(_toReturn, zoomPoint, zoomValue);
            return this;
        }

        public TransformationBuilder Scale(float scaleX, float scaleY)
        {
            _toReturn = new Scale(_toReturn, scaleX, scaleY);
            return this;
        }

        public TransformationBuilder Affine(float cell_11, float cell_12,
            float cell_21, float cell_22, float translationX, float translationY)
        {
            _toReturn = new Affine(_toReturn, cell_11, cell_12, 
            cell_21, cell_22, translationX, translationY);
            return this;
        }

        public ITransformation CreateTransformation()
        {
            return _toReturn;
        }

        public static PointF Origin
        {
            get
            {
                return new PointF(0, 0);
            }
        }
    }
}
