using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFS.View
{
    public interface IFractalCompilerView
    {
        string XmlFractal { get; set; }

        bool AskForFilePathToOpen(out string filePath);
        bool AskForFilePathToSave(out string filePath);
    }
}
