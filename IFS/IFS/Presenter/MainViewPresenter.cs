using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Model;
using FractalLibrary.Model.Application;
using IFS.View;
using System.Windows.Forms;
using IFS.Presenter;
using GDIFractalRendererLibrary;
using IFS.Presenter.ViewValidator;
using FractalDimensionLibrary;
using OpenGLFractalRenderer;
using FractalLibrary.Events;
using FractalOpenGLExtra;
using System.IO;
using FractalRendererLibrary.Model;
using WeifenLuo.WinFormsUI.Docking;

namespace FractalRendererLibrary.Presenter
{
    public class MainViewPresenter
    {
        //View Status------START
        private IMainView _mainView;
        private IDimensionCalculatorFactory _dimensionCalculatorFactory;
        private IRendererAbstractFactory _rendererAbstractFactory;
        private Dictionary<IFractal, IControlPanel> _viewStatus = new Dictionary<IFractal, IControlPanel>();
        private IDictionary<IDockContent, IFractal> _dockContentFractalDictionary = new Dictionary<IDockContent, IFractal>();
        private IFractal _selected;
        private bool _showingIsDirty;
        private bool _isClosing;
        private bool _canRemoveFractals = true;

        private IControlPanelView _trackBarControlPanelView;
        private IControlPanelView _numbersControlPanelView;
        private IFractalDataGridView _fractalDataGridView;
        private IFractalEditorView _fractalEditorView;

        private ControlPanelViewPresenter _numberViewPresenter;
        private ControlPanelViewPresenter _trackBarsViewPresenter;
        private FractalDataGridViewPresenter _dataGridPresenter;
        private FractalEditorViewPresenter _editorViewPresenter;
        //View Status------END
        private FractalDocument _document;//Model of the application

        public MainViewPresenter(
            IMainView mainView,
            TrackBarControlPanelView trackBarControlPanelView,
            NumbersControlPanelView numbersControlPanelView,
            FractalDataGridView fractalDataGridView,
            FractalEditorView fractalEditorView,
            IDimensionCalculatorFactory dimensionCalculatorFactory)
        {
            if (mainView == null)
                throw new ArgumentNullException("mainView");
            if (trackBarControlPanelView == null)
                throw new ArgumentNullException("trackBarControlPanelView");
            if (numbersControlPanelView == null)
                throw new ArgumentNullException("numbersControlPanelView");
            if (fractalDataGridView == null)
                throw new ArgumentNullException("fractalDataGridView");
            if (fractalEditorView == null)
                throw new ArgumentNullException("fractalEditorView");
            if (dimensionCalculatorFactory == null)
                throw new ArgumentNullException("dimensionCalculatorFactory");
            _mainView = mainView;
            _trackBarControlPanelView = trackBarControlPanelView;
            _numbersControlPanelView = numbersControlPanelView;
            _fractalDataGridView = fractalDataGridView;
            _fractalEditorView = fractalEditorView;

            _numberViewPresenter = new ControlPanelViewPresenter(_numbersControlPanelView);
            _trackBarsViewPresenter = new ControlPanelViewPresenter(_trackBarControlPanelView);
            _dataGridPresenter = new FractalDataGridViewPresenter(_fractalDataGridView);
            _editorViewPresenter = new FractalEditorViewPresenter(_fractalEditorView);

            _dimensionCalculatorFactory = dimensionCalculatorFactory;
           
            _document = FractalDocument.GetInstance();
            _document.Changed += new EventHandler(_document_Changed);
            _mainView.Load += new EventHandler(_mainView_Load);
            _mainView.SelectedChanged += new SelectedFractalEventHandler(SelectedFractalChanged);
            _mainView.DisplaySierpinsky3DClick += MainView_DisplaySierpinsky3DClick;
            _mainView.DisplayJuliaSetAnimationClick += _mainView_DisplayJuliaSetAnimationClick;
            _mainView.NewDocumentClick += _mainView_NewDocumentClick;
            _mainView.OpenDocumentClick += _mainView_OpenDocumentClick;
            _mainView.SaveDocumentClick += _mainView_SaveDocumentClick;
            _mainView.SaveAsDocumentClick += _mainView_SaveAsDocumentClick;
            _mainView.ExitApplicationClick += _mainView_ExitApplicationClick;
            _mainView.NewFractalClick += _mainView_NewFractalClick;
            _mainView.OpenFractalClick += _mainView_OpenFractalClick;
            _mainView.DisplayGDIClick += _mainView_DisplayGDIClick;
            _mainView.DisplayOpenGLClick += _mainView_DisplayOpenGLClick;
            _mainView.CompositeViewClosed += _mainView_CompositeViewClosed;

            _mainView.TrackBarsControlMenuItemClick += _mainView_TrackBarsControlMenuItemClick;
            _mainView.NumbersControlMenuItemClick += _mainView_NumbersControlMenuItemClick;
            _mainView.FractalEditorMenuItemClick += _mainView_FractalEditorMenuItemClick;
            _mainView.FractalDataGridMenuItemClick += _mainView_FractalDataGridMenuItemClick;
        }

        private IRendererAbstractFactory RendererAbstractFactory
        {
            get
            {
                return _rendererAbstractFactory;
            }
        }

        private IDimensionCalculatorFactory DimensionCalculatorFactory
        {
            get
            {
                return _dimensionCalculatorFactory;
            }
        }

        private void _mainView_FractalDataGridMenuItemClick(object sender, EventArgs e)
        {
            InitFractalDataGrid();
        }

        private void _mainView_FractalEditorMenuItemClick(object sender, EventArgs e)
        {
            InitFractalEditor();
        }

        private void _mainView_NumbersControlMenuItemClick(object sender, EventArgs e)
        {
            InitNumbersControlPanel();
        }

        private void _mainView_TrackBarsControlMenuItemClick(object sender, EventArgs e)
        {
           InitTrackBarsControlPanel();
        }

        private void _mainView_CompositeViewClosed(object sender, EventArgs e)
        {
            var compositeView = sender as FractalCompositeView2;
            if (compositeView != null)
            {
                if (_dockContentFractalDictionary.ContainsKey(compositeView))
                {
                    var fractal = _dockContentFractalDictionary[compositeView];
                    if (fractal != null)
                    {
                        Remove(fractal);
                        _dockContentFractalDictionary.Remove(compositeView);
                    }
                }
            }
        }


        //Save logic goes here
        private void NewDocument()
        {
            if (_document.IsDirty)
            {
                DialogResult result = _mainView.AskSaving();
                if (result == DialogResult.Yes)
                    SaveDocument();
                else if (result == DialogResult.Cancel)
                    return;
            }
            FractalDocument.GetInstance().New();
        }

        private void OpenDocument()
        {
            if (_document.IsDirty)
            {
                DialogResult result = _mainView.AskSaving();
                if (result == DialogResult.Yes)
                    SaveDocument();
                else if (result == DialogResult.Cancel)
                    return;
            }
            string filePath;
            bool ok = _mainView.AskForFilePathToOpen(out filePath);
            if (ok)
            {
                try
                {
                    _document.Load(filePath);
                }
                catch (Exception e)
                {
                    _mainView.ShowMessageBox(e.Message);
                }
            }
        }

        private void SaveDocument()
        {
            if (_document.Fractals.Count == 0)
                return;
            if (_document.CanSave())
            {
                _document.Save();
            }
            else
            {
                SaveDocumentAs();
            }
        }

        private void SaveDocumentAs()
        {
            if (_document.Fractals.Count == 0)
                return;
            string filePath;
            bool ok = _mainView.AskForFilePathToSave(out filePath);
            if (ok)
            {
                try
                {
                    _document.Save(filePath);
                }
                catch (Exception e)
                {
                    _mainView.ShowMessageBox(e.Message);
                }
            }
        }

        private void ExitApplication()
        {
            if (!_isClosing)
            {
                _isClosing = true;
                if (_document.IsDirty)
                {
                    DialogResult result = _mainView.AskSaving();
                    if (result == DialogResult.Yes)
                        SaveDocument();
                    else if (result == DialogResult.Cancel)
                        return;
                }
                Application.Exit();
            }
        }

        private void NewFractal()
        {
            NewFractal(string.Empty);
        }

        private void NewFractal(string xmlFractal)
        {
            FractalCompilerView view = new FractalCompilerView();
            view.XmlFractal = xmlFractal;
            FractalCompilerViewPresenter presenter = new FractalCompilerViewPresenter(view);
            view.FractalCompilerViewPresenter = presenter;
            view.ShowDialog();
        }

        private void OpenFractal()
        {
            string filePath;
            bool ok = _mainView.AskForFilePathToOpen(out filePath);
            if (ok)
            {
                string xmlFractal;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    xmlFractal = sr.ReadToEnd();
                }
                NewFractal(xmlFractal);
            }
        }

        private void Remove(IFractal fractal)
        {
            if (_canRemoveFractals)
            {
                _document.RemoveFractal(fractal);
            }
        }

        private void LoadFractal(IFractal fractal)
        {
            _document.LoadFractal(fractal);
        }

        private void DisplayGDI()
        {
            try
            {
                _canRemoveFractals = false;
                _mainView.SelectedChanged -= new SelectedFractalEventHandler(SelectedFractalChanged);
                ClearAll();
                _rendererAbstractFactory = new GDIRendererAbstractFactory();
                foreach (var fractal in _document.Fractals)
                    AddTab(fractal);
                _mainView.SelectedChanged += new SelectedFractalEventHandler(SelectedFractalChanged);
                Select(_selected);
                DisplayRendering(RenderingEnum.GDI);
                RefreshMainView();
            }
            finally
            {
                _canRemoveFractals = true;
            }
        }

        private void Select(IFractal selected)
        {
            for (int index = _mainView.DockPanel.Contents.Count - 1; index >= 0; index--)
            {
                if (_mainView.DockPanel.Contents[index] is IDockContent)
                {
                    IDockContent content = (IDockContent)_mainView.DockPanel.Contents[index];
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

        private void DisplayRendering(RenderingEnum rendering)
        {
            switch (rendering)
            {
                case RenderingEnum.GDI:
                    _mainView.GdiToolStripMenuItem.Checked = true;
                    _mainView.OpenGlToolStripMenuItem.Checked = false;
                    break;
                default:
                    _mainView.GdiToolStripMenuItem.Checked = false;
                    _mainView.OpenGlToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void ClearAll()
        {
            _dockContentFractalDictionary.Clear();
            for (int index = _mainView.DockPanel.Contents.Count - 1; index >= 0; index--)
            {
                if (_mainView.DockPanel.Contents[index] is IDockContent)
                {
                    IDockContent content = (IDockContent)_mainView.DockPanel.Contents[index];
                    if (content != _mainView.NumberDockContent &&
                        content != _mainView.TrackBarsDockContent &&
                        content != _mainView.EditorDockContent &&
                        content != _mainView.DataGridDockContent)
                        content.DockHandler.Close();
                }
            }
        }

        private void DisplayOpenGL()
        {
            try
            {
                _canRemoveFractals = false;
                _mainView.SelectedChanged -= new SelectedFractalEventHandler(SelectedFractalChanged);
                ClearAll();
                _rendererAbstractFactory = new OpenGLRendererAbstractFactory();
                foreach (var fractal in _document.Fractals)
                    AddTab(fractal);
                _mainView.SelectedChanged += new SelectedFractalEventHandler(SelectedFractalChanged);
                Select(_selected);
                DisplayRendering(RenderingEnum.OpenGL);
                RefreshMainView();
            }
            finally
            {
                _canRemoveFractals = true;
            }
        }

        private void DisplaySierpinsky3D()
        {
            OpenGLExampleFacade facade = new OpenGLExampleFacade();
            facade.RunSierpinskiCarpet();
        }

        private void DisplayJuliaSetAnimation()
        {
            OpenGLExampleFacade facade = new OpenGLExampleFacade();
            facade.RunJuliaSet();
        }

        private void _mainView_DisplayOpenGLClick(object sender, EventArgs e)
        {
            DisplayOpenGL();
        }

        private void _mainView_DisplayGDIClick(object sender, EventArgs e)
        {
            DisplayGDI();
        }

        private void _mainView_OpenFractalClick(object sender, EventArgs e)
        {
            OpenFractal();
        }

        private void _mainView_NewFractalClick(object sender, EventArgs e)
        {
            NewFractal();
        }

        private void _mainView_ExitApplicationClick(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void _mainView_SaveAsDocumentClick(object sender, EventArgs e)
        {
            SaveDocumentAs();
        }

        private void _mainView_SaveDocumentClick(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void _mainView_OpenDocumentClick(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void _mainView_NewDocumentClick(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void _mainView_DisplayJuliaSetAnimationClick(object sender, EventArgs e)
        {
            DisplayJuliaSetAnimation();
        }

        private void MainView_DisplaySierpinsky3DClick(object sender, EventArgs e)
        {
            DisplaySierpinsky3D();
        }

        private void InitPredefinedMenuFractals()
        {
            foreach (var fractalCreator in _document.PredefinedFractalCreators)
            {
                var menuItem = _mainView.AddMenuItem(fractalCreator.Name);
                menuItem.Click += new EventHandler
                    ((s, e) => LoadFractal(fractalCreator.Create()));
            }
        }

        private void AddTab(IFractal fractal)
        {
            if (!_viewStatus.ContainsKey(fractal))
            {
                var tmpControlPanel = new ControlPanel();
                tmpControlPanel.XTranslation = 500;
                tmpControlPanel.YTranslation = 100;
                tmpControlPanel.AnticlockWiseRotation = 0;
                tmpControlPanel.Zoom = 100;
                _viewStatus.Add(fractal, tmpControlPanel);
            }
            FractalCompositeView2 compositeView = new FractalCompositeView2();
            compositeView.FractalView = RendererAbstractFactory.CreateFractalView();
            InitFractalCompositeView(fractal, compositeView, _viewStatus[fractal]);
            compositeView.Text = fractal.Name;
            compositeView.Dock = DockStyle.Fill;
            compositeView.Activated += (s, e) =>
            {
                var dockContent = s as IDockContent;
                if (dockContent == null)
                    return;
                if (fractal != null)
                    _selected = fractal;
                    RefreshMainView();
            };
            compositeView.FormClosed += compositeViewClosed;
            compositeView.Show(_mainView.DockPanel);
            _dockContentFractalDictionary[compositeView] = fractal;
        }

        private void compositeViewClosed(object sender, EventArgs e)
        {
            var compositeView = sender as FractalCompositeView2;
            if (compositeView != null)
            {
                if (_dockContentFractalDictionary.ContainsKey(compositeView))
                {
                    var fractal = _dockContentFractalDictionary[compositeView];
                    if (fractal != null)
                    {
                        Remove(fractal);
                        _dockContentFractalDictionary.Remove(compositeView);
                    }
                }
            }
        }

        private void InitFractalCompositeView(IFractal fractal, FractalCompositeView2 view, IControlPanel controlPanel)
        {
                int pointsToCalculate = 100000;//TODO should be moved
                controlPanel.Rectangle = view.FractalView.DrawableRectangle;
                view.FractalCalculatorView.RefreshView(pointsToCalculate);
                FractalCalculatorViewPresenter fractalCalculatorViewPresenter = new FractalCalculatorViewPresenter(fractal, DimensionCalculatorFactory,
                    view.FractalCalculatorView, controlPanel);
                FractalViewPresenterBase fractalViewPresenter =
                    RendererAbstractFactory.CreateFractalViewPresenter(fractal, controlPanel, view.FractalView,
                    RendererAbstractFactory.CreateRenderer(view.FractalView));
        }

        private void _mainView_Load(object sender, EventArgs e)
        {
            _rendererAbstractFactory = new GDIRendererAbstractFactory();
            DisplayRendering(RenderingEnum.GDI);
            InitPredefinedMenuFractals();
            IntializeFractalEditors();
        }

        private void SelectedFractalChanged(object sender, FractalEventArgs e)
        {
            _selected = e.Fractal;
            RefreshMainView();
        }

        private void RefreshMainView()
        {
            if (_selected != null)
            {
                _numberViewPresenter.ControlPanel = _viewStatus[_selected];
                _trackBarsViewPresenter.ControlPanel = _viewStatus[_selected];
                _editorViewPresenter.Fractal = _selected;
                _dataGridPresenter.Fractal = _selected;
            }
            else
            {
                _numberViewPresenter.ControlPanel = null;
                _trackBarsViewPresenter.ControlPanel = null;
                _editorViewPresenter.Fractal = null;
                _dataGridPresenter.Fractal = null;
            }
        }

        private void _document_Changed(object sender, EventArgs e)
        {
            if (_document.IsDirty && !_showingIsDirty)
            {
                _mainView.ShowDocumentIsDirty();
                _showingIsDirty = true;
            }
            else if (!_document.IsDirty && _showingIsDirty)
            {
                _mainView.ShowDocumentIsClean();
                _showingIsDirty = false;
            }
            if (_document.Fractals.Count == 0)
            {
                ClearAll();
                _viewStatus.Clear();
                _selected = null;
                RefreshMainView();
            }
            foreach (IFractal fractal in _document.Fractals)
            {
                if (!_viewStatus.ContainsKey(fractal))
                {
                    AddTab(fractal);
                }
            }
        }

        private void IntializeFractalEditors()
        {
            InitTrackBarsControlPanel();
            InitNumbersControlPanel();
            InitFractalEditor();
            InitFractalDataGrid();
        }

        private void InitTrackBarsControlPanel()
        {
           
            if (_mainView.TrackBarsDockContent != null)
            {
                 _mainView.TrackBarsDockContent.Activate();
                return;
            }
            DockContent trackBarsDockContent = new DockContent();
            _trackBarControlPanelView.UserControl.Dock = DockStyle.Fill;
            trackBarsDockContent.Controls.Add(_trackBarControlPanelView.UserControl);
            trackBarsDockContent.Show(_mainView.DockPanel, DockState.DockRightAutoHide);
            trackBarsDockContent.Text = "TrackBars Control Panel";
            trackBarsDockContent.HideOnClose = true;
            _mainView.TrackBarsDockContent = trackBarsDockContent;
        }

        private void InitNumbersControlPanel()
        {
            if (_mainView.NumberDockContent != null)
            {
                _mainView.NumberDockContent.Activate();
                return;
            }
            DockContent numberDockContent = new DockContent();
            _numbersControlPanelView.UserControl.Dock = DockStyle.Fill;
            numberDockContent.Controls.Add(_numbersControlPanelView.UserControl);
            numberDockContent.Show(_mainView.DockPanel, DockState.DockRightAutoHide);
            numberDockContent.Text = "Numbers Control Panel";
            numberDockContent.HideOnClose = true;
            _mainView.NumberDockContent = numberDockContent;
        }

        private void InitFractalEditor()
        {
            if (_mainView.EditorDockContent != null)
            {
                _mainView.EditorDockContent.Activate();
                return;
            }
            DockContent editorDockContent = new DockContent();
            _fractalEditorView.UserControl.Dock = DockStyle.Fill;
            editorDockContent.Controls.Add(_fractalEditorView.UserControl);
            editorDockContent.Show(_mainView.DockPanel, DockState.DockRightAutoHide);
            editorDockContent.Text = "Fractal Transformations Editor";
            editorDockContent.HideOnClose = true;
            _mainView.EditorDockContent = editorDockContent;
        }

        private void InitFractalDataGrid()
        {
            if (_mainView.DataGridDockContent != null)
            {
                _mainView.DataGridDockContent.Activate();
                return;
            }
            DockContent dataGridDockContent = new DockContent();
            _fractalDataGridView.UserControl.Dock = DockStyle.Fill;
            dataGridDockContent.Controls.Add(_fractalDataGridView.UserControl);
            dataGridDockContent.Show(_mainView.DockPanel, DockState.DockLeftAutoHide);
            dataGridDockContent.Text = "Fractal Data Grid";
            dataGridDockContent.HideOnClose = true;
            _mainView.DataGridDockContent = dataGridDockContent;
        }
    }
}
