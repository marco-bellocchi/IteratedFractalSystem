using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IFS.Presenter;
using IFS.View.Helpers;

namespace IFS.View
{
    public partial class FractalCompilerView : Form, IFractalCompilerView
    {
        private FractalCompilerViewPresenter _presenter;
        //private XmlEditor _xmlEditor;

        public FractalCompilerView()
        {
            InitializeComponent();
        }

        public FractalCompilerViewPresenter FractalCompilerViewPresenter
        {
            get
            {
                return _presenter;
            }
            set
            {
                _presenter = value;
            }
        }

        public string XmlFractal
        {
            get
            {
                return  _xmlEditor.Text;
            }
            set
            {
                _xmlEditor.Text = value;
                _xmlEditor.Refresh();
            }
        }

        private void _createBt_Click(object sender, EventArgs e)
        {
            string whyNot;
            bool ok = FractalCompilerViewPresenter.AddFractalToDocument(out whyNot);
            if (!ok)
                MessageBox.Show(whyNot);
            else
                Close();
        }

        private void _saveBt_Click(object sender, EventArgs e)
        {
            FractalCompilerViewPresenter.SaveAs();
        }

        public bool AskForFilePathToOpen(out string filePath)
        {
            return FileDialogHelper.AskForFilePathToOpen(out filePath);

        }

        public bool AskForFilePathToSave(out string filePath)
        {
            return FileDialogHelper.AskForFilePathToSave(out filePath);
        }
    }
}
