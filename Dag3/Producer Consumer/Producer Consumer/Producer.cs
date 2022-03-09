using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Producer_Consumer.Buffer;

namespace Producer_Consumer
{
    class Producer
    {
        private const int ProducerTimeToProduce = 700;
        private const int ProducerTimeToSetProductInQueue = 200;
        public void StartProducing()
        {
            while (true)
            {
                //Simulates the time it takes to make a product.
                ProduceProduct();
                //Checks if the queue is full every 100ms.
                while (BufferQueue.Count >= MaxQueue)
                    Thread.Sleep(100);
                try
                {
                    //Waits for the buffer queue to be unlocked.
                    Monitor.TryEnter(BufferQueue, -1);
                    //Simulates a task that uses the Queue.
                    SetProductInQueue();
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

            }
        }

        private void ProduceProduct()
        {
            Console.WriteLine($"Producer is producing product for {ProducerTimeToProduce} ms");
            Thread.Sleep(ProducerTimeToProduce);
        }

        private void SetProductInQueue()
        {
            //Console.WriteLine($"Producer is producing product for {ProducerTimeToSetProductInQueue} ms");
            Thread.Sleep(ProducerTimeToSetProductInQueue);
            string newProductSerialNum = Guid.NewGuid().ToString();
            BufferQueue.Enqueue(new Product(newProductSerialNum));
            Console.WriteLine($"Product {newProductSerialNum} has been queued. Now a total of {BufferQueue.Count} products is in the queue");

        }
    }
}
