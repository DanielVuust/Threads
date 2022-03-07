using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cs_programmering_basis_tråd_øvelserOpgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Program program = new Program();
            //program.DisplayStrings();
            //program.Tempature();
            program.DisplayKeys();
            Console.Read();
        }
        private void DisplayStrings()
        {
            ThreadProgram threadProgram = new ThreadProgram();
            Thread thread = new Thread(new ThreadStart(threadProgram.DisplayString));
            thread.Name = "DisplayString";
            thread.Start();
            Thread thread2 = new Thread(new ThreadStart(threadProgram.DisplayString2));
            thread2.Name = "DisplayString2";
            thread2.Start();
        }
        private void Tempature()
        {
            ThreadProgram threadProgram = new ThreadProgram();
            Thread CheckTempreatureThread = new Thread(new ThreadStart(threadProgram.CheckTempreatureThread));
            CheckTempreatureThread.Name = "CheckTempreatureThread";
            CheckTempreatureThread.Start();

            CheckTempreatureThread.Join();
            Console.WriteLine("Alarm-tråd termineret!");
        }
        private void DisplayKeys()
        {
            ThreadProgram threadProgram = new ThreadProgram();
            Thread getKeys = new Thread(new ThreadStart(threadProgram.ReadKeyPress));
            getKeys.Name = "GetKeys";
            getKeys.Start();
            Thread DisplayCharThread = new Thread(new ThreadStart(threadProgram.DisplayChar));
            DisplayCharThread.Name = "DisplayCharThread";
            DisplayCharThread.Start();

        }
    }
}
