using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Timers;

namespace MFCcontrol
{
    class HiResTimer
    {
        private int mTimerId;

        private TimerEventHandler mHandler;  // NOTE: declare at class scope so garbage collector doesn't release it!!!
        private delegate void TimerEventHandler(int id, int msg, IntPtr user, int dw1, int dw2);
        public event EventHandler TimerElapsed;




        //private int mTestTick;
        //private DateTime mTestStart;

        //units of ms
        private int timerInterval;


        public HiResTimer()
        {
            mHandler = new TimerEventHandler(TimerCallback);
            //mTestTick = 0;
            timerInterval = 200;
        }

        public void StartTimer()
        {
            timeBeginPeriod(1);
            //orig
            //mTimerId = timeSetEvent(1, 0, mHandler, IntPtr.Zero, EVENT_TYPE);
            //MMRESULT timeSetEvent(UINT uDelay,   UINT uResolution,   LPTIMECALLBACK lpTimeProc,   DWORD_PTR dwUser,   UINT fuEvent);
            mTimerId = timeSetEvent(timerInterval, 0, mHandler, IntPtr.Zero, EVENT_TYPE);
            //mTestStart = DateTime.Now;
        }


        public void StopTimer()
        {
            mTimerId = 0;
            int err = timeKillEvent(mTimerId);
            timeEndPeriod(1);
            // Ensure callbacks are drained
            System.Threading.Thread.Sleep(100);
            //Timer t = new Timer();
            //t.Interval = 0.5; //In seconds here
            //t.AutoReset = true; //Stops it from repeating
            //t.Elapsed += new ElapsedEventHandler(TimerElapsedDelay);
            //t.Start();
        }

        //void TimerElapsedDelay(object sender, ElapsedEventArgs e)
        //{
        //    Console.WriteLine("Hello, world!");
        //}

        /* interval unit is ms */
        public void SetInterval(int interval)
        {
            timerInterval = interval;
        }


        //private void MyTimerEventHandler(Object obj, EventArgs e)
        //{
        //    if (TimerElapsed != null)
        //        TimerElapsed(obj, e);
        //}

        //private delegate void TestEventHandler(int tick, TimeSpan span);

        private void TimerCallback(int id, int msg, IntPtr user, int dw1, int dw2)
        {

            //mTestTick += 1;
            //if ((mTestTick % timerInterval) == 0 && mTimerId != 0)
            //    TimerElapsed(this, EventArgs.Empty);
            TimerElapsed(this, EventArgs.Empty);



            //    this.BeginInvoke(new TestEventHandler(ShowTick), mTestTick, DateTime.Now - mTestStart);
        }

        //private void ShowTick(int msec, TimeSpan span)
        //{
        //    label1.Text = msec.ToString();
        //    label2.Text = span.TotalMilliseconds.ToString();
        //}


        // P/Invoke declarations

        private const int TIME_PERIODIC = 1;
        private const int EVENT_TYPE = TIME_PERIODIC;// + 0x100;  // TIME_KILL_SYNCHRONOUS causes a hang ?!
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(int delay, int resolution, TimerEventHandler handler, IntPtr user, int eventType);
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int id);
        [DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [DllImport("winmm.dll")]
        private static extern int timeEndPeriod(int msec);
    }
}

