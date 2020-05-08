using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FractalLibrary.Model;
using FractalLibrary.Transformations;

namespace MyPluginFractals.Model
{
    public class BrowniandMotionFractalCreator : IFractalCreator
    {
        private readonly string NAME = "Browniand Motion";

        public string Name
        {
            get { return NAME; }
        }

        public string Description
        {
            get { return ""; }
        }

        public IFractal Create()
        {
            return new BrowniandMotionFractal(NAME);
        }
    }

    class BrowniandMotionFractal: FractalBase
    {
        private float _tau = 0.0000001f;
        private float _sqrtTau;

        public BrowniandMotionFractal(string name):base(name)
        {
            _currentPoint = new PointF(0, 0);
            _points.Add(_currentPoint);
            _sqrtTau = (float)Math.Sqrt(_tau);
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f,
                ScaleY = 1.0f,
                AnticlockWiseRotationAngle = 0,
                TranslationX = _tau,
                TranslationY = _sqrtTau,
                Probability = 0.5
            });
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1f,
                ScaleY = 1f,
                AnticlockWiseRotationAngle = 0,
                TranslationX = _tau,
                TranslationY = -_sqrtTau,
                Probability = .5
            });
        }

        public override void Clear()
        {
            base.Clear();
            _currentPoint = new PointF(0, 0);
            _points.Add(_currentPoint);
        }

        public override double? ExactDimension
        {
            get { return 1.5; }
        }
    }
}
