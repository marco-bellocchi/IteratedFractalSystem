using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Persistence;

namespace FractalLibrary.Model.Application
{
    public class FractalDocument
    {
        private static FractalDocument _instance;
        private static List<IFractalCreator> _predefinedFractalCreators = new List<IFractalCreator>();
        private List<IFractal> _fractals = new List<IFractal>();
        private IFractalDocumentPersister _persister;
        private bool _isDirty;

        public event EventHandler Changed;

        static FractalDocument()
        {
            _predefinedFractalCreators = new List<IFractalCreator>(FractalCreatorFactory.GetFractalCreators());
        }

        private FractalDocument()
        {
            New();
        }

        public static FractalDocument GetInstance()
        {
            if (_instance == null)
                _instance = new FractalDocument();
            return _instance;
        }

        #region Document Status

        public List<IFractal> Fractals
        {
            get
            {
                return _fractals;
            }
        }

        public List<IFractalCreator> PredefinedFractalCreators
        {
            get { return _predefinedFractalCreators; }
        }

        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }
        }

        #endregion

        public void New()
        {
            _persister = null;
            _fractals = new List<IFractal>();
            _isDirty = false;
            OnChanged();
        }

        public void Load(string filePath)
        {
            New();
            _persister = new FractalDocumentPersister(filePath);
            _fractals = _persister.Load();
            foreach (var fractal in _fractals)
            {
                fractal.TransformationChanged += new EventHandler(fractal_TransformationChanged);
            }
            OnChanged();
        }

        public bool CanSave()
        {
            return _persister != null;
        }

        public void Save()
        {
            if (CanSave())
            {
                _persister.Save(this);
                _isDirty = false;
                OnChanged();
            }
        }

        public void Save(string filePath)
        {
            _persister = new FractalDocumentPersister(filePath);
            Save();
        }

        public void LoadFractalFromXml(string xmlFractal)
        {
            FractalCompiler fractalCompiler = new FractalCompiler();
            var fractal = fractalCompiler.CompileFromXml(xmlFractal);
            fractal.TransformationChanged += new EventHandler(fractal_TransformationChanged);
            _fractals.Add(fractal);
            _isDirty = true;
            OnChanged();
        }

        public void LoadFractalFromFile(string filePath)
        {
            FractalCompiler fractalCompiler = new FractalCompiler();
            var fractal = fractalCompiler.CompileFromFilePath(filePath);
            fractal.TransformationChanged += new EventHandler(fractal_TransformationChanged);
            _fractals.Add(fractal);
            _isDirty = true;
            OnChanged();
        }

        public void LoadFractal(IFractal fractal)
        {
            _fractals.Add(fractal);
            _isDirty = true;
            OnChanged();
        }
        
        public void RemoveFractal(IFractal fractal)
        {
        	if(_fractals.Contains(fractal))
        	{
        		//throw new ArgumentException("!_fractals.Contains(fractal)");
        		_fractals.Remove(fractal);
        		 _isDirty = true;
            	OnChanged();
        	}
        }

        private void fractal_TransformationChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            OnChanged();
        }

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
}
