using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Gate
    {
        private string gateName;
        private string destination;
        private Queue<Baggage> gateQueue = new Queue<Baggage>();
        private bool inUse;

        public string GateName
        {
            get { return gateName; }
        }

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        //List of Queues/Buffers to the specific gate 
        public Queue<Baggage> GateQueue 
        { 
            get { return gateQueue; } 
            set { gateQueue = value; }
        }

        public bool InUse
        {
            get { return inUse; }
            set { inUse = value; }
        }
        public Gate(string gateName)
        {
            this.gateName = gateName;
        }
    }
}
