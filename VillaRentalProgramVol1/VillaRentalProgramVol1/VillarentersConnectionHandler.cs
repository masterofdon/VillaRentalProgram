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
        private override void NavigateToMainPage()
        {
            this.currentWebBrowser.Navigate(VillarentersSD.MAIN_PAGE);            
        }
        private override void NavigateToLoginPage()
        {            
            this.currentWebBrowser.Navigate(VillarentersSD.LOGIN_PAGE);
        }
        private override void NavigateToPropertiesPage()
        {
            this.currentWebBrowser.Navigate(VillarentersSD.PROPERTIES_PAGE);
        }
        private override void NavigateToCalendarPage()
        {
            this.currentWebBrowser.Navigate(VillarentersSD.CALENDAR_PAGE);
        }
        void NavigatedHandler(object sender, WebBrowserNavigatedEventArgs e)
        {
            stateMachine.NextStateDone();
            if (TraceClassData.TRACE_ON) TraceClass.AddNewLog("Setting current event to NULL", "NavigatedHandler");
            switch (stateMachine.GetCurrentState())
            {
                case WebSiteStateMachine.SiteState.LOGIN_VIEW:
                    LoginToSite();
                    break;
                default:
                    break;
            }
        }
        void NavigatingHandler(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (TraceClassData.TRACE_ON) TraceClass.AddNewLog("Setting current event to NAV_LOGIN", "NavigatingHandler");
            stateMachine.SetCurrentEvent(WebSiteStateMachine.SiteEvent.NAV_LOGIN);
            stateMachine.SetNextState();
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
        public override enum SiteState 
            {LOGIN_VIEW,
            LOGIN_ATTEMPT,
            LOGGED_VIEW,
            PROP_ATTEMPT,
            PROP_VIEW,
            CAL_ATTEMPT,
            CAL_VIEW,
            LOAD_ERROR};
        public override enum SiteEvent {
            NAV_LOGIN,
            LOGIN_SUC,
            LOGIN_FAIL,
            LOG_ERR,
            PROP_CLICK,
            PROP_SUC,
            PROP_ERR,
            CAL_CLICK,
            CAL_SUC,
            CAL_ERR};
        private SiteState currentSiteState;
        private SiteState nextSiteState;
        private SiteEvent currentEvent;

        public delegate void StateEventHandler(object sender, VillarentersSMEventArgs e);
        public event StateEventHandler SMEvent;


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
        public override SiteState GetNextState()
        {
            return nextSiteState;
        }
    }
}
