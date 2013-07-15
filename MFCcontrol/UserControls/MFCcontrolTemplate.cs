using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MFCcontrol
{
    public partial class MFCcontrolTemplate: UserControl
    {
        protected int mfcNumber;

        //Set by parent Form after initiation of parent form
        public Form1 parentForm; 
        
        public MFCcontrolTemplate()
        {
            InitializeComponent();
            mfc1TextBox.Value = Convert.ToDecimal(0);
            mfc1CheckBox.Enabled = true;
            mfc1TextBox.Enabled = true;
        }

        private void MFCcontrolTemplate_Load(object sender, EventArgs e)
        {

        }

        //Sets unique MFC number (program settings file will have info related to this mfc)

        public void SetMFCnumber (int numberIn)  //, MFCSettings mfcSettingsIn)
        {
            mfcNumber = numberIn;

            mfc1GasName.Text = parentForm.mfcGasNames[mfcNumber - 1];
            mfc1TextBox.Maximum = Convert.ToDecimal(parentForm.maxFlowMFCs[mfcNumber - 1]);
            mfc1maxLabel.Text = parentForm.maxFlowMFCs[mfcNumber - 1].ToString();
            mfc1TextBox.Enabled = parentForm.stateMFCs[mfcNumber - 1];
            mfc1CheckBox.Checked = parentForm.stateMFCs[mfcNumber - 1];
            mfc1PlotCheck.Checked =parentForm.mfcPlotEnableArray[mfcNumber - 1];
            mfc1Display.Text = mfcNumber.ToString();
            mfc1PresFlowBox.Text = 0.ToString();


        }

        public void UpdateConfig()
        {

            mfc1GasName.Text = parentForm.mfcGasNames[mfcNumber - 1];
            mfc1TextBox.Maximum = Convert.ToDecimal(parentForm.maxFlowMFCs[mfcNumber - 1]);
            mfc1maxLabel.Text = parentForm.maxFlowMFCs[mfcNumber - 1].ToString();
            mfc1CheckBox.Checked = parentForm.stateMFCs[mfcNumber - 1];

        }

        public void UpdatePresFlowBox(double inFlow)
        {
            mfc1PresFlowBox.Text = inFlow.ToString("0.00");
        }

        public void UpdateSetFlowValue(double inFlow)
        {
            mfc1TextBox.Value = Convert.ToDecimal(inFlow);
        }

        public void ZeroControl()
        {
            mfc1TextBox.Value = Convert.ToDecimal(0);
        }

        public void EnableUserControl()
        {
            mfc1TextBox.Enabled = true;
            mfc1CheckBox.Enabled = true;
        }

        public void DisableUserControl()
        {
            mfc1TextBox.Enabled = false;
            mfc1CheckBox.Enabled = false;
        }



        private void mfc1PlotCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (mfc1PlotCheck.Checked)
                parentForm.mfcPlotEnableArray[mfcNumber - 1] = true;
            else
                parentForm.mfcPlotEnableArray[mfcNumber - 1] = false;

            parentForm.MfcPlotCheck_CheckedChanged(mfcNumber, mfc1PlotCheck.Checked);
        }

        private void mfc1TextBox_ValueChanged(object sender, EventArgs e)
        {
            parentForm.mfcTextBox_ValueChanged(mfcNumber, mfc1TextBox.Value);
        }

        private void mfc1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mfc1CheckBox.Checked == false)
            {
                try
                {
                    if (parentForm.mfcAoutChannels[mfcNumber - 1] != "")
                        parentForm.daqOutputMFC.UpdateDaqOut(parentForm.mfcAoutChannels[mfcNumber - 1], 0);
                }
                catch
                {
                    DaqOutputProblem();
                } 
                mfc1TextBox.Enabled = false;
                mfc1TextBox.Value = 0;
                parentForm.stateMFCs[mfcNumber - 1] = false;
            }
            else if (Properties.Settings.Default.mfcMainControlEnable == true)
            {
                mfc1TextBox.Enabled = true;
                try
                {
                    if (parentForm.mfcAoutChannels[mfcNumber - 1] != "")
                        parentForm.daqOutputMFC.UpdateDaqOut(parentForm.mfcAoutChannels[mfcNumber - 1], DaqAction.GetVoltsFromMFCflow(mfc1TextBox.Value.ToString(), mfcNumber-1,parentForm.maxFlowMFCs));
                }
                catch
                {
                    DaqOutputProblem();
                }
                parentForm.stateMFCs[mfcNumber - 1] = true;
            }

            //Save Enabled State of this MFC
            SaveConfig();

        }

        public void SaveConfig()
        {

            Properties.Settings.Default.MfcControlEnableList = Util.BoolArrayToString(parentForm.stateMFCs);
            Properties.Settings.Default.MfcPlotEnableList = Util.BoolArrayToString(parentForm.mfcPlotEnableArray);

            Properties.Settings.Default.Save();
        }


        private void DaqOutputProblem()
        {
            string messageBoxText = "Do you want to exit?";
            string caption = "DAQ Output Problem";
            var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Environment.Exit(0);
        }


    }
}
