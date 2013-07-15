
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;


// Controls the Keithly 617


namespace MFCcontrol
{
    public class K617Control
    {
        private int GPIBaddress = 16;
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





        public void ChangeVolt(double newVolt)
        {
            try
            {
                device.Write("D1V" + newVolt.ToString() + "O1X");
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
