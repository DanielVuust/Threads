using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread producerThread = new Thread(new Producer().ProduceDrinks);
            producerThread.Start();

            lock (DrinkBuffers.AllDrinksBuffer)
            {
                Console.WriteLine("Producer is waiting2");
                Console.WriteLine("Producer is waiting3");


            }
            Console.Read();
        }
    }
}
