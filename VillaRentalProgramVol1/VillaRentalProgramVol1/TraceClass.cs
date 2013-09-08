using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VillaRentalProgramVol1
{
    static class TraceClass
    {
        public delegate void LogEventHandler(LogEventArgs e);
        public delegate void SubLogEventHandler(LogEventArgs e);
        public delegate void ErrorLogEventHandler(LogEventArgs e);
        public static event LogEventHandler LogAddedEvent;
        public static event SubLogEventHandler SubLogAddedEvent;
        public static event ErrorLogEventHandler ErrorLogAddedEvent;

        private static void OnNewLogAdded(string x)
        {
            LogEventHandler handler = LogAddedEvent;
            LogEventArgs e = new LogEventArgs(x, DateTime.Now.ToString());
            if (handler != null)
            {
                handler(e);
            }
        }
        private static void OnNewLogAdded(string t,string c)
        {
            LogEventHandler handler = LogAddedEvent;
            LogEventArgs e = new LogEventArgs(t,c, DateTime.Now.ToString());
            if (handler != null)
            {
                handler(e);
            }
        }
        private static void OnNewSubLogAdded(string t, string c)
        {
            SubLogEventHandler handler = SubLogAddedEvent;
            LogEventArgs e = new LogEventArgs(t, c, DateTime.Now.ToString());
            if (handler != null)
            {
                handler(e);
            }
        }
        private static void OnNewErrorLogAdded(string t, string c)
        {
            ErrorLogEventHandler handler = ErrorLogAddedEvent;
            LogEventArgs e = new LogEventArgs(t, c, DateTime.Now.ToString());
            if (handler != null)
            {
                handler(e);
            }
        }
        public static void AddNewLog(string text)
        {
            OnNewLogAdded(text);
        }
        public static void AddNewLog(string text,string callerFunction)
        {
            OnNewLogAdded(text,callerFunction);
        }
        public static void AddNewSubLog(string text)
        {
            OnNewLogAdded(text);
        }
        public static void AddNewSubLog(string text, string callerFunction)
        {
            OnNewLogAdded(text, callerFunction);
        }
        public static void AddNewErrorLog(string text)
        {
            OnNewLogAdded(text);
        }
        public static void AddNewErrorLog(string text, string callerFunction)
        {
            OnNewLogAdded(text, callerFunction);
        }
    }
}
