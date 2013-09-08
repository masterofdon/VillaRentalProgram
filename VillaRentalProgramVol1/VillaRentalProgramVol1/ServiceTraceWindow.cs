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
            this.Show();
        }
        private void resolutionAndLocation()
        {

        }
        public void AddNewLog(string m)
        {
            service_trace_logs.AppendText(">" + m + "\n");
        }
        public void AddNewLog(string m,string called_location)
        {
            service_trace_logs.AppendText(">["+called_location.ToUpper()+"] : " + m + "\n");
        }
        public void AddSubLog(string m)
        {
            service_trace_logs.AppendText("\t" + m + "\n");
        }
        private void ShowLocationOnClick(object sender, EventArgs e)
        {
            AddNewLog("Mouse Position => X : " + MousePosition.X.ToString() + ", Y: " + MousePosition.Y.ToString());
        }
        private void StartLogDialog(object sender, EventArgs e)
        {
            AddNewLog("Action Logging Started", "startLogDialog");
        }
        public void StartTracing(Form f)
        {
            f.Shown += new EventHandler(StartLogDialog);
            f.Click += new EventHandler(ShowLocationOnClick);
            //f.Validating += new CancelEventHandler(StartLogDialog);
        }
        
    }
}
