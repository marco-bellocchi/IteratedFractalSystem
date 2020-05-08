using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logger
{
    public class FileLogger : LoggerBase, IDisposable
    {
        private readonly string _filePath;
        private readonly TextWriter _textWriter;
        private bool _disposed;

        public FileLogger(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) )
            {
                _filePath = filePath;
                try
                {
                    _textWriter = new StreamWriter(_filePath, true);
                }
                catch(Exception)
                {
                }
            }
        }

        protected override void InternalTrace(Level level, string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                if (_textWriter != null)
                {
                    _textWriter.WriteLine(string.Format("[{0}][{1}]", level, msg));
                    _textWriter.Flush();
                }
            }
        }

        protected override void InternalTraceException(Exception e, string msg)
        {
            if (e == null)
                return;
            msg = msg ?? "";
            if (_textWriter != null)
            {
                _textWriter.Flush();
                _textWriter.WriteLine(string.Format("[{0}][{1}][{2}]", Level.Error, msg, e.Message));
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _textWriter.Flush();
                    _textWriter.Close();
                    _textWriter.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
