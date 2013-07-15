using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;

namespace MFCcontrol
{
    public partial class Ke648xGUI : Form
    {

        private Ke648xControl pAmm;
        private GenTimer readTimer;
        private bool gpibBusy;
        internal double presReading;
        private Form1 parentForm;

        public Ke648xGUI(Form1 parentFormIn, Ke648xControl pAmmIn)
        {
            InitializeComponent();
            presReading = 0;
            pAmm = pAmmIn;
            readTimer = new GenTimer();
            parentForm = parentFormIn;
        }

        private void Ke648xGUI_Load(object sender, EventArgs e)
        {
            picoammRangeUpDown.Value = Properties.Settings.Default.PicoammRange;

            readTimer.SetInterval(200);
            readTimer.TimerElapsed += ReadTimerHandler;
            gpibBusy = false;
            refreshPicoammRead.Checked = Properties.Settings.Default.PicoammRefreshRead;
            nplcUpDown.Value = Convert.ToDecimal(Properties.Settings.Default.PicoammNPLC);

        }


        private void ReadTimerHandler(object obj, EventArgs e)
        {
            if (gpibBusy == true)
                return;
            else
            {
                gpibBusy = true;
                presReading = pAmm.GetReading();
                gpibBusy = false;

                UpdatePresCurrent();
            }
        }

        private void UpdatePresCurrent()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)UpdatePresCurrent);
                return;
            }

            presPicoammRead.Text = presReading.ToString();

        }


        private void initDeviceButton_Click(object sender, EventArgs e)
        {
            pAmm.InitDevice();

        }

        // Prevent this Form from being Disposed on its Form Close
        private void Ke648xGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshPicoammRead.Checked = false;
            
            // Hides the Form
            this.Visible = false;

            //Allow Main Form Control over Picoammeter Enable
            parentForm.controlPicoammBox.Enabled = true;

            

            // This cancels the closing event, prevents Dispose of the Form
            e.Cancel = true;
            // Throw OnClosing event (normal behavior on Form Closing)
            base.OnClosing(e);

            //this.Close();
        }

        private void picoammRangeUpDown_ValueChanged(object sender, EventArgs e)
        {
            int newRange = Convert.ToInt32(picoammRangeUpDown.Value);

            if (newRange != Properties.Settings.Default.PicoammRange)
            {
                pAmm.SetRange(newRange);
                Properties.Settings.Default.PicoammRange = newRange;
            }

        }



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    presPicoammRead.Text = pAmm.GetReading().ToString();
        //}

        private void refreshPicoammRead_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PicoammRefreshRead = refreshPicoammRead.Checked;

            if (refreshPicoammRead.Checked == true)
                readTimer.StartTimer();
            else
                readTimer.StopTimer();

        }

        private void nplcUpDown_ValueChanged(object sender, EventArgs e)
        {
            double newNplc = Convert.ToDouble(nplcUpDown.Value);

            if (newNplc != Properties.Settings.Default.PicoammNPLC)
            {
                pAmm.ChangeNplc(newNplc);
                Properties.Settings.Default.PicoammNPLC = newNplc;
            }

        }


    }
}
