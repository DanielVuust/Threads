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
        Thread DisplayAllAirportInfoThread;
        public void StartListeningForKeyPresses()
        {
            //Debug.Listeners.Add(listener);
            char consoleKey;
            DisplayAirportInfo displayAirportInfo = new DisplayAirportInfo();
            DisplayAllAirportInfoThread = new Thread(displayAirportInfo.DisplayAllAirportInfo);
            AirportController airportController = new AirportController();
            int connectionIndex;
            DisplayAllAirportInfoThread.Start();
            while (true)
            {
                consoleKey = Console.ReadKey().KeyChar;

                switch (consoleKey)
                {
                    case 'm':
                        ToggleDisplayType();
                        break;
                    case '1':
                        airportController.AddGateToAirport();
                        break;
                    case '2':
                        connectionIndex = PromtUserAllConnectionsAndGetChoose();
                        airportController.AddCheckInDesk(connectionIndex);
                        break;
                    case '3':

                        break;
                    case 'æ':
                        //Makes sure the interval won't go under 0ms.
                        if (Airport.BaggageInterval <= 0)
                            break;
                        Airport.BaggageInterval -= 100;
                        break;
                    case 'p':
                        Airport.BaggageInterval += 100;
                        break;
                    case 'z':
                        if (displayAirportInfo.ShowKeybindings)
                            displayAirportInfo.ShowKeybindings = false;
                        else
                            displayAirportInfo.ShowKeybindings = true;
                        break;


                }
            }
        }
        private void ToggleDisplayType()
        {
            if (!Debug.Listeners.Contains(listener))
            {
                DisplayAllAirportInfoThread.Suspend();
                Debug.Listeners.Add(listener);
                return;
            }
            DisplayAllAirportInfoThread.Resume();
            Debug.Listeners.Remove(listener);
            
        }
        private int PromtUserAllConnectionsAndGetChoose()
        {
            var consoleKey = Console.ReadKey().KeyChar;
            Int32.TryParse(consoleKey.ToString(), out int j);
            return j;
        }
    }
}
