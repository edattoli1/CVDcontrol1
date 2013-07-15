//#define K6487
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;

// Controls the Keithly 6485 or 6487
// Undefine #define K6487 if you have a 6487 and want to control voltage output
// This is a singleton class (only one instance is allowed)

namespace MFCcontrol
{
    public class Ke648xControl
    {
        private int GPIBaddress = 22;
        private Device device;
        
        public void InitSession()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Convert the Secondary Address Combo Text into a number.
                int currentSecondaryAddress = 0;
                int boardId = 0;

                // Intialize the device
                device = new Device(boardId, (byte)GPIBaddress, (byte)currentSecondaryAddress);
                //SetupControlState(true);
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                ErrorMessage();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }

        public void EndSession()
        {
            device.Dispose();
        }

        public string GetIdentString()
        {
            string stringToWrite = "*idn?";

            //Write to Device
            try
            {
                device.Write(stringToWrite);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            string stringRead = "";

            //Read from Device
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringRead = device.ReadString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return stringRead;
        }


        // Initalize Keithley picoammeter to default state
        public void InitDevice()
        {
            string initString1 = ":SYST:PRES;:SENS:FUNC 'CURR';:SENS:CURR:RANG 2E-";
            string nplcString = ":SENS:CURR:DC:NPLC ";

            try
            {

                //reset 6487
                device.Write(initString1 + Properties.Settings.Default.PicoammRange.ToString());

                //turn off digital averaging filter
                device.Write(":SENS:AVER:STAT OFF");

                //turn off Zero Check
                device.Write(":SYST:ZCH:STAT OFF");

                //Set up current reporting string on READs from GPIB
                device.Write(":FORM:ELEM READ");

                //turn off Median filter
                device.Write(":SENS:CURR:MED:STAT OFF");

                //set up NPLC (analog filter)
                device.Write(nplcString + Properties.Settings.Default.PicoammNPLC.ToString());

                //set up arm and trace
                device.Write(":ARM:COUNT INF; :TRACE:CLE; :TRACE:POINTS 1; :TRACE:FEED SENS; :TRACE:FEED SENS; :TRACE:FEED:CONT NEXT;"
                     + ":TRIG:COUNT 1");

#if (K6487)
            
            //set Voltage out range
            device.Write(":SOUR:VOLT:RANG 500");

            //set Voltage out to zero
            device.Write(":SOUR:VOLT 0");

            //turn on Voltage Out
            device.Write(":SOUR:VOLT:STATE ON");
            
#endif

                //Start measurements
                device.Write(":INIT");

                device.IOTimeout = TimeoutValue.T1s;    

            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                ErrorMessage();
            }


        }

        public void SetRange(int newRange)
        {

            try
            {
                device.Write(":ABORT");
                device.Write(":SENS:CURR:RANG 2E-" + newRange.ToString());
                device.Write(":INIT");
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                ErrorMessage();
            }
            
        }

        public double GetReading()
        {
            double returnValue = 0;
            string retrievedString = "0.00";
            
            try
            {
            
            //    
            device.Write(":ABORT");
            device.Write(":ARM:COUNT 1");
            device.Write(":INIT");
            device.Write(":READ?");

           
            device.IOTimeout = TimeoutValue.T1s;
            retrievedString = device.ReadString(14);
            returnValue = Convert.ToDouble(retrievedString);
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                ErrorMessage();
                //return 0;
            }


            return returnValue;
        }

        public void ChangeNplc(double newNplcVal)
        {
            try
            {
                device.Write(":ABORT");
                device.Write(":SENS:CURR:DC:NPLC " + newNplcVal.ToString());
                device.Write(":INIT");
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                ErrorMessage();
            }
        }

        private void ErrorMessage()
        {
            string messageBoxText = "Do you want to exit?";
            string caption = "GPIB Problem";
            var result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.PicoammeterControlEnable = false;
                Properties.Settings.Default.Save();
                Environment.Exit(0);
            }
        }

        //private string ReplaceCommonEscapeSequences(string s)
        //{
        //    return s.Replace("\\n", "\n").Replace("\\r", "\r");
        //}

        //private string InsertCommonEscapeSequences(string s)
        //{
        //    return s.Replace("\n", "\\n").Replace("\r", "\\r");
        //}

    }
}
