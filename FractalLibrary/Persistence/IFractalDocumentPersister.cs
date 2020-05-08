using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Model;
using FractalLibrary.Model.Application;

namespace FractalLibrary.Persistence
{
    public interface IFractalDocumentPersister
    {
        void Save(FractalDocument document);
        List<IFractal> Load();
    }
}
