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
            //Returns all flights that are 90% or more full.
            var gates = Airport.Gates.Where(x => x?.Flight?.Cargo.Count(y=>y != null) >= (x?.Flight?.MaxCargo * 0.9)).ToList();
            foreach (var item in gates)
            {
                item.DepartFlight();
            }
        }
        private void LoadAllCargoFromGateBufferToFlight()
        {
            foreach (Gate gate in Airport.Gates.Where(x => x.InUse == true && x.Flight != null && x.GateQueue.Count > 0))
            {
                if(gate.Flight.Status != "Loading Cargo")
                    gate.Flight.Status = "Loading Cargo";

                //var test = gate.Flight.Cargo.Where(x => x != null);

                gate.Flight.Cargo = gate.Flight.Cargo.Where(x => x != null).Concat(gate.GateQueue).ToArray();
                gate.GateQueue.Clear();
                //IEnumerable<Baggage> bag = gate.GateQueue.AsEnumerable();

                //var test = gate.Flight.Cargo.Where(x => x != null).ToList().AddRange(bag);
                //gate.Flight.Cargo = test;
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
