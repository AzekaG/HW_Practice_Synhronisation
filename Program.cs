using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW_Practice_Synhronisation
{
    internal class Program
    {
        static int x = 0;
        static object locker = new object();

        static void Main(string[] args)
        {
            for (int i  = 1; i < 6 ; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = $"Thread {i}";
                myThread.Start();

            }
            Console.ReadLine();

        }


        public static void Count()
        {
                lock(locker)            //объект блокировки. Наш код будет обрабатываться в одно время только одним потоком. 
                { 
                   x = 1;
                   for(int i = 1; i < 6; i++)
                          {
                                 Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
                                  x++;
                                  Thread.Sleep(100);
                           }
                 }
        }
    }
}
