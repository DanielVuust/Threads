using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class CheckInDesksController
    {
        public void StartAcceptingBaggage()
        {
            while (true)
            {
                foreach (var checkInDesk in Airport.CheckInDesks)
                {
                    if(checkInDesk.CurrentQueue.Count > 0)
                        checkInDesk.CheckInBaggageNextInQueue();
                }
                Thread.Sleep(1000);

            }
        }
    }
}
