using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Flaskeautomaten.DrinkBuffers;


namespace Flaskeautomaten
{
    class BeerTruck
    {
        private const int timeToWaitForNewTruck = 3000;
        private const int timeToDequeue = 100;
        private const int truckMaxCargo = 10;
        private int currentTruckCargo = 0;
        private int totalLoadsSent = 0;
        public void StartLoadingBeerTruck()
        {
            while (true)
            {
                LoadBeer();
                if (CheckIfFullCargo())
                    SendTruck();

            }
        }
        private void LoadBeer()
        {
            try
            {
                Monitor.Enter(BeerBuffer);
                while (BeerBuffer.Count <= 0)
                {
                    Console.WriteLine("The beer truck is now wating for BeerBuffer");
                    Monitor.Wait(BeerBuffer);
                }
                Console.WriteLine("The beer truck is now dequeueing a beer from BeerBuffer");
                Thread.Sleep(timeToDequeue);
                BeerBuffer.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(BeerBuffer);
                Monitor.Exit(BeerBuffer);
            }
            currentTruckCargo++;
        }
        private bool CheckIfFullCargo()
        {
            return (currentTruckCargo >= truckMaxCargo);
        }
        private void SendTruck()
        {
            //Simulates the time it takes to send and get a new truck.
            Thread.Sleep(timeToWaitForNewTruck);
            totalLoadsSent++;
            Console.WriteLine($"A total of {totalLoadsSent} loads of {truckMaxCargo} beers have been sent");
        }
    }
}
