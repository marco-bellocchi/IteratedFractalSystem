using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Transformations
{
    public abstract class FractalTransformationBase : IFractalTransformation
    {
        public event EventHandler Changed;

        public abstract void Accept(IFractalTransformationVisitor visitor);

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
        
    }
}
