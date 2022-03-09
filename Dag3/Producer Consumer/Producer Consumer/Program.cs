using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Producer_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Producer producer = new Producer();
            Consumer consumer = new Consumer();

            Thread producerThread = new Thread(producer.StartProducing);
            Thread consumerThread = new Thread(consumer.StartConsuming);
            producerThread.Start();
            consumerThread.Start();
            Console.WriteLine("start");
            Console.Read();
        }
    }
}
