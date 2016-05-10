using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DelegateUhr
{
    public sealed class KukusUhr
    {
        // Die Methode soll die Zeit ausgeben
        public delegate void ClockDelegat(DateTime time);

        //privat von aussen geschützt
        private ClockDelegat DelegatedMethod;


        public event ClockDelegat Tick;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public KukusUhr()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        //public void Register(ClockDelegat delegatedMethod)
        //{
        //    DelegatedMethod += delegatedMethod;
        //}

        //public void Unregister(ClockDelegat callback)
        //{
        //    DelegatedMethod -= callback;
        //}

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Ab VS2015 wäre folgndes möglich
            //DelegatedMethod?.Invoke(e.SignalTime);

            //if (DelegatedMethod != null)
            //{
            //    DelegatedMethod(e.SignalTime);
            //}
            //else
            //{
            //    Console.WriteLine(".");
            //}

            //Tick.Invoke(e.SignalTime);
            if (Tick != null)
            {
                Tick.Invoke(e.SignalTime);
            }
            else
            {
                Console.WriteLine(".");
            }


            //foreach (ClockDelegat callback in DelegatedMethod.GetInvocationList())
            //{
            //    try
            //    {
            //    callback(e.SignalTime);
            //    }
                //catch (Exception exception)
                //{
                //    Console.WriteLine(exception.Message);
                //}
            //}
        }


    }
}
