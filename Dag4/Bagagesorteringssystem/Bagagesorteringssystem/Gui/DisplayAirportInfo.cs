using Bagagesorteringssystem.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Thread.Sleep(1000);

                Console.Clear();
                Console.WriteLine(GatesInfo());
                DesksInfo();
                Console.WriteLine(SplitterInfo());
                Console.WriteLine(FlightQueueInfo());

            }
        }
        private StringBuilder GatesInfo()
        {
            StringBuilder gatesInfo = new StringBuilder();
            gatesInfo.AppendLine("Gates--------------------------------");
            foreach (var gate in Airport.Gates.Where(x=> x?.InUse == true))
            {
                gatesInfo.AppendLine($"Gate Name:{gate.GateName}; Gate Buffer Count {gate.GateQueue.Count}; Gate Destination:{gate.Destination}");
            }
            return gatesInfo;

        }
        private StringBuilder DesksInfo()
        {
            StringBuilder desksInfo = new StringBuilder();

            Console.WriteLine("Desks--------------------------------");
            foreach (var desk in Airport.CheckInDesks)
            {
                ChangeDeskColorByQueueCount(desk);
                Console.WriteLine($"Desk Id:{desk.Id}; IsOpen {desk.IsOpen}; Desk Destination:{desk.Destination}; Current Queue {desk.CurrentQueue.Count}");
            }

            ResetConsoleColor();
            return desksInfo;
        }
        private StringBuilder SplitterInfo()
        {
            StringBuilder splitterInfo = new StringBuilder();

            splitterInfo.AppendLine("Splitter--------------------------------");
            splitterInfo.AppendLine($"Current Queue Count {Airport.DeskQueue.Count}");
            
            return splitterInfo;
        }

        private StringBuilder FlightQueueInfo()
        {
            StringBuilder flightQueueInfo = new StringBuilder();
            flightQueueInfo.AppendLine("WaitingFlightQueue--------------------------------");
            var flightsWaitingQueue = new Queue<Flight>(Airport.FlightsWaitingQueue);
            foreach (var flight in flightsWaitingQueue)
            {
                flightQueueInfo.Append($"Flight Id {flight.FlightId}; Destination {flight.Destination};\n");
            }

            return flightQueueInfo;
        }
        private void ChangeDeskColorByQueueCount(CheckInDesk desk)
        {

            int currentQueue = desk.CurrentQueue.Count;
            if (currentQueue <= 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (currentQueue <= 5)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else 
                Console.ForegroundColor = ConsoleColor.Red;
        }

        private void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
