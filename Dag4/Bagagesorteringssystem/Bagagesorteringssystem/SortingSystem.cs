using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Gui;

namespace Bagagesorteringssystem
{
    class SortingSystem
    {
        public void StartSortingSystem()
        {
            SetUpAirport setUpAirport = new SetUpAirport();
            setUpAirport.SetUpAll();
            Thread createBaggageThread = new Thread(new CreateBaggage().StartCreatingBaggage);
            createBaggageThread.Start();
            Thread acceptFlightsThread = new Thread(new ControlTower().StartAcceptingFlights);
            acceptFlightsThread.Start();
            Thread checkInDeskThread = new Thread(new CheckInDesksController().StartAcceptingBaggage);
            checkInDeskThread.Start();
            Thread baggageSplitterThread = new Thread(new BaggageSplitter().StartSplittingBaggage);
            baggageSplitterThread.Start();
            Thread keyBoardListenerThread = new Thread(new KeyBoardListener().StartListeningForKeyPresses);
            keyBoardListenerThread.Start();

        }

    }
}
