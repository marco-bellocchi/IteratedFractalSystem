﻿/*
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

        private TrackBarControlPanelView _trackBarControlPanelView;
        private NumbersControlPanelView _numbersControlPanelView;
        private FractalDataGridView _fractalDataGridView;
        private FractalEditorView _fractalEditorView;

        private IDictionary<IDockContent, IFractal> _dockContentFractalDictionary = new Dictionary<IDockContent, IFractal>();

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

        public MainForm2(
            TrackBarControlPanelView trackBarControlPanelView,
            NumbersControlPanelView numbersControlPanelView,
            FractalDataGridView fractalDataGridView,
            FractalEditorView fractalEditorView)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint, true);
            _trackBarControlPanelView = trackBarControlPanelView;
            _numbersControlPanelView = numbersControlPanelView;
            _fractalDataGridView = fractalDataGridView;
            _fractalEditorView = fractalEditorView;
            IntializeFractalEditors();
        }

        public IDictionary<IDockContent, IFractal> DockContentFractalDictionary { get { return _dockContentFractalDictionary; } }

        public DockPanel DockPanel { get { return _dockPanel; } }
        

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

        public void ClearAll()
        {
            _dockContentFractalDictionary.Clear();
            for (int index = _dockPanel.Contents.Count - 1; index >= 0; index--)
            {
                if (_dockPanel.Contents[index] is IDockContent)
                {
                    IDockContent content = (IDockContent)_dockPanel.Contents[index];
                    if(content != _numberDockContent &&
                        content != _trackBarsDockContent &&
                        content != _editorDockContent &&
                        content != _dataGridDockContent)
                            content.DockHandler.Close();
                }
            }
        }

        public void Select(IFractal selected)
        {
            for (int index = _dockPanel.Contents.Count - 1; index >= 0; index--)
            {
                if (_dockPanel.Contents[index] is IDockContent)
                {
                    IDockContent content = (IDockContent)_dockPanel.Contents[index];
                    if (_dockContentFractalDictionary.ContainsKey(content))
                    {
                        var fractal = _dockContentFractalDictionary[content];
                        if (fractal == selected)
                        {
                            content.DockHandler.Activate();
                        }
                    }
                }
            }
        }

        public void DisplayRendering(RenderingEnum rendering)
        {
            switch (rendering)
            {
                case RenderingEnum.GDI:
                    _gdiToolStripMenuItem.Checked = true;
                    _openGLToolStripMenuItem.Checked = false;
                    break;
                default:
                    _gdiToolStripMenuItem.Checked = false;
                    _openGLToolStripMenuItem.Checked = true;
                    break;
            }
        }

        public ToolStripItem AddMenuItem(string name)
        {
            return _predefinedFractalsToolStripMenuItem.DropDownItems.Add(name);
        }

        private void InitTrackBarsControlPanel()
        {
            if (_trackBarsDockContent != null)
            {
                _trackBarsDockContent.Activate();
                return;
            }
        	_trackBarsDockContent = new DockContent();
        	_trackBarControlPanelView.Dock = DockStyle.Fill;
            _trackBarsDockContent.Controls.Add(_trackBarControlPanelView);
            _trackBarsDockContent.Show(_dockPanel, DockState.DockRightAutoHide);
            _trackBarsDockContent.Text = "TrackBars Control Panel";
            _trackBarsDockContent.HideOnClose = true;
        }

        private void InitNumbersControlPanel()
        {
            if (_numberDockContent != null)
            {
                _numberDockContent.Activate();
                return;
            }
            _numberDockContent = new DockContent();
            _numbersControlPanelView.Dock = DockStyle.Fill;
            _numberDockContent.Controls.Add(_numbersControlPanelView);
            _numberDockContent.Show(_dockPanel, DockState.DockRightAutoHide);
            _numberDockContent.Text = "Numbers Control Panel";
            _numberDockContent.HideOnClose = true;
        }

        private void InitFractalEditor()
        {
            if (_editorDockContent != null)
            {
                _editorDockContent.Activate();
                return;
            }
            _editorDockContent = new DockContent();
            _fractalEditorView.Dock = DockStyle.Fill;
            _editorDockContent.Controls.Add(_fractalEditorView);
            _editorDockContent.Show(_dockPanel, DockState.DockRightAutoHide);
            _editorDockContent.Text = "Fractal Transformations Editor";
            _editorDockContent.HideOnClose = true;
        }

        private void InitFractalDataGrid()
        {
            if (_dataGridDockContent != null)
            {
                _dataGridDockContent.Activate();
                return;
            }
            _dataGridDockContent = new DockContent();
            _fractalDataGridView.Dock = DockStyle.Fill;
            _dataGridDockContent.Controls.Add(_fractalDataGridView);
            _dataGridDockContent.Show(_dockPanel, DockState.DockLeftAutoHide);
            _dataGridDockContent.Text = "Fractal Data Grid";
            _dataGridDockContent.HideOnClose = true;
        }

        private void IntializeFractalEditors()
        {
            InitTrackBarsControlPanel();
            InitNumbersControlPanel();
            InitFractalEditor();
            InitFractalDataGrid();
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
            InitTrackBarsControlPanel();
        }

        private void _numbersControlPanelToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            InitNumbersControlPanel();
        }

        private void _fractalEditorToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            InitFractalEditor();
        }

        private void fractalDataGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFractalDataGrid();
        }
    }
}
