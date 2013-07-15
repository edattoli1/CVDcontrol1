using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFCcontrol.Properties;

namespace MFCcontrol.UserControls
{
    public partial class GateSweepControl : UserControl
    {
        
        internal Form1 parentForm;        

        public GateSweepControl()
        {
            InitializeComponent();
        }

        private void enableGateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableGateCheckBox.Checked == true)
            {
                parentForm.k617.InitSession();
                stepSweepUpDown.Enabled = true;
                hiSweepUpDown.Enabled = true;
                lowSweepUpDown.Enabled = true;
                manSetUpDown.Enabled = true;
                gateSettleTimeUpDown.Enabled = true;
                parentForm.k617.ChangeVolt(0);
                presGateVOut.Text = 0.ToString();
            }
            else
            {
                manSetUpDown.Value = 0;
                parentForm.k617.ChangeVolt(0);
                parentForm.k617.EndSession();
                presGateVOut.Text = 0.ToString();
                stepSweepUpDown.Enabled = false;
                hiSweepUpDown.Enabled = false;
                lowSweepUpDown.Enabled = false;
                manSetUpDown.Enabled = false;
                gateSettleTimeUpDown.Enabled = false;

            }

            Settings.Default.GateSweepEnable = enableGateCheckBox.Checked;

        }

        internal void onCloseProgram()
        {
            parentForm.k617.ChangeVolt(0);
            parentForm.k617.EndSession();
        }

        private void manSetUpDown_ValueChanged(object sender, EventArgs e)
        {
            parentForm.k617.ChangeVolt(Convert.ToDouble(manSetUpDown.Value));
            presGateVOut.Text = manSetUpDown.Value.ToString();
        }

        private void GateSweepControl_Load(object sender, EventArgs e)
        {
            if (Settings.Default.GateSweepEnable == true)
                enableGateCheckBox.Checked = true;
            else
                enableGateCheckBox.Checked = false;

            gateSettleTimeUpDown.Value = Settings.Default.GateSettleTime;

            lowSweepUpDown.Value = Convert.ToDecimal(Settings.Default.GateLow);
            hiSweepUpDown.Value = Convert.ToDecimal(Settings.Default.GateHi);
            stepSweepUpDown.Value = Convert.ToDecimal(Settings.Default.GateStep);

        }

        private void gateSettleTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.GateSettleTime = Convert.ToInt32(gateSettleTimeUpDown.Value);
        }


        internal void updatePresentGateV(double input)
        {

            if (InvokeRequired)
            {
                BeginInvoke((Action<double>)updatePresentGateV, input);
                return;
            }

            presGateVOut.Text = input.ToString();

        }


        public void DisableUserControl()
        {
            stepSweepUpDown.Enabled = false;
            hiSweepUpDown.Enabled = false;
            lowSweepUpDown.Enabled = false;
            manSetUpDown.Enabled = false;
            gateSettleTimeUpDown.Enabled = false;

        }

        public void EnableUserControl()
        {
            stepSweepUpDown.Enabled = true;
            hiSweepUpDown.Enabled = true;
            lowSweepUpDown.Enabled = true;
            manSetUpDown.Enabled = true;
            gateSettleTimeUpDown.Enabled = true;

        }

        private void lowSweepUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.GateLow = Convert.ToDouble(lowSweepUpDown.Value);
        }

        private void hiSweepUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.GateHi = Convert.ToDouble(hiSweepUpDown.Value);
        }

        private void stepSweepUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.GateStep = Convert.ToDouble(stepSweepUpDown.Value);
        }

    }
}
