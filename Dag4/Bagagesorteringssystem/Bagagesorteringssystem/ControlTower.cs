using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class ControlTower
    {
        public void StartControllingFlights()
        {
            while (true)
            {
                TryToAssigningFlightToGates();
                LoadAllCargoFromGateBufferToFlight();
                DepartFullFlights();

                Thread.Sleep(1000);
            }
        }
        private void DepartFullFlights()
        {
            //return Airport.Gates.Any(x => x.Flight.MaxCargo-10 >= x.GateQueue.Count);
        }
        private void LoadAllCargoFromGateBufferToFlight()
        {
            foreach (Gate gate in Airport.Gates.Where(x => x.InUse == true && x.Flight != null && x.GateQueue.Count > 0))
            {
                gate.Flight.Status = "Loading Cargo";
                gate.Flight.Cargo.ToList().AddRange(gate.GateQueue.AsEnumerable());
            }
        }

        private void TryToAssigningFlightToGates()
        {
            
            Flight flight = GetNextInFlightQueue();
            if (flight == null)
            {
                Debug.Print($"No flights to assigs to gates");
                return;
            }
            Gate gate = GetUnUsedGate();
            if (gate == null)
            {
                Debug.Print($"No gates for flights to be assigened to ");
                return;
            }

            
        }

        private Flight GetNextInFlightQueue()
        {
            Flight flight = null;
            try
            {
                Monitor.Enter(Airport.FlightsWaitingQueue);
                while (Airport.FlightsWaitingQueue.Count <= 0)
                {
                    Debug.Print("Control tower is waiting for flights");
                    Monitor.Wait(Airport.FlightsWaitingQueue);
                }


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

            return flight;
        }
        
        private Gate GetUnUsedGate()
        {
            var test = Airport.Gates.FirstOrDefault(x => x.InUse == false);
            return test;
        }
    }
}
