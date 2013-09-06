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
        public enum MainWindoViewState { NULL, VIEW1STATE, VIEW2STATE, VIEW3STATE }
        public enum MainWindowButtonClickEvents { CON_TO_SITE_CLK, OPT_CLK, ABT_ME_CLK }
        public enum MouseClickEvents { RGHT_CLK, LEFT_CLK }

        public int initiatedViews = 0;

        private MainWindoViewState currentState;
        private MainWindoViewState previousState;
        private MainWindoViewState nextState;

        public delegate void MainWindowButtonEventHandler(object sender, MainWindowEventArgs e);
        public event MainWindowButtonEventHandler MainWindowButtonClick;

        public MainWindowVS()
        {
            previousState = MainWindoViewState.NULL;
            currentState = MainWindoViewState.NULL;
            nextState = MainWindoViewState.NULL;
            
        }
        protected virtual void OnMainwindowStateChanged(MainWindowEventArgs e)
        {
            MainWindowButtonEventHandler handler = MainWindowButtonClick;
            if(handler != null)
            {
                handler(this,e);
            }
        }
        public MainWindoViewState GetCurrentState()
        {
            return currentState;
        }
        public MainWindoViewState GetPreviousState()
        {
            return previousState;
        }
        public MainWindoViewState GetNextState()
        {
            return nextState;
        }
        public void ConToSiteClicked()
        {
            if (currentState != MainWindoViewState.VIEW1STATE)
            {
                MainWindowEventArgs args = new MainWindowEventArgs(MainWindoViewState.VIEW1STATE,currentState,previousState);
                
                //MainWindowEventArgs args = new MainWindowEventArgs(MainWindoViewState.VIEW1STATE, currentState);
                //currentState = MainWindoViewState.VIEW1STATE;
                OnMainwindowStateChanged(args);
            }
        }
        public void OptionsClicked()
        {
            if (currentState != MainWindoViewState.VIEW2STATE)
            {
                MainWindowEventArgs args = new MainWindowEventArgs(MainWindoViewState.VIEW2STATE, currentState, previousState);
                //currentState = MainWindoViewState.VIEW2STATE;
                OnMainwindowStateChanged(args);
            }
        }
        public void AboutMeClicked()
        {
            if (currentState != MainWindoViewState.VIEW3STATE)
            {
                MainWindowEventArgs args = new MainWindowEventArgs(MainWindoViewState.VIEW3STATE, currentState, previousState);
                //currentState = MainWindoViewState.VIEW3STATE;
                OnMainwindowStateChanged(args);
            }
        }
        
        
    }
}
