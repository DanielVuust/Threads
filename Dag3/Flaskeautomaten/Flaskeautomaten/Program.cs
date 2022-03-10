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
            Thread SplitterThread = new Thread(new Splitter().StartSplittingDrinks);
            SplitterThread.Start();
            Thread BeerTruckThread = new Thread(new BeerTruck().StartLoadingBeerTruck);
            BeerTruckThread.Start();
            Thread WaterTruckThread = new Thread(new WaterTruck().StartLoadingWaterTruck);
            WaterTruckThread.Start();
            
            Console.Read();
        }
    }
}
