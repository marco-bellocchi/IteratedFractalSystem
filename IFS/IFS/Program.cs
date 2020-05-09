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
using System.IO;
using System.Collections.Generic;

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
            //Do();
            //Do1();
             Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logger.LoggerProvider.Instance = new FileLogger(@".\logger.txt");

            NumbersControlPanelView ncp = new NumbersControlPanelView();
            TrackBarControlPanelView tbc = new TrackBarControlPanelView();
            FractalDataGridView fdg = new FractalDataGridView();
            FractalEditorView fev = new FractalEditorView();

            ControlPanelSlimViewValidator validator1 = new ControlPanelSlimViewValidator(tbc);
            ControlPanelSlimViewValidator validator2 = new ControlPanelSlimViewValidator(ncp);

            var mainForm = new MainForm2();
            var boxDimensionCalculatorFactory = new BoxDimensionCalculatorFactory();
            var mainPresenter = new MainViewPresenter(mainForm, tbc, ncp,fdg,fev, boxDimensionCalculatorFactory);
            
            Application.Run(mainForm);
		}
	
   //     public static void Do()
   //     {
   //         string s = @"    0,           0.053,      -0.429,        0,           -7.083,     5.43
   // 0.143,       0,          0,         -0.053,       -5.619,     8.513
   // 0.143,       0    ,       0   ,         0.083   ,    -5.619  ,   2.057
   // 0 ,          0.053 ,      0.429  ,      0      ,     -3.952  ,   5.43
   // 0.119 ,      0   ,        0     ,       0.053  ,     -2.555 ,    4.536
   //-0.0123806 , -0.0649723 ,  0.423819 ,    0.00189797 , -1.226 ,    5.235
   // 0.0852291 ,  0.0506328  , 0.420449 ,    0.0156626 ,  -0.421 ,    4.569
   // 0.104432   , 0.00529117 , 0.0570516 ,   0.0527352 ,   0.976 ,    8.113
   //-0.00814186 ,-0.0417935,   0.423922  ,   0.00415972 ,  1.934 ,    5.37
   // 0.093   ,    0    ,       0     ,       0.053  ,      0.861,     4.536
   // 0     ,      0.053  ,    -0.429   ,     0     ,       2.447,     5.43
   // 0.119 ,      0    ,       0      ,     -0.053 ,       3.363 ,    8.513
   // 0.119  ,     0    ,       0       ,     0.053,        3.363 ,    1.487
   // 0    ,       0.053  ,     0.429   ,     0       ,     3.972 ,    4.569
   // 0.123998 ,  -0.00183957 , 0.000691208 , 0.0629731  ,  6.275 ,    7.716
   // 0     ,      0.053  ,     0.167   ,     0     ,       5.215  ,   6.483
   // 0.071 ,      0       ,    0      ,      0.053 ,       6.279  ,   5.298
   // 0     ,     -0.053   ,   -0.238  ,      0     ,       6.805 ,    3.714
   //-0.121  ,     0       ,    0      ,      0.053  ,      5.941 ,    1.48";

   //         var sr = new StringReader(s);
   //         string line;
   //         int count = 0;
   //         string res = "";
   //         double x = 1.0 / 19.0;
   //         string template = @"<transformation type=""AffineFractalTransformation"" Cell_11=""{0}"" Cell_12=""{1}"" Cell_21=""{2}"" Cell_22=""{3}"" TranslationX=""{4}"" TranslationY=""{5}"" Probability=""{6}"" />";
   //         while ((line = sr.ReadLine()) != null)
   //         {
   //             count++;
   //             Console.WriteLine("Line {0}: {1}", count, line);
   //             string[] splits = line.Split(new char[] { ',' });
   //             string[] cleanSplit = new string[7];
   //             for(int i = 0; i <6;i++)
   //             {
   //                 cleanSplit[i] = splits[i].Trim();
   //             }
   //             cleanSplit[6] = x.ToString();
   //             res += string.Format(template, cleanSplit);
   //         }


   //     }

   //     public static void Do1()
   //     {
   //         string s = @"0.0500,   -0.0500   , 0.0300  , -0.0300 ,   0.5600 ,   0.1900  , -0.3300
   //          0.0000,    0.0000  , -0.1400 ,   0.1400  ,  0.4400 ,   0.0700 ,  -0.3400
   //          0.0000  ,  0.0000  ,  0.0000  ,  0.0000  , -0.3700  , -0.1000 ,  -0.3300
   //          0.4000 ,  -0.4000  ,  0.2600  , -0.2600  ,  0.5100  ,  0.1500 ,   0.3400
   //          -0.0600 ,  -0.0600 ,  -0.1600 ,  -0.1600  ,  0.3000  , -0.2000 ,  -0.5400
   //          -0.4700 ,  -0.4700  , -0.0100  , -0.0100  ,  0.1500  ,  0.2800  ,  0.3900";
   //         var sr = new StringReader(s);
   //         string line;
   //         int count = 0;
   //         string res = "";
   //         string template = @"<transformation type=""AffineFractalTransformation"" Cell_11=""{0}"" Cell_12=""{1}"" Cell_21=""{2}"" Cell_22=""{3}"" TranslationX=""{4}"" TranslationY=""{5}"" Probability=""{6}"" />";
   //         List<string> a = new List<string>();
   //         List<string> b = new List<string>();
   //         List<string> c = new List<string>();
   //         List<string> d = new List<string>();
   //         List<string> e = new List<string>();
   //         List<string> f = new List<string>();

   //         line = sr.ReadLine();
   //         string[] splits = line.Split(new char[] { ',' });
   //         foreach(string str in splits)
   //         {
   //             a.Add(str.Trim());
   //         }
   //         line = sr.ReadLine();
   //         splits = line.Split(new char[] { ',' });
   //         foreach (string str in splits)
   //         {
   //             b.Add(str.Trim());
   //         }
   //         line = sr.ReadLine();
   //         splits = line.Split(new char[] { ',' });
   //         foreach (string str in splits)
   //         {
   //             c.Add(str.Trim());
   //         }
   //         line = sr.ReadLine();
   //         splits = line.Split(new char[] { ',' });
   //         foreach (string str in splits)
   //         {
   //             d.Add(str.Trim());
   //         }
   //         line = sr.ReadLine();
   //         splits = line.Split(new char[] { ',' });
   //         foreach (string str in splits)
   //         {
   //             e.Add(str.Trim());
   //         };
   //         line = sr.ReadLine();
   //         splits = line.Split(new char[] { ',' });
   //         foreach (string str in splits)
   //         {
   //             f.Add(str.Trim());
   //         }
   //         int numTransf = f.Count;
   //         double x = 1.0 / numTransf;
   //         for (int i = 0; i < numTransf; i++)
   //         {
   //             string[] cleanSplit = new string[7];
   //             cleanSplit[0] = a[i];
   //             cleanSplit[1] = b[i];
   //             cleanSplit[2] = c[i];
   //             cleanSplit[3] = d[i];
   //             cleanSplit[4] = e[i];
   //             cleanSplit[5] = f[i];
   //             cleanSplit[6] = x.ToString();
   //             res += string.Format(template, cleanSplit);
   //         }
   //     }
	}
}
