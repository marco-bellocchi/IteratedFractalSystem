using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FractalLibrary.Model;
using TransformationsLibrary.Transformation;
using FractalLibrary.Transformations;

namespace MyPluginFractals.Model
{
    public class VonKochCurveFractalCreator : IFractalCreator
    {
        private readonly string NAME = "Von Koch Curve";

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
            return new VonKochCurveFractal(NAME);
        }
    }

    class VonKochCurveFractal : FractalBase
    {
        public VonKochCurveFractal(string name)
            : base(name)
        {
            _currentPoint = new PointF(0, 0);
            _points.Add(_currentPoint);

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX =1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                AnticlockWiseRotationAngle = 60,
                TranslationX =1.0f / 3.0f,
                TranslationY = 0,
                Probability = 0.25
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                AnticlockWiseRotationAngle = -60,
                TranslationX = 1.0f / 2.0f,
                TranslationY = (float)Math.Sqrt(1.0 / 9.0 - 1.0 / 36.0),
                Probability = 0.25
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                AnticlockWiseRotationAngle = 0,
                TranslationX = 0,
                TranslationY = 0,
                Probability = 0.25
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                AnticlockWiseRotationAngle = 0,
                TranslationX = 2.0f / 3.0f,
                TranslationY = 0,
                Probability = 0.25
            });
        }

        public override double? ExactDimension
        {
            get { return Math.Log(4) / Math.Log(3); }
        }
    }
}
