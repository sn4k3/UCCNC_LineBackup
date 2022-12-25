using System;
using System.Diagnostics;

namespace Plugins
{
    public class UCCNCplugin //Class name must be UCCNCplugin to work! 
    {
        private const ushort GcodeLineID = 866;
        private const ushort CurrentTimeID = 898;
        private const ushort LoadedFileID = 895;
        private bool FirstRun { get; set; } = true;
        public Plugininterface.Entry UC { get; private set; }
        public ConfigForm ConfigForm { get; private set; }
        private PluginForm PluginForm { get; set; }
        public bool LoopStop { get; set; } = true;
        public bool LoopWorking { get; set; } 

        private BackupManager LineManager { get; set; }

        private BackupData BackupData { get; set; }

        private long currentTime;
        private Stopwatch StopWatchTimer;


        public UCCNCplugin()
        {
        }

        //Called when the plugin is initialised.
        //The parameter is the Plugin interface object which contains all functions prototypes for calls and callbacks.
        public void Init_event(Plugininterface.Entry UC)
        {
            this.UC = UC;
            PluginForm = new PluginForm(this);
            BackupData = new BackupData();
            LineManager = new BackupManager();
            StopWatchTimer = new Stopwatch();

            var backup = BackupManager.ReadBackup();
            if (backup.CurrentLine > 0)
            {
                UC.AddStatusmessage($"Unfinished job detected!\n{backup}");
            }
            
        }

        //Called when the plugin is loaded, the author of the plugin should set the details of the plugin here.
        public Plugininterface.Entry.Pluginproperties Getproperties_event(Plugininterface.Entry.Pluginproperties Properties)
        {
            Properties.author = "Tiago Conceição";
            Properties.pluginname = "LineBackup"; 
            Properties.pluginversion = "1.1";

            return Properties;
        }

        //Called from UCCNC when the user presses the Configuration button in the Plugin configuration menu.
        //Typically the plugin configuration window is shown to the user.
        public void Configure_event()
        {
            if (ConfigForm is null) ConfigForm = new ConfigForm();
            else if (ConfigForm.IsDisposed) ConfigForm = new ConfigForm();
            ConfigForm.ShowDialog();
        }

        //Called from UCCNC when the plugin is loaded and started.
        public void Startup_event()
        {
            /*if (PluginForm.IsDisposed) PluginForm = new PluginForm(this);
            PluginForm.Show();*/
        }

        //Called when the Pluginshowup(string Pluginfilename); function is executed in the UCCNC.
        public void Showup_event()
        {
            /*if (PluginForm.IsDisposed) PluginForm = new PluginForm(this);
            PluginForm.Show();
            PluginForm.BringToFront();*/
        }

        //Called when the UCCNC software is closing.
        public void Shutdown_event()
        {
            try
            {
                PluginForm.Close();
                LineManager.Dispose();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        //Called in a loop with a 25Hz interval.
        public void Loop_event() 
        {
            if (LoopStop || LoopWorking)
            {
                return;
            }

            // Call at a set time frequency
            if (StopWatchTimer.ElapsedMilliseconds < BackupManager.BackupFrequencyMs) return;

            LoopWorking = true;

            /*if (FirstRun)
            {
                FirstRun = false;
                //Write code here which has to be run on first cycle only...
            }*/

            var line = GetCurrentLine();
            if (BackupData.CurrentLine != line)
            {
                BackupData.CurrentLine = line;
                BackupData.CurrentTime = GetCurrentTime();

                LineManager.Write(BackupData);
            }

            StopWatchTimer.Restart();
            LoopWorking = false;
        }

        //This is a direct function call addressed to this plugin dll
        //The function can be called by macros or by another plugin
        //The passed parameter is an object and the return value is also an object
        public object Informplugin_event(object Message)
        {
            if (!(PluginForm == null || PluginForm.IsDisposed))
            {
                /*if (Message is string receivedstr)
                {
                    MessageBox.Show(this.PluginForm, "Informplugin message received by Plugintest! Message was: " + receivedstr);
                }*/
            }

            //string returnstr = "Return string by Plugintest";
            return BackupData.CurrentLine;
        }

        //This is a function call made to all plugin dll files
        //The function can be called by macros or by another plugin
        //The passed parameter is an object and there is no return value
        public void Informplugins_event(object Message)
        {
            if (!(PluginForm == null || PluginForm.IsDisposed))
            {
                //string receivedstr = Message as string;
                //MessageBox.Show(this.PluginForm, "Informplugins message received by Plugintest! Message was: " + receivedstr);
            }
        }

        //Called when the user presses a button on the UCCNC GUI or if a Callbutton function is executed.
        //The int buttonnumber parameter is the ID of the caller button.
        // The bool onscreen parameter is true if the button was pressed on the GUI and is false if the Callbutton function was called.
        /*public void Buttonpress_event(int buttonnumber, bool onscreen)
        {
            if (onscreen)
            {
                if (buttonnumber == 128)
                {
                    
                }
            }
        }*/

        //Called when the user clicks the toolpath viewer
        //The parameters X and Y are the click coordinates in the model space of the toolpath viewer
        //The Istopview parameter is true if the toolpath viewer is rotated into the top view,
        //because the passed coordinates are only precise when the top view is selected.
        /*public void Toolpathclick_event(double X, double Y, bool Istopview)
        {
            
        }*/

        //Called when the user clicks and enters a Textfield on the screen
        //The labelnumber parameter is the ID of the accessed Textfield
        //The bool Ismainscreen parameter is true is the Textfield is on the main screen and false if it is on the jog screen
        /*public void Textfieldclick_event(int labelnumber, bool Ismainscreen)
        {
            if (Ismainscreen)
            {
                if (labelnumber == 1000)
                {
                    
                }
            }
        }*/

        //Called when the user enters text into the Textfield and it gets validated
        //The labelnumber parameter is the ID of the accessed Textfield
        //The bool Ismainscreen parameter is true is the Textfield is on the main screen and is false if it is on the jog screen.
        //The text parameter is the text entered and validated by the user
        /*public void Textfieldtexttyped_event(int labelnumber, bool Ismainscreen, string text)
        {
            if (Ismainscreen)
            {
                if (labelnumber == 1000)
                {
                    
                }
            }
        }*/

        //Called when the user click an imageview control on the UCCNC GUI.
        //The MouseEventArgs e parameter contains the click coordinates on the control and the mouse button used to click etc.
        //The int labelnumber parameter is the ID of the clicked imageview.
        // The bool onscreen parameter is true if the imageview was clicked on the GUI and is false if it was clicked on the jog screen.
        /*public void Imageviewclick_event(MouseEventArgs e, int labelnumber, bool Ismainscreen)
        {
            
        }*/

        //Called when the user presses the Cycle start button and before the Cycle starts
        //This event may be used to show messages or do actions on Cycle start 
        //For example to cancel the Cycle if a condition met before the Cycle starts with calling the Button code 130 Cycle stop
        public void Cyclethreadstart_event()
        {
            //MessageBox.Show("Cycle is starting...", );
            BackupData.CurrentLine = 0;
            BackupData.CurrentTime = GetCurrentTime();
            BackupData.LoadedFile = GetLoadedFile();
            LineManager.Init();
            StopWatchTimer.Restart();
            LoopStop = false;
        }

        public void Cyclethreadfinish_event()
        {
            LoopStop = true;
            StopWatchTimer.Stop();

            try
            {
                LineManager.Close();
                BackupManager.DeleteBackups();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private string GetCurrentLineString()
        {
            return UC.Getfield(true, GcodeLineID);
        }

        private uint GetCurrentLine()
        {
            return uint.Parse(GetCurrentLineString());
        }

        private string GetCurrentTime()
        {
            return UC.Getfield(true, CurrentTimeID);
        }

        private string GetLoadedFile()
        {
            return UC.Getfield(true, LoadedFileID).Trim();
        }
    }
}
