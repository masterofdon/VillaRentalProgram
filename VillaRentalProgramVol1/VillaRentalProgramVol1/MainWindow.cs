using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VillaRentalProgramVol1
{
    public partial class MainWindow : Form
    {
        ServiceTraceWindow TraceClass = new ServiceTraceWindow();       //tracing activity
        List<Control> sitesManagementControls;                          //CG-B
        List<Control> MainPanels = new List<Control>();                 //a collection of CGs.

        private bool CGB_VIEW1Initiated = false;
        private bool CGB_VIEW2Initiated = false;
        private bool CGB_VIEW3Initiated = false;

        MainWindowVS currentWindowVS = new MainWindowVS();

        private bool sitesManagementControlsInitiated = false;          //boolean values for the window state.
        private bool CGBVisible = false;

        private bool CGAInitiated = true;
        private bool View1Initiated = false;
        private bool CGCInitiated = true;

        private bool traceOn = true;
        private bool debuggingLevel1On = false;
        private bool debuggingLevel2On = false;
        private bool visualDebuggingModeLevel1On = false;
        private bool visualDebuggingModeLevel2On = false;
        private bool processingDebuggingModeLevel1On = false;
        private bool processingDebuggingModeLevel2On = false;

        public MainWindow()
        {
            InitializeComponent();
            BasicResolutionIntegrity();
            TraceClass.StartTracing(this);
            
            //Initiate SitesManagementControl section
            sitesManagementControls = new List<Control>();

            /*--------------------------------------*/
            /*-------------EVENTHANDLERS------------*/
            /*--------------------------------------*/
            //Load CGAButtonEvent
            currentWindowVS.MainWindowButtonClick += new MainWindowVS.MainWindowButtonEventHandler(CGBViewChanged);
            //Create Main Panels when this page is fully loaded
            this.Shown += new EventHandler(CreateMainPanels);
        }
        private void CGBViewChanged(object sender, MainWindowEventArgs e)
        {
            //View change has been initiated yet not set.
            if (e.NextState == MainWindowVS.MainWindoViewState.VIEW1STATE)
            {
                if(!View1Initiated)   View1Initiate();
                
            }
        }
        private void CreateMainPanels(object sender, EventArgs e)
        {
            createCGAPanel();
            createCGBPanel();
            createCGCPanel();
        }
        private void BasicResolutionIntegrity()
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            this.Width = (resolution.Width / 8) * 7;
            this.Height = (resolution.Height / 8) * 7;
            int pb_loc = Convert.ToInt32(this.Height*0.85);
            int lbl_loc = pb_loc - 32;
            pb_progress_indicator.Location = new Point(52,pb_loc);
            lbl_progress_indicator.Location = new Point(52, lbl_loc);
            this.Resize += new EventHandler(MainWindow_Resize);
        }
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            int pb_loc = Convert.ToInt32(this.Height * 0.85);
            int lbl_loc = pb_loc - 32;
            pb_progress_indicator.Location = new Point(52, pb_loc);
            lbl_progress_indicator.Location = new Point(52, lbl_loc);
            MainPanels[2].Location = new Point(45, lbl_loc - 5);
        }
        /*----------------------------------------------------------------*/
        /*--------------------Initiation Processes------------------------*/
        /*----------------------------------------------------------------*/
        private void createCGAPanel()
        {
            if (traceOn) TraceClass.AddNewLog("Adding CG-A Panel Options", "createCGAPanel");
            Panel leftButtonGroupPanel = new Panel();
            leftButtonGroupPanel.Parent = this;
            leftButtonGroupPanel.Location = new Point(45, 50);
            leftButtonGroupPanel.Size = new Size(230, 230);
            if (visualDebuggingModeLevel1On) leftButtonGroupPanel.BackColor = ColorTranslator.FromHtml("Lime");
            MainPanels.Add(leftButtonGroupPanel);
            if (traceOn) TraceClass.AddNewLog("CG-A Panel Options Added Successfully", "createCGAPanel");
            if (traceOn) TraceClass.AddNewLog("Exiting", "createCGAPanel");
            
        }
        private void createCGBPanel()
        {
            /*This is the initial CG-B for the specific VIEW1.*/
            /*This function's name need to be changed*/
            if (traceOn) TraceClass.AddNewLog("Adding CG-B Panel Options", "createCGBPanel");
            Panel CGBPanel = new Panel();
            CGBPanel.Parent = this;
            CGBPanel.Location = new Point(320, 50);
            CGBPanel.Size = new Size(800, 550);
            if (visualDebuggingModeLevel1On) CGBPanel.BackColor = ColorTranslator.FromHtml("Red");
            MainPanels.Add(CGBPanel);
            if (traceOn) TraceClass.AddNewLog("CG-B Panel Options Added Successfully", "createCGBPanel");
            if (traceOn) TraceClass.AddNewLog("Exiting", "createCGBPanel");
        }
        private void createCGCPanel()
        {
            if (traceOn) TraceClass.AddNewLog("Adding CG-C Panel Options", "createCGCPanel");
            Panel progressIndicatorGroupPanel = new Panel();
            progressIndicatorGroupPanel.Parent = this;
            int x = Convert.ToInt32(this.Height * 0.85f);
            progressIndicatorGroupPanel.Location = new Point(45, x - 35);
            progressIndicatorGroupPanel.Size = new Size(750, 80);
            if (visualDebuggingModeLevel1On) progressIndicatorGroupPanel.BackColor = ColorTranslator.FromHtml("Lime");
            MainPanels.Add(progressIndicatorGroupPanel);
            if (traceOn) TraceClass.AddNewLog("CG-C Panel Options Added Successfully", "createCGCPanel");
            if (traceOn) TraceClass.AddNewLog("Exiting", "createCGCPanel");            
        }

        private void View1Initiate()
        {
            View1TopPanelInitiation();
            View1MidPanelInitiation();
            View1BottomPanelInitiation();
        }
        private void View1TopPanelInitiation()
        {
            /*This is the top panel for select all checkbox and select all label to be added*/
            /*This control is a child of CG-B*/
            /*FD Name:VIEW1_TOP*/
            Panel ctsTopPanel = new Panel();
            ctsTopPanel.Parent = MainPanels[1];
            ctsTopPanel.Location = new Point(0,0);
            ctsTopPanel.Size = new Size(420, 20);
            if (visualDebuggingModeLevel1On) ctsTopPanel.BackColor = ColorTranslator.FromHtml("Yellow");

            /*This section adds select all checkbox and select all label*/
            /*Both controls are added to sitesManagementControls ControlCollection*/
            if (traceOn) TraceClass.AddNewLog("Adding select all checkbox properties", "CGBTopPanelInitiation");
            Control selectAllCheckBox = new CheckBox();         
            selectAllCheckBox.Location = new Point(10, 5);
            selectAllCheckBox.Size = new Size(15, 15);
            selectAllCheckBox.Name = "selectall checkbox";
            selectAllCheckBox.Click += new EventHandler(SelectAllClick);
            selectAllCheckBox.Parent = ctsTopPanel;  
            sitesManagementControls.Add(selectAllCheckBox);
            if (traceOn) TraceClass.AddNewLog("Added select all checkbox properties", "CGBTopPanelInitiation");


            if (traceOn) TraceClass.AddNewLog("Adding select all label properties", "CGBTopPanelInitiation");
            Control selectAllLabel = new Label();
            selectAllLabel.Parent = ctsTopPanel;
            selectAllLabel.Text = "Select All";
            selectAllLabel.ForeColor = ColorTranslator.FromHtml("Lime");
            selectAllLabel.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.75f,FontStyle.Bold);
            selectAllLabel.Name = "selectall label";
            selectAllLabel.Location = new Point(40, 5);
            sitesManagementControls.Add(selectAllLabel);
            sitesManagementControlsInitiated = true;
            if (traceOn) TraceClass.AddNewLog("Added select all label properties", "CGBTopPanelInitiation");
        }
        private void View1MidPanelInitiation()
        {
            /*This is the panel where listed rental sites are shown according to the page nummber*/
            /*FD Name: VIEW1_MID*/
            Panel rentalSitesListPanel = new Panel();
            rentalSitesListPanel.Parent = MainPanels[1];
            rentalSitesListPanel.Location = new Point(0, 25);
            rentalSitesListPanel.Size = new Size(700, 300);
            rentalSitesListPanel.Name = "rentalSitesListPanel";
            if (visualDebuggingModeLevel1On) rentalSitesListPanel.BackColor = ColorTranslator.FromHtml("Yellow");

            if (traceOn) TraceClass.AddNewLog("Adding villarenters.com controls.", "CGBTopPanelInitiation");
            SMCAddSite(1, "villarenters.com", "anatolian", "aksaray68");
            if (traceOn) TraceClass.AddNewLog("Added villarentes.com controls.", "CGBTopPanelInitiation");

            if (traceOn) TraceClass.AddNewLog("Adding airbnb.com controls.", "CGBTopPanelInitiation");
            SMCAddSite(2, "airbnb.com", "anatolian", "aksaray68");
            if (traceOn) TraceClass.AddNewLog("Added airbnb.com controls.", "CGBTopPanelInitiation");

            if (traceOn) TraceClass.AddNewLog("Adding housetrip.com controls.", "CGBTopPanelInitiation");
            SMCAddSite(3, "housetrip.com", "anatolian", "aksaray68");
            if (traceOn) TraceClass.AddNewLog("Added housetrip.com controls.", "CGBTopPanelInitiation");

            if (traceOn) TraceClass.AddNewLog("Adding holidaylettings.co.uk controls.", "CGBTopPanelInitiation");
            SMCAddSite(4, "holidayletting.co.uk", "26210", "aksarayli");
            if (traceOn) TraceClass.AddNewLog("Added holidayletting.co.uk controls.", "CGBTopPanelInitiation");

            if (traceOn) TraceClass.AddNewLog("Adding ownersdirect.co.uk controls.", "CGBTopPanelInitiation");
            SMCAddSite(5, "ownersdirect.co.uk", "anatolian", "aksaray68");
            if (traceOn) TraceClass.AddNewLog("Added ownersdirect.co.uk controls.", "CGBTopPanelInitiation");

            if (traceOn) TraceClass.AddNewLog("Adding flipkey.com controls.", "CGBTopPanelInitiation");
            SMCAddSite(6, "flipkey.com", "anatolian752002@yahoo.com", "aksaray68");
            if (traceOn) TraceClass.AddNewLog("Added flipkey.co.uk controls.", "CGBTopPanelInitiation");

            if (traceOn) TraceClass.AddNewLog("Adding e-domizil.de controls.", "CGBTopPanelInitiation");
            SMCAddSite(7, "e-domizil.de", "anatolian", "Aksaray68");
            if (traceOn) TraceClass.AddNewLog("Added e-domizil.de controls.", "CGBTopPanelInitiation");

            if (traceOn) TraceClass.AddNewLog("Adding holiday-villas.ru controls.", "CGBTopPanelInitiation");
            SMCAddSite(8, "holiday-villas.ru", "anatolian752002@yahoo.com", "aksaray68");
            if (traceOn) TraceClass.AddNewLog("Added holiday-villas.ru controls.", "CGBTopPanelInitiation");
        }
        private void View1BottomPanelInitiation()
        {
            /*This panel is for the bottom control.Paging and connecion controls are on this panel*/
            /*FD Name: VIEW1_BOT*/
        }        
        
        
                
        
        private void SMCAddSite(int index,string siteName,string username,string password)
        {
            /*Adds a checkbox, a label and a username-password field for the specified rentalsite in the label*/
            /**/
            CheckBox siteCheckBox = new CheckBox();
            siteCheckBox.Location = new Point(10, 10 + (index - 1) * 30);
            AddStandardCheckBox(siteName, siteCheckBox, (MainPanels[1]).GetChildAtPoint(new Point(0,30)), index);
            sitesManagementControls.Add(siteCheckBox);

            Label siteLabel = new Label();
            AddStandardLabel(siteName, siteLabel, (MainPanels[1]).GetChildAtPoint(new Point(0, 30)), index);
            siteLabel.Text = siteName;
            siteLabel.Name = siteName + " label";
            siteLabel.Location = new Point(40, 10 + (index - 1) * 30);
            MyStyleApply(siteLabel);            
            sitesManagementControls.Add(siteLabel);

            TextBox siteUsername = new TextBox();
            AddStandardTextBox(siteName, siteUsername, (MainPanels[1]).GetChildAtPoint(new Point(0,30)), index);
            siteUsername.Location = new Point(210, 10 + (index - 1) * 30);
            siteUsername.Text = username;            
            siteUsername.ReadOnly = true;
            MyStyleApply(siteUsername);
            siteUsername.Name = siteName + " username";
            sitesManagementControls.Add(siteUsername);

            TextBox sitePassword = new TextBox();
            AddStandardTextBox(siteName, sitePassword, (MainPanels[1]).GetChildAtPoint(new Point(0, 30)), index);
            sitesManagementControls.Add(sitePassword);
            sitePassword.UseSystemPasswordChar = true;
            sitePassword.Text = password;
            sitePassword.Location = new Point(450, 10 + (index - 1) * 30);
            MyStyleApply(sitePassword);
            sitePassword.Name = siteName + " password";            
        }
        /*----------------------------------------------------------------*/
        /*--------------------Button Click Events-------------------------*/
        /*----------------------------------------------------------------*/
        private void btn_cts_Click(object sender, EventArgs e)
        {
            if (traceOn) TraceClass.AddNewLog("Connect To Sites Clicked");
            //raise the ConToSiteClick event
            currentWindowVS.ConToSiteClicked();
        }
        private void btn_user_options_Click(object sender, EventArgs e)
        {
            if (traceOn) TraceClass.AddNewLog("Options Clicked");
            //raise the OptionsClick event
            currentWindowVS.OptionsClicked();
        }
        private void btn_about_me_Click(object sender, EventArgs e)
        {
            if (traceOn) TraceClass.AddNewLog("About Me Clicked");
            //raise the AboutMeClick event
            currentWindowVS.AboutMeClicked();
        }
        private void SelectAllClick(object sender, EventArgs e)
        {

        }
        /*----------------------------------------------------------------*/
        /*-------------Dynamic Content Draw Functions---------------------*/
        /*----------------------------------------------------------------*/
        private void DrawConnectionListContol()
        {

        }
        /*----------------------------------------------------------------*/
        /*------------------------Helper Functions------------------------*/
        /*----------------------------------------------------------------*/
        private void SetAllControlsVisibility(List<Control> collection, bool visibility)
        {
            /*This is for test purpose but might be used for others control collecitons as well*/
            /*All controls inside the list will be set the visibility bool value*/
            string x = (visibility ? "visible" : "invisible");
            int count = collection.Count;
            if (traceOn) TraceClass.AddNewLog("Setting controls visibility of " + count.ToString() + " controls to " + x, "setallcontrolsvisibility");
            for (int i = 0; i < count; i++)
            {
                collection[i].Visible = visibility;
                if(traceOn) TraceClass.AddSubLog("setting [" + collection[i].Name + "] visibility to " + x);
            }
        }
        private void AddStandardCheckBox(string siteName, Control c, Control parent, int index)
        {
            c.Parent = parent;
            c.Size = new Size(15, 15);
            c.Name = siteName + " checkbox";
        }
        private void AddStandardLabel(string siteName, Control c, Control parent, int index)
        {
            c.Parent = parent;
            c.Size = new Size(150, 15);
        }
        private void AddStandardTextBox(string siteName, Control c, Control parent, int index)
        {
            c.Parent = parent;
            c.Size = new Size(220, 15);
        }
        private void MyStyleApply(Control c)
        {
            c.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.75f, FontStyle.Bold);
            c.ForeColor = ColorTranslator.FromHtml("Lime");
            c.BackColor = ColorTranslator.FromHtml("Black");
        }
        private void MyStyleEdit()
        {

        }
    }
}
