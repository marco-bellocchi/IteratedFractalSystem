using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.Events;

namespace IFS.View
{
    public interface IFractalCalculatorView : IView
    {
        event EventHandler CalculatePoints;
        event EventHandler ClearPoints;
        event EventHandler ResetControlPanel;
        event EventHandler CalculateDimension;

        string PointsToCalculate { get; }

        bool EnableCalculatePoints { get; set; }
        bool EnableCalculateDimension { get; set; } 

        void RefreshView(long pointsToCalculate);
        void DisplayDimension(double dimension);

        void CalculatingPoints();
        void CalculatedPoints();
    }
}
