using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.Events;
using IFS.Events;

namespace IFS.View
{
    public interface IView
    {
        event EventHandler ChangedUI;
        event ValidatingEventHandler ValidatingUI;
    }
}
