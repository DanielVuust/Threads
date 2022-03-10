using Bagagesorteringssystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem.Gui
{
    class DisplayAirportInfo
    {
        public void DisplayAllAirportInfo()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(GatesInfo());
                Console.WriteLine(DesksInfo());
                Console.WriteLine(SplitterInfo());
                Thread.Sleep(1000);

            }
        }
        private StringBuilder GatesInfo()
        {
            StringBuilder gatesInfo = new StringBuilder();
            gatesInfo.AppendLine("Gates--------------------------------");
            foreach (var gate in Airport.Gates)
            {
                gatesInfo.AppendLine($"Gate Name:{gate.GateName}; Gate Buffer Count {gate.GateQueue.Count}; Gate Destination:{gate.Destination}");
            }
            return gatesInfo;

        }
        private StringBuilder DesksInfo()
        {
            StringBuilder desksInfo = new StringBuilder();

            desksInfo.AppendLine("Desks--------------------------------");
            foreach (var desk in Airport.CheckInDesks)
            {
                desksInfo.AppendLine($"Desk Id:{desk.Id}; IsOpen {desk.IsOpen}; Desk Destination:{desk.Destination}");
            }
            return desksInfo;
        }
        private StringBuilder SplitterInfo()
        {
            StringBuilder splitterInfo = new StringBuilder();

            splitterInfo.AppendLine("Splitter--------------------------------");
            splitterInfo.AppendLine($"Current Queue Count {Airport.DeskQueue.Count}");
            
            return splitterInfo;
        }
    }
}
