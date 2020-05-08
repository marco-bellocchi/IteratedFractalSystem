using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;

namespace IFS.View
{
    public interface IFractalCompositeView
    {
        IControlPanelView TrackBarContorlPanelView { get; }
        IControlPanelView NumbersControlPanelView { get; }
        IFractalView FractalView { get; set; }
        IFractalCalculatorView FractalCalculatorView { get; }
        IFractalDataGridView FractalDataGridView { get; }
        IFractalEditorView FractalEditorView { get; }
    }
}
