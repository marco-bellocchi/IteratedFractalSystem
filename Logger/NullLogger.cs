using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class NullLogger : LoggerBase
    {
        protected override void InternalTrace(Level level, string msg)
        {
            
        }

        protected override void InternalTraceException(Exception e, string msg)
        {
            
        }
    }
}
