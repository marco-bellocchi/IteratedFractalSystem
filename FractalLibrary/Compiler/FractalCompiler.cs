using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Model;
using FractalLibrary.Exceptions;
using System.Xml;
using FractalLibrary.Transformations;
using System.IO;
using FractalLibrary.Helpers;

namespace FractalLibrary.Persistence
{
    public class FractalCompiler
    {

        public IFractal CompileFromFilePath(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string xmlFractal = sr.ReadToEnd();
                return CompileFromXml(xmlFractal);
            }
        }

        public IFractal CompileFromXml(string xmlFractal)
        {
            if (string.IsNullOrEmpty(xmlFractal))
                throw new FractalCompilerException("fractal string cannot be null");
            XmlDocument fractalDoc = new XmlDocument();
            fractalDoc.LoadXml(xmlFractal);
            XmlNode fractalNode = fractalDoc.SelectSingleNode("fractal");
            if (fractalNode == null)
                throw new FractalCompilerException("you must have a node <fractal name=\"nameOfFractal\">");
            string name = fractalNode.Attributes.GetNamedItem("name").Value;
            XmlNodeList transformationNodes = fractalNode.SelectNodes("transformation");
            List<IFractalTransformation> transformations = new List<IFractalTransformation>();
            foreach (XmlNode node in transformationNodes)
            {
                string transformationType = node.Attributes.GetNamedItem("type").Value;
                switch (transformationType)
                {
                    case "SimilarityFractalTransformation":
                        transformations.Add(new SimilarityFractalTransformation()
                        {
                            ScaleX = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("ScaleX").Value),
                            ScaleY = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("ScaleY").Value),
                            AnticlockWiseRotationAngle = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("AnticlockWiseRotationAngle").Value),
                            TranslationX = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("TranslationX").Value),
                            TranslationY = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("TranslationY").Value),
                            Probability = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("Probability").Value)
                        });
                        break;
                    case "AffineFractalTransformation":
                        transformations.Add(new AffineFractalTransformation()
                        {
                            Cell_11 = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("Cell_11").Value),
                            Cell_12 = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("Cell_12").Value),
                            Cell_21 = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("Cell_21").Value),
                            Cell_22 = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("Cell_22").Value),
                            TranslationX = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("TranslationX").Value),
                            TranslationY = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("TranslationY").Value),
                            Probability = FractionHelper.FractionToDouble(node.Attributes.GetNamedItem("Probability").Value)
                        });
                        break;
                }
            }
            CompileTransformations(transformations);
            return new CustomFractal(name, transformations);
        }

        private void CompileTransformations(List<IFractalTransformation> transformations)
        {
            IFractalTransformationCompiler compiler = new FractalTransformationCompiler();
            compiler.BeginCompilation();
            foreach (IFractalTransformation fTransformation in transformations)
            {
                fTransformation.Accept(compiler);
            }
            compiler.EndCompilation();
        }
    }
}
