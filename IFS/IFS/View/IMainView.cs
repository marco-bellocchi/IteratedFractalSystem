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
        event EventHandler TrackBarsControlMenuItemClick;
        event EventHandler NumbersControlMenuItemClick;
        event EventHandler FractalEditorMenuItemClick;
        event EventHandler FractalDataGridMenuItemClick;

        IDictionary<IDockContent, IFractal> DockContentFractalDictionary { get; }

        DockPanel DockPanel { get; }

        DockContent NumberDockContent { get; set; }
        DockContent TrackBarsDockContent { get; set; }
        DockContent DataGridDockContent { get; set; }
        DockContent EditorDockContent { get; set; }

        ToolStripItem AddMenuItem(string name);
        ToolStripMenuItem GdiToolStripMenuItem { get; }
        ToolStripMenuItem OpenGlToolStripMenuItem { get; }

        void ShowMessageBox(string p);

        void ShowDocumentIsDirty();

        void ShowDocumentIsClean();

        bool AskForFilePathToSave(out string filePath);

        bool AskForFilePathToOpen(out string filePath);

        DialogResult AskSaving();

    }
}
