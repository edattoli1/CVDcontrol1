using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using System.Windows.Forms;

namespace MFCcontrol
{
    public class DaqAction
    {
        private NationalInstruments.DAQmx.Task myTask;
        private double daqOutputRangeMax;
        private double daqOutputRangeMin;

        public DaqAction()
        {
            daqOutputRangeMin = 0;
            daqOutputRangeMax = 5;
        }
        
        public DaqAction(double daqOutputRangeMinIn, double daqOutputRangeMaxIn)
        {
            daqOutputRangeMin = daqOutputRangeMinIn;
            daqOutputRangeMax = daqOutputRangeMaxIn;
        }

        public void UpdateDigitalOutPort(string portAddress, bool newState)
        {
            try
            {
                using (myTask = new NationalInstruments.DAQmx.Task())
                {
                    myTask.DOChannels.CreateChannel(portAddress, "",
                        ChannelLineGrouping.OneChannelForAllLines);
                    DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(myTask.Stream);
                    writer.WriteSingleSampleSingleLine(true, newState);
                }
            }
            catch (DaqException exception)
            {
                DaqOutputProblem();

            }
        }

        // Reads input values from DAQ,
        // which DAQs to read from is controlled from Properties.Settings.Default.DAQ_CreateVoltageChannel_AI_chans
        public void Read(ref double[] currentValue)
        {
            
            bool daqsToLoop = true;
            string parseStr = Properties.Settings.Default.MfcAinChannelsList;
            int locNextDel = 0;
            string curDaqLine = "";
            List<double> dataInList = new List<double>();

            while (daqsToLoop == true)
            {
                //Parse the input string, if there is a daq input in the list, read from it, else break from the loop

                if (parseStr == "")
                {
                    daqsToLoop = false;
                    break;
                }

                locNextDel = (parseStr.IndexOf(',') == -1) ? 0 : parseStr.IndexOf(',');

                if (locNextDel != 0)
                    curDaqLine = parseStr.Substring(0, locNextDel);
                else
                {
                    curDaqLine = parseStr;
                    daqsToLoop = false;
                }
                
                parseStr = parseStr.Substring(locNextDel + 1);

                try
                {
                    //Create a new task
                    using (myTask = new NationalInstruments.DAQmx.Task())
                    {
                        //Create a virtual channel

                        //"Dev1/ai0,Dev1/ai1"
                        myTask.AIChannels.CreateVoltageChannel(curDaqLine, "",
                            (AITerminalConfiguration.Rse), 0.0,
                            5.0, AIVoltageUnits.Volts);


                        AnalogMultiChannelReader reader = new AnalogMultiChannelReader(myTask.Stream);

                        //Verify the Task
                        myTask.Control(TaskAction.Verify);

                        //Plot Multiple Channels to the table
                        double[] data = reader.ReadSingleSample();
                        dataInList.Add(data[0]);
                        //dataToDataTable(data,ref dataTable);
                    }
                }
                catch (DaqException exception)
                {
                    System.Windows.Forms.MessageBox.Show(exception.Message);
                    throw;
                }

            }

            currentValue = dataInList.ToArray();
        }

        //zeros all Daq Out Channels
        public void ZeroDaqOuts(string [] daqOutChannels)
        {
            for (int i = 0; i < Properties.Settings.Default.MFCcontrol_numMFCs; i++)
            {
                if (daqOutChannels[i] != "")
                    UpdateDaqOut(daqOutChannels[i], 0);
                
            }
        }


        //Updates DAQ Analog Output value to a single DAQ channel, accepts string as AOchannel input
        public void UpdateDaqOut(string AOchannel_s, double voltOut)
        {
            // Loop over all DAQs, create a separate task and read in the voltage for each separate DAQ input


                try
                {
                    using (myTask = new NationalInstruments.DAQmx.Task())
                    {
                        myTask.AOChannels.CreateVoltageChannel(AOchannel_s, "aoChannel",
                            daqOutputRangeMin, daqOutputRangeMax, AOVoltageUnits.Volts);
                        AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(myTask.Stream);
                        writer.WriteSingleSample(true, voltOut);
                    }
                }
                catch (DaqException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    throw;
                }
            
        }


        static public double GetVoltsFromMFCflow(string inputFlow, int mfcNumber, int[] maxFlows)
        {
            double inputFlow_d = Convert.ToDouble(inputFlow);

            return (inputFlow_d / Convert.ToDouble(maxFlows[mfcNumber])) * 5;

        }

        static public double GetMFCflowFromVolts(double inputVolts, int mfcNumber, int[] maxFlows, double[] mfcFudges)
        {

            return (inputVolts / 1) * Convert.ToDouble(maxFlows[mfcNumber]) * mfcFudges[mfcNumber];

        }

        internal void DaqOutputProblem()
        {
            string messageBoxText = "Do you want to exit?";
            string caption = "DAQ Output Problem";
            var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.mfcMainControlEnable = false;
                Properties.Settings.Default.sensorBiasEnable = false;
                Properties.Settings.Default.DigitalOutputEnable = false;
                Properties.Settings.Default.Save();
                Environment.Exit(0);
            }
        }

    }

}
