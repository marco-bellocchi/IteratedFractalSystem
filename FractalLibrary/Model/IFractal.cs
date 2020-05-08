/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 31/07/2014
 * Time: 22:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using TransformationsLibrary.Transformation;
using FractalLibrary.Transformations;

namespace FractalLibrary.Model
{
	public interface IFractal
	{
		event EventHandler PointsChanged;
        event EventHandler TransformationChanged;

		string Name {get;}
		List<PointF> Points{get;}
        List<IFractalTransformation> Tansformations { get; }
        bool IsValid(out string whyNot);
		void CalculatePoints(long numOfPoints);
		void Clear();
        void RecalculateAll();
        double? ExactDimension { get; }
    }
}
