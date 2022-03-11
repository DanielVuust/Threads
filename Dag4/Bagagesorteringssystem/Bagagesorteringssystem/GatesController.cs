using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class GatesController
    {
        public void StartControllingGates()
        {
            while (true)
            {
                Flight flight = GetNextInFlightQueue();

            }
        }

        private Flight GetNextInFlightQueue()
        {
            Flight flight = null;
            try
            {
                Monitor.Enter(Airport.FlightsWaitingQueue);
                while (Airport.FlightsWaitingQueue.Count <= 0)
                {
                    Debug.Print("Waiting for flights");
                    Monitor.Wait(Airport.FlightsWaitingQueue);
                }

                flight = Airport.FlightsWaitingQueue.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(Airport.FlightsWaitingQueue);
                Monitor.Exit(Airport.FlightsWaitingQueue);
            }

            return flight;
        }

        private void AssignFlightToGate(Flight flight)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Monitor.PulseAll(Airport.Gates);
                Monitor.Exit(Airport.Gates);
            }
        }
    }
}
