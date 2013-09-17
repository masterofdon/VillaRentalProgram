using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaRentalProgramVol1
{
    class MainWindowEventArgs : EventArgs
    {
        public MainWindowVS.MainWindowViewState CurrentState { get; private set; }
        public MainWindowVS.MainWindowViewState NextState { get; private set; }
        private DateTime timeStamp;

        public MainWindowEventArgs(MainWindowVS.MainWindowViewState n, MainWindowVS.MainWindowViewState c)
        {
            CurrentState = c;
            NextState = n;
        }
    }
}
