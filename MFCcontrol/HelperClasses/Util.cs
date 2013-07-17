using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFCcontrol
{
    static class Util
    {

        public static void ShowError(string message)
        {
            if (string.IsNullOrEmpty(message))
                message = "Unexpected Error";
            MessageBox.Show(message, "Error"); ;
        }

        static internal bool[] StringToBoolArray(string sIn)
        {
            return sIn.Split(',').Select(s => Boolean.Parse(s)).ToArray();
        }

        static internal string BoolArrayToString(bool[] boolArr)
        {
            return String.Join(",", boolArr.Select(i => i.ToString()).ToArray());
        }

        static internal string[] StringToStringArray(string sIn)
        {
            return sIn.Split(',');
        }

        static internal string StringArrayToString(string[] sArrIn)
        {
            return String.Join(",", sArrIn);
        }

        static internal int[] StringToIntArray(string sIn)
        {
            return sIn.Split(',').Select(s => Int32.Parse(s)).ToArray();
        }

        static internal double[] StringToDoubleArray(string sIn)
        {
            return sIn.Split(',').Select(s => Double.Parse(s)).ToArray();
        }

        static internal string IntArrayToString(int[] intArr)
        {
            return String.Join(",", intArr.Select(i => i.ToString()).ToArray());
        }

        static internal string DoubleArrayToString(double[] doubleArr)
        {
            return String.Join(",", doubleArr.Select(i => i.ToString()).ToArray());
        }

        public class ADstorage
        {
            // single instance of class which is created on declaration
            static readonly ADstorage _instance = new ADstorage();

            // returns the above single instance
            public static ADstorage Instance
            {
                get
                {
                    return _instance;
                }
            }

            public Stack<double> inTimesQ { get; set; }
            public Stack<double> readMFC1 { get; set; }
            public Stack<double> readMFC2 { get; set; }

            public ADstorage()
            {
                inTimesQ = new Stack<double>(new List<double> { });
                readMFC1 = new Stack<double>(new List<double> { });
                readMFC2 = new Stack<double>(new List<double> { });
            }
        }
        
        
        //public async Task LongDelay()
        //{
        //    //simulate a long delay

        //    int b = await Task.Run(() =>
        //     {
        //         //Task.Delay(10000);
        //         for (int i = 0; i < 1000000000000000; i++)
        //         {
        //             i = i * 2;
        //         }
        //         return 1;

        //     });
        //}
    }
}
