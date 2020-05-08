using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalLibrary.Transformations;
using System.Xml;

namespace FractalLibrary.Persistence
{
    public class FractalTransformationPersister : IFractalTransformationVisitor
    {
        private XmlTextWriter _textWriter;

        public FractalTransformationPersister(XmlTextWriter tw)
        {
            if (tw == null)
                throw new ArgumentNullException("tw == null");
            _textWriter = tw;
        }

        public void Visit(AffineFractalTransformation t)
        {
            _textWriter.WriteStartElement("transformation");
            _textWriter.WriteAttributeString("type", "AffineFractalTransformation");
            _textWriter.WriteAttributeString("Cell_11", t.Cell_11.ToString());
            _textWriter.WriteAttributeString("Cell_12", t.Cell_12.ToString());
            _textWriter.WriteAttributeString("Cell_21", t.Cell_21.ToString());
            _textWriter.WriteAttributeString("Cell_22", t.Cell_22.ToString());
            _textWriter.WriteAttributeString("TranslationX", t.TranslationX.ToString());
            _textWriter.WriteAttributeString("TranslationY", t.TranslationY.ToString());
            _textWriter.WriteAttributeString("Probability", t.Probability.ToString());
            _textWriter.WriteEndElement();
        }

        public void Visit(SimilarityFractalTransformation t)
        {
            _textWriter.WriteStartElement("transformation");
            _textWriter.WriteAttributeString("type", "SimilarityFractalTransformation");
            _textWriter.WriteAttributeString("ScaleX", t.ScaleX.ToString());
            _textWriter.WriteAttributeString("ScaleY", t.ScaleY.ToString());
            _textWriter.WriteAttributeString("AnticlockWiseRotationAngle", t.AnticlockWiseRotationAngle.ToString());
            _textWriter.WriteAttributeString("TranslationX", t.TranslationX.ToString());
            _textWriter.WriteAttributeString("TranslationY", t.TranslationY.ToString());
            _textWriter.WriteAttributeString("Probability", t.Probability.ToString());
            _textWriter.WriteEndElement();
        }
    }
}
