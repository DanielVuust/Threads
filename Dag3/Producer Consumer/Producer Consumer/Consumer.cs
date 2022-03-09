using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Producer_Consumer.Buffer;


namespace Producer_Consumer
{
    class Consumer
    {
        private const int ConsumerTimeToConsume = 1000;
        private const int ConsumerTimeToPickProductFromQueue = 200;

        public void StartConsuming()
        {
            while (true)
            {
                //Check if the queue has values every 100ms.
                while(BufferQueue.Count <= 0)
                    Thread.Sleep(100);
                try
                {
                    //Waits for the buffer queue to be unlocked.
                    Monitor.TryEnter(BufferQueue, -1);
                    //Simulates  a task that uses the Queue.
                    PickUpProductFromQueue();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    //Removes the lock from BufferQueue.
                    Monitor.Exit(BufferQueue);
                }
                //Simulates how long it takes a product to be consumed.
                ConsumeProduct();
            }
        }

        private void PickUpProductFromQueue()
        {
            //Console.WriteLine($"Consumer is picking up product from queue for {ConsumerTimeToPickProductFromQueue} ms");
            Thread.Sleep(ConsumerTimeToPickProductFromQueue);
            Console.WriteLine($"Product {BufferQueue.First()} has been dequeued. Now a total of {BufferQueue.Count-1} products is left");
            BufferQueue.Dequeue();
        }

        private void ConsumeProduct()
        {
            Console.WriteLine($"Consumer is consuming products for {ConsumerTimeToConsume} ms");
            Thread.Sleep(ConsumerTimeToConsume);
        }
    }
}
