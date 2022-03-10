using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem.Gui
{
    class ConsoleController
    {
        private char keyToToggleListener = 'M';
        TextWriterTraceListener listener = new TextWriterTraceListener(System.Console.Out);
        public void StartConsoleController()
        {
            Debug.Listeners.Add(listener);
            Thread thread = new Thread(this.StartLisiningForKeys);
            thread.Start();
            thread.Join();
        }
        private void StartLisiningForKeys()
        {
            string strInput;
            char charInput;
            bool allowedInput;
            DisplayAirportInfo displayAirportInfo = new DisplayAirportInfo();
            Thread DisplayAllAirportInfoThread = new Thread(displayAirportInfo.DisplayAllAirportInfo);
            while (true)
            {
                strInput = Console.ReadKey().Key.ToString();
                allowedInput = char.TryParse(strInput, out charInput);
                if (allowedInput == true && charInput == keyToToggleListener)
                {
                    if (!Debug.Listeners.Contains(listener))
                    {
                        Debug.Listeners.Add(listener);
                        DisplayAllAirportInfoThread.Abort();
                        continue;
                    }

                    Debug.Listeners.Remove(listener);
                    DisplayAllAirportInfoThread.Start();


                }
                
            }
        }
    }
}
