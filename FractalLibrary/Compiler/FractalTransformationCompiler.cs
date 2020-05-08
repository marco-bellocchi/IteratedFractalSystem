using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransformationsLibrary.Transformation;
using FractalLibrary.Exceptions;

namespace FractalLibrary.Transformations
{
    public sealed class FractalTransformationCompiler : IFractalTransformationCompiler
    {
        private double _rightEndPoint = 0;
        private double _leftEndPoint = 0;
        private bool _isCompiling;
        private List<CompiledTransformation> _compiledTransformations = new List<CompiledTransformation>();
       
        public void BeginCompilation()
        {
            _compiledTransformations.Clear();
            _rightEndPoint = 0;
            _leftEndPoint = 0;
            _isCompiling = true;
        }

        public List<CompiledTransformation> EndCompilation()
        {
            if (!_isCompiling)
                throw new FractalCompilerException("BeginCompilation has not been called");
            _isCompiling = false;
            if (_rightEndPoint < .9998 || _rightEndPoint > 1.0001)
            {
                throw new FractalCompilerException("Compilation failed because probability of the transformations does not sum to 1 but to " + _rightEndPoint);
            }
            return _compiledTransformations;
        }

        public void Visit(SimilarityFractalTransformation fractalTransformation)
        {
            if (!_isCompiling)
                throw new FractalCompilerException("BeginCompilation has not been called");
            _leftEndPoint = _rightEndPoint;
            _rightEndPoint += fractalTransformation.Probability;
            TransformationBuilder transformationBuilder = new TransformationBuilder();
            ITransformation transformation = transformationBuilder.
                Scale(fractalTransformation.ScaleX, fractalTransformation.ScaleY).
                Rotate(TransformationBuilder.Origin, fractalTransformation.AnticlockWiseRotationAngle).
                Translate(fractalTransformation.TranslationX, fractalTransformation.TranslationY).
                CreateTransformation();
            _compiledTransformations.Add(new CompiledTransformation(_leftEndPoint, _rightEndPoint, transformation)); 
        }

        public void Visit(AffineFractalTransformation fractalTransformation)
        {
            _leftEndPoint = _rightEndPoint;
            _rightEndPoint += fractalTransformation.Probability;
               TransformationBuilder transformationBuilder = new TransformationBuilder();
               ITransformation transformation = transformationBuilder.Affine(fractalTransformation.Cell_11,
                   fractalTransformation.Cell_12, fractalTransformation.Cell_21, fractalTransformation.Cell_22, fractalTransformation.TranslationX,
                   fractalTransformation.TranslationY).CreateTransformation();
               _compiledTransformations.Add(new CompiledTransformation(_leftEndPoint, _rightEndPoint, transformation)); 
        }
       
    }
}
