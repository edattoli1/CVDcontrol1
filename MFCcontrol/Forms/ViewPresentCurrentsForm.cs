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

namespace MFCcontrol
{
    public partial class ViewPresentCurrentsForm : Form
    {
        internal MfcRecipeControl parentControl;
        internal TextBox[] tb;
        private GenTimer updateTimer;
        
        
        public ViewPresentCurrentsForm()
        {
            InitializeComponent();
            updateTimer = new GenTimer();
        }

        private void ViewPresentCurrentsForm_Load(object sender, EventArgs e)
        {
            tb = new TextBox[Settings.Default.SwitchMatrixRowsNum * Settings.Default.SwitchMatrixColsNum];
            Label[] lbl = new Label[Settings.Default.SwitchMatrixColsNum];

            int deviceIterator = 0;

            DisplayPartSwitchMatrix(lbl, ref deviceIterator, 0, 10, 10);
            DisplayPartSwitchMatrix(lbl, ref deviceIterator, 34, 10, 80);
            DisplayPartSwitchMatrix(lbl, ref deviceIterator, 68, 10, 180);
            DisplayPartSwitchMatrix(lbl, ref deviceIterator, 102, 10, 280);

            updateTimer.SetInterval(Convert.ToDouble(refreshTimeUpDown.Value));
            updateTimer.TimerElapsed += UpdateHandler;
            updateTimer.StartTimer();


        }

        private void UpdateHandler(object obj, EventArgs e)
        {
            UpdateCurrents();
        }

        private void UpdateCurrents()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)UpdateCurrents);
                return;
            }

            for (int j = 0; j < Settings.Default.SwitchMatrixColsNum; j++)
            {
                if (parentControl.parentForm.devicesToScan[j] == true)
                {
                    string relayNameRow0 = "kr" + 0.ToString() + "c" + j.ToString();
                    string relayNameRow1 = "kr" + 1.ToString() + "c" + j.ToString();

                    tb[j].Text = parentControl.parentForm.presCurrentArr[j].ToString("0.0e0");
                }
            }

        }

        private void DisplayPartSwitchMatrix(Label[] lbl, ref int deviceIterator, int startSwitch, int originX, int originY)
        {
            int xcoord = originX;
            int ycoord = originY;
            string relayName = "";

            for (int j = startSwitch; j < startSwitch + 34; j++)
            {
                ycoord = originY;

                lbl[j] = new Label();
                lbl[j].Text = j.ToString();
                lbl[j].Location = new Point(xcoord + 7, ycoord);
                lbl[j].Visible = true;
                lbl[j].Width = 40;
                lbl[j].Height = 20;
                ycoord += 5;
                this.Controls.Add(lbl[j]);


                for (int i = 0; i < 1; i++)
                {
                    tb[deviceIterator] = new TextBox();
                    relayName = "r" + i.ToString() + "c" + j.ToString();
                    tb[deviceIterator].Name = "textBox" + relayName;
                    tb[deviceIterator].Width = 45;
                    tb[deviceIterator].Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    tb[deviceIterator].Height = 10;
                    tb[deviceIterator].Margin = new Padding(3);
                    tb[deviceIterator].Padding = new Padding(3);
                    tb[deviceIterator].Enabled = false;

                    ycoord += tb[deviceIterator].Height + 2;
                    tb[deviceIterator].Visible = true;
                    tb[deviceIterator].Location = new Point(xcoord, ycoord);

                    this.Controls.Add(tb[deviceIterator]);

                    deviceIterator++;
                }
                xcoord += 50;
            }

        }

        private void ViewPresentCurrentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentControl.viewPresentCurrentsButton.Enabled = true;
        }

        private void refreshTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            updateTimer.SetInterval(Convert.ToDouble(refreshTimeUpDown.Value));
        }

    }
}
