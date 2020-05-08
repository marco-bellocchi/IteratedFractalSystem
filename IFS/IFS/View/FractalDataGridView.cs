using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IFS.View
{
    public partial class FractalDataGridView : UserControl, IFractalDataGridView
    {
        public FractalDataGridView()
        {
            InitializeComponent();
        }

        public void Refresh(List<PointF> data)
        {
            var toBind = data.Take(Math.Min(100000,data.Count-1)).ToList();
            FractalRendererLibrary.Extensions.UserControlExtension.InvokeInUIThread(this,()=>
            {
                _dataGridView.DataSource = toBind;
            });
           
        }
    }
}
