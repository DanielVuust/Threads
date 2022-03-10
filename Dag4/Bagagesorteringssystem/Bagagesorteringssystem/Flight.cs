using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Flight
    {
        private string flightId;
        private string destination;
        public string FlightId
        {
            get { return flightId; }
        }
        
        public string Destination
        {
            get { return destination; }
        }

        public Flight(string flightId, string destination)
        {
            this.flightId = flightId;
            this.destination = destination;
        }
    }
}
