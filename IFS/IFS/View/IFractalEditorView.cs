using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IFS.Presenter;
using System.Windows.Forms;

namespace IFS.View
{
    public interface IFractalEditorView
    {
        event EventHandler Apply;

        void AddTransformation(string name, object transformation);

        void ClearTransformations();

        void ShowErrorMessage(string whyNot);

        bool IsAppliedImmediatelyChecked { get; }

        UserControl UserControl { get;  }
    }
}
