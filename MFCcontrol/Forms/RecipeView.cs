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
    public partial class RecipeView : Form
    {
        private MfcRecipeControl parentForm;
        //private Form1 mainForm;
        private List<string[]> MfcTableList;
        private List<string[]> DigOutTableList;
        private List<string> FurnaceTempList;
        private bool[] stateMFCs;

        public RecipeView(MfcRecipeControl parentFormIn, List<string[]> inputMfcTable, List<string[]> inputDigOutTable, List<string> inputFurnaceTempList, bool[] stateMFCsIn)
        {
            InitializeComponent();
            parentForm = parentFormIn;
            MfcTableList = inputMfcTable;
            DigOutTableList = inputDigOutTable;
            FurnaceTempList = inputFurnaceTempList;
            stateMFCs = stateMFCsIn;

            parentForm.DisableViewFlowBtn();

        }

        private void RecipeView_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            
            // Create an unbound DataGridView by declaring a column count.
            dataGridView1.ColumnCount = Properties.Settings.Default.MFCcontrol_numMFCs + 1 + Properties.Settings.Default.DigitalOutputNumLines + 1;
            dataGridView1.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = System.Drawing.Color.Beige;
            columnHeaderStyle.Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridView1.Columns[0].Name = "Time (min)";
            dataGridView1.Columns[0].Width = 65;
            dataGridView1.Columns[1].Name = "MFC1";
            dataGridView1.Columns[1].Width = 65;
            dataGridView1.Columns[2].Name = "MFC2";
            dataGridView1.Columns[2].Width = 65;
            dataGridView1.Columns[3].Name = "MFC3";
            dataGridView1.Columns[3].Width = 65;
            dataGridView1.Columns[4].Name = "MFC4";
            dataGridView1.Columns[4].Width = 65;
            dataGridView1.Columns[5].Name = "MFC5";
            dataGridView1.Columns[5].Width = 65;
            dataGridView1.Columns[6].Name = "MFC6";
            dataGridView1.Columns[6].Width = 65;
            dataGridView1.Columns[7].Name = "MFC7";
            dataGridView1.Columns[7].Width = 65;
            dataGridView1.Columns[8].Name = "MFC8";
            dataGridView1.Columns[8].Width = 65;
            dataGridView1.Columns[9].Name = "Temp.";
            dataGridView1.Columns[9].Width = 50;

            dataGridView1.Columns[10].Name = "D1";
            dataGridView1.Columns[10].Width = 50;
            dataGridView1.Columns[11].Name = "D2";
            dataGridView1.Columns[11].Width = 50;
            dataGridView1.Columns[12].Name = "D3";
            dataGridView1.Columns[12].Width = 50;
            dataGridView1.Columns[13].Name = "D4";
            dataGridView1.Columns[13].Width = 50;
            dataGridView1.Columns[14].Name = "D5";
            dataGridView1.Columns[14].Width = 50;
            dataGridView1.Columns[15].Name = "D6";
            dataGridView1.Columns[15].Width = 50;
            dataGridView1.Columns[16].Name = "D7";
            dataGridView1.Columns[16].Width = 50;
            dataGridView1.Columns[17].Name = "D8";
            dataGridView1.Columns[17].Width = 50;



            LoadValuesDataGridView(MfcTableList, DigOutTableList, FurnaceTempList);
        }

        private void RecipeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.EnableViewFlowBtn();
        }

        public void LoadValuesDataGridView(List<string[]> inputList_s, List<string[]> inputList2_s, List<string> inputList3_s)
        {
            for (int i = 0; i < inputList_s.Count; i++)
            {
                string[] curRow1 = inputList_s.ElementAt(i);
                string[] curRow2 = inputList2_s.ElementAt(i);
                string[] curRow = new string[curRow1.Length + curRow2.Length + 1];
                Array.Copy(curRow1, curRow, curRow1.Length);
                curRow[curRow1.Length ] = inputList3_s.ElementAt(i);
                Array.Copy(curRow2, 0, curRow, curRow1.Length+1, curRow2.Length);
                
                dataGridView1.Rows.Add(curRow);
            }

            //foreach (string[] rowArray in inputList_s)
            //{
            //    //loop over MFCs and convert Volts to sccm
            //    //for (int i = 1; i < stateM; i++)
            //    //{
            //    //    if (
            //    //}
            //    string [] rowArray2 = inputList2_s.
            //    dataGridView1.Rows.Add(rowArray);
            //}

        }



    }
}
