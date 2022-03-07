using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_programmering_trådpool_øvelserOpgave
{
    public class ThreadPoolDemo
    {
        public void Task1(object obj)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("This is task 1");
            }
        }
        public void Task2(object obj)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("This is task 2");
            }
        }
    }
}
