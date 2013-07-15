using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFCcontrol
{
    public partial class SensorBiasControl : UserControl
    {
        internal Form1 parentForm;
        static private ConfigBiasOutForm configBiasForm1;
        private DaqAction daqOutputBiases;
        
        public SensorBiasControl()
        {
            InitializeComponent();
        }

        private void configBiasOutputButton_Click(object sender, EventArgs e)
        {
            configBiasForm1 = new ConfigBiasOutForm();

            configBiasForm1.ShowDialog();
        }

        private void biasOutsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (biasOutsBox.Checked == true)
            {
                VgsUpDown.Enabled = true;
                VdsUpDown.Enabled = true;
                ZeroAllBiasOutputs();
            }
            else
            {
                VgsUpDown.Enabled = false;
                VdsUpDown.Enabled = false;
                ZeroAllBiasOutputs();
            }
            Properties.Settings.Default.sensorBiasEnable = biasOutsBox.Checked;
        }

        private void vdsLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vdsLockCheckBox.Checked == true)
            {
                VdsUpDown.Enabled = false;
            }
            else if ((vdsLockCheckBox.Checked == false) && (Properties.Settings.Default.sensorBiasEnable == true))
            {
                VdsUpDown.Enabled = true;
            }
            Properties.Settings.Default.sensorVdsDaqLock = vdsLockCheckBox.Checked;
        }

        private void vgsLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vgsLockCheckBox.Checked == true)
            {
                VgsUpDown.Enabled = false;
            }
            else if ((vgsLockCheckBox.Checked == false) && (Properties.Settings.Default.sensorBiasEnable == true))
            {
                VgsUpDown.Enabled = true;
            }
            Properties.Settings.Default.sensorVgsDaqLock = vgsLockCheckBox.Checked;
        }

        private void VdsUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                daqOutputBiases.UpdateDaqOut(Properties.Settings.Default.sensorVdsDaqAOchan, Convert.ToDouble(VdsUpDown.Value));
            }
            catch
            {
                parentForm.DaqOutputProblem();
            }
            vdsPresValTextBox.Text = VdsUpDown.Value.ToString("0.00");
        }

        private void VgsUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                daqOutputBiases.UpdateDaqOut(Properties.Settings.Default.sensorVgsDaqAOchan, Convert.ToDouble(VgsUpDown.Value));
            }
            catch
            {
                parentForm.DaqOutputProblem();
            }
            vgsPresValTextBox.Text = VgsUpDown.Value.ToString("0.00");
        }

        internal void ZeroAllBiasOutputs()
        {
            //Exit this function if at on startup neither of these structures are inited yet
            if (daqOutputBiases == null || parentForm == null)
                return;
            
            try
            {
                daqOutputBiases.UpdateDaqOut(Properties.Settings.Default.sensorVgsDaqAOchan, Convert.ToDouble(0));
                daqOutputBiases.UpdateDaqOut(Properties.Settings.Default.sensorVdsDaqAOchan, Convert.ToDouble(0));
            }
            catch
            {
                parentForm.DaqOutputProblem();
            }
            vdsPresValTextBox.Text = "0.00";
            vgsPresValTextBox.Text = "0.00";
            VgsUpDown.Value = 0;
            VdsUpDown.Value = 0;
        }

        internal void SensorBiasControlInit()
        {
            tableLayoutPanel3.CellPaint += parentForm.tableLayoutPanel_CellPaint;
            
            daqOutputBiases = new DaqAction(Properties.Settings.Default.sensorBiasMinRange, Properties.Settings.Default.sensorBiasMaxRange);

            //If DAQ Analog Out is Enabled in Settings file, Update Checkmark and Zero Bias Outputs
            if (Properties.Settings.Default.sensorBiasEnable == true)
            {
                biasOutsBox.Checked = Properties.Settings.Default.sensorBiasEnable;
                //ZeroAllBiasOutputs();
            }


            // Ready fields for Daq Bias Output
            VdsUpDown.Maximum = Convert.ToDecimal(Properties.Settings.Default.sensorBiasMaxRange);
            VgsUpDown.Maximum = Convert.ToDecimal(Properties.Settings.Default.sensorBiasMaxRange);
            VdsUpDown.Minimum = Convert.ToDecimal(Properties.Settings.Default.sensorBiasMinRange);
            VgsUpDown.Minimum = Convert.ToDecimal(Properties.Settings.Default.sensorBiasMinRange);



        }


    }
}
