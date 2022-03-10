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
        private int timeToPickUpFromDeskQueue = 100;
        public void StartSplittingBaggage()
        {
            while (true)
            {
                Baggage baggage = TakeBaggegeFromDeskQueue();
                Gate gate = DetermenGateOutput(baggage);
                QueueBaggageInSpecificGateBuffer(baggage, gate);

            }
        }
        private Baggage TakeBaggegeFromDeskQueue()
        {
            Baggage baggage = null;
            try
            {
                Monitor.Enter(Airport.DeskQueue);
                if (Airport.DeskQueue.Count <= 0)
                {
                    Debug.Print("Spittler is now wating for baggage");
                    Monitor.Wait(Airport.DeskQueue);
                }
                //Simulates the time it takes to pick up from queue.
                Thread.Sleep(timeToPickUpFromDeskQueue);
                baggage = Airport.DeskQueue.Dequeue();    
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
        private Gate DetermenGateOutput(Baggage baggage)
        {
            //Finds the first gate with a destination equals to the baggage destination.
            return Airport.Gates.First(x => x.Destination == baggage.Destination);
        }
        private void QueueBaggageInSpecificGateBuffer(Baggage baggage, Gate gate)
        {
            //Acquiers the lock for the specific gate and enqueues the specific baggage to the queue.
            try
            {
                Monitor.Enter(gate.GateQueue);
                gate.GateQueue.Enqueue(baggage);
                Debug.Print($"Baggage {baggage.Id} to gate {gate.GateName} has been enqueueed");
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
