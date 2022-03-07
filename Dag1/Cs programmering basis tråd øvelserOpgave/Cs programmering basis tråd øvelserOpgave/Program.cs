using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Cs_programmering_basis_tråd_øvelserOpgave
{
    class program
    {
        public List<string> names = new List<string>();
        //Displays SimpleThread 5 times.
        public void WorkThreadFuntion()
        {
            foreach(string name in names)
            {
                Console.WriteLine(name + "|||");
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("SimpleThread");
            }
        }
        public void WorkThreadFuntion2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("SimpleThread");
            }
        }
    }
    class threaprog
    {
        public static void Main()
        {
            //Creates thread and start thread.
            program pg = new program();
            Thread thread = new Thread(new ThreadStart(pg.WorkThreadFuntion));
            thread.Name = "testName";
            pg.names.Add("testName");
            thread.Start();
            Thread thread2 = new Thread(new ThreadStart(pg.WorkThreadFuntion2));
            thread2.Name = "testName2";
            pg.names.Add("testName2");

            thread2.Start();
            Console.ReadLine();
        }
    }
}
