using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaRentalProgramVol1
{
    class LogEventArgs : EventArgs
    {
        private string logText;
        private string dateTimeAdded;
        private string callerFunction;

        public LogEventArgs()
        {

        }
        public LogEventArgs(string m,string x)
        {
            logText = m;
            dateTimeAdded = x;
        }
        public LogEventArgs(string t, string c,string d)
        {
            logText = t;
            dateTimeAdded = d;
            callerFunction = c;
        }
        public string getCallerFunction()
        {
            return callerFunction;
        }
        public string getLogText()
        {
            return logText;
        }
        public string getDateTimeAdded()
        {
            return dateTimeAdded;
        }

    }
}
