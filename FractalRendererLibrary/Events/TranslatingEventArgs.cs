using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalRendererLibrary.Events
{
    public delegate void TranslatingEventHandler(object sender, TranslatingEventArgs ze);
    
    public class TranslatingEventArgs : EventArgs
    {
        private int _xTranslation;
        private int _yTranslation;

        public TranslatingEventArgs(int x, int y)
        {
            _xTranslation = x;
            _yTranslation = y;
        }

        public int XTranslation
        {
            get
            {
                return _xTranslation;
            }
        }

        public int YTranslation
        {
            get
            {
                return _yTranslation;
            }
        }

    }
}
