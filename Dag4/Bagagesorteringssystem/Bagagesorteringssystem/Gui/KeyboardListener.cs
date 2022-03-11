using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Gui;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class KeyBoardListener
    {
        TextWriterTraceListener listener = new TextWriterTraceListener(System.Console.Out);
        Thread DisplayAllAirportInfoThread = new Thread(new DisplayAirportInfo().DisplayAllAirportInfo);
        public void StartListeningForKeyPresses()
        {
            Debug.Listeners.Add(listener);
            ConsoleKey consoleKey;
            char charInput;
            bool allowedInput;
            DisplayAirportInfo displayAirportInfo = new DisplayAirportInfo();
            while (true)
            {
                consoleKey = Console.ReadKey().Key;

                switch (consoleKey)
                {
                    case (ConsoleKey.M):
                        ToggleDisplayType();
                        break;
                    case ConsoleKey.D1:
                        Airport.AddGateToAirport();
                        break;
                    case ConsoleKey.D2:

                        break;
                    case ConsoleKey.D3:

                        break;
                }
            }
        }
        private void ToggleDisplayType()
        {
            if (!Debug.Listeners.Contains(listener))
            {
                DisplayAllAirportInfoThread.Abort();
                Debug.Listeners.Add(listener);
                return;
            }

            Debug.Listeners.Remove(listener);
            DisplayAllAirportInfoThread.Start();
        }

        private void AddCheckInDesk()
        {

        }
    }
}
