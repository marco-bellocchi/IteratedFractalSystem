using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FractalRendererLibrary.Events;

namespace FractalRendererLibrary.View
{
    public interface IFractalView
    {
        event PaintEventHandler PaintView;
        event EventHandler Resize;
        event ZoomEventHandler ZoomIn;
        event TranslatingEventHandler Translating; 

        Rectangle DrawableRectangle { get; }
        UserControl View { get; }

        void RefreshScreen();
        void SetNumOfCalculatedPoints(int numOfPoints);
        void SetSimilarityDimension(string dimension);
        Graphics CreateViewGraphic();
    }
}
