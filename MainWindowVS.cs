﻿using System;
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

        private MainWindoViewState currentState;
        private MainWindoViewState nextState;

        public delegate void MainWindowButtonEventHandler(object sender, MainWindowEventArgs e);
        public event MainWindowButtonEventHandler MainWindowButtonClick;
		
		private MainWindowButtonClickEvents newEvent;

        public MainWindowVS()
        {
            currentState = MainWindoViewState.NULL;
            nextState = MainWindoViewState.NULL;
            
        }
        protected virtual void OnMainwindowStateChanging(MainWindowEventArgs e)
        {
            MainWindowButtonEventHandler handler = MainWindowButtonClick;
            if(handler != null)
            {
                handler(this,e);
				this.currentState = this.nextState;
				this.nextState = null;
            }
        }
        public MainWindoViewState GetCurrentState()
        {
            return currentState;
        }
        public MainWindoViewState GetNextState()
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
					case MainWindoViewState.VIEW1STATE :
						if(this.newEvent == MainWindowButtonClickEvents.CON_TO_SITE_CLK)
						{
							this.nextState = MainWindoViewState.VIEW1STATE;
						}
						else if(this.newEvent == MainWindowButtonClickEvents.OPT_CLK)
						{
							this.nextState = MainWindoViewState.VIEW2STATE;							
						}
						else if(this.newEvent == MainWindowButtonClickEvents.ABT_ME_CLK)
						{
							this.nextState = MainWindoViewState.VIEW3STATE;
						}
						else
						{
							//next state is null
							
						}						
						if(this.nextState != this.currentState)
						{
							MainWindowEventArgs args = new MainWindowEventArgs(this.nextState, currentState);
							OnMainwindowStateChanged(args);
						}						
					case MainWindoViewState.VIEW2STATE :
			}
		}
        
        
    }
}
