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

namespace FractalRendererLibrary.Presenter
{
    public class MainViewPresenter
    {
        //View Status------START
        private IMainView _mainView;
        private IDimensionCalculatorFactory _dimensionCalculatorFactory;
        private IRendererAbstractFactory _rendererAbstractFactory;
        private Dictionary<IFractal, IControlPanel> _viewStatus = new Dictionary<IFractal, IControlPanel>();
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
            _mainView.SelectedChanged += new SelectedFractalEventHandler(SelectedFractalChanged);
            _document = FractalDocument.GetInstance();
            _mainView.Load += new EventHandler(_mainView_Load);
            _document.Changed += new EventHandler(_document_Changed);
        }

        public IRendererAbstractFactory RendererAbstractFactory
        {
            get
            {
                return _rendererAbstractFactory;
            }
        }

        public IDimensionCalculatorFactory DimensionCalculatorFactory
        {
            get
            {
                return _dimensionCalculatorFactory;
            }
        }

        //Save logic goes here
        public void NewDocument()
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

        public void OpenDocument()
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

        public void SaveDocument()
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

        public void SaveDocumentAs()
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

        public void ExitApplication()
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

        public void NewFractal()
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

        public void OpenFractal()
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

        public void Remove(IFractal fractal)
        {
            if (_canRemoveFractals)
                _document.RemoveFractal(fractal);
        }

        public void LoadFractal(IFractal fractal)
        {
            _document.LoadFractal(fractal);
        }

        public void DisplayGDI()
        {
            try
            {
                _canRemoveFractals = false;
                _mainView.SelectedChanged -= new SelectedFractalEventHandler(SelectedFractalChanged);
                _mainView.ClearAll();
                _rendererAbstractFactory = new GDIRendererAbstractFactory();
                foreach (var fractal in _document.Fractals)
                    AddTab(fractal);
                _mainView.SelectedChanged += new SelectedFractalEventHandler(SelectedFractalChanged);
                _mainView.Select(_selected);
                _mainView.DisplayRendering(RenderingEnum.GDI);
                RefreshMainView();
            }
            finally
            {
                _canRemoveFractals = true;
            }
        }

        public void DisplayOpenGL()
        {
            try
            {
                _canRemoveFractals = false;
                _mainView.SelectedChanged -= new SelectedFractalEventHandler(SelectedFractalChanged);
                _mainView.ClearAll();
                _rendererAbstractFactory = new OpenGLRendererAbstractFactory();
                foreach (var fractal in _document.Fractals)
                    AddTab(fractal);
                _mainView.SelectedChanged += new SelectedFractalEventHandler(SelectedFractalChanged);
                _mainView.Select(_selected);
                _mainView.DisplayRendering(RenderingEnum.OpenGL);
                RefreshMainView();
            }
            finally
            {
                _canRemoveFractals = true;
            }
        }

        public void DisplaySierpinsky3D()
        {
            OpenGLExampleFacade facade = new OpenGLExampleFacade();
            facade.RunSierpinskiCarpet();
        }

        public void DisplayJuliaSetAnimation()
        {
            OpenGLExampleFacade facade = new OpenGLExampleFacade();
            facade.RunJuliaSet();
        }

        private void InitPredefinedMenuFractals()
        {
            foreach (var fractalCreator in _document.PredefinedFractalCreators)
            {
                _mainView.AddPredefinedFractalMenu(fractalCreator);
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
            _mainView.ShowFractal(fractal, _viewStatus[fractal]);
        }

        private void _mainView_Load(object sender, EventArgs e)
        {
            _rendererAbstractFactory = new GDIRendererAbstractFactory();
            _mainView.DisplayRendering(RenderingEnum.GDI);
            InitPredefinedMenuFractals();
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
                _mainView.ClearAll();
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
    }
}
