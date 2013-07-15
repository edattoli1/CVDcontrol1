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
        
        public FurnaceControl()
        {
            InitializeComponent();
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            port.Write((char)2 + "01010WWRD0121,01,0001" + (char)3 + '\r');

        }

        private void FurnaceControl_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FurnaceControlEnable == true)
                furnaceControlCheckBox.Checked = true;
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            port.Write((char)2 + "01010WWRD0121,01,0000" + (char)3 + '\r');

        }

        private void setTempUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ///set start sp amount, to 200
            // \x0201010WWRD0228,01,00C8\x03
            port.Write((char)2 + "01010WWRD0228,01," + Convert.ToInt32(setTempUpDown1.Value).ToString("X4") + (char)3 + '\r');

            //            set temperature to 200
            //\x0201010WWRD0229,01,00C8\x03
            port.Write((char)2 + "01010WWRD0229,01," + Convert.ToInt32(setTempUpDown1.Value).ToString("X4") + (char)3 + '\r');

            //            set sp1 time (minutes), 68 hr
            //\x0201010WWRD0230,01,0FFF\x03
            port.Write((char)2 + "01010WWRD0229,01,0FFF" + (char)3 + '\r');

        }

        internal string UpdatePresTemperature()
        {
            // don't check temperature if furnace control is turned off

            
            //\x0201010WRDD002,01\03 
            string inTemp;
            port.Write((char)2 + "01010WRDD0002,01" + (char)3 + '\r');
            inTemp = port.ReadTo("\r");
            return inTemp;

        }

        private void furnaceControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (furnaceControlCheckBox.Checked == true)
            {
                try
                {
                    port = new SerialPort("COM1", 9600, Parity.Even, 8, StopBits.One);
                    port.Open();
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
                onButton.Enabled = true;
                offButton.Enabled = true;
                setTempUpDown1.Enabled = true;
                parentForm.timerFurnaceTemp.StartTimer();

                Properties.Settings.Default.FurnaceControlEnable = true;
            }
            else
            {
                parentForm.timerFurnaceTemp.StopTimer();
                port.Close();
                onButton.Enabled = false;
                offButton.Enabled = false;
                setTempUpDown1.Enabled = false;


                Properties.Settings.Default.FurnaceControlEnable = false;

            }
        }

    }
}
