using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FractalLibrary.Events;
using FractalLibrary.Model;
using IFS.Presenter;
using FractalRendererLibrary.Model;

namespace IFS.View
{
    public delegate void SelectedFractalEventHandler(object sender, FractalEventArgs e);

    public interface IMainView
    {
        event EventHandler Load;

        event SelectedFractalEventHandler SelectedChanged;

        void AddPredefinedFractalMenu(IFractalCreator creator);

        void ShowMessageBox(string p);

        void ShowDocumentIsDirty();

        void ShowDocumentIsClean();

        bool AskForFilePathToSave(out string filePath);

        bool AskForFilePathToOpen(out string filePath);

        DialogResult AskSaving();

        void ShowFractal(FractalLibrary.Model.IFractal fractal, IControlPanel controlPanel);

        void ClearAll();

        void Select(IFractal _selected);

        void DisplayRendering(RenderingEnum rendering);

    }
}
