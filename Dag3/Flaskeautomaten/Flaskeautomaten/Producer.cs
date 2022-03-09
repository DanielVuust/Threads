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
        private int _timeToMakeDrink = 1000;

        private int runningNum = 0;
        public void ProduceDrinks()
        {
            Random ran = new Random();
            DrinksInfo drinksInfo = new DrinksInfo();
            while (true)
            {
                //Simulates how long it takes to make a drink.
                Thread.Sleep(_timeToMakeDrink);

                int index = ran.Next(0, drinksInfo.DrinkTypesCount);
                EnqueueInAllDrinksBuffer(index);

                runningNum++;
            }
        }

        private void EnqueueInAllDrinksBuffer(int index)
        {
            try
            {
                Monitor.Enter(AllDrinksBuffer);
                while(AllDrinksBuffer.Count >= MaxBufferSize)
                {
                    Console.WriteLine("Producer is wating for AllDrinksBuffer");
                    Monitor.Wait(AllDrinksBuffer);
                }
                Console.WriteLine("Producer is no longer wating and is in the proccess of queueing a drink in AllDrinksBuffer");

                //Simulates how long it takes to queue a drink.
                Thread.Sleep(_timeToEnqueuInBufferInMs);

                //Add drink to the AllDrinksBuffer
                Drink newDrink = new Drink(index, runningNum);
                AllDrinksBuffer.Enqueue(newDrink);

                Monitor.PulseAll(AllDrinksBuffer);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.Exit(AllDrinksBuffer);
            }
        }
    }
}
