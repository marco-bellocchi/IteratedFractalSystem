using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FractalLibrary.Events;
using FractalLibrary.Model;
using IFS.Presenter;
using FractalRendererLibrary.Model;
using WeifenLuo.WinFormsUI.Docking;

namespace IFS.View
{
    public delegate void SelectedFractalEventHandler(object sender, FractalEventArgs e);

    public interface IMainView
    {
        event EventHandler Load;

        event SelectedFractalEventHandler SelectedChanged;
        event EventHandler DisplaySierpinsky3DClick;
        event EventHandler DisplayJuliaSetAnimationClick;
        event EventHandler NewDocumentClick;
        event EventHandler OpenDocumentClick;
        event EventHandler SaveDocumentClick;
        event EventHandler SaveAsDocumentClick;
        event EventHandler ExitApplicationClick;
        event EventHandler NewFractalClick;
        event EventHandler OpenFractalClick;
        event EventHandler DisplayGDIClick;
        event EventHandler DisplayOpenGLClick;
        event EventHandler CompositeViewClosed;

        IDictionary<IDockContent, IFractal> DockContentFractalDictionary { get; }

        DockPanel DockPanel { get; }

        ToolStripItem AddMenuItem(string name);

        void ShowMessageBox(string p);

        void ShowDocumentIsDirty();

        void ShowDocumentIsClean();

        bool AskForFilePathToSave(out string filePath);

        bool AskForFilePathToOpen(out string filePath);

        DialogResult AskSaving();

        void ClearAll();

        void Select(IFractal _selected);

        void DisplayRendering(RenderingEnum rendering);



    }
}
