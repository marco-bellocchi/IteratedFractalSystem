using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Exceptions
{
    [Serializable]
    public class FractalCompilerException: Exception
    {
        public FractalCompilerException()
        {
        }

        public FractalCompilerException(string msg)
            : base(msg)
        {
        }
    }
}
