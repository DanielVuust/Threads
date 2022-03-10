using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bagagesorteringssystem.Objects
{
    class Airport
    {
        public static List<CheckInDesk> CheckInDesks = new List<CheckInDesk>();
        public static Queue<Baggage> DeskQueue = new Queue<Baggage>();
        public static List<Gate> Gates = new List<Gate>();


        public static List<string> Connections = new List<string>()
        {
            "London",
            "Copenhagen",
            "Barcelona"
        };
    }
}
