using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cs_programmering_trådpool_øvelserOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Task1();

            Console.ReadLine();
        }
        private void Task0()
        {
            ThreadPoolDemo threadPoolDemo = new ThreadPoolDemo();
            for(int i = 0; i < 2; i++)
            {
                ThreadPool.QueueUserWorkItem(threadPoolDemo.Task1);
                ThreadPool.QueueUserWorkItem(threadPoolDemo.Task2);

            }

        }
        private void Task1()
        {
            Task1 task1 = new Task1();
            task1.StartTask1();
        }
    }
}
