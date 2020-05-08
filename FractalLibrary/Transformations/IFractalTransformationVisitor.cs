using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Transformations
{
    public interface IFractalTransformationVisitor
    {
        void Visit(AffineFractalTransformation t);
        void Visit(SimilarityFractalTransformation t);
    }
}
