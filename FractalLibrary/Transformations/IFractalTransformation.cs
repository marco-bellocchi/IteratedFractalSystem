using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Transformations
{
    public interface IFractalTransformation
    {
        event EventHandler Changed;
        void Accept(IFractalTransformationVisitor visitor);
    }
}
