using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public abstract class LoggerBase
    {
        public void Trace(string msg)
        {
            Trace(Level.Info, msg);
        }

        public void Trace(Level level, string msg)
        {
            try
            {
                InternalTrace(level, msg);
            }
            catch (Exception)//Add the logger of the log
            {
            }
        }

        public void TraceException(Exception e, string msg)
        {
            try
            {
                InternalTraceException(e, msg);
            }
            catch (Exception)//Add the logger of the log
            {
            }
        }

        protected abstract void InternalTrace(Level level, string msg);
        protected abstract void InternalTraceException(Exception e, string msg);
    }
}
