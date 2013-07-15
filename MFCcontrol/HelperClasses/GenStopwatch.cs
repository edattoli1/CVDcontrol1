using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCcontrol
{
    public class GenStopwatch
    {
        private System.Diagnostics.Stopwatch aWatch;

        public GenStopwatch()
        {
            aWatch = new System.Diagnostics.Stopwatch();
        }

        public void StartStopwatch()
        {
            aWatch.Start();
        }

        public void StopStopwatch()
        {
            aWatch.Stop();
        }

        public void ResetStopwatch()
        {
            aWatch.Reset();
        }

        public long GetMsElapsed()
        {
            return aWatch.ElapsedMilliseconds;
        }
    }
}
