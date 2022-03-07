using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cs_programmering_basis_tråd_øvelserOpgave2
{
    class ThreadProgram
    {
        char ch = '*';
        public void DisplayString()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("C#-trådning er nemt!");
                Thread.Sleep(1000);
            }
        }
        public void DisplayString2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" Også med flere tråde …");
                Thread.Sleep(1000);
            }
        }
        public void CheckTempreatureThread()
        {
            int alarmNum = 0;
            Random ran = new Random();
            while(!(alarmNum >= 3))
            {
                Thread.Sleep(2000);
                int currentTemp = ran.Next(-20, 120);
                Console.WriteLine(currentTemp);
                if (currentTemp > 100 || currentTemp < 0)
                {
                    alarmNum++;
                }
            }
        }
        public void ReadKeyPress()
        {
            string strInput;
            bool allowedInput;
            while (true)
            {
                strInput = Console.ReadLine();
                allowedInput = char.TryParse(strInput, out this.ch);
                if (allowedInput == false)
                    this.ch = '*';
            }
        }
        public void ReadKeyPress2()
        {
            char currentKey = '*';
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    this.ch = currentKey;
                    Console.WriteLine();
                }
                else
                {
                    currentKey = consoleKeyInfo.KeyChar;
                }
            }
        }
        public void DisplayChar()
        {
            while (true)
            {
                Console.Write(this.ch);
                Thread.Sleep(100);
            }
        }
    }
}
