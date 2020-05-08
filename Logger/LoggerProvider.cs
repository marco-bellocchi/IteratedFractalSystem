using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class LoggerProvider
    {
        public static LoggerBase _instance;

        private LoggerProvider()
        {
        }

        public static LoggerBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NullLogger();
                return _instance;
            }
            set
            {
                if (value == null)
                    _instance = new NullLogger();
                else
                    _instance = value;
            }
        }
    }
}
