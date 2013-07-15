using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFCcontrol
{
    public partial class ScanListView : Form
    {
        internal SwitchMatrixControl parentControl;
        
        public ScanListView()
        {
            InitializeComponent();
        }

        private void ScanListView_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentControl.viewDeviceListButton.Enabled = true;
        }

        private void ScanListView_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;

            // Create an unbound DataGridView by declaring a column count.
            dataGridView1.ColumnCount = Properties.Settings.Default.SwitchMatrixColsNum;
            dataGridView1.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = System.Drawing.Color.Beige;
            columnHeaderStyle.Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            for (int i = 0; i <  Properties.Settings.Default.SwitchMatrixColsNum; i++)
            {
                dataGridView1.Columns[i].Name = (i).ToString();
                dataGridView1.Columns[i].Width = 55;
            }

            // Load read values from spreadsheet for device state
            dataGridView1.Rows.Add();
            string[] rowArraysTotal = new string[0]; //= new string[Properties.Settings.Default.SwitchMatrixColsNum];
            foreach (string[] rowArray in parentControl.deviceListState)
            {
                rowArraysTotal = rowArraysTotal.Concat(rowArray).ToArray();

            }
            dataGridView1.Rows.Add(rowArraysTotal);
        }
    }
}
