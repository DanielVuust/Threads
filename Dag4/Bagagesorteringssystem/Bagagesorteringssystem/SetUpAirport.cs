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
            foreach(var connections in Airport.Connections)
            {
                CheckInDesk checkInDesk  = Airport.CheckInDesks.First(x => x.IsOpen == false);
                checkInDesk.Destination = connections;
                checkInDesk.IsOpen = true;
            }
        }

        
        private void SetUpGates()
        {
            
            //Creates a gate foreach destination.
            //foreach(var gateDestination in Airport.Connections)
            //{
            //    Gate gate = Airport.Gates.First(x => x.InUse == false);
            //    gate.Destination = gateDestination;
            //    gate.InUse = true;
            //}
        }
    }
}
