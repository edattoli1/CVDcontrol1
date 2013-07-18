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
    public partial class GraphMfcs : UserControl
    {
        internal Form1 parentForm;
        internal int pointsToPlot = 10;
        
        public GraphMfcs()
        {
            InitializeComponent();
        }

        private void GraphMfcs_Load(object sender, EventArgs e)
        {
           chart1.ChartAreas[0].Axes[0].Title = "Time (min)";
           chart1.ChartAreas[0].Axes[1].Title = "MFC Flow (sccm)";

            // null check is required by Visual Studio Designer
           if (parentForm != null)
           {
               for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
               {
                   chart1.Series[i].Name = parentForm.mfcGasNames[i];
                   chart1.Series[i].Enabled = parentForm.mfcPlotEnableArray[i];
               }
           }
        }

        internal void resetGraphButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
                chart1.Series[i].Points.Clear();

            parentForm.pointsPlotted = 0;
        }

        internal void samplesToResetUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SamplesToGraphRst = Convert.ToInt32(samplesToResetUpDown.Value);
            Properties.Settings.Default.Save();
        }

        private void graphUpdateUD_ValueChanged(object sender, EventArgs e)
        {
            //On Startup this value is 0, in this case don't overwritten saved GraphTimeUpdate value
            if (graphUpdateUDbox.Value != 0)
            {
                Properties.Settings.Default.GraphTimeUpdateMS = Convert.ToInt32(graphUpdateUDbox.Value * 1000);
                Properties.Settings.Default.ADacquireTime_ms = Convert.ToInt32(graphUpdateUDbox.Value * 1000);
            }

            //Only update timers if parentForm has been initialized (During startup)
            if (parentForm != null)
            {
                parentForm.timerADacquire.SetInterval(Properties.Settings.Default.ADacquireTime_ms);
                parentForm.timerADgraph.SetInterval(Properties.Settings.Default.GraphTimeUpdateMS);
            }
            Properties.Settings.Default.Save();
        }

        internal void AinGraphUpdateBox_CheckedChanged(object sender, EventArgs e)
        {
            //Only Graph AD Input if both Update Box is Checked and MFC Control is enabled
            if ((AinGraphUpdateBox.Checked == true) && Properties.Settings.Default.mfcMainControlEnable)
            {
                parentForm.AinGraphUpdateState = true;
                parentForm.timerADgraph.StartTimer();
            }
            else
            {
                parentForm.AinGraphUpdateState = false;
                parentForm.timerADgraph.StopTimer();
            }
        }

        private void pointsToPlotUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PointsToPlot = Convert.ToInt32(pointsToPlotUpDown.Value);
            pointsToPlot = Convert.ToInt32(pointsToPlotUpDown.Value);
            Properties.Settings.Default.Save();
        }

    }
}
