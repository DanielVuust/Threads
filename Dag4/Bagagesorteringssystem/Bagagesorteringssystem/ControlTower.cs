using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class ControlTower
    {
        public void StartAcceptingFlights()
        {
            while (true)
            {
                AddFlightToWaitingQueue();
            }
        }
        
        private void AddFlightToWaitingQueue()
        {
            try
            {
                Monitor.Enter(Airport.FlightsWaitingQueue);
                Flight flight = CreateFlight();
                Airport.FlightsWaitingQueue.Enqueue(flight);
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
            Thread.Sleep(3000);
        }

        private Flight CreateFlight()
        {
            Flight flight = new Flight("London");
            return flight;
        }
    }
}
