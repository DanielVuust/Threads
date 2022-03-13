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

        public void StartCreatingBaggage()
        {
            while (true)
            {
                Baggage baggage = CreateRandomBaggage();

                //First gets all of the check in desks with the destination of the baggage,
                //Then uses the aggregate command to get the check in desk with the lowest queue count.
                var checkInDesk = Airport.CheckInDesks.Where(x => x.Destination == baggage.Destination).Aggregate((minItem, nextItem) => minItem.CurrentQueue.Count < nextItem.CurrentQueue.Count ? minItem : nextItem);

                checkInDesk.AddBaggageToCurrentQueue(baggage);

                //Simulates te delay between passengers checking in baggage. 
                Thread.Sleep(Airport.BaggageInterval);
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
