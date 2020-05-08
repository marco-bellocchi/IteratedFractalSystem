using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FractalLibrary.Model;
using FractalLibrary.Transformations;

namespace MyPluginFractals.Model
{
    public class CantorDustFractalCreator : IFractalCreator
    {
        private readonly string NAME = "Cantor Dust";

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
            return new CantorDustFractal(NAME);
        }
    }

    class CantorDustFractal : FractalBase
    {
        public CantorDustFractal(string name)
            :base(name)
		{
			_currentPoint = new PointF(0,0);
			_points.Add(_currentPoint);
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 4.0f,
                ScaleY = 1.0f / 4.0f,
                AnticlockWiseRotationAngle = 0,
                TranslationX = 0,
                TranslationY = 0.5f,
                Probability = 0.25
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 4.0f,
                ScaleY = 1.0f / 4.0f,
                AnticlockWiseRotationAngle = 0,
                TranslationX = 0.25f,
                TranslationY = 0,
                Probability = 0.25
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 4.0f,
                ScaleY = 1.0f / 4.0f,
                AnticlockWiseRotationAngle = 0,
                TranslationX = 0.5f,
                TranslationY = 0.75f,
                Probability = 0.25
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 4.0f,
                ScaleY = 1.0f / 4.0f,
                AnticlockWiseRotationAngle = 0,
                TranslationX = 0.75f,
                TranslationY = 0.25f,
                Probability = 0.25
            });
		}

        public override double? ExactDimension
        {
            get { return Math.Log(4) / Math.Log(3); }
        }
    }
}
