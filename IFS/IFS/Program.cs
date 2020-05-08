/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 29/07/2014
 * Time: 22:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Logger;
using FractalRendererLibrary.Presenter;
using FractalDimensionLibrary;
using IFS.View;
using IFS.Presenter.ViewValidator;

namespace IFS
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
	 		Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logger.LoggerProvider.Instance = new FileLogger(@".\logger.txt");

            NumbersControlPanelView ncp = new NumbersControlPanelView();
            TrackBarControlPanelView tbc = new TrackBarControlPanelView();
            FractalDataGridView fdg = new FractalDataGridView();
            FractalEditorView fev = new FractalEditorView();

            ControlPanelSlimViewValidator validator1 = new ControlPanelSlimViewValidator(tbc);
            ControlPanelSlimViewValidator validator2 = new ControlPanelSlimViewValidator(ncp);

            var mainForm = new MainForm2(tbc, ncp, fdg, fev);
            var boxDimensionCalculatorFactory = new BoxDimensionCalculatorFactory();
            var mainPresenter = new MainViewPresenter(mainForm, tbc, ncp,fdg,fev, boxDimensionCalculatorFactory);
            
            Application.Run(mainForm);
		}
		
	}
}
