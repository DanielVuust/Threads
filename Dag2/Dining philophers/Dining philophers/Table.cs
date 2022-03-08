using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_philophers
{
    public class Table
    {
        private int philophersCount;
        static bool[] forks = new bool[5];

        public Table(Philopher[] philophers)
        {
            this.philophersCount = philophers.Length;
        }
        public void StartEating(Philopher philopher)
        {
            int forkOneIndex = philopher.allowedForks[0];
            int forkTwoIndex = philopher.allowedForks[1];
            while (true)
            {
                Monitor.Enter(forks);
                    if (forks[forkOneIndex] || forks[forkTwoIndex])
                    {
                        Monitor.Wait(forks);
                    }
                    forks[forkOneIndex] = true;
                    forks[forkTwoIndex] = true;
                    philopher.isEating = true;
                    Thread.Sleep(1000);
                    philopher.isEating = false;
                    forks[forkOneIndex] = false;
                    forks[forkTwoIndex] = false;
                    Monitor.PulseAll(forks);
                
            }
        }
        public void DisplayStatus(Philopher[] philophers)
        {
            while (true)
            {
                Console.Clear();
                this.CheckForkStatus();
                Console.WriteLine();
                this.CheckPhilophersStatus(philophers);
                Thread.Sleep(200);
            }

        }
        private void CheckPhilophersStatus(Philopher[] philophers)
        {
            foreach (Philopher philopher in philophers)
            {
                if (philopher.isEating)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(philopher.philopherNum + " is eating");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(philopher.philopherNum + " is Not eating");
                }
            }
            
        }
        public void CheckForkStatus()
        {
            int forkNum = 0;
            foreach(bool fork in forks)
            {
                if (fork)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(forkNum + " is in use");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(forkNum + " is Not in use");
                }
                forkNum++;
            }


        }
    }
}
