using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFCcontrol.Properties;

namespace MFCcontrol
{
    public partial class DigitalOutLineStatesForm : Form
    {
        internal DigitalOutputControl parentControl;
        private GenTimer updateTimer;
        
        public DigitalOutLineStatesForm()
        {
            InitializeComponent();
        }

        private void DigitalOutLineStatesForm_Load(object sender, EventArgs e)
        {
            CheckBox currentCheckBox;

            for (int i = 1; i <= 8; i++)
            {
                currentCheckBox = (CheckBox) tableLayoutPanel1.Controls["digitalOutCheckBox" + i.ToString("0")];

                if ((currentCheckBox.Checked == true) && (parentControl.digitalOutStates[i - 1] == false))
                    currentCheckBox.Checked = false;
                else if ((currentCheckBox.Checked == false) && (parentControl.digitalOutStates[i - 1] == true))
                    currentCheckBox.Checked = true;
               
                currentCheckBox.CheckedChanged += DigOutCheckedChanged;

            }

            updateTimer = new GenTimer();
            updateTimer.SetInterval(Settings.Default.DigitalOutRefreshTime);
            updateTimer.TimerElapsed += UpdateTimerHander;
            updateTimer.Enable();

            if (Settings.Default.DigitalOutRefreshEnable == true)
                refreshListCheckBox.Checked = true;

        }

        private void UpdateTimerHander(object sender, EventArgs e)
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)UpdateTimer);
                return;
            }

            CheckBox currentCheckBox;

            for (int i = 1; i <= 8; i++)
            {
                currentCheckBox = (CheckBox)tableLayoutPanel1.Controls["digitalOutCheckBox" + i.ToString("0")];

                if ((currentCheckBox.Checked == true) && (parentControl.digitalOutStates[i - 1] == false))
                    currentCheckBox.Checked = false;
                else if ((currentCheckBox.Checked == false) && (parentControl.digitalOutStates[i - 1] == true))
                    currentCheckBox.Checked = true;

                currentCheckBox.CheckedChanged += DigOutCheckedChanged;

            }


        }


        private void DigOutCheckedChanged(object sender, EventArgs e)
        {
            //string relayName = "k" + ((CheckBox)sender).Name.Substring(8);
            int digOutNum = Convert.ToInt32( ((CheckBox)sender).Name.Substring(18) ) - 1;

            ((CheckBox)sender).CheckedChanged -= DigOutCheckedChanged;

            if (((CheckBox)sender).Checked == true)
                parentControl.digitalOutStates[digOutNum] = true;
            else
                parentControl.digitalOutStates[digOutNum] = false;

            parentControl.digitalWrite.UpdateDigitalOutPort(parentControl.digitalOutLineArray[digOutNum], parentControl.digitalOutStates[digOutNum]);

            ((CheckBox)sender).CheckedChanged += DigOutCheckedChanged;
        }

        private void DigitalOutLineStatesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer.StopTimer();
            parentControl.viewDigitalOutStateButton.Enabled = true;
            parentControl.configureDigitalOutButton.Enabled = true;
            parentControl.enableDigitalOutCheckBox.Enabled = true;
        }

        private void refreshListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (refreshListCheckBox.Checked == true)
                updateTimer.StartTimer();
            else
                updateTimer.StopTimer();

            Settings.Default.DigitalOutRefreshEnable = refreshListCheckBox.Checked;
        }

        private void refreshRateUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.DigitalOutRefreshTime = Convert.ToInt32(refreshRateUpDown.Value);
            updateTimer.SetInterval(Settings.Default.DigitalOutRefreshTime);
        }

       
    }
}
