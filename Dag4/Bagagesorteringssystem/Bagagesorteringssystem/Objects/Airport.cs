using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bagagesorteringssystem.Objects
{
    class Airport
    {
        public static CheckInDesk[] CheckInDesks = new CheckInDesk[10];
        public static Queue<Baggage> DeskQueue = new Queue<Baggage>();
        public static Gate[] Gates = new Gate[10];
        public static Queue<Flight> FlightsWaitingQueue = new Queue<Flight>();
        public static Queue<Baggage> LostBaggageQueue = new Queue<Baggage>();

        //Busyness is not intregated yet.
        public static int BaggageInterval = 1000;

        public static List<string> Connections = new List<string>()
        {
            "London",
            "Copenhagen",
            "Barcelona"
        };

        static Airport()
        {
            for (int i = 0; i < Gates.Length; i++)
            {
                Gates[i] = new Gate(i.ToString());
            }
            for (int i = 0; i < Gates.Length; i++)
            {
                CheckInDesks[i] = new CheckInDesk(null);
            }
        }
        public static bool AddGateToAirport()
        {
            var gate = Gates.FirstOrDefault(x => x.InUse == false);
            if (gate == null)
                return false;

            //Creates a new gate and assigns a flight to it.
            gate.Destination = FlightsWaitingQueue.First().Destination;
            gate.InUse = true;

            return true;
        }
    }
}
