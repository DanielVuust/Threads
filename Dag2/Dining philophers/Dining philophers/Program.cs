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
            int philophersCount = 5;
            Philopher[] philophers = new Philopher[philophersCount];
            for(int i = 0; i < philophersCount; i++)
            {
                philophers[i] = new Philopher(i, philophersCount);
            }
            Table table= new Table(philophers);
            for(int i = 0; i < philophersCount  ; i++)
            {
                Console.WriteLine(i);
                Thread thread = new Thread(() => table.StartEating(philophers[i]));
                thread.Start();
                Thread.Sleep(100);
            }
            Thread forkThread = new Thread(() => table.DisplayStatus(philophers));
            forkThread.Start();
        }
    }
}
