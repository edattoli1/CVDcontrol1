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
using NationalInstruments.DAQmx;


namespace MFCcontrol
{
    public partial class ConfigureMFCs : Form
    {
        internal Form1 parentForm;
        
        public ConfigureMFCs(Form1 parentFormIn)
        {
            InitializeComponent();
            parentForm = parentFormIn;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TextBox curMfcTypeBox;
            NumericUpDown curMfcMaxFlowUpDown;
            ComboBox curMfcAinComboBox, curMfcAoutComboBox;

            for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
            {
                curMfcTypeBox = (TextBox) tableLayoutPanel1.Controls["mfcTypeBox" + (i + 1).ToString()];
                parentForm.mfcGasNames[i] = curMfcTypeBox.Text;

                curMfcMaxFlowUpDown = (NumericUpDown) tableLayoutPanel1.Controls["mfcMaxFlowUpDown" + (i + 1).ToString()];
                parentForm.maxFlowMFCs[i] = Convert.ToInt32(curMfcMaxFlowUpDown.Value);

                curMfcAinComboBox = (ComboBox)tableLayoutPanel1.Controls["mfcAinComboBox" + (i + 1).ToString()];
                if (curMfcAinComboBox.Text != null)
                    parentForm.mfcAinChannels[i] = curMfcAinComboBox.Text;

                curMfcAoutComboBox = (ComboBox)tableLayoutPanel1.Controls["mfcAoutComboBox" + (i + 1).ToString()];
                if (curMfcAoutComboBox.Text != null)
                    parentForm.mfcAoutChannels[i] = curMfcAoutComboBox.Text;
            }

            Properties.Settings.Default.MfcAinChannelsList = Util.StringArrayToString(parentForm.mfcAinChannels);
            Properties.Settings.Default.MfcAoutChannelsList = Util.StringArrayToString(parentForm.mfcAoutChannels);

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigureMFCs_Load(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                TextBox curMfcTypeBox;
                NumericUpDown curMfcMaxFlowUpDown;
                ComboBox curMfcAinComboBox, curMfcAoutComboBox;
                string[] aiChannels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External);
                string[] aoChannels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External);

                for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
                {
                    curMfcTypeBox = (TextBox) tableLayoutPanel1.Controls["mfcTypeBox" + (i + 1).ToString("0")];
                    //Debug.WriteLine("mfcTypeBox" + (i + 1).ToString("0"));
                    curMfcTypeBox.Text = parentForm.mfcGasNames[i];
                    curMfcMaxFlowUpDown = (NumericUpDown) tableLayoutPanel1.Controls["mfcMaxFlowUpDown" + (i + 1).ToString()];
                    curMfcMaxFlowUpDown.Value = (parentForm.maxFlowMFCs[i]);

                    curMfcAinComboBox = (ComboBox)tableLayoutPanel1.Controls["mfcAinComboBox" + (i + 1).ToString()];
                    curMfcAinComboBox.Items.AddRange(aiChannels);
                    curMfcAinComboBox.Items.Add("");
                    curMfcAinComboBox.SelectedIndex = curMfcAinComboBox.FindStringExact(parentForm.mfcAinChannels[i]);
                    //if (i < aiChannels.Length)
                    //    curMfcAinComboBox.SelectedIndex = i;
                   // curMfcAinComboBox.SelectedText
                    curMfcAoutComboBox = (ComboBox)tableLayoutPanel1.Controls["mfcAoutComboBox" + (i + 1).ToString()];
                    curMfcAoutComboBox.Items.AddRange(aoChannels);
                    //if (i < aoChannels.Length)
                    //    curMfcAoutComboBox.SelectedIndex = i;
                    curMfcAoutComboBox.Items.Add("");
                    curMfcAoutComboBox.SelectedIndex = curMfcAoutComboBox.FindStringExact(parentForm.mfcAoutChannels[i]);
                }
                

            }

        }
    }
}
