/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 29/07/2014
 * Time: 22:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FractalRendererLibrary.Renderer;
using System.Text;
using FractalRendererLibrary.View;
using System.Threading;
using FractalLibrary.Model;
using GDIFractalRendererLibrary;
using OpenGLFractalRenderer;
using FractalDimensionLibrary;
using FractalRendererLibrary;
using WeifenLuo.WinFormsUI.Docking;
using IFS.View;
using IFS.Presenter;
using IFS.Presenter.ViewValidator;
using Examples.Tutorial;
using FractalOpenGLExtra;
using FractalRendererLibrary.Presenter;
using IFS.View.Helpers;
using FractalRendererLibrary.Model;

namespace IFS
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm2 : Form, IMainView
    {
        private DockContent _numberDockContent;
        private DockContent _trackBarsDockContent;
        private DockContent _dataGridDockContent;
        private DockContent _editorDockContent;


        public event SelectedFractalEventHandler SelectedChanged;
        public event EventHandler DisplaySierpinsky3DClick;
        public event EventHandler DisplayJuliaSetAnimationClick;
        public event EventHandler NewDocumentClick;
        public event EventHandler OpenDocumentClick;
        public event EventHandler SaveDocumentClick;
        public event EventHandler SaveAsDocumentClick;
        public event EventHandler ExitApplicationClick;
        public event EventHandler NewFractalClick;
        public event EventHandler OpenFractalClick;
        public event EventHandler DisplayGDIClick;
        public event EventHandler DisplayOpenGLClick;
        public event EventHandler CompositeViewClosed;
        public event EventHandler TrackBarsControlMenuItemClick;
        public event EventHandler NumbersControlMenuItemClick;
        public event EventHandler FractalEditorMenuItemClick;
        public event EventHandler FractalDataGridMenuItemClick;

        public MainForm2()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint, true);
        }

        public DockPanel DockPanel { get { return _dockPanel; } }
        public DockContent NumberDockContent { get { return _numberDockContent; } set { _numberDockContent = value; } }
        public DockContent TrackBarsDockContent { get { return _trackBarsDockContent; } set { _trackBarsDockContent = value; } }
        public DockContent DataGridDockContent { get { return _dataGridDockContent; } set { _dataGridDockContent = value; } }
        public DockContent EditorDockContent { get { return _editorDockContent; } set { _editorDockContent = value; } }
        public ToolStripMenuItem GdiToolStripMenuItem { get { return _gdiToolStripMenuItem; } }
        public ToolStripMenuItem OpenGlToolStripMenuItem { get { return _openGLToolStripMenuItem; } }
        

        public bool AskForFilePathToOpen(out string filePath)
        {
            return FileDialogHelper.AskForFilePathToOpen(out filePath);
        }

        public bool AskForFilePathToSave(out string filePath)
        {
            return FileDialogHelper.AskForFilePathToSave(out filePath);
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public DialogResult AskSaving()
        {
            return MessageBox.Show("Do you want to save your changes?", "Saving", MessageBoxButtons.YesNoCancel);
        }

        public void ShowDocumentIsDirty()
        {
            Text = Text + "*";
        }

        public void ShowDocumentIsClean()
        {
            Text = Text.Remove(Text.Length - 1, 1);
        }

        public ToolStripItem AddMenuItem(string name)
        {
            return _predefinedFractalsToolStripMenuItem.DropDownItems.Add(name);
        }

        private void dSierpinskiCarpetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplaySierpinsky3DClick?.Invoke(sender, e);
        }

        private void dJULIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayJuliaSetAnimationClick?.Invoke(sender, e);

        }

        private void _newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDocumentClick?.Invoke(sender, e);
        }

        private void _openDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           OpenDocumentClick?.Invoke(sender, e);
        }

        private void _saveDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDocumentClick?.Invoke(sender, e);
        }

        private void _saveAsDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsDocumentClick?.Invoke(sender, e);
        }

        private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplicationClick?.Invoke(sender, e);
        }

        private void _newFractalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFractalClick?.Invoke(sender, e);
        }

        private void _openFractalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFractalClick?.Invoke(sender, e);
        }

        private void _gdiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayGDIClick?.Invoke(sender, e);
        }

        private void _openGLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayOpenGLClick?.Invoke(sender, e);
        }


        private void _aboutIFS10ToolStripMenuItem_Click(object sender, EventArgs e)
        {

           MessageBox.Show("Written by Marco M Bellocchi.","IFS 1.0");
           
        }

        private void compositeViewClosed(object sender, EventArgs e)
        {
            CompositeViewClosed?.Invoke(sender, e);
        }

        private void OnCompositeViewClosed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitApplicationClick?.Invoke(sender, e);
        }

        protected virtual void OnSelectedChanged(IFractal fractal)
        {
            if (SelectedChanged != null)
                SelectedChanged(this, new FractalLibrary.Events.FractalEventArgs(fractal));
        }

        private void _trackBarsControlPanelToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            TrackBarsControlMenuItemClick?.Invoke(sender, e);
        }

        private void _numbersControlPanelToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            NumbersControlMenuItemClick?.Invoke(sender, e);
        }

        private void _fractalEditorToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            FractalEditorMenuItemClick?.Invoke(sender, e);
        }

        private void fractalDataGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FractalDataGridMenuItemClick?.Invoke(sender, e);
        }
    }
}
