using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Transformations
{

    public class AffineFractalTransformation : FractalTransformationBase
    {
        private float _cell_11;
        private float _cell_12;
        private float _cell_21;
        private float _cell_22;
        private float _translationX;
        private float _translationY;
        private double _probability;

        public float Cell_11 { get { return _cell_11; } set { _cell_11 = value; OnChanged(); } }
        public float Cell_12 { get { return _cell_12; } set { _cell_12 = value; OnChanged(); } }
        public float Cell_21 { get { return _cell_21; } set { _cell_21 = value; OnChanged(); } }
        public float Cell_22 { get { return _cell_22; } set { _cell_22 = value; OnChanged(); } }
        public float TranslationX { get { return _translationX; } set { _translationX = value; OnChanged(); } }
        public float TranslationY { get { return _translationY; } set { _translationY = value; OnChanged(); } }
        public double Probability { get { return _probability; } set { _probability = value; OnChanged(); } }

        public override void Accept(IFractalTransformationVisitor compiler)
        {
            compiler.Visit(this);
        }
    }
}
