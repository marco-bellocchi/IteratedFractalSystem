using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FractalRendererLibrary.View;
using IFS.View;
using FractalLibrary.Model.Application;
using FractalLibrary.Exceptions;
using FractalLibrary.Persistence;
using System.IO;

namespace IFS.Presenter
{
    public class FractalCompilerViewPresenter
    {
        private readonly IFractalCompilerView _view;

        public FractalCompilerViewPresenter(IFractalCompilerView view)
        {
            if (view == null)
                throw new ArgumentNullException("view == null");
            _view = view;
        }

        public bool AddFractalToDocument(out string whyNot)
        {
            whyNot = "";
            string xmlFractal = _view.XmlFractal;
            try
            {
                FractalDocument.GetInstance().LoadFractalFromXml(xmlFractal);
                return true;
            }
            catch (FractalCompilerException e)
            {
                whyNot = e.Message;
            }
            catch (Exception e)
            {
                whyNot = e.Message;
            }
            return false;
        }

        public void SaveAs()
        {
            if (string.IsNullOrEmpty(_view.XmlFractal))
                return;
            string filePath;
            bool okSave = _view.AskForFilePathToSave(out filePath);
            if (okSave)
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(_view.XmlFractal);
                }
            }
        }
    }
}
