using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Mumble
{
    public sealed class MumbleScheduler: IMumbleScheduler
    {
        private readonly IMumbleServerClient _mumbleServerClient;
        private Timer tm = null;

        //private static readonly Lazy<MumbleScheduler>
        //        lazy =
        //        new Lazy<MumbleScheduler>
        //            (() => new MumbleScheduler());

        //public static MumbleScheduler Instance { get { return lazy.Value; } }

        //private MumbleScheduler()
        //{
        //    //_mumbleServerClient = ?; //How can i set the reference here ? 
        //}

        
        public MumbleScheduler(IMumbleServerClient mumbleServerClient)
        {
            _mumbleServerClient = mumbleServerClient;
            //this.tm.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            //this.tm.AutoReset = true;
            //this.tm = new Timer(60000);
            // Create a timer with a two second interval.
            tm = new Timer(5000);
            // Hook up the Elapsed event for the timer. 
            tm.Elapsed += OnTimedEvent;
            tm.AutoReset = true;
            tm.Enabled = false;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!_mumbleServerClient.IsConnected)
                {
                    _mumbleServerClient.CreateInstance();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_mumbleServerClient.IsConnected)
                {
                    this.tm.Stop();
                }
            }
        }

        public void StartTimer()
        {
            this.tm.Start();
        }

        public void StopTimer()
        {
            this.tm.Stop();
        }

        public bool IsTimerRunning()
        {
            return this.tm.Enabled;
        }
    }

    public interface IMumbleScheduler
    {
        void StartTimer();
        void StopTimer();
        bool IsTimerRunning();
    }
}
