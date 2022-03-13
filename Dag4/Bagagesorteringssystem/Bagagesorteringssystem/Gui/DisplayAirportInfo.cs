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
        public bool ShowKeybindings = false;
        
        public void DisplayAllAirportInfo()
        {
            while (true)
            {

                Console.Clear();
                GatesInfo();
                DesksInfo();
                LostAndFound();
                SplitterInfo();
                FlightQueueInfo();
                ShowIntervals();
                if(ShowKeybindings)
                    DisplayKeybinding();

                Thread.Sleep(1000);
            }
        }
        private void GatesInfo()
        {
            StringBuilder gatesInfo = new StringBuilder();
            gatesInfo.AppendLine("Gates--------------------------------");
            foreach (var gate in Airport.Gates.Where(x=> x?.InUse == true))
            {
                gatesInfo.AppendLine($"Gate Name:{gate.GateName}; Gate Buffer Count {gate.GateQueue.Count}; Gate Destination:{gate?.Flight?.Destination}; Flight max cargo:{gate?.Flight?.MaxCargo}; Current flight cargo {gate?.Flight?.Cargo.Count(x => x != null)}; Status {gate?.Flight?.Status};");
            }
            Console.WriteLine(gatesInfo);

        }
        private void DesksInfo()
        {

            Console.WriteLine("Desks--------------------------------");
            foreach (var desk in Airport.CheckInDesks.Where(x => x.IsOpen == true).OrderBy(x => x.Destination))
            {
                ChangeDeskColorByQueueCount(desk.CurrentQueue.Count);
                Console.WriteLine($"Desk Id:{desk.Id}; IsOpen {desk.IsOpen}; Desk Destination:{desk.Destination}; Current Queue {desk.CurrentQueue.Count}");
            }

            ResetConsoleColor();
            Console.WriteLine();

        }
        private void LostAndFound()
        {
            Console.WriteLine($"Lost and found--------------------------------");
            ChangeDeskColorByQueueCount(Airport.LostBaggageQueue.Count);
            Console.WriteLine($"Current Count {Airport.LostBaggageQueue.Count}");
            ResetConsoleColor();
            Console.WriteLine();

        }
        private void SplitterInfo()
        {
            StringBuilder splitterInfo = new StringBuilder();

            splitterInfo.AppendLine("Splitter--------------------------------");
            splitterInfo.AppendLine($"Current splitter Count {Airport.DeskQueue.Count}");

            Console.WriteLine(splitterInfo);
        }

        private void FlightQueueInfo()
        {
            StringBuilder flightQueueInfo = new StringBuilder();
            flightQueueInfo.AppendLine("WaitingFlightQueue--------------------------------");
            var flightsWaitingQueue = new Queue<Flight>(Airport.FlightsWaitingQueue);
            foreach (var flight in flightsWaitingQueue)
            {
                flightQueueInfo.Append($"Flight Id {flight.FlightId}; Destination {flight.Destination};\n");
            }

            Console.WriteLine(flightQueueInfo);
        }
        private void ChangeDeskColorByQueueCount(int currentQueue)
        {

            
            if (currentQueue <= 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (currentQueue <= 5)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else 
                Console.ForegroundColor = ConsoleColor.Red;
        }
        private void ShowIntervals()
        {
            Console.WriteLine("Intervals--------------------------------");
            Console.WriteLine($"BaggageInterval; {Airport.BaggageInterval}");
            Console.WriteLine();
        }
        private void DisplayKeybinding()
        {
            Console.WriteLine("Keybindings--------------------------------");
            Console.WriteLine($"\t [m] Show stuff");
            Console.WriteLine($"\t [p] Add 100ms to BaggageInterval");
            Console.WriteLine($"\t [æ] Deduct 100ms to BaggageInterval");
            Console.WriteLine($"\t [z] Show keybindings");
            Console.WriteLine($"\t [1] Add gate");
            Console.WriteLine($"\t [2] Add check in desk");
            for (int i = 0; i < Airport.Connections.Count; i++)
            {
                Console.WriteLine($"\t\t [{i}] {Airport.Connections[i]}");
            }
        }
        private void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
