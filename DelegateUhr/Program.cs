using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateUhr
{
    class Program
    {
        static void Main(string[] args)
        {
            KukusUhr mykukUhr = new KukusUhr();


            Thread.Sleep(TimeSpan.FromSeconds(2));

            //mykukUhr.Register(ShowTime);
            mykukUhr.Tick += ShowTime;
            Thread.Sleep(TimeSpan.FromSeconds(5));

            //mykukUhr.Register(ShowDate);
            mykukUhr.Tick += ShowDate;
            Thread.Sleep(TimeSpan.FromSeconds(5));

            //mykukUhr.Unregister(ShowDate);
            mykukUhr.Tick -= ShowTime;
            Thread.Sleep(TimeSpan.FromSeconds(5));

            //mykukUhr.Unregister(ShowTime);
            mykukUhr.Tick -= ShowDate;
            Thread.Sleep(TimeSpan.FromSeconds(5));

        }


        public static void ShowTime(DateTime time)
        {
            Console.WriteLine(time.ToLongTimeString());
        }
           public static void ShowDate(DateTime time)
        {
            Console.WriteLine(time.ToLongDateString());

            // zu testzwecken
           // throw new Exception("Something went wrong");

        }
    } 
}
