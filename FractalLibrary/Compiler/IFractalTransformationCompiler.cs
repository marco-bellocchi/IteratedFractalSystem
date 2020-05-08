using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransformationsLibrary.Transformation;

namespace FractalLibrary.Transformations
{
    public interface IFractalTransformationCompiler : IFractalTransformationVisitor
    {
        void BeginCompilation();
        List<CompiledTransformation> EndCompilation();
    }
}
