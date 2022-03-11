using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class CreateBaggage
    {
        private int delayBeforeCreatingNewBaggage = 100;

        public void StartCreatingBaggage()
        {
            while (true)
            {
                Baggage baggage = CreateRandomBaggage();

                var checkInDesk = Airport.CheckInDesks.Where(x => x.Destination == baggage.Destination).Min();
                checkInDesk.AddBaggageToCurrentQueue(baggage);

                //Simulates te delay between passengers checking in baggage. 
                Thread.Sleep(delayBeforeCreatingNewBaggage);
            }

        }
        private Baggage CreateRandomBaggage()
        {
            return new Baggage(GetRandomLocationForBaggage());
        }
        private string GetRandomLocationForBaggage()
        {
            Random ran = new Random();
            return Airport.Connections[ran.Next(0, Airport.Connections.Count)];
        }
    }
}
