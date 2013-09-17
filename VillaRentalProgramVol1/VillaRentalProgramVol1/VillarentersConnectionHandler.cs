using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Windows.Forms;

namespace VillaRentalProgramVol1
{
    class VillarentersConnectionHandler : WebSiteConnectionHandler
    {
        public VillarentersConnectionHandler()
        {
            this.currentWebBrowser = new WebBrowser();
            this.stateMachine = new VillarentersStateMachine();
            this.currentWebBrowser.Navigating += new WebBrowserNavigatingEventHandler(NavigatingHandler);
            this.currentWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(NavigatedHandler);
        }        
        public override void NavigateToMainPage()
        {
            this.currentWebBrowser.Navigate(VillarentersSD.MAIN_PAGE);            
        }
        public override void NavigateToLoginPage()
        {
            this.currentWebBrowser.Navigate(VillarentersSD.LOGIN_PAGE);
        }
        public override void NavigateToPropertiesPage()
        {
            this.currentWebBrowser.Navigate(VillarentersSD.PROPERTIES_PAGE);
        }
        public override void NavigateToCalendarPage()
        {
            this.currentWebBrowser.Navigate(VillarentersSD.CALENDAR_PAGE);
        }
        void NavigatedHandler(object sender, WebBrowserNavigatedEventArgs e)
        {
        }
        void NavigatingHandler(object sender, WebBrowserNavigatingEventArgs e)
        {
        }
        public override void LoginToSite()
        {

        }
        public override void GetToCalendarPage()
        {

        }
    }
    public class VillarentersStateMachine : WebSiteStateMachine
    {
        public override enum SiteState { NULL, LOGIN_VIEW, LOGGED_IN_VIEW, PROPERTIES_VIEW, CALENDAR_VIEW};
        public override enum SiteEvent { NAV_LOGIN, LOGIN, NAV_PROP, NAV_CALENDAR };
        private SiteState currentSiteState;
        private SiteState nextSiteState;
        private SiteEvent currentEvent;

        public VillarentersStateMachine()
        {
            currentSiteState = SiteState.NULL;
        }
        public VillarentersStateMachine(SiteState siteState)
        {
            currentSiteState = siteState;
        }
        public override SiteState GetCurrentState()
        {
            return currentSiteState;
        }
        public override void SetCurrentEvent(SiteEvent e)
        {
            currentEvent = e;
        }
        public override SiteEvent GetCurrentEvent()
        {
            return currentEvent;
        }
        public override void SetNextState()
        {
            switch (currentSiteState)
            {
                case SiteState.NULL:
                    if (GetCurrentEvent() == SiteEvent.NAV_LOGIN)
                    {
                        nextSiteState = SiteState.LOGIN_VIEW;
                    }
                    break;
                case SiteState.LOGIN_VIEW:
                    if (GetCurrentEvent() == SiteEvent.LOGIN)
                    {
                        nextSiteState = SiteState.LOGGED_IN_VIEW;
                    }
                    break;
                case SiteState.LOGGED_IN_VIEW:
                    if (GetCurrentEvent() == SiteEvent.NAV_PROP)
                    {
                        nextSiteState = SiteState.PROPERTIES_VIEW;
                    }
                    break;
                case SiteState.PROPERTIES_VIEW:
                    if (GetCurrentEvent() == SiteEvent.NAV_CALENDAR)
                    {
                        nextSiteState = SiteState.CALENDAR_VIEW;
                    }
                    break;
                default:
                    nextSiteState = currentSiteState;
                    break;
            }
        }
    }
}
