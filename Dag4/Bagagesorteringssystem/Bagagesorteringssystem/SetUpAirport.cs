using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bagagesorteringssystem.Objects;

namespace Bagagesorteringssystem
{
    class SetUpAirport
    {
        public void SetUpAll()
        {
            SetUpDesks();
            SetUpGates();
        }

        private void SetUpDesks()
        {
            foreach(var str in GetRandomLocation())
            {
                Airport.CheckInDesks.Add(new CheckInDesk(str));
            }
        }

        
        private void SetUpGates()
        {
            
            //Creates a gate foreach destination.
            foreach(var gateDestination in GetRandomLocation())
            {
                Gate gate = 
                gate.Destination = gateDestination;
                gate.InUse = true;
                int gateIndexToChange = Array.IndexOf(Airport.Gates, null);
                Airport.Gates[gateIndexToChange] = gate;
            }
            //for (int i = 0; i < 4; i++)
            //{
            //    Gate gate = new Gate("A" + i.ToString());
            //    gate.Destination = xxxxx
            //    Airport.Gates.Add(gate);
            //}
        }

        private IEnumerable<string> GetRandomLocation()
        {
            
            yield return Airport.Connections[0].ToString();
            yield return Airport.Connections[1].ToString();
            yield return Airport.Connections[2].ToString();
        }
    }
}
