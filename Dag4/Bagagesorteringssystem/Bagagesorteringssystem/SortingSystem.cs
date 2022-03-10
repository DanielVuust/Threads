using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class SortingSystem
    {
        public void StartSortingSystem()
        {
            SetUpAirport setUpAirport = new SetUpAirport();
            setUpAirport.SetUpAll();
            Thread checkInDeskThread = new Thread(new CheckInDesks().StartAcceptingBaggage);
            checkInDeskThread.Start();
        }
        
    }
}
