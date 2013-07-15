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
using NationalInstruments.DAQmx;

namespace MFCcontrol
{
    public partial class ConfigureDigitalOut : Form
    {
        internal DigitalOutputControl parentControl;
        
        public ConfigureDigitalOut()
        {
            InitializeComponent();


        }

        private void saveExitButton_Click(object sender, EventArgs e)
        {
            ComboBox curDigitalOutComboBox;
            string digitalOutLinesToSave = "";

            for (int i = 1; i <= 8; i++)
            {
                curDigitalOutComboBox = (ComboBox)tableLayoutPanel1.Controls["digitalOutComboBox" + i.ToString("0")];
                digitalOutLinesToSave += curDigitalOutComboBox.Text;
                if (i != 8)
                    digitalOutLinesToSave += ',';
            }

            Settings.Default.DigitalOutputLineNames = digitalOutLinesToSave;
            Settings.Default.Save();
            this.Close();

        }

        private void ConfigureDigitalOut_Load(object sender, EventArgs e)
        {

            string [] digitalOutChannelsAvail = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DOLine, PhysicalChannelAccess.External);

            ComboBox curDigitalOutComboBox;

            for (int i = 1; i <= 8; i++)
            {
                curDigitalOutComboBox = (ComboBox)tableLayoutPanel1.Controls["digitalOutComboBox" + i.ToString("0")];
                curDigitalOutComboBox.Items.AddRange(digitalOutChannelsAvail);
                curDigitalOutComboBox.SelectedIndex = curDigitalOutComboBox.FindStringExact(parentControl.digitalOutLineArray[i-1]);
            }


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
