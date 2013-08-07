using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace MFCcontrol
{
    public partial class FurnaceControl : UserControl
    {
        internal SerialPort port;
        internal Form1 parentForm;
        internal int presTemp;
        internal bool controlFurnaceInRecipe;
        internal bool controlFurnace;
        internal ManualFurnaceControlForm manFurnaceControlForm1;
        internal int startSetPoint;
        internal volatile bool commBusy;

        public FurnaceControl()
        {
            InitializeComponent();
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            turnOnHeater();
        }

        internal void turnOnHeater()
        {
            port.Write((char)2 + "01010WWRD0121,01,0001" + (char)3 + '\r');
            heaterStateBox.Text = "ON";
        }

        internal void turnOffHeater()
        {
            port.Write((char)2 + "01010WWRD0121,01,0000" + (char)3 + '\r');
            heaterStateBox.Text = "OFF";
        }

        private void FurnaceControl_Load(object sender, EventArgs e)
        {
            DisableUserControl();
            
            if (Properties.Settings.Default.FurnaceControlEnable == true)
                furnaceControlCheckBox.Checked = true;

        }

        private void offButton_Click(object sender, EventArgs e)
        {
            turnOffHeater();

        }

        

        internal string UpdatePresTemperature()
        {
            if (commBusy == true)
            {
                return "timeout";
            }
            
            // don't check temperature if furnace control is turned off

            if (furnaceControlCheckBox.Checked == false)
                return "Comm. OFF";

            commBusy = true;

            //\x0201010WRDD002,01\03 
            string inTemp;
            port.Write((char)2 + "01010WRDD0002,01" + (char)3 + '\r');
            try
            {
                // alternative
                 //                returnBytes = port.Read(inRead, 0, 11);
                // inTemp = new string (inRead);
                 

                inTemp = port.ReadTo("\r");
                if ((inTemp.Length >= 10) && parentForm.HasHexNumber(inTemp))
                    presTemp = Convert.ToInt32(inTemp.Substring(7, 4), 16);
                else
                    presTemp = -1;
            }
            catch
            {
                inTemp = "timeout";
            }

            commBusy = false;

            return inTemp;

        }

        internal void DisableUserControl()
        {
            onButton.Enabled = false;
            offButton.Enabled = false;
            manualFurnaceControlButton.Enabled = false;
            uploadFurnaceTempProfileButton.Enabled = false;
            //setTempUpDown1.Enabled = false;
            //furnaceControlCheckBox.Enabled = false;

        }

        internal void EnableUserControl()
        {
            onButton.Enabled = true;
            offButton.Enabled = true;
            manualFurnaceControlButton.Enabled = true;
            if (controlFurnaceInRecipe == true)
                uploadFurnaceTempProfileButton.Enabled = true;
            //setTempUpDown1.Enabled = true;
            //furnaceControlCheckBox.Enabled = true;

        }

        

        private void furnaceControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (furnaceControlCheckBox.Checked == true)
            {
                try
                {
                    port = new SerialPort("COM1", 9600, Parity.Even, 8, StopBits.One);
                    port.Open();
                    port.ReadTimeout = 50;

                }
                catch
                {
                    string messageBoxText = "Do you want to exit?";
                    string caption = "COM1 Problem";
                    var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                }
                EnableUserControl();
                parentForm.timerFurnaceTemp.StartTimer();

                controlFurnace = true;
                Properties.Settings.Default.FurnaceControlEnable = true;
            }
            else
            {
                parentForm.timerFurnaceTemp.StopTimer();
                port.Close();
                DisableUserControl();

                controlFurnace = false;
                Properties.Settings.Default.FurnaceControlEnable = false;

            }
        }

        private void manualFurnaceControlButton_Click(object sender, EventArgs e)
        {
            manFurnaceControlForm1 = new ManualFurnaceControlForm();
            manFurnaceControlForm1.parentForm = this;
            manFurnaceControlForm1.Show();
        }


        public void AdvanceRecipe()
        {
            if (commBusy == true)
            {
                while (commBusy == true)
                    Thread.Sleep(50);
            }

            commBusy = true;

            try
            {
                //Advance to Next step
                // \x0201010WWRD0123,01,0001\x03

                port.Write((char)2 + "01010WWRD0123,01,0001"  + (char)3 + '\r');

                Thread.Sleep(50);
            }
            catch
            {
                string messageBoxText = "Problem Sending Commands to Furnace";
                string caption = "COM1 Problem";
                var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            commBusy = false;

        }

        private void uploadFurnaceTempProfileButton_Click(object sender, EventArgs e)
        {

            int[] nonZeroFurnaceSPs = new int[17];
            int[] nonZeroFurnaceSPtimestamps = new int[17];
            
            int [] actualFurnaceSPs = new int[17];
            int [] actualFurnaceTMs = new int [17];
            int numOfSPs = 0;

            //turnOffHeater();



            // Create new arrays which contain actual heater temp. change events

            for (int i = 0; i < (parentForm.FurnaceTempList_i).Count; i++)
            {
                if (parentForm.FurnaceTempList_i[i] >= 0)
                {
                    nonZeroFurnaceSPs[numOfSPs] = parentForm.FurnaceTempList_i[i];
                    nonZeroFurnaceSPtimestamps[numOfSPs+1] = Convert.ToInt32(parentForm.ADoutTableValues_d[i][0]);
                    numOfSPs++;
                }
            }



            for (int i = 0; i < numOfSPs; i++)
            {
                    actualFurnaceSPs[i] = nonZeroFurnaceSPs[i];

                    //actualFurnaceTMs[i] = nonZeroFurnaceSPtimestamps[i+1] -nonZeroFurnaceSPtimestamps[i] ;
                    
                // set maximum tm time
                actualFurnaceTMs[i] = 4095;
            }
            actualFurnaceTMs[numOfSPs] = -1;



            if (commBusy == true)
            {
                while (commBusy == true)
                    Thread.Sleep(50);
            }

            commBusy = true;

            try
            {
                //Load SSP 
                port.Write((char)2 + "01010WWRD0228,01," + startSetPoint.ToString("X4") + (char)3 + '\r');

                Thread.Sleep(50);

                //make JC = 0 so furnace shuts down when recipe is over
                port.Write((char)2 + "01010WWRD0261,01," + "0000" + (char)3 + '\r');

                Thread.Sleep(50);
            }
            catch
            {
                string messageBoxText = "Problem Sending Commands to Furnace";
                string caption = "COM1 Problem";
                var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            //Load SP1, SP2, TM1, TM2
            

            for (int i = 0; i < numOfSPs; i++)
            {
                string spName = (229 + i * 2 ).ToString();
                string tmName = (230 + i * 2).ToString();
                    try
                    {
                        port.Write((char)2 + "01010WWRD0" + spName + ",01," + actualFurnaceSPs[i].ToString("X4") + (char)3 + '\r');

                        Thread.Sleep(50);

                        //            set temperature to 200
                        //\x0201010WWRD0229,01,00C8\x03
                        //port.Write((char)2 + "01010WWRD0" + tmName + ",01," + actualFurnaceTMs[i].ToString("X4") + (char)3 + '\r');

                        //Thread.Sleep(50);

                        //Advance to Next step
                        // \x0201010WWRD0123,01,0001\x03

                        ////            set sp1 time (minutes), 68 hr
                        ////\x0201010WWRD0230,01,0FFF\x03
                        port.Write((char)2 + "01010WWRD0229,01,0FFF" + (char)3 + '\r');
                        Thread.Sleep(50);

                    }
                    catch
                    {
                        string messageBoxText = "Problem Sending Commands to Furnace";
                        string caption = "COM1 Problem";
                        var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }

                //Load Last SP, TM
            string spName2 = (229 + numOfSPs*2).ToString();
            string tmName2 = (230 + numOfSPs*2).ToString();        


                    try
                    {
                        port.Write((char)2 + "01010WWRD0" + spName2 +",01," + 0.ToString("X4") + (char)3 + '\r');

                        Thread.Sleep(50);

                        //            write -1 to furnace controller, TM, turns furnace off
                        port.Write((char)2 + "01010WWRD0" + tmName2 +",01," + "FFFF" + (char)3 + '\r');

                        Thread.Sleep(50);

                    }
                    catch
                    {
                        string messageBoxText = "Problem Sending Commands to Furnace";
                        string caption = "COM1 Problem";
                        var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }

                    commBusy = false;
            }
        
    }
}
