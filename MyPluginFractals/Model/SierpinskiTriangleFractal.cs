using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FractalLibrary.Model;
using FractalLibrary.Transformations;

namespace MyPluginFractals.Model
{
    public class SierpinskiTriangleFractalCreator : IFractalCreator
    {
        private readonly string NAME = "Sierpinski Triangle";

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
            return new SierpinskiTriangleFractal(NAME);
        }
    }

    class SierpinskiTriangleFractal : FractalBase
    {
        public SierpinskiTriangleFractal(string name)
            : base(name)
		{
			_currentPoint = new PointF(0,0);
			_points.Add(_currentPoint);
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 2.0f,
                ScaleY = 1.0f / 2.0f,
                Probability = 1.0 / 3.0
            });
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 2.0f,
                ScaleY = 1.0f / 2.0f,
                TranslationX = 0.5f,
                Probability = 1.0 / 3.0
            });
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 2.0f,
                ScaleY = 1.0f / 2.0f,
                TranslationX = .25f,
                TranslationY = (float)Math.Sqrt(3) / 4.0f,
                Probability = 1.0 / 3.0
            });
		}

        public override double? ExactDimension
        {
            get { return Math.Log(3) / Math.Log(2); }
        }
    }
}
