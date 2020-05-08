/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 13/09/2014
 * Time: 18:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using FractalRendererLibrary.View;
using WeifenLuo.WinFormsUI.Docking;

namespace IFS.View
{
	/// <summary>
	/// Description of FractalCompositeView2.
	/// </summary>
	public partial class FractalCompositeView2 : DockContent
	{
		private IFractalView _fractalView;
		public FractalCompositeView2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		 public IFractalView FractalView {
            get { return _fractalView; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("FractalView");
                _fractalViewPlaceholder.Controls.Clear();
                _fractalView = value;
                var fractalViewUI = _fractalView.View;
                fractalViewUI.Dock = DockStyle.Fill;
                _fractalViewPlaceholder.Controls.Add(fractalViewUI);
            }
        }
        public IFractalCalculatorView FractalCalculatorView { get { return _fractalCalculatorView; } }
	}
}
