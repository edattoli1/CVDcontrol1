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

namespace MFCcontrol
{
    public partial class FurnaceControl : UserControl
    {
        internal SerialPort port;
        internal Form1 parentForm;
        internal int presTemp;
        internal bool controlFurnaceInRecipe;
        internal bool controlFurnace;

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
        }

        internal void turnOffHeater()
        {
            port.Write((char)2 + "01010WWRD0121,01,0000" + (char)3 + '\r');
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

        private void setTempUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ///set start sp amount, to 200
            // \x0201010WWRD0228,01,00C8\x03

            int newTemp = Convert.ToInt32(setTempUpDown1.Value);

            UpdateSetTemperature(newTemp);


        }

        internal string UpdatePresTemperature()
        {
            // don't check temperature if furnace control is turned off

            
            //\x0201010WRDD002,01\03 
            string inTemp;
            port.Write((char)2 + "01010WRDD0002,01" + (char)3 + '\r');
            try
            {
                // alternative
                 //                returnBytes = port.Read(inRead, 0, 11);
                // inTemp = new string (inRead);
                 

                inTemp = port.ReadTo("\r");
            }
            catch
            {
                inTemp = "timeout";
            }

            presTemp = Convert.ToInt32(inTemp);

            return inTemp;

        }

        internal void DisableUserControl()
        {
            onButton.Enabled = false;
            offButton.Enabled = false;
            setTempUpDown1.Enabled = false;
            //furnaceControlCheckBox.Enabled = false;

        }

        internal void EnableUserControl()
        {
            onButton.Enabled = true;
            offButton.Enabled = true;
            setTempUpDown1.Enabled = true;
            //furnaceControlCheckBox.Enabled = true;

        }

        internal void UpdateSetTemperature(int newTemp)
        {
            try
            {
                port.Write((char)2 + "01010WWRD0228,01," + newTemp.ToString("X4") + (char)3 + '\r');

                //            set temperature to 200
                //\x0201010WWRD0229,01,00C8\x03
                port.Write((char)2 + "01010WWRD0229,01," + newTemp.ToString("X4") + (char)3 + '\r');

                //            set sp1 time (minutes), 68 hr
                //\x0201010WWRD0230,01,0FFF\x03
                port.Write((char)2 + "01010WWRD0229,01,0FFF" + (char)3 + '\r');
            }
            catch
            {
                string messageBoxText = "Problem Sending Commands to Furnace";
                string caption = "COM1 Problem";
                var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            lastSetTempBox.Text = newTemp.ToString();
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

    }
}
