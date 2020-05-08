using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransformationsLibrary.Transformation;
using FractalLibrary.Model;
using FractalRendererLibrary.Model;

namespace FractalRendererLibrary.Extensions
{
    public static class ControlPanelExtensions
    {
        public static ITransformation CreateTransformation(this IControlPanel controlPanel)
        {
            TransformationBuilder transformationBuilder = new TransformationBuilder();
            ITransformation transformation = transformationBuilder.
                Zoom(controlPanel.ZoomPoint, controlPanel.Zoom).
                Rotate(controlPanel.RotationPoint, controlPanel.AnticlockWiseRotation).
                Translate(controlPanel.XTranslation, controlPanel.YTranslation).
                CreateTransformation();
            return transformation;
        }

        public static ITransformation CreateInverseTransformation(this IControlPanel controlPanel)
        {
            TransformationBuilder transformationBuilder = new TransformationBuilder();
            ITransformation transformation = transformationBuilder.
                Translate(-controlPanel.XTranslation, -controlPanel.YTranslation).
                Rotate(controlPanel.RotationPoint, -controlPanel.AnticlockWiseRotation).
                Zoom(controlPanel.ZoomPoint, 1 / controlPanel.Zoom).
                CreateTransformation();
            return transformation;
        }
    }
}
