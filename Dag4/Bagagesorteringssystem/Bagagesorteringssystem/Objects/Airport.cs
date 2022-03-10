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
        public static List<Queue<Baggage>> DeskQueues = new List<Queue<Baggage>>();
    }
}
