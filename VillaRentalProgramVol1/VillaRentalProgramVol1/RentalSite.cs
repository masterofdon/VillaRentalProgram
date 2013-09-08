using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Windows.Forms;

namespace VillaRentalProgramVol1
{
    abstract class RentalSite
    {
        private string siteName;
        private string siteFullAddress;
        public enum VillaStatus  {AVAILABLE,NOT_AVAILABLE,BOOKED};

        private WebBrowser rentalSiteVirtualBrowser;


        public RentalSite()
        {

        }

    }
}
