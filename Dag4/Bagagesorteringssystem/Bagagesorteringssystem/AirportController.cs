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
    /// <summary>
    ///     Controlls everything inside the airport
    /// </summary>
    class AirportController
    {
        public bool AddCheckInDesk(int connectionIndex)
        {
            
            var checkInDesk = Airport.CheckInDesks.FirstOrDefault(x => x.IsOpen == false);
            if (checkInDesk == null)
                return false;

            //Creates a new desk and assigns a destination to it.
            checkInDesk.Destination = Airport.Connections[connectionIndex];
            checkInDesk.IsOpen = true;

            return true;
        }
        public bool AddGateToAirport()
        {
            var gate = Airport.Gates.FirstOrDefault(x => x.InUse == false);
            if (gate == null)
                return false;

            //Creates a new gate and assigns a flight to it.
            gate.Flight = Airport.FlightsWaitingQueue.Dequeue();
            gate.InUse = true;

            return true;
        }
        public void QueueBaggageInSpecificBuffer(Baggage baggage, Gate gate)
        {
            if (gate == null)
            {
                EnqueueBaggeToLostAndFound(baggage);
                return;
            }
            EnqueueInBaggageQueue(gate, baggage);
        }
        private void EnqueueBaggeToLostAndFound(Baggage baggage)
        {
            try
            {
                Monitor.Enter(Airport.LostBaggageQueue);
                Airport.LostBaggageQueue.Enqueue(baggage);
                Debug.Print($"Baggage {baggage.Id} has been sent to Lost And Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(Airport.LostBaggageQueue);
                Monitor.Exit(Airport.LostBaggageQueue);
            }

        }
        private void EnqueueInBaggageQueue(Gate gate, Baggage baggage)
        {
            //Acquiers the lock for the specific gate and enqueues the specific baggage to the queue.
            try
            {
                Monitor.Enter(gate?.GateQueue);
                gate.GateQueue.Enqueue(baggage);
                Debug.Print($"Baggage {baggage.Id} has been sent to gate {gate.GateName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(gate.GateQueue);
                Monitor.Exit(gate.GateQueue);
            }
        }
    }
}
