using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using NationalInstruments.ModularInstruments.NISwitch;
using NationalInstruments.ModularInstruments.SystemServices.DeviceServices;
using MFCcontrol.Properties;


namespace MFCcontrol
{

    public partial class SwitchStateForm : Form
    {
        
        internal SwitchMatrixControl parentControl;
        internal NISwitch switchSession;
        private NationalInstruments.PrecisionTimeSpan maximumTime = new NationalInstruments.PrecisionTimeSpan(5);
        private GenTimer refreshTimer;
        private CheckBox[] cb;
        
        public SwitchStateForm()
        {
          InitializeComponent();
          
        }

        private void SwitchStateForm_Load(object sender, EventArgs e)
        {
            parentControl.enableSwitchCheckBox.Enabled = false;
            
            
            cb = new CheckBox[Settings.Default.SwitchMatrixRowsNum * Settings.Default.SwitchMatrixColsNum];
            Label[] lbl = new Label[Settings.Default.SwitchMatrixColsNum];

            int switchIterator = 0;

            DisplayPartSwitchMatrix(cb, lbl, ref switchIterator, 0, 10, 10);
            DisplayPartSwitchMatrix(cb, lbl, ref switchIterator, 34, 10, 110);
            DisplayPartSwitchMatrix(cb, lbl, ref switchIterator, 68, 10, 210);
            DisplayPartSwitchMatrix(cb, lbl, ref switchIterator, 102, 10, 310);

            refreshTimer = new GenTimer();
            refreshTimer.SetInterval(Settings.Default.SwitchRefreshMs);
            refreshTimer.TimerElapsed += refreshTimerHandler;

            if (Settings.Default.SwitchRefreshEnable == true)
            {
                refreshListCheckBox.Checked = true;
            }

            refreshRateUpDown.Value = Convert.ToDecimal(Settings.Default.SwitchRefreshMs);

        }

        private void refreshTimerHandler(object obj, EventArgs e)
        {
            RefreshTimer();

        }

        private void RefreshTimer()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action) RefreshTimer);
                return;
            }

            string relayName = "";
            int switchIterator = 0;

            for (int j = 0; j < Settings.Default.SwitchMatrixColsNum; j++)
            {
                for (int i = 0; i < Settings.Default.SwitchMatrixRowsNum; i++)
                {
                    relayName = "kr" + i.ToString() + "c" + j.ToString();
                    
                    // Remove check box's check changed event handler so that refresh of check box state doesn't force a switch / relay state change
                    cb[switchIterator].CheckedChanged -= SwitchStateForm_CheckedChanged;
                    
                    try
                    {

                        // if switch is actually closed and gui says it is open, change state
                        if ((switchSession.RelayOperations.GetRelayPosition(relayName) == SwitchRelayPosition.Close) && (cb[switchIterator].Checked == false))
                        {
                            cb[switchIterator].Checked = true;
                            //Debug.WriteLine("yes");
                        }
                        // if switch is actually open and gui says it is closed, change state
                        else if ((switchSession.RelayOperations.GetRelayPosition(relayName) == SwitchRelayPosition.Open) && (cb[switchIterator].Checked == true))
                        {
                            cb[switchIterator].Checked = false;
                            //Debug.WriteLine("no");
                        }

                    }
                    catch (System.Exception ex)
                    {
                        ShowError(ex.Message);
                    }
                    // Restore normal check box event handler
                    cb[switchIterator].CheckedChanged += SwitchStateForm_CheckedChanged;
                    
                    switchIterator++;
                }
            }
        }

        private void DisplayPartSwitchMatrix(CheckBox[] cb, Label[] lbl, ref int switchIterator, int startSwitch, int originX, int originY)
        {
            int xcoord = originX;
            int ycoord = originY;
            string relayName = "";

            for (int j = startSwitch; j < startSwitch + 34; j++)
            {
                ycoord = originY;

                lbl[j] = new Label();
                lbl[j].Text = j.ToString();
                lbl[j].Location = new Point(xcoord-5, ycoord);
                lbl[j].Visible = true;
                lbl[j].Width = 40;
                lbl[j].Height = 20;
                ycoord += 5;
                this.Controls.Add(lbl[j]);


                for (int i = 0; i < 4; i++)
                {
                    cb[switchIterator] = new CheckBox();
                    relayName = "r" + i.ToString() + "c" + j.ToString();
                    cb[switchIterator].Name = "checkBox" + relayName;
                    cb[switchIterator].Width = 15;
                    cb[switchIterator].Height = 15;

                    ycoord += cb[switchIterator].Height + 2;
                    cb[switchIterator].Visible = true;
                    cb[switchIterator].Location = new Point(xcoord, ycoord);
                    cb[switchIterator].CheckedChanged += SwitchStateForm_CheckedChanged;

                    try
                    {
                        if (switchSession.RelayOperations.GetRelayPosition("k" + relayName) == SwitchRelayPosition.Close)
                            cb[switchIterator].Checked = true;
                        else
                            cb[switchIterator].Checked = false;

                    }
                    catch (System.Exception ex)
                    {
                        ShowError(ex.Message);
                    }


                    this.Controls.Add(cb[switchIterator]);

                    switchIterator++;
                }
                xcoord += 40;
            }
            
        }


        void SwitchStateForm_CheckedChanged(object sender, EventArgs e)
        {
            string relayName = "k" + ((CheckBox)sender).Name.Substring(8);
             //Debug.WriteLine(relayName);
            try
            {
                if ( ((CheckBox) sender).Checked == true)
                    ChangeRelayPosition(relayName, SwitchRelayAction.CloseRelay);
                else
                    ChangeRelayPosition(relayName, SwitchRelayAction.OpenRelay);

            }
            catch (System.Exception ex)
            {
                ShowError(ex.Message);
            }
            //finally
            //{
            //    //Close session to switch module.
            //    //CloseSession();
            //    //ChangeControlState(true);

            //}


            //throw new NotImplementedException();
        }


        private void ChangeRelayPosition(string relayName, SwitchRelayAction position)
        {
            //CloseSession();

            //Open session to the switch module and sets topology
            //InitializeSwitchSession();

            // Open the relay.
            switchSession.RelayOperations.RelayControl(relayName, position);
            // Wait for the relay to activate and debounce.
            //switchSession.Path.WaitForDebounce(maximumTime);
        }


        //private void ChangeControlState(bool isEnabled)
        //{
        //    //this.openRelayButton.Enabled = isEnabled;
        //    //this.closeRelayButton.Enabled = isEnabled;
        //    //this.resourceNameComboBox.Enabled = isEnabled;
        //    //this.topologyNameComboBox.Enabled = isEnabled;
        //    //this.relayNameTextBox.Enabled = isEnabled;
        //}

        private static void ShowError(string message)
        {
            if (string.IsNullOrEmpty(message))
                message = "Unexpected Error";
            MessageBox.Show(message, "Error"); ;
        }

        private void CloseSession()
        {
            //Debug.WriteLine("Closing Session");
            if (switchSession != null)
            {
                try
                {
                    switchSession.Close();
                    switchSession = null;
                }
                catch (System.Exception ex)
                {
                    ShowError("Unable to Close Session, Reset the device.\n" + "Error : " + ex.Message);
                    Application.Exit();
                }
            }
        }

        private void SwitchStateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hides the Form
            //this.Visible = false;

            //Allow Main Form Control over Switch Box Enable
            refreshListCheckBox.Checked = false;

            parentControl.enableSwitchCheckBox.Enabled = true;
            parentControl.configureSwitchButton.Enabled = true;
            parentControl.viewSwitchStateButton.Enabled = true;

            // This cancels the closing event, prevents Dispose of the Form
           // e.Cancel = true;
            // Throw OnClosing event (normal behavior on Form Closing)
            //base.OnClosing(e);
        }

        private void refreshListCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            
            if (refreshListCheckBox.Checked == true)
            {
                refreshTimer.StartTimer();
                Settings.Default.SwitchRefreshEnable = true;
            }
            else
            {
                refreshTimer.StopTimer();
                Settings.Default.SwitchRefreshEnable = false;
            }

        }

        private void refreshRateUpDown_ValueChanged(object sender, EventArgs e)
        {
            refreshTimer.SetInterval(Convert.ToDouble(refreshRateUpDown.Value));
            Settings.Default.SwitchRefreshMs = Convert.ToDouble(refreshRateUpDown.Value);
        }

        private void row2CloseAllButton_click(object sender, EventArgs e)
        {
            int switchIterator = 0;
            string relayName = "";

            for (int j = 2; j <= 29; j++)
            {

                    relayName = "kr" + 1.ToString() + "c" + j.ToString();
                    cb[switchIterator].CheckedChanged -= SwitchStateForm_CheckedChanged;
                    try
                    {
                        ChangeRelayPosition(relayName, SwitchRelayAction.CloseRelay);
                    }
                    catch (System.Exception ex)
                    {
                        ShowError(ex.Message);
                    }
                    switchIterator++;
                
            }

            for (int j = 40; j <= 67; j++)
            {

                relayName = "kr" + 1.ToString() + "c" + j.ToString();
                cb[switchIterator].CheckedChanged -= SwitchStateForm_CheckedChanged;
                try
                {
                    ChangeRelayPosition(relayName, SwitchRelayAction.CloseRelay);
                }
                catch (System.Exception ex)
                {
                    ShowError(ex.Message);
                }
                switchIterator++;

            }

        }

        private void openAllButton_Click(object sender, EventArgs e)
        {
            int switchIterator = 0;
            string relayName = "";

            for (int j = 0; j < Settings.Default.SwitchMatrixColsNum; j++)
            {
                for (int i = 0; i < Settings.Default.SwitchMatrixRowsNum; i++)
                {
                    relayName = "kr" + i.ToString() + "c" + j.ToString();
                    cb[switchIterator].CheckedChanged -= SwitchStateForm_CheckedChanged;
                    try
                    {
                        ChangeRelayPosition(relayName, SwitchRelayAction.OpenRelay);

                    }
                    catch (System.Exception ex)
                    {
                        ShowError(ex.Message);
                    }
                    switchIterator++;
                }
        }
        }
    }
}
