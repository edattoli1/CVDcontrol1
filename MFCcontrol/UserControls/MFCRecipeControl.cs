using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime;
using System.Threading;


namespace MFCcontrol
{
    public partial class MfcRecipeControl : UserControl
    {
        public Form1 parentForm;
        private RecipeView RecipeView1;
        private CancellationTokenSource tokenSource;
        private StreamWriter swriterCurrents = null;

        public MfcRecipeControl()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Check if output files exist, if so, ask you user if its OK to overwrite or abort the recipe

            if (File.Exists("adInput.txt"))
            {
                string messageBoxText = "File adInput.txt already exists. Do you want to overwrite this file and continue running the recipe?";
                string caption = "Older Log File Exists";
                var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            //if (File.Exists("currentMeasurements.txt"))
            //{
            //    string messageBoxText = "File currentMeasurements.txt already exists. Do you want to overwrite this file and continue running the recipe?";
            //    string caption = "Older Log File Exists";
            //    var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.No)
            //        return;
            //}
            
            //Create AD results text file, put headers in
            //Make sure writes are done asynchronously using FileStream to open file async

            FileStream sourceStream = new FileStream("adInput.txt",
                   FileMode.Create, FileAccess.Write, FileShare.Read,
                   bufferSize: 4096, useAsync: true);

            parentForm.swriter = new StreamWriter(sourceStream);
            parentForm.swriter.AutoFlush = true;

            string headerString = "Time (s)";


            int numActiveMFCs = 0;
            for (int i = 0; i < parentForm.stateMFCs.Length; i++)
            {
                if (parentForm.stateMFCs[i] == true)
                {
                    numActiveMFCs++;
                    //headerString += "\tMFC " + (i + 1).ToString() + " Flow (sccm)";
                    headerString += "\t"+ parentForm.mfcGasNames[i] + " Flow (sccm)";
                }
            }

            parentForm.swriter.Write(headerString + Environment.NewLine);

            parentForm.IsADoutfileOpen = true;
            

            // ///////////////////////  DO Prep Work if Sensor Matrix Sweeping is Enabled
            FileStream sourceStream2 = null;
           

            if (parentForm.switchMatrixControl1.sweepMatrixCheckBox.Checked == true)
            {
                
                try
                {
                    sourceStream2 = new FileStream("currentMeasurements.txt",
                           FileMode.Create, FileAccess.Write, FileShare.Read,
                           bufferSize: 4096, useAsync: false);
                }
                catch
                {
                    Util.ShowError("Current store File Creation Error");
                }
            
                
                swriterCurrents = new StreamWriter(sourceStream2);
                swriterCurrents.AutoFlush = true;

                string headerString2 = "Time (s)";

                if (parentForm.gateSweepControl1.enableGateCheckBox.Checked == true)
                    headerString2 += "\tGate (V)";


                for (int i = 0; i < parentForm.devicesToScan.Length; i++)
                {
                    if (parentForm.devicesToScan[i] == true)
                    {
                        headerString2 += "\t" + i.ToString();
                    }
                }
                swriterCurrents.Write(headerString2 + Environment.NewLine);


            }

            // //////////////////////////////////////////////////////////////////////////


            //Go Into Low Latency Mode for Garbage Collector
            // GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

            //Output initial DAQ Output values
            for (int i = 1; i <= Properties.Settings.Default.MFCcontrol_numMFCs; i++)
            {
                if ( (parentForm.stateMFCs[i - 1] == true) && (parentForm.mfcAoutChannels[i-1] != "") )
                {
                    try
                    {
                        parentForm.daqOutputMFC.UpdateDaqOut(parentForm.mfcAoutChannels[i - 1], parentForm.ADoutTableVolts[0][i]);
                        parentForm.presentMFCsetting[i - 1] = (parentForm.ADoutTableValues_d[0][i]);
                        
                        //parentForm.mfcControlArray[i - 1].mfc1TextBox.Value = Convert.ToDecimal(parentForm.ADoutTableValues_d);
                    }
                    catch
                    {
                        parentForm.DaqOutputProblem();
                    }

                }
            }

            //Output initial Digital Output values
            // Check whether changes are being made to DigOut states, if so update the TTL voltage out
            for (int i = 0; i < Properties.Settings.Default.DigitalOutputNumLines; i++)
            {
                if (parentForm.DigOutTableValues_i[parentForm.curRow_ADoutTable][i] > 0)
                    parentForm.digitalOutputControl1.UpdateDigOutput(i, true);
                else if (parentForm.DigOutTableValues_i[parentForm.curRow_ADoutTable][i] == 0)
                    parentForm.digitalOutputControl1.UpdateDigOutput(i, false);
            }


            //Check whether furnace is controlled in recipe
            if (parentForm.furnaceControl1.controlFurnaceInRecipe == true)
            {
                parentForm.furnaceControl1.furnaceControlCheckBox.Checked = true;
                parentForm.furnaceControl1.turnOnHeater();

               

            }

            parentForm.curRow_ADoutTable = 1;

            //start Program Stopwatch
            parentForm.watch.StopStopwatch();
            parentForm.watch.ResetStopwatch();
            parentForm.watch.StartStopwatch();

            //start AD output update timer (when to update output for A/D), units of ms
            parentForm.timerADoutUpdate.SetInterval(parentForm.ADoutTableVolts[1][0] * 60 * 1000);
            nextRecipeTimeEventBox.Text = parentForm.ADoutTableVolts[1][0].ToString();
            parentForm.timerADoutUpdate.StopTimer();
            parentForm.timerADoutUpdate.StartTimer();

            // If Switch Sweeping is enabled, Start it, disable user from messing with the switch matrix control
            if (parentForm.switchMatrixControl1.sweepMatrixCheckBox.Checked == true)
            {
                tokenSource = new CancellationTokenSource();
                CancellationToken ct = tokenSource.Token;
                parentForm.presCurrentArr = new double[Properties.Settings.Default.SwitchMatrixColsNum];

                SwitchOperations.OpenAllRelays(parentForm.switchMatrixControl1.switchSession);
                SwitchOperations.CloseRow2Relays(parentForm.switchMatrixControl1.switchSession);

                Task.Run(() => SwitchOperations.SweepAndMeasureDevices(parentForm.switchMatrixControl1.switchSession, parentForm.PicoammControl, parentForm.k617, parentForm.gateSweepControl1,
                   swriterCurrents, parentForm.devicesToScan, parentForm.watch, ref parentForm.presCurrentArr, ct), ct);

                parentForm.switchMatrixControl1.configureSwitchButton.Enabled = false;
                parentForm.switchMatrixControl1.sweepMatrixCheckBox.Enabled = false;
                parentForm.switchMatrixControl1.enableSwitchCheckBox.Enabled = false;
                parentForm.switchMatrixControl1.ScanDeviceCurrentsButton.Enabled = false;
                parentForm.switchMatrixControl1.loadDeviceListButton.Enabled = false;
            }


            //Clear Output Graph
            parentForm.resetGraphButton_Click(this, EventArgs.Empty);

            //Disable users from Changing MFC states
            parentForm.configMFCsButton.Enabled = false;
            recipePauseCheckbox.Enabled = true;

            for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
                parentForm.mfcControlArray[i].DisableUserControl();


            startButton.Enabled = false;
            loadFlowsButton.Enabled = false;
            exitRecipeButton.Enabled = true;

            parentForm.recipeRunning = true;
            parentForm.mfcMainControlEnable.Enabled = false;
            parentForm.digitalOutputControl1.enableDigitalOutCheckBox.Checked = true;
            parentForm.digitalOutputControl1.enableDigitalOutCheckBox.Enabled = false;

            //Disable Gate Bias Controls
            parentForm.gateSweepControl1.DisableUserControl();

            // Disable Furnace Control
            parentForm.furnaceControl1.DisableUserControl();


            lastRecipeTimeEventBox.Text = "0";

            viewPresentCurrentsButton.Enabled = true;
        }

        private delegate DialogResult loadFlowBoxDel(string file);

        private void loadFlowsButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            DialogResult diagResult = this.openFileDialog1.ShowDialog();

            if (diagResult == DialogResult.OK) // Test result.
            {
                if (FileInUse(this.openFileDialog1.FileName) == true)
                    return;

                SShtLoad sshtLoad1 = new SShtLoad();

                parentForm.stateMFCs = sshtLoad1.LoadMFCstate(this.openFileDialog1.FileName);

                parentForm.furnaceControl1.controlFurnaceInRecipe = sshtLoad1.LoadFurnaceControlState(this.openFileDialog1.FileName);

                parentForm.furnaceControl1.startSetPoint = sshtLoad1.LoadFurnaceSSP(this.openFileDialog1.FileName);


                if ( (parentForm.furnaceControl1.controlFurnaceInRecipe == true) && (parentForm.furnaceControl1.furnaceControlCheckBox.Checked == true) )
                    parentForm.furnaceControl1.uploadFurnaceTempProfileButton.Enabled = true;
                else
                    parentForm.furnaceControl1.uploadFurnaceTempProfileButton.Enabled = false;


                parentForm.maxFlowMFCs = sshtLoad1.LoadMFCmaxFlows(this.openFileDialog1.FileName);

                for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
                    parentForm.mfcControlArray[i].SetMFCnumber(i+1);

                // Load all rows of recipe Spreadsheet into ADoutTableValues_s
                // Empty cells are marked translated into -1 (means do nothing)
                // ADoutTableValues_d is in format of Flow (sccm)

                parentForm.ADoutTableValues_s = sshtLoad1.LoadMfc(this.openFileDialog1.FileName);

                parentForm.ADoutTableValues_d = new List<double[]>();
                double[] currentRow_d;
                foreach (string[] rowArray in parentForm.ADoutTableValues_s)
                {
                    currentRow_d = new double[Properties.Settings.Default.MFCcontrol_numMFCs + 1];
                    for (int i = 0; i < Properties.Settings.Default.MFCcontrol_numMFCs + 1; i++)
                    {
                        if ( (rowArray[i] == "") || (rowArray[i] == null) )
                            currentRow_d[i] = -1.0;
                        else
                            currentRow_d[i] = Convert.ToDouble(rowArray[i]);
                    }
                    parentForm.ADoutTableValues_d.Add(currentRow_d);
                }

                // Convert ADoutTableValues_d (flow sccm) into ADoutTableVolts (volts)
                // column 1 is times, rest of columns are MFC voltage control values (1,2...)

                parentForm.ADoutTableVolts = new List<double[]>();

                foreach (string[] rowArray in parentForm.ADoutTableValues_s)
                {
                    currentRow_d = new double[Properties.Settings.Default.MFCcontrol_numMFCs + 1];

                    //Load times (column 1 into volts list of arrays
                    currentRow_d[0] = Convert.ToDouble(rowArray[0]);

                    for (int i = 1; i <= parentForm.stateMFCs.Length; i++)
                    {
                        if (rowArray[i] == "" || (rowArray[i] == null))
                            currentRow_d[i] = -1.0;
                        else
                            currentRow_d[i] = DaqAction.GetVoltsFromMFCflow(rowArray[i], i-1, parentForm.maxFlowMFCs);
                    }
                    parentForm.ADoutTableVolts.Add(currentRow_d);
                }

                // Load DigOut Recipe part

                parentForm.DigOutTableValues_s = sshtLoad1.LoadDigOut(this.openFileDialog1.FileName, parentForm.ADoutTableValues_d.Count);

                parentForm.DigOutTableValues_i = new List<int[]>();
                int[] currentRow_i;
                foreach (string[] rowArray in parentForm.DigOutTableValues_s)
                {
                    currentRow_i = new int[Properties.Settings.Default.DigitalOutputNumLines];
                    for (int i = 0; i < currentRow_i.Length; i++)
                    {
                        if ((rowArray[i] == "") || (rowArray[i] == null))
                            currentRow_i[i] = -1;
                        else
                            currentRow_i[i] = Convert.ToInt32(rowArray[i]);
                    }
                    parentForm.DigOutTableValues_i.Add(currentRow_i);
                }


                // Load Furnace Temperature Recipe Part 


                //List <string> furnaceTempReadList = sshtLoad1.LoadFurnaceTemps(this.openFileDialog1.FileName, parentForm.ADoutTableValues_d.Count);
                parentForm.FurnaceTempList_s = sshtLoad1.LoadFurnaceTemps(this.openFileDialog1.FileName, parentForm.ADoutTableValues_d.Count);

                parentForm.FurnaceTempList_i = new List<int>();
                //int[] currentRow_i;

                int[] furnaceTempsArray = new int[parentForm.ADoutTableValues_d.Count];
                for (int i = 0; i < parentForm.ADoutTableValues_d.Count; i++)
                {
                    if ((parentForm.FurnaceTempList_s[i] == "") || (parentForm.FurnaceTempList_s[i] == null))
                        parentForm.FurnaceTempList_i.Add( -1 );
                    else
                        parentForm.FurnaceTempList_i.Add ( Convert.ToInt32(parentForm.FurnaceTempList_s[i]) );
                }



                if ( (parentForm.mfcMainControlEnable.Checked == true) )
                    startButton.Enabled = true;
                viewFlowRecipe.Enabled = true;
            }
        }



        private void viewFlowRecipe_Click(object sender, EventArgs e)
        {
            RecipeView1 = new RecipeView(this, parentForm.ADoutTableValues_s, parentForm.DigOutTableValues_s, parentForm.FurnaceTempList_s, parentForm.stateMFCs);

            RecipeView1.Show();
        }


        private void recipePauseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (recipePauseCheckbox.Checked == true)
            {
                parentForm.timerADoutUpdate.StopTimer();
                parentForm.recipeRunning = false;

            }
            else
            {
                parentForm.recipeRunning = true;
                parentForm.timerADoutUpdate.StartTimer();
            }
        }

        internal void exitRecipe_Click(object sender, EventArgs e)
        {

            ExitRecipe();

        }

        private void ExitRecipe()
        {

            if (InvokeRequired)
            {
                //BeginInvoke(new UpdateADgraphDelegate(UpdateADgraph));
                BeginInvoke((Action)ExitRecipe);
                return;
            }

            nextRecipeTimeEventBox.Text = "Finished";

            parentForm.watch.StopStopwatch();
            //parentForm.watch.ResetStopwatch();

            parentForm.timerADoutUpdate.StopTimer();

            if (parentForm.switchMatrixControl1.sweepMatrixCheckBox.Checked == true)
                tokenSource.Cancel();

            // GCSettings.LatencyMode = GCLatencyMode.Interactive;
            //disable writing to disk for last AD acquire events due to last callbacks from HiResTimer class
            //UpdateADacquireBusy = true;


            //wait for disk writes, our timer handlers to finish before closing file
            while ((parentForm.saveADdataBusy == true) || (parentForm.UpdateADacquireBusy == true) || (parentForm.updateADoutputBusy == true))
                Thread.Sleep(200);

            if (parentForm.IsADoutfileOpen == true)
            {
                parentForm.swriter.Close();
                parentForm.IsADoutfileOpen = false;
            }

            parentForm.updateADoutputBusy = false;

            startButton.Enabled = true;
            parentForm.configMFCsButton.Enabled = true;

            for (int i = 0; i < parentForm.mfcControlArray.Length; i++)
                parentForm.mfcControlArray[i].EnableUserControl();

            //Zero all AD outputs
            parentForm.ZeroAllMFCOutputs();

            parentForm.recipeRunning = false;
            recipePauseCheckbox.Enabled = false;
            //parentForm.resetGraphButton_Click(this, EventArgs.Empty);
            parentForm.Form1_Load(this, EventArgs.Empty);
            startButton.Enabled = true;
            loadFlowsButton.Enabled = true;
            viewFlowRecipe.Enabled = true;
            viewPresentCurrentsButton.Enabled = false;
            exitRecipeButton.Enabled = false;


            // If Switch Sweeping is enabled, Stop it, renable user control of the switch matrix control
            if (parentForm.switchMatrixControl1.sweepMatrixCheckBox.Checked == true)
            {
                //while (! SwitchOperations.currentTask.IsCompleted)
                //    Thread.Sleep(500);
                SwitchOperations.currentTask.Wait();

                swriterCurrents.Close();

                // Shut down GPIB interface
                //parentForm.controlPicoammBox.Checked = false;
                //parentForm.controlPicoammBox.Checked = true;


                parentForm.switchMatrixControl1.configureSwitchButton.Enabled = true;
                parentForm.switchMatrixControl1.sweepMatrixCheckBox.Enabled = true;
                parentForm.switchMatrixControl1.enableSwitchCheckBox.Enabled = true;
                parentForm.switchMatrixControl1.ScanDeviceCurrentsButton.Enabled = true;
                parentForm.switchMatrixControl1.loadDeviceListButton.Enabled = true;
            }

            parentForm.mfcMainControlEnable.Enabled = true;
            parentForm.digitalOutputControl1.enableDigitalOutCheckBox.Enabled = true;

            // Enable Gate Bias Control
            parentForm.gateSweepControl1.EnableUserControl();

            //Turn off Furnace
            // ?

            //Enable Furnace Control
            parentForm.furnaceControl1.EnableUserControl();
        }

        static bool FileInUse(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
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

        private void MfcRecipeControl_Load(object sender, EventArgs e)
        {
            viewFlowRecipe.Enabled = false;
            startButton.Enabled = false;
            recipePauseCheckbox.Enabled = false;
            exitRecipeButton.Enabled = false;

            //openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        }

        public void DisableViewFlowBtn()
        {
            this.viewFlowRecipe.Enabled = false;
        }

        public void EnableViewFlowBtn()
        {
            this.viewFlowRecipe.Enabled = true;
        }

        private void viewPresentCurrentsButton_Click(object sender, EventArgs e)
        {
            ViewPresentCurrentsForm viewPresCurrForm1 = new ViewPresentCurrentsForm();
            viewPresCurrForm1.parentControl = this;
            viewPresCurrForm1.Show();
            viewPresentCurrentsButton.Enabled = false;

        }



    }
}
