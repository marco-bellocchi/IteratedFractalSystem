using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Model;
using IFS.View;
using System.Threading.Tasks;

namespace IFS.Presenter
{
    public class FractalEditorViewPresenter
    {
        private IFractal _fractal;
        private readonly IFractalEditorView _fractalEditorView;

        public FractalEditorViewPresenter(
            IFractalEditorView fractalEditorView)
        {
            if (fractalEditorView == null)
                throw new ArgumentNullException("fractalEditorView");
            _fractalEditorView = fractalEditorView;
            _fractalEditorView.Apply += new EventHandler(_fractalEditorView_Apply);
        }

        public IFractal Fractal
        {
            get
            {
                return _fractal;
            }
            set
            {
                if (_fractal != null)
                {
                    _fractal.TransformationChanged -= new EventHandler(_fractal_TransformationChanged);
                    _fractalEditorView.ClearTransformations();
                }
                _fractal = value;
                if (_fractal != null)
                {
                    _fractal.TransformationChanged += new EventHandler(_fractal_TransformationChanged);
                    int i = 0;
                    foreach (var transformation in _fractal.Tansformations)
                        _fractalEditorView.AddTransformation("Transformation " + i++, transformation);
                }
            }
        }

        public IFractalEditorView FractalEditorView
        {
            get
            {
                return _fractalEditorView;
            }
        }

        private void _fractalEditorView_Apply(object sender, EventArgs e)
        {
            Apply();
        }

        private void Apply()
        {
            string whyNot;
            if (Fractal != null && FractalEditorView != null)
            {
                if (!_fractal.IsValid(out whyNot))
                {
                    _fractalEditorView.ShowErrorMessage(whyNot);
                }
                else
                {
                    Task task = Task.Factory.StartNew(() =>
                    {
                        _fractal.RecalculateAll();

                    });
                }
            }
        }

        private void _fractal_TransformationChanged(object sender, EventArgs e)
        {
            if (_fractalEditorView.IsAppliedImmediatelyChecked)
                Apply();
        }
    }
}
