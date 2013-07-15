using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.ModularInstruments.NISwitch;
using NationalInstruments.ModularInstruments.SystemServices.DeviceServices;
using System.Reflection;
using MFCcontrol.Properties;

namespace MFCcontrol
{
    public partial class ConfigureSwitchMatrix : Form
    {
        
        public ConfigureSwitchMatrix()
        {
            InitializeComponent();
            LoadTopology();
            LoadSwitchDeviceNames();
        }

        private void LoadTopology()
        {
            Type myType = typeof(SwitchDeviceTopology);
            PropertyInfo[] properties = myType.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                topologyNameComboBox.Items.Add(prop.GetValue(myType, null).ToString());
            }
            topologyNameComboBox.SelectedIndex = topologyNameComboBox.FindStringExact(Settings.Default.SwitchTopologyName);
        }
        private void LoadSwitchDeviceNames()
        {
            ModularInstrumentsSystem modularInstrumentsSystem = new ModularInstrumentsSystem("NI-SWITCH");
            foreach (DeviceInfo device in modularInstrumentsSystem.DeviceCollection)
            {
                resourceNameComboBox.Items.Add(device.Name);
            }
            resourceNameComboBox.SelectedIndex = resourceNameComboBox.FindStringExact(Settings.Default.PxiResourceName);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.PxiResourceName = resourceNameComboBox.Text;
            Settings.Default.SwitchTopologyName = topologyNameComboBox.Text;
            Settings.Default.Save();
            this.Close();
        }


    }



}
