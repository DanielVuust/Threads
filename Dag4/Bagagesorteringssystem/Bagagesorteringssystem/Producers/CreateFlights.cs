using Bagagesorteringssystem.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem.Producers
{
    class CreateFlights
    {
        public void StartAcceptingFlights()
        {
            while (true)
            {
                if(Airport.FlightsWaitingQueue.Count < 10)
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
            Flight flight = new Flight(GetRandomAirportConnection());
            return flight;
        }
        Random ran = new Random();
        private string GetRandomAirportConnection()
        {
            return Airport.Connections[ran.Next(Airport.Connections.Count)];

        }
    }
}
