/*
 * GenTimer.cs
 * 
 * Custom Timer class using System.Timers.Timer
 * 
 * Notes:
 * Class contains an event (TimerElapsed) that is triggered when the timer value elapses
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MFCcontrol
{
    class GenTimer
    {
        private System.Timers.Timer aTimer;
        public event EventHandler TimerElapsed;
        //public delegate void myElapsedHandler(object source, ElapsedEventArgs e);


        private void aTimerEventHandler (Object obj, ElapsedEventArgs e)
        {
            if (TimerElapsed != null)
                TimerElapsed(obj, e);
        }

        public GenTimer()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += aTimerEventHandler;
            //aTimer.Enabled = true;
            aTimer.Interval = 100; /* unit is ms */
        }
        
        public void StartTimer()
        {
            aTimer.Start();
        }

        public void StopTimer()
        {
            aTimer.Stop();
        }

        /* interval unit is ms */
        public void SetInterval(double interval)
        {
            if (interval == 0)
                throw new Exception();
            if (interval > 10)
                aTimer.Interval = interval;
        }

        public void Enable()
        {
            aTimer.Enabled = true;
        }

        public void AutoResetEnable()
        {
            aTimer.AutoReset = true;
        }
        
    }
}
