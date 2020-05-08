using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Model;
using System.Xml;
using System.IO;
using FractalLibrary.Transformations;
using FractalLibrary.Model.Application;

namespace FractalLibrary.Persistence
{
    public class FractalDocumentPersister : IFractalDocumentPersister
    {
        private readonly string _filePath;

        public FractalDocumentPersister(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("string.IsNullOrEmpty(filePath)");
            _filePath = filePath;
        }

        public void Save(FractalDocument document)
        {
            if (document == null)
                return;
            using (XmlTextWriter tw = new XmlTextWriter(_filePath, Encoding.ASCII))
            {
                FractalTransformationPersister ftp = new FractalTransformationPersister(tw);
                tw.WriteStartDocument();
                tw.WriteStartElement("fractals");
                foreach (var fractal in document.Fractals)
                {
                    tw.WriteStartElement("fractal");
                    tw.WriteAttributeString("name", fractal.Name);
                    foreach (var t in fractal.Tansformations)
                    {
                        t.Accept(ftp);
                    }
                    tw.WriteEndElement();
                }
                tw.WriteEndElement();
                tw.WriteEndDocument();
            }
        }

        public List<IFractal> Load()
        {
            if (string.IsNullOrEmpty(_filePath))
                throw new ArgumentException("string.IsNullOrEmpty(filePath)");
            if (!File.Exists(_filePath))
                throw new FileNotFoundException(_filePath);
            List<IFractal> fractals = new List<IFractal>();
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            var fractalsRoot = doc["fractals"];
            XmlNodeList fractalNodes = fractalsRoot.SelectNodes("fractal");
            FractalCompiler fractalCompiler = new FractalCompiler();
            foreach (XmlNode fractalNode in fractalNodes)
            {
                IFractal fractal = fractalCompiler.CompileFromXml(fractalNode.OuterXml);
                fractals.Add(fractal);
            }
            return fractals;
        }
    }
}
