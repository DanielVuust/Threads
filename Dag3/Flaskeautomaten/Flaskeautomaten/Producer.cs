using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using static Flaskeautomaten.DrinkBuffers;

namespace Flaskeautomaten
{
    class Producer
    {
        private int _timeToEnqueuInBufferInMs = 100;

        private int runningNum = 0;
        public void ProduceDrinks()
        {
            Random ran = new Random();
            while (true)
            {
                int index = ran.Next(0, DrinkTypesCount);
                EnqueueInAllDrinksBuffer(index);

                runningNum++;
            }
        }

        private void EnqueueInAllDrinksBuffer(int index)
        {
            Thread.Sleep(100);
            
            Monitor.Enter(DrinkBuffers.AllDrinksBuffer);
            while(AllDrinksBuffer.Count >= MaxBufferSize)
                Monitor.Wait(AllDrinksBuffer);

            Thread.Sleep(_timeToEnqueuInBufferInMs);
            Drink newDrink = new Drink(index, runningNum);
            AllDrinksBuffer.Enqueue(newDrink);

            Monitor.PulseAll(AllDrinksBuffer);
        }
    }
}
