using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Events
{
    public delegate void FractalAddedEventHandler(object sender, FractalEventArgs e);
    public delegate void FractalRemovedEventHandler(object sender, FractalEventArgs e);
    public delegate void FractalTransformationChangedEventHandler(object sender, FractalEventArgs e);
}
