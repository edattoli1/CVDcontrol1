using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.DAQmx;


namespace MFCcontrol
{
    public partial class ConfigBiasOutForm : Form
    {
        public ConfigBiasOutForm()
        {
            InitializeComponent();
        }

        private void ConfigBiasOutForm_Load(object sender, EventArgs e)
        {
            string[] aoChannels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External);
            vgsAoChanComboBox.Items.AddRange(aoChannels);
            vdsAoChanComboBox.Items.AddRange(aoChannels);

            vgsAoChanComboBox.SelectedIndex = vgsAoChanComboBox.FindStringExact(Properties.Settings.Default.sensorVgsDaqAOchan);
            vdsAoChanComboBox.SelectedIndex = vdsAoChanComboBox.FindStringExact(Properties.Settings.Default.sensorVdsDaqAOchan);

            daqAoMaxRangeUpDown.Value = Convert.ToDecimal(Properties.Settings.Default.sensorBiasMaxRange);
            daqAoMinRangeUpDown.Value = Convert.ToDecimal(Properties.Settings.Default.sensorBiasMinRange);


        }

        private void saveConfigBiasForm_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.sensorVdsDaqAOchan = vdsAoChanComboBox.Text;
            Properties.Settings.Default.sensorVgsDaqAOchan = vgsAoChanComboBox.Text;

            Properties.Settings.Default.sensorBiasMaxRange = Convert.ToDouble(daqAoMaxRangeUpDown.Value);
            Properties.Settings.Default.sensorBiasMinRange = Convert.ToDouble(daqAoMinRangeUpDown.Value);

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelConfigBiasForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
