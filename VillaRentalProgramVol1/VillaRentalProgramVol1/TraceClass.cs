using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VillaRentalProgramVol1
{
    static class TraceClass
    {
        private static ServiceTraceWindow a = new ServiceTraceWindow();
        public static void AddNewLog(string d)
        {
            a.AddNewLog(d);
        }
        public static void AddNewLog(string m, string called_location)
        {
            a.AddNewLog(m, called_location);
        }
        public static void AddSubLog(string m)
        {
            a.AddSubLog(m);
        }
        public static void StartTracing(Form f)
        {
            a.StartTracing(f);
            //f.Validating += new CancelEventHandler(StartLogDialog);
        }
    }
}
