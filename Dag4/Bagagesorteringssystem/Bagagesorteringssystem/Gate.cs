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
        private List<string> acceptedFlightsIdList;
        private string destination;
        public string GateName
        {
            get { return gateName; }
        }
        public List<string> AcceptedFlightsIdList
        {
            get { return acceptedFlightsIdList; }
        }

        public string Destination
        {
            get { return destination; }
        }

        public Gate(string gateName, string destination)
        {
            this.gateName = gateName;
            this.destination = destination;
        }

    }
}
