using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.ModularInstruments.NISwitch;
using NationalInstruments.ModularInstruments.SystemServices.DeviceServices;
using MFCcontrol.Properties;
using System.IO;

namespace MFCcontrol
{
    public partial class SwitchMatrixControl : UserControl
    {
        internal Form1 parentForm;
        internal NISwitch switchSession;
        static private ConfigureSwitchMatrix configSwitchMatrixForm1;
        static private SwitchStateForm switchStateForm1;
        private static ScanDeviceCurrentsForm scanDeviceCurrentsForm1;
        private static ScanListView scanListView1;
        internal bool isDeviceListLoaded = false;
        internal List<string[]> deviceListState;

        public SwitchMatrixControl()
        {
            InitializeComponent();
        }

        private void InitializeSwitchSession()
        {
            switchSession = new NISwitch(Settings.Default.PxiResourceName, Settings.Default.SwitchTopologyName, false, true);
            switchSession.DriverOperation.Warning += new System.EventHandler<Ivi.Driver.WarningEventArgs>(DriverOperationWarning);
        }


        private void CloseSession()
        {
            if (switchSession != null)
            {
                try
                {
                    switchSession.Close();
                    switchSession = null;
                }
                catch (System.Exception ex)
                {
                    ShowError("Unable to Close Session, Reset the device.\n" + "Error : " + ex.Message);
                    Application.Exit();
                }
            }
        }

        private static void ShowError(string message)
        {
            if (string.IsNullOrEmpty(message))
                message = "Unexpected Error";
            MessageBox.Show(message, "Error"); ;
        }

        private void DriverOperationWarning(object sender, Ivi.Driver.WarningEventArgs e)
        {
            MessageBox.Show(e.ToString(), "Warning");
        }

        private void configureSwitchButton_Click(object sender, EventArgs e)
        {
            configSwitchMatrixForm1 = new ConfigureSwitchMatrix ();
            configSwitchMatrixForm1.ShowDialog();
        }

        private void enableSwitchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableSwitchCheckBox.Checked == true)
            {
                InitializeSwitchSession();
                
                Settings.Default.SwitchMatrixEnable = true;

                viewSwitchStateButton.Enabled = true;

                if (isDeviceListLoaded && parentForm.controlPicoammBox.Checked)
                {
                    viewSwitchStateButton.Enabled = true;
                    ScanDeviceCurrentsButton.Enabled = true;
                    sweepMatrixCheckBox.Enabled = true;
                    sweepMatrixCheckBox.Checked = Settings.Default.SweepMatrixDuringRecipe;
                }
            }
            else
            {
                CloseSession();
                Settings.Default.SwitchMatrixEnable = false;
                ScanDeviceCurrentsButton.Enabled = false;
                sweepMatrixCheckBox.Enabled = false;
                viewSwitchStateButton.Enabled = false;
                sweepMatrixCheckBox.Checked = false;
            }

        }

        private void viewSwitchStateButton_Click(object sender, EventArgs e)
        {
            //if (switchStateForm1 == null)
            //{
                switchStateForm1 = new SwitchStateForm();
                switchStateForm1.parentControl = this;
                switchStateForm1.switchSession = switchSession;
            //}

            viewSwitchStateButton.Enabled = false;
            configureSwitchButton.Enabled = false;

            switchStateForm1.Show();
        }

        private void SwitchMatrixControl_Load(object sender, EventArgs e)
        {
            if (Settings.Default.SwitchMatrixEnable == true)
                enableSwitchCheckBox.Checked = true;

            // openFileDialog1 = new OpenFileDialog();

            
        }

        private void loadDeviceListButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialog1.Filter = "Excel2007+|*.xls*";
            
            DialogResult diagResult = this.openFileDialog1.ShowDialog();

            if (diagResult == DialogResult.OK) // Test result.
            {
                if (FileInUse(this.openFileDialog1.FileName) == true)
                    return;

                SShtLoad sshtLoad1 = new SShtLoad();

                deviceListState = sshtLoad1.LoadDeviceList(this.openFileDialog1.FileName);

                // Load enabled devices into parent Form's bool array for device states
                int deviceIterator = 0;
                foreach (string[] rowArray in deviceListState)
                {
                    for (int i = 0; i < rowArray.Length; i++)
                    {
                        if ( rowArray[i] != null)
                            parentForm.devicesToScan[deviceIterator] = true;
                        else
                            parentForm.devicesToScan[deviceIterator] = false;

                        deviceIterator++;
                    }
                }

                isDeviceListLoaded = true;
                viewDeviceListButton.Enabled = true;

                if ( (enableSwitchCheckBox.Checked == true) && (parentForm.controlPicoammBox.Checked == true) )
                {
                    ScanDeviceCurrentsButton.Enabled = true;
                    sweepMatrixCheckBox.Enabled = true;
                    sweepMatrixCheckBox.Checked = Settings.Default.SweepMatrixDuringRecipe;
                }



            }

        }


        static bool FileInUse(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    var test = fs.CanWrite;
                }
                return false;
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show("File Access Exception " + ex.Message);
                return true;
            }
        }

        private void ScanDeviceCurrentsButton_Click(object sender, EventArgs e)
        {
            ScanDeviceCurrentsButton.Enabled = false;
            loadDeviceListButton.Enabled = false;

            scanDeviceCurrentsForm1 = new ScanDeviceCurrentsForm();
            scanDeviceCurrentsForm1.parentControl = this;
            scanDeviceCurrentsForm1.Show();
        }

        private void viewDeviceListButton_Click(object sender, EventArgs e)
        {
            scanListView1 = new ScanListView();
            scanListView1.parentControl = this;
            viewDeviceListButton.Enabled = false;
            scanListView1.Show();
        }

        //private void sweepMatrixCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    Settings.Default.SweepMatrixDuringRecipe = sweepMatrixCheckBox.Checked;
        //    Settings.Default.Save();
        //}

        private void sweepMatrixCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            Settings.Default.SweepMatrixDuringRecipe = sweepMatrixCheckBox.Checked;
            Settings.Default.Save();
        }

    }
}
