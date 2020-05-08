using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FractalLibrary.Model;
using FractalLibrary.Transformations;

namespace MyPluginFractals.Model
{
    public class CantorFractalCreator : IFractalCreator
    {
        private readonly string NAME = "Middle Cantor Set";

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
            return new CantorFractal(NAME);
        }
    }

    class CantorFractal: FractalBase
    {
         public CantorFractal(string name)
            :base(name)
		{
			_currentPoint = new PointF(0,0);
			_points.Add(_currentPoint);
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                Probability = 0.5
            });
            AddTransformation(new SimilarityFractalTransformation
            {
                ScaleX = 1.0f / 3.0f,
                ScaleY = 1.0f / 3.0f,
                TranslationX = 2.0f/3.0f,
                Probability = 0.5
            });
		}

        public override double? ExactDimension
        {
            get { return Math.Log(2) / Math.Log(3); }
        }
    }
}
