using Bagagesorteringssystem.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class BaggageSplitter
    {
        public void StartSplittingBaggage()
        {
            Baggage baggage;
            Gate baggageQueue;
            AirportController airportController = new AirportController();
            while (true)
            {
                baggage = TakeBaggageFromDeskQueue();
                baggageQueue = DetermineGateOutput(baggage);
                airportController.QueueBaggageInSpecificBuffer(baggage, baggageQueue);

            }
        }
        private Baggage TakeBaggageFromDeskQueue()
        {
            Baggage baggage = null;
            try
            {
                Monitor.Enter(Airport.DeskQueue);

                if (Airport.DeskQueue.Count <= 0)
                {
                    Debug.Print("Splitter is now waiting for baggage");
                    Monitor.Wait(Airport.DeskQueue);
                }
                
                baggage = Airport.DeskQueue.Dequeue();
                baggage.AddTimeStampWithCurrentTime("Has been queued to the desk queue");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(Airport.DeskQueue);
                Monitor.Exit(Airport.DeskQueue);
            }
            return baggage;
        }
        private Gate DetermineGateOutput(Baggage baggage)
        {
            //Finds the first gate with a destination equals to the baggage destination and has space for more cargo.
            return Airport.Gates.FirstOrDefault(x => x.Destination == baggage.Destination && x.GateQueue.Count + x?.Flight?.Cargo.Count(y => y != null) < x?.Flight?.MaxCargo);
        }
        


    }
}
