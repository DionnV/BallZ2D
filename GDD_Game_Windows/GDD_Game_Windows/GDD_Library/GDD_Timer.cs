﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace GDD_Library
{
    public class GDD_Timer: IDisposable
    {
        public GDD_Timer()
        {
            //Redrawing every 1/60th of  second
            this.worker = new BackgroundWorker();
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new DoWorkEventHandler(loop);  
        }

        public void Dispose()
        {
            this.Stop();
            this.worker.CancelAsync();

            worker.Dispose();
        }

        ~GDD_Timer()
        {
            this.Dispose();
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Stop()
        {
            IsRunning = false;   
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            if (!IsRunning)
            {
                if (!worker.IsBusy)
                {
                    worker.RunWorkerAsync();
                }           
                IsRunning = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Boolean IsRunning {get; set;}

        /// <summary>
        /// The tick event that gets called x times per second
        /// </summary>
        public EventHandler Tick;


        /// <summary>
        /// The background worker
        /// </summary>
        private BackgroundWorker worker;

        /// <summary>
        /// Should we cancel processing?
        /// </summary>
        public Boolean CancellationPending { get { return worker.CancellationPending; } }

        /// <summary>
        /// Ticks Per Second that have been executed
        /// </summary>
        public Int32 TPS { get { return this._TPS; } }
        private Int32 _TPS;

        /// <summary>
        /// The caps for frames per second
        /// </summary>
        public Int32 TickCap
        {
            get
            {
                //No action for getting
                return _TickCap;
            }
            set
            {
                this._TickCap = value;
                if (this._TickCap == -1)
                {
                    this.DesiredTickTime = 0;
                }
                else
                {
                    this.DesiredTickTime = 1000f / (float)TickCap;
                }
            }
        }
        private Int32 _TickCap;

        /// <summary>
        /// The desired time between ticks
        /// </summary>
        public float DesiredTickTime { get; set; }

        /// <summary>
        /// The amount of MS that passed since the last tick
        /// </summary>
        public Int32 TickTime
        {
            get { return this._TickTime; }
            set
            {
                this._TickTime = value;
                this._TPS = (int)Math.Round(1000f / (float)value);
            }
        }

        private Int32 _TickTime;
        private Int32 _TicksThisSecond;

        public void loop(object sender, DoWorkEventArgs e)
        {
            //To draw frames
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Loop untill we quit
            while (true)
            {
                //Do we need to stop?
                if (worker.CancellationPending == true)
                {
                    break;
                }

                if (IsRunning)
                {

                    //Restarting the counters every second
                    if (stopwatch.ElapsedMilliseconds >= 1000)
                    {
                        stopwatch.Restart();
                        this._TicksThisSecond = 0;
                    }

                    //some other processing to do STILL POSSIBLE
                    if (stopwatch.ElapsedMilliseconds >= (int)((float)this.DesiredTickTime * (_TicksThisSecond)))
                    {
                        //We created another frame!
                        if (_TicksThisSecond != 0)
                        {
                            this.TickTime = (int)(stopwatch.ElapsedMilliseconds / _TicksThisSecond);
                        }

                        //Forcing to redraw
                        if (this.Tick != null)
                        {
                            this.Tick(this, new EventArgs());
                            this._TicksThisSecond++;
                        }
                    }
                    Thread.Sleep(1); //so processor can rest for a while
                }
            }
        }
    }
}
