using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FractalLibrary.Model;
using System.Collections;

namespace FractalDimensionLibrary
{
    public class BoxDimensionCalculator : IDimensionCalculator
    {
        private readonly float _delta;
        private readonly IFractal _fractal;

        public BoxDimensionCalculator(IFractal fractal):this(fractal, 0.00015f)
        {
            
        }

        public BoxDimensionCalculator(IFractal fractal, float delta)
        {
            if (fractal == null)
                throw new ArgumentNullException("fractal == null");
            _fractal = fractal;
            _delta = delta;
        }

        public double CalculateDimension()
        {
            //float delta = 0.00015f;//(1.0f / (float)Math.Sqrt((double)fractal.NumOfPoints))/5.0f;
            return CalculateDimension(_fractal, _delta);
        }

        public double CalculateDimension(IFractal fractal, float delta)
        {
            if (fractal == null)
                throw new ArgumentNullException("fractal == null");
            List<PointF> points = fractal.Points;
            double numOfDeltaMeshCubes = (double)GetNumOfDeltaMeshCubesIntersectingFractal(points, delta);
            return Math.Log(numOfDeltaMeshCubes) / (-1 * Math.Log((double)delta));
        }

        private static long f(long x)
        {
            return x >= 0 ? 2 * x : (-2 * x) + 1;    
        }

        private static long f_inverse(long x)
        {
            return x >= 0 ? x/2: (1-x)/2;
        }

        private static long phi(long x, long y)
        {
            return (((x + y + 1) * (x + y)) / 2) + x;
        }

        private long GetNumOfDeltaMeshCubesIntersectingFractal(List<PointF> points, float delta)
        {
            HashSet<long> discretePoints = new HashSet<long>();
            foreach (var point in points)
            {
                long x = (long)Math.Round(point.X / delta, 0);
                long y = (long)Math.Round(point.Y / delta, 0);
                long unique = f_inverse(phi(f(x), f(y)));
                if (!discretePoints.Contains(unique))
                    discretePoints.Add(unique);
            }
            return discretePoints.Count;
        }
    }
}
