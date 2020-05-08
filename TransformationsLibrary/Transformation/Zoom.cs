using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TransformationsLibrary.Transformation
{
    public class Zoom : TransformationBase
    {
        private readonly PointF _fixedPoint;
        private readonly float _zoomValue;

        public Zoom(ITransformation transformation,
            PointF fixedPoint, float zoomValue)
            : base(transformation)
        {
            _fixedPoint = fixedPoint;
            _zoomValue = zoomValue;
        }

        public override PointF Apply(PointF pointToZoom)
        {
            pointToZoom = base.Apply(pointToZoom);
            float rotatedX = pointToZoom.X;
            float rotatedY = pointToZoom.Y;
            //Translate to 0,0 firts
            rotatedX -= _fixedPoint.X;
            rotatedY -= _fixedPoint.Y;
            //Apply zoom
            rotatedX = rotatedX * _zoomValue;// +controlPanel.XTranslation;
            rotatedY = rotatedY * _zoomValue; ;//+controlPanel.YTranslation;
            //retranslate
            rotatedX += _fixedPoint.X;
            rotatedY += _fixedPoint.Y;
            return new PointF(rotatedX, rotatedY);
        }
    }
}
