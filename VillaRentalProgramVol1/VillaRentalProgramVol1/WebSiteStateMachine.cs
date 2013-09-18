using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaRentalProgramVol1
{
    class WebSiteStateMachine
    {

        public virtual enum SiteState { NULL, LOGIN_VIEW, LOGGED_IN_VIEW, PROPERTIES_VIEW, CALENDAR_VIEW };
        public virtual enum SiteEvent { NULL, NAV_LOGIN, LOGIN, NAV_PROP, NAV_CALENDAR };
        protected virtual SiteState currentSiteState;
        protected virtual SiteState nextSiteState;
        protected virtual SiteEvent currentEvent;

        public WebSiteStateMachine()
        {
            currentSiteState = SiteState.NULL;
            currentEvent = SiteEvent.NULL;
        }
        

        public virtual SiteState GetCurrentState()
        {
            return currentSiteState;
        }
        public virtual void SetCurrentEvent(SiteEvent e)
        {
            currentEvent = e;
        }
        public virtual SiteEvent GetCurrentEvent()
        {
            return currentEvent;
        }
        public virtual void SetNextState()
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
        public virtual SiteState GetNextState()
        {
            return nextSiteState;
        }
    }
}
