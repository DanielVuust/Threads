using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Gui;
using Bagagesorteringssystem.Producers;

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
            Thread createFlightsThread = new Thread(new CreateFlights().StartAcceptingFlights);
            createFlightsThread.Start();
            Thread controlTowerThread = new Thread(new ControlTower().StartControllingFlights);
            controlTowerThread.Start();
            Thread checkInDeskThread = new Thread(new CheckInDesksController().StartAcceptingBaggage);
            checkInDeskThread.Start();
            Thread baggageSplitterThread = new Thread(new BaggageSplitter().StartSplittingBaggage);
            baggageSplitterThread.Start();
            Thread keyBoardListenerThread = new Thread(new KeyBoardListener().StartListeningForKeyPresses);
            keyBoardListenerThread.Start();

        }

    }
}
