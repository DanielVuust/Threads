using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Flaskeautomaten.DrinkBuffers;

namespace Flaskeautomaten
{
    class Splitter
    {
        private int _timeToEnqueuInBufferInMs = 2000;
        private Dictionary<DrinkTypes, Queue<Drink>> drinkOutputBuffer = new Dictionary<DrinkTypes, Queue<Drink>>()
        {
            {DrinkTypes.Water, WaterBuffer},
            {DrinkTypes.Beer, BeerBuffer }
        };
        public void StartSplittingDrinks()
        {
            while (true)
            {
                //Will block AllDrinksBuffer
                Drink drink = TakeDrinkFromAllDrinksBuffer();
                Queue<Drink> drinkQueue = DetermenBufferToPutDrinkIn(drink);

                this.EnqueueInOutputBuffer(drinkQueue, drink);
                
            }
        }
        private Drink TakeDrinkFromAllDrinksBuffer()
        {
            Drink drink = null;
            try
            {
                Monitor.Enter(AllDrinksBuffer);

                //Waits untill the AllDrinksBuffer has drinks in it
                while (AllDrinksBuffer.Count == 0)
                {
                    Console.WriteLine("Spitter is now wating for AllDrinksBuffer");
                    Monitor.Wait(AllDrinksBuffer);
                }

                drink = AllDrinksBuffer.Dequeue();
                Console.WriteLine($"Splitter is no longer waiting for AllDrinksBuffer and has dequeued a {drink.DrinkType}");
                Monitor.PulseAll(AllDrinksBuffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.Exit(AllDrinksBuffer);
            }
            return drink;
        }
        private Queue<Drink> DetermenBufferToPutDrinkIn(Drink drink)
        {
            var test = drinkOutputBuffer[drink.DrinkType];
            return test;
        }
        private void EnqueueInOutputBuffer(Queue<Drink> queue, Drink drink)
        {
            try
            {
                Monitor.Enter(queue);
                while (queue.Count >= MaxBufferSize)
                {
                    Console.WriteLine($"Splitter is wating for {drink.DrinkType}");
                    Monitor.Wait(queue);
                }
                Console.WriteLine($"Splitter is now in the proccess of queueing a drink in {drink.DrinkType} queue");

                //Simulates how long it takes to queue a drink.
                Thread.Sleep(_timeToEnqueuInBufferInMs);

                //Add drink to the AllDrinksBuffer
                queue.Enqueue(drink);

                Monitor.PulseAll(queue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.Exit(queue);
            }
        }
    }
}
