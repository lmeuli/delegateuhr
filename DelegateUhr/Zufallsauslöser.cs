using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DelegateUhr
{

    class Zufallsauslöser
    {

        public delegate void DelegateRandZahl(int RandZahl);

        public event DelegateRandZahl RandomEvent;

        public Zufallsauslöser()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random rzahl = new Random();
            double doublevalue = rzahl.NextDouble();
            int intvalue = (int)(doublevalue*10);
            this.istangesprungen(intvalue);
        }

        public void istangesprungen(int rzahl)
        {
            //RandomEvent?.Invoke(rzahl);

            if (RandomEvent != null)
            {
                RandomEvent.Invoke(rzahl);
            }
            else
            {
                //Console.WriteLine(".");
            }
        }

    }
}
