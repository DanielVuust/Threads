using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Flaskeautomaten.DrinkBuffers;

namespace Flaskeautomaten
{
    class WaterTruck
    {
        private const int timeToWaitForNewTruck = 3000;
        private const int timeToDequeue = 100;
        private const int truckMaxCargo = 10;
        private int currentTruckCargo = 0;
        private int totalLoadsSent = 0;
        public void StartLoadingWaterTruck()
        {
            while (true)
            {
                LoadWater();
                if (CheckIfFullCargo())
                    SendTruck();

            }
        }
        private void LoadWater()
        {
            try
            {
                Monitor.Enter(WaterBuffer);
                while (WaterBuffer.Count <= 0)
                {
                    Console.WriteLine("The WaterTruck is now wating for WaterBuffer");
                    Monitor.Wait(WaterBuffer);
                }
                Console.WriteLine("The water truck is now dequeueing a water from WaterBuffer");
                Thread.Sleep(timeToDequeue);
                WaterBuffer.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(WaterBuffer);
                Monitor.Exit(WaterBuffer);
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
            currentTruckCargo = 0;
            Console.WriteLine($"A total of {totalLoadsSent} loads of {truckMaxCargo} Waters have been sent");
        }
    }
}

