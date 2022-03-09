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
        static bool[] forks = new bool[50];

        public Table(Philosopher[] philosophers)
        {
            this.philophersCount = philosophers.Length;
        }
        public void StartEating(Philosopher philosopher)
        {
            int forkOneIndex = philosopher.allowedForks[0];
            int forkTwoIndex = philosopher.allowedForks[1];
            while (true)
            {
                lock (forks)
                {
                    while (forks[forkOneIndex] || forks[forkTwoIndex])
                    {
                        Monitor.Wait(forks);
                    }
                    forks[forkOneIndex] = true;
                    forks[forkTwoIndex] = true;
                    philosopher.isEating = true;

                }
                //The philosopher is eating for 500ms 
                Thread.Sleep(500);
                //The philosopher stopped eating
                lock (forks) 
                { 
                    philosopher.isEating = false;
                    forks[forkOneIndex] = false;
                    forks[forkTwoIndex] = false;
                    Monitor.PulseAll(forks);

                }
                Thread.Sleep(10);
                
            }
        }
        /// <summary>
        ///     Displays the current status for forks and philosophers
        /// </summary>
        public void DisplayStatus(Philosopher[] philophers)
        {
            while (true)
            {
                Console.Clear();
                this.CheckForkStatus();
                Console.WriteLine();
                this.CheckPhilophersStatus(philophers);
                Thread.Sleep(100);
            }

        }
        private void CheckPhilophersStatus(Philosopher[] Philosophes)
        {
            foreach (Philosopher philosopher in Philosophes)
            {
                if (philosopher.isEating)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(philosopher.philosopherNum + " is eating");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(philosopher.philosopherNum + " is Not eating");
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
