using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VillaRentalProgramVol1
{
    public abstract class WebSiteConnectionHandler
    {
        public WebBrowser currentWebBrowser;
        protected WebSiteStateMachine stateMachine;

        protected delegate void NavigationEventHandler(object sender,EventArgs e);
        protected event NavigationEventHandler NavigationProcessing;
        protected event NavigationEventHandler NavigationComplete;

        protected abstract void LoginToSite();
        protected abstract void GetCalendarData();
        protected abstract void GetDayData();
        protected abstract void NavigateToMainPage();
        protected abstract void NavigateToLoginPage();
        protected abstract void NavigateToCalendarPage();

    }
}
