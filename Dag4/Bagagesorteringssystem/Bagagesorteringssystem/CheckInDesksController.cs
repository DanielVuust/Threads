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
                    //Opens the desk if if its closed 
                    if(!checkInDesk.IsOpen)
                        checkInDesk.IsOpen = true;

                    checkInDesk.CheckInBaggageNextInQueue();
                }

            }
        }

        private void CheckIfDeskCanClose(CheckInDesk checkInDesk)
        {

        }
    }
}
