using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;
using System.Drawing;
using FractalLibrary.Model;
using TransformationsLibrary.Transformation;
using FractalRendererLibrary.Extensions;
using FractalRendererLibrary.Renderer;
using FractalRendererLibrary.Model;


namespace OpenGLFractalRenderer.Renderer
{
    public class OpenTkRenderer : FractalRendererBase
	{
        private object _syncRendering = new object();
        //private IGraphicsContext context;
        private Vector2[] _chachedVertices;
        public OpenTkRenderer(IFractalView fractalView)
            : base(fractalView)
		{
		}

        public override void Render(IFractal fractal, IControlPanel controlPanel)
        {
            lock (_syncRendering)
            {
                int vbo = -1;
                try
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.EnableVertexAttribArray(0);//Enable vertex array attribute
                    //If points are cached, use them without recreating them
                    var points = fractal.Points;
                    if (points.Count == 0)
                        return;
                    if (_chachedVertices == null || _chachedVertices.Length != points.Count
                        || _chachedVertices[points.Count - 1].X != points[points.Count - 1].X
                        || _chachedVertices[points.Count - 1].Y != points[points.Count - 1].Y)
                    {
                        //var points = fractal.Points;
                        _chachedVertices = new Vector2[points.Count];
                        int i = 0;
                        foreach (var p in points)
                        {
                            _chachedVertices[i] = new Vector2(p.X, p.Y);
                            i++;
                        }
                    }

                    //Apply trnasformations in OpenGL
                    GL.Scale(controlPanel.Zoom / 1000.0, controlPanel.Zoom / 1000.0, 1);
                    GL.Rotate(controlPanel.AnticlockWiseRotation, Vector3.UnitZ);
                    GL.Translate(controlPanel.XTranslation / 100.0, controlPanel.YTranslation / 100.0, 0);

                    GL.GenBuffers(1, out vbo);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
                    GL.BufferData<Vector2>(BufferTarget.ArrayBuffer, new IntPtr(_chachedVertices.Length * Vector2.SizeInBytes),
                                           _chachedVertices, BufferUsageHint.StaticDraw);
                    GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
                    GL.DrawArrays(PrimitiveType.Points, 0, _chachedVertices.Length);
                }
                finally
                {
                    GL.DisableVertexAttribArray(0);
                    GL.Flush();
                    GL.DeleteBuffer(vbo);
                }
            }
        }
    }
}
