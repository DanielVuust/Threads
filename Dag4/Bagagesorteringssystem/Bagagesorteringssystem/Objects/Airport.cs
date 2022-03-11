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
        public static List<CheckInDesk> CheckInDesks = new List<CheckInDesk>();
        public static Queue<Baggage> DeskQueue = new Queue<Baggage>();
        public static Gate[] Gates = new Gate[10];
        public static Queue<Flight> FlightsWaitingQueue = new Queue<Flight>();


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
        }
        public static bool AddGateToAirport()
        {
            var gate = Gates.First(x => x.InUse == true);
            if (gate == null)
                return false;

            //Creates a new gate and assigns a flight to it.
            gate.Destination = FlightsWaitingQueue.First().Destination;
            gate.InUse = true;
            int gateIndexToChange = Array.IndexOf(Airport.Gates, null);
            Airport.Gates[gateIndexToChange] = gate;
            return true;
        }
    }
}
