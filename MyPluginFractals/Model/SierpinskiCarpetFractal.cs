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
    public class SierpinskiCarpetFractalCreator : IFractalCreator
    {
        private readonly string NAME = "Sierpinski Carpet";

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
            return new SierpinskiCarpetFractal(NAME);
        }
    }

    class SierpinskiCarpetFractal : FractalBase
    {

        public SierpinskiCarpetFractal(string name)
            : base(name)
        {
            _currentPoint = new PointF(1, 1);
            _points.Add(_currentPoint);
            
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                Probability = 1.0/8.0
            });
            //_t1 = new TransformationBuilder().
            //    Zoom(new PointF(0, 0), 1.0f / 3.0f).
            //    CreateTransformation();
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                TranslationX = 1.0f / 3.0f,
                Probability = 1.0 / 8.0
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                TranslationX = 2.0f / 3.0f,
                Probability = 1.0 / 8.0
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                TranslationY = 1.0f / 3.0f,
                Probability = 1.0 / 8.0
            });
           
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                TranslationY = 2.0f / 3.0f,
                Probability = 1.0 / 8.0
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                TranslationX = 1.0f / 3.0f,
                TranslationY = 2.0f / 3.0f,
                Probability = 1.0 / 8.0
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                TranslationX = 2.0f / 3.0f,
                TranslationY = 2.0f / 3.0f,
                Probability = 1.0 / 8.0
            });

            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                TranslationX = 2.0f / 3.0f,
                TranslationY = 1.0f / 3.0f,
                Probability = 1.0 / 8.0
            });
        }

        public override double? ExactDimension
        {
            get { return Math.Log(8) / Math.Log(3); }
        }
    }
}
