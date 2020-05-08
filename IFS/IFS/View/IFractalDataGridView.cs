using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace IFS.View
{
    public interface IFractalDataGridView
    {
        void Refresh(List<PointF> data);

        UserControl UserControl { get; }
    }
}
