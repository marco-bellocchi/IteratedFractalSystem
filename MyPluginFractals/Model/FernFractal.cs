/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 31/07/2014
 * Time: 23:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using FractalLibrary.Model;
using FractalLibrary.Transformations;

namespace MyPluginFractals.Model
{
    public class FernFractalCreator : IFractalCreator
    {
        private readonly string NAME = "Fern";

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
            return new FarnFractal(NAME);
        }
    }
	/// <summary>
	/// Description of FarnFractal.
	/// </summary>
    class FarnFractal : FractalBase
	{
		#region IFractal implementation

        public FarnFractal(string name)
            : base(name)
		{
			_currentPoint = new PointF(0,0);
			_points.Add(_currentPoint);
            AddTransformation(new AffineFractalTransformation
            {
                Cell_11 = 0,
                Cell_21 = 0,
                Cell_12 = 0,
                Cell_22 = 0.16f,
                TranslationX = 0,
                TranslationY = 0,
                Probability = 0.01
            });
            AddTransformation(new AffineFractalTransformation
            {
                Cell_11 = 0.85f,
                Cell_21 = -0.04f,
                Cell_12 = 0.04f,
                Cell_22 = 0.85f,
                TranslationX = 0,
                TranslationY = 1.60f,
                Probability = 0.85
            });
            AddTransformation(new AffineFractalTransformation
            {
                Cell_11 = 0.20f,
                Cell_21 = 0.23f,
                Cell_12 = -0.26f,
                Cell_22 = 0.22f,
                TranslationX = 0,
                TranslationY = 1.60f,
                Probability = 0.07
            });
            AddTransformation(new AffineFractalTransformation
            {
                Cell_11 = -0.15f,
                Cell_21 = 0.26f,
                Cell_12 = 0.28f,
                Cell_22 = 0.24f,
                TranslationX = 0,
                TranslationY = 0.44f,
                Probability = 0.07
            });
		}

        public override double? ExactDimension
        {
            get { return null; }
        }

		#endregion
	}
}
