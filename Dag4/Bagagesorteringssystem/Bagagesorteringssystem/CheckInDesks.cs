using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class CheckInDesks
    {
        private int delayBeforeCreatingNewBaggage = 0;
        public void StartAcceptingBaggage()
        {
            while (true)
            {
                Baggage baggage = CreateBaggage();

                CheckInDesk checkInDesk = Airport.CheckInDesks.First(x=>x.Destination == baggage.Destination);
                //Opens the desk if if its closed 
                if(!checkInDesk.IsOpen)
                    checkInDesk.IsOpen = true;

                checkInDesk.CheckInBaggage(baggage);
            }
        }
        private Baggage CreateBaggage()
        {
            Thread.Sleep(delayBeforeCreatingNewBaggage);
            return new Baggage(GetRandomLocationForBaggage()); 
        }
        private string GetRandomLocationForBaggage()
        {
            Random ran = new Random();
            return Airport.Connections[ran.Next(0, Airport.Connections.Count)];
        }

        
    }
}
