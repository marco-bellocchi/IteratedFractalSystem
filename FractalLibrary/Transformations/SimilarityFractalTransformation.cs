using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Transformations
{
    //TODO add preconditions for all property setters
    public class SimilarityFractalTransformation : FractalTransformationBase
    {
        private float _scaleX;
        private float _scaleY;
        private float _anticlockWiseRotationAngle;
        private float _translateX;
        private float _translateY;
        private double _probability;

        public float ScaleX { get { return _scaleX; } set { _scaleX = value; OnChanged(); } }
        public float ScaleY { get { return _scaleY; } set { _scaleY = value; OnChanged(); } }
        public float AnticlockWiseRotationAngle { get { return _anticlockWiseRotationAngle; } set { _anticlockWiseRotationAngle = value; OnChanged(); } }
        public float TranslationX { get { return _translateX; } set { _translateX = value; OnChanged(); } }
        public float TranslationY { get { return _translateY; } set { _translateY = value; OnChanged(); } }
        public double Probability { get { return _probability; } set { _probability = value; OnChanged(); } }

        public override void Accept(IFractalTransformationVisitor compiler)
        {
            compiler.Visit(this);
        }
    }
}
