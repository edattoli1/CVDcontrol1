using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using NationalInstruments.DAQmx;
using MFCcontrol.Properties;

namespace MFCcontrol
{
    public partial class DigitalOutputControl : UserControl
    {
        internal DaqAction digitalWrite;
        internal string[] digitalOutLineArray;
        internal bool [] digitalOutStates;
        internal static DigitalOutLineStatesForm digOutStatesForm1;
        
        public DigitalOutputControl()
        {
            digitalWrite = new DaqAction();

            digitalOutStates = new bool[Settings.Default.DigitalOutputNumLines];
            for (int i = 0; i < digitalOutStates.Length; i++)
                digitalOutStates[i] = !digitalOutStates[i];
            digitalOutLineArray = Util.StringToStringArray(Settings.Default.DigitalOutputLineNames);

            InitializeComponent();
        }

        private void enableDigitalOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableDigitalOutCheckBox.Checked == true)
            {
                for (int i = 0; i < Settings.Default.DigitalOutputNumLines; i++)
                    digitalWrite.UpdateDigitalOutPort(digitalOutLineArray[i], digitalOutStates[i]);

                viewDigitalOutStateButton.Enabled = true;
            }
            else
            {
                // make sure digital outs are high when control is turned off
                for (int i = 0; i < Settings.Default.DigitalOutputNumLines; i++)
                    digitalWrite.UpdateDigitalOutPort(digitalOutLineArray[i], true);

                viewDigitalOutStateButton.Enabled = false;
            }
            Settings.Default.DigitalOutputEnable = enableDigitalOutCheckBox.Checked;
        }

        private void DigitalOutputControl_Load(object sender, EventArgs e)
        {
            if (Settings.Default.DigitalOutputEnable == true)
                enableDigitalOutCheckBox.Checked = true;
        }

        private void configureDigitalOutButton_Click(object sender, EventArgs e)
        {
            ConfigureDigitalOut configDigOut = new ConfigureDigitalOut();
            configDigOut.parentControl = this;

            configDigOut.ShowDialog();

            // reload Digital Output assignments if change has been made
            digitalOutLineArray = Util.StringToStringArray(Settings.Default.DigitalOutputLineNames);
        }

        private void viewDigitalOutStateButton_Click(object sender, EventArgs e)
        {
            digOutStatesForm1 = new DigitalOutLineStatesForm();
            digOutStatesForm1.parentControl = this;
            viewDigitalOutStateButton.Enabled = false;
            configureDigitalOutButton.Enabled = false;
            enableDigitalOutCheckBox.Enabled = false;
            digOutStatesForm1.Show();
        }

        internal void ZeroAllDigOuts()
        {
            for (int i = 0; i < Settings.Default.DigitalOutputNumLines; i++)
                digitalWrite.UpdateDigitalOutPort(digitalOutLineArray[i], true);

        }

        internal void UpdateDigOutput(int digOutNum, bool state)
        {

            if (state == true)
                digitalOutStates[digOutNum] = true;
            else
                digitalOutStates[digOutNum] = false;

            digitalWrite.UpdateDigitalOutPort(digitalOutLineArray[digOutNum], state);
        }


    }
}
