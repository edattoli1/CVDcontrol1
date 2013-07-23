using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFCcontrol
{
    public partial class ManualFurnaceControlForm : Form
    {

        internal FurnaceControl parentForm;
        
        public ManualFurnaceControlForm()
        {
            InitializeComponent();
        }

        private void setTempUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ///set start sp amount, to 200
            // \x0201010WWRD0228,01,00C8\x03

            int newTemp = Convert.ToInt32(setTempUpDown1.Value);

            UpdateSetTemperature(newTemp);
        }

        internal void UpdateSetTemperature(int newTemp)
        {
            try
            {
                parentForm.port.Write((char)2 + "01010WWRD0228,01," + newTemp.ToString("X4") + (char)3 + '\r');

                //            set temperature to 200
                //\x0201010WWRD0229,01,00C8\x03
                parentForm.port.Write((char)2 + "01010WWRD0229,01," + newTemp.ToString("X4") + (char)3 + '\r');

                //            set sp1 time (minutes), 68 hr
                //\x0201010WWRD0230,01,0FFF\x03
                parentForm.port.Write((char)2 + "01010WWRD0229,01,0FFF" + (char)3 + '\r');
            }
            catch
            {
                string messageBoxText = "Problem Sending Commands to Furnace";
                string caption = "COM1 Problem";
                var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            lastSetTempBox.Text = newTemp.ToString();
        }


    }
}
