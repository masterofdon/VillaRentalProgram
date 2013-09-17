using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*-----------------------------------------------------------------------------------------------------*/
/*Coded By: Erdem Ahmet EKIN---------------------------------------------------------------------------*/
/*Date Started:21AUG2013-------------------------------------------------------------------------------*/
/*Description:-----------------------------------------------------------------------------------------*/
/*This class works as a View State Machine. It basically handles CGA Button Clicks. It can in the------*/
/*future handle any sort of click events or state change events. When any CGA Button is clicked--------*/
/*a MainWindowButtonClick event is thrown and is handled properly.-------------------------------------*/
/*-----------------------------------------------------------------------------------------------------*/
namespace VillaRentalProgramVol1
{
    class MainWindowVS : ViewStateMachine
    {
        public enum MainWindowViewState { NULL, VIEW1STATE, VIEW2STATE, VIEW3STATE }
        public enum MainWindowButtonClickEvents { CON_TO_SITE_CLK, OPT_CLK, ABT_ME_CLK }
        public enum MouseClickEvents { RGHT_CLK, LEFT_CLK }

        public int initiatedViews = 0;

        private MainWindowViewState currentState;
        private MainWindowViewState nextState;

        public delegate void MainWindowButtonEventHandler(object sender, MainWindowEventArgs e);
        public event MainWindowButtonEventHandler MainWindowButtonClick;

        public delegate void MainWindowStateEventHandler(object sender, MainWindowEventArgs e);
        public event MainWindowStateEventHandler MainWindowStateChanged;
		
        private MainWindowButtonClickEvents newEvent;

        public MainWindowVS()
        {
            currentState = MainWindowViewState.NULL;
            nextState = MainWindowViewState.NULL;
            
        }
        protected virtual void OnMainwindowStateChanging(MainWindowEventArgs e)
        {
            MainWindowStateEventHandler handler = MainWindowStateChanged;
            if(handler != null)
            {
                handler(this,e);
				this.currentState = this.nextState;
                this.nextState = MainWindowViewState.NULL;
            }
        }
        public MainWindowViewState GetCurrentState()
        {
            return currentState;
        }
        public MainWindowViewState GetNextState()
        {
            return nextState;
        }
		public void SetNewEvent(MainWindowButtonClickEvents e)
		{
			this.newEvent = e;
		}
		public MainWindowButtonClickEvents SetNewEvent()
		{
			return this.newEvent;
		}
		public void CGAButtonClicked()
		{
			switch(currentState)
			{
                case MainWindowViewState.VIEW1STATE:
					if(this.newEvent == MainWindowButtonClickEvents.CON_TO_SITE_CLK)
					{
                        this.nextState = MainWindowViewState.VIEW1STATE;
					}
					else if(this.newEvent == MainWindowButtonClickEvents.OPT_CLK)
					{
                        this.nextState = MainWindowViewState.VIEW2STATE;							
					}
					else if(this.newEvent == MainWindowButtonClickEvents.ABT_ME_CLK)
					{
                        this.nextState = MainWindowViewState.VIEW3STATE;
					}
					else
					{
						//next state is null
                        //there must be something wrong in here...
							
					}						
					if(this.nextState != this.currentState)
					{
						MainWindowEventArgs args = new MainWindowEventArgs(this.nextState, currentState);
                        OnMainwindowStateChanging(args);
					}
                    break;
                case MainWindowViewState.VIEW2STATE:
                    if(this.newEvent == MainWindowButtonClickEvents.CON_TO_SITE_CLK)
					{
                        this.nextState = MainWindowViewState.VIEW1STATE;
					}
					else if(this.newEvent == MainWindowButtonClickEvents.OPT_CLK)
					{
                        this.nextState = MainWindowViewState.VIEW2STATE;							
					}
					else if(this.newEvent == MainWindowButtonClickEvents.ABT_ME_CLK)
					{
                        this.nextState = MainWindowViewState.VIEW3STATE;
					}
					else
					{
						//next state is null
							
					}						
					if(this.nextState != this.currentState)
					{
						MainWindowEventArgs args = new MainWindowEventArgs(this.nextState, currentState);
                        OnMainwindowStateChanging(args);
					}
                    break;
                case MainWindowViewState.VIEW3STATE:
                    if (this.newEvent == MainWindowButtonClickEvents.CON_TO_SITE_CLK)
                    {
                        this.nextState = MainWindowViewState.VIEW1STATE;
                    }
                    else if (this.newEvent == MainWindowButtonClickEvents.OPT_CLK)
                    {
                        this.nextState = MainWindowViewState.VIEW2STATE;
                    }
                    else if (this.newEvent == MainWindowButtonClickEvents.ABT_ME_CLK)
                    {
                        this.nextState = MainWindowViewState.VIEW3STATE;
                    }
                    else
                    {
                        //next state is null

                    }
                    if (this.nextState != this.currentState)
                    {
                        MainWindowEventArgs args = new MainWindowEventArgs(this.nextState, currentState);
                        OnMainwindowStateChanging(args);
                    }
                    break;
                case MainWindowViewState.NULL:
                    if (this.newEvent == MainWindowButtonClickEvents.CON_TO_SITE_CLK)
                    {
                        this.nextState = MainWindowViewState.VIEW1STATE;
                    }
                    else if (this.newEvent == MainWindowButtonClickEvents.OPT_CLK)
                    {
                        this.nextState = MainWindowViewState.VIEW2STATE;
                    }
                    else if (this.newEvent == MainWindowButtonClickEvents.ABT_ME_CLK)
                    {
                        this.nextState = MainWindowViewState.VIEW3STATE;
                    }
                    else
                    {
                        //next state is null

                    }
                    if (this.nextState != this.currentState)
                    {
                        MainWindowEventArgs args = new MainWindowEventArgs(this.nextState, currentState);
                        OnMainwindowStateChanging(args);
                    }
                    break;
                default:
                    break;
			}//end of switch

		}
        
        
    }
}
