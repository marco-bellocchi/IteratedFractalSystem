using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TransformationsLibrary.Transformation;
using FractalLibrary.Transformations;
using FractalLibrary.Exceptions;

namespace FractalLibrary.Model
{
    public abstract class FractalBase : IFractal
    {
        public event EventHandler PointsChanged;
        public event EventHandler TransformationChanged;

        private readonly string _name;
        protected List<IFractalTransformation> _transformations = new List<IFractalTransformation>();
        private List<CompiledTransformation> _compiledTransformations = new List<CompiledTransformation>();
        
        protected PointF _currentPoint;
        protected List<PointF> _points;
        private object _synchPoints = new object();
        private readonly Random _random = new Random();

        protected FractalBase(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("string.IsNullOrEmpty(name)");
            _name = name;
            _points = new List<PointF>();
        }

        public string Name { get { return _name; } }

        public List<System.Drawing.PointF> Points
        {
            get
            {
                lock (_synchPoints)
                {
                    return new List<PointF>(_points);
                }
            }
        }

        public List<IFractalTransformation> Tansformations
        {
            get
            {
                return _transformations;
            }
        }

        public bool IsValid(out string whyNot)
        {
            lock (_synchPoints)
            {
                whyNot = string.Empty;
                if (_transformations.Count == 0)
                    return true;
                try
                {
                    CompileTransformations();
                    return true;
                }
                catch (FractalCompilerException exception)
                {
                    whyNot = exception.Message;
                    return false;
                }
            }
        }

        public void CalculatePoints(long numOfPoints)
        {
            lock (_synchPoints)
            {
                CompileTransformations();
                for (int i = 0; i < numOfPoints; i++)
                {
                    _points.Add(CalculatePoint());
                }
            }
            OnPointsChanged();
        }

        public virtual void Clear()
        {
            ClearPoints();
            OnPointsChanged();
        }

        public virtual void RecalculateAll()
        {
            int numOfPoints = _points.Count;
            ClearPoints();
            CalculatePoints(numOfPoints);
        }

        protected double GetRandomNextDouble()
        {
            return _random.NextDouble();
        }

        protected void ClearPoints()
        {
            lock (_synchPoints)
            {
                _currentPoint = new PointF();
                _points.Clear();
            }
        }

        protected void AddTransformation(IFractalTransformation transformation)
        {
            if (transformation == null)
                throw new ArgumentNullException("transformation == null");
            _transformations.Add(transformation);
            transformation.Changed += (s, e) => OnTransformationChanged();
            OnTransformationChanged();
        }

        protected virtual PointF CalculatePoint()
        {
            double d = GetRandomNextDouble();
            for (int i = 0; i < Tansformations.Count; i++)
            {
                var compiledTransformation = _compiledTransformations[i];
                if (compiledTransformation.IsInRange(d))
                {
                    _currentPoint = compiledTransformation.Transformation.Apply(_currentPoint);
                    break;
                }
            }
            return _currentPoint;
        }

        private void CompileTransformations()
        {
            if (_transformations.Count == 0)
                return;
            IFractalTransformationCompiler compiler = new FractalTransformationCompiler();
            _compiledTransformations.Clear();
            compiler.BeginCompilation();
            foreach (IFractalTransformation fTransformation in _transformations)
            {
                fTransformation.Accept(compiler);
            }
            _compiledTransformations = compiler.EndCompilation();
        }

        protected virtual void OnPointsChanged()
        {
            if (PointsChanged != null)
                PointsChanged(this, EventArgs.Empty);
        }

        protected virtual void OnTransformationChanged()
        {
            if (TransformationChanged != null)
                TransformationChanged(this, EventArgs.Empty);
        }

        public abstract double? ExactDimension { get; }

    }
}
