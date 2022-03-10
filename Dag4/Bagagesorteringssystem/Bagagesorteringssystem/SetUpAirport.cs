using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class SetUpAirport
    {
        private readonly int maxCheckInDesks = 10;
        public void SetUpAll()
        {
            SetUpDesks();
            //SetUpGates();
        }

        private void SetUpDesks()
        {
            for (int i = 0; i < maxCheckInDesks; i++)
            {
                Airport.CheckInDesks.Add(new CheckInDesk("London"));
            }
        }

        private void SetUpDesksBuffers()
        {
            foreach (CheckInDesk checkInDesks in Airport.CheckInDesks)
            {
                Queue<Baggage> queue = new Queue<Baggage>();

            }
        }
        private void SetUpGates()
        {
            for (int i = 0; i < 4; i++)
            {
                Gate gate = new Gate(i.ToString(), GetRandomDestination());
                Gates.AllGates.Add(gate);
            }
        }

        private string GetRandomDestination()
        {
            Random ran = new Random();

            //Gets a random destination form the Destinations enum
            Destinations destination = (Destinations)ran.Next(0, 3);

            //Converts the Destinations enum to string and returns it.
            return Enum.GetName(typeof(Destinations), destination);
        }
    }
}
