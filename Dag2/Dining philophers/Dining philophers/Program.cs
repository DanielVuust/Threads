using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_philophers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 50;
            Philosopher[] philosophers = new Philosopher[count];
            for(int i = 0; i < count; i++)
            {
                philosophers[i] = new Philosopher(i, count);
            }
            Table table= new Table(philosophers);
            for(int i = 0; i < count  ; i++)
            {
                Console.WriteLine(i);
                Thread thread = new Thread(() => table.StartEating(philosophers[i]));
                thread.Start();
                Thread.Sleep(100);
            }
            Thread forkThread = new Thread(() => table.DisplayStatus(philosophers));
            forkThread.Start();
        }
    }
}
