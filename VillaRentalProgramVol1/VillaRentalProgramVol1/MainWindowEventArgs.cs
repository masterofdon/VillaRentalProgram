using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaRentalProgramVol1
{
    class MainWindowEventArgs : EventArgs
    {
        public MainWindowVS.MainWindoViewState CurrentState { get; private set; }
        public MainWindowVS.MainWindoViewState PreviousState { get; private set; }
        public MainWindowVS.MainWindoViewState NextState { get; private set; }
        private DateTime timeStamp;

        public MainWindowEventArgs(MainWindowVS.MainWindoViewState n,MainWindowVS.MainWindoViewState c,MainWindowVS.MainWindoViewState p)
        {
            CurrentState = c;
            PreviousState = p;
            NextState = n;
        }
        /*
        public MainWindowEventArgs(MainWindowVS.MainWindoViewState n, MainWindowVS.MainWindoViewState c)
        {
            CurrentState = c;
            NextState = n;
        }
        */
    }
}
