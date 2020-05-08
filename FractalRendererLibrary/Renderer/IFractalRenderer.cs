/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 31/07/2014
 * Time: 23:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using FractalLibrary.Model;
using FractalRendererLibrary.Model;

namespace FractalRendererLibrary.Renderer
{
	/// <summary>
	/// Description of IFractalRenderer.
	/// </summary>
	public interface IFractalRenderer
	{
        void Render(IFractal fractal, IControlPanel controlPanel);
	}
}
