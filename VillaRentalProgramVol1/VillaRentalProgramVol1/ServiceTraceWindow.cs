using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VillaRentalProgramVol1
{
    public partial class ServiceTraceWindow : Form
    {
        public ServiceTraceWindow()
        {
            InitializeComponent();
            resolutionAndLocation();


            TraceClass.LogAddedEvent += new TraceClass.LogEventHandler(LogAdded);
            this.Show();
        }
        private void resolutionAndLocation()
        {

        }
        private void LogAdded(LogEventArgs e)/*event handler for LogAddedEvent*/
        {
            service_trace_logs.AppendText(">" + e.getLogText() + "\n");
        }
        private void SubLogAdded(LogEventArgs e)/*event handler for SubLogAddedEvent*/
        {
            service_trace_logs.AppendText(">" + e.getLogText() + "\n");
        }
        public void StartTracing(Form f)
        {

        }
        
        
    }
}
