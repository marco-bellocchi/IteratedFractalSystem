using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Model
{
    public interface IFractalCreator
    {
        string Name { get; }
        string Description { get; }
        IFractal Create();
        //Guid UniqueId { get; }
    }
}
