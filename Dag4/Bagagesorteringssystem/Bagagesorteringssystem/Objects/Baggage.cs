using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Baggage
    {
        private string id;
        private string destination;
        public string Id
        {
            get { return id; }
        }
        public string Destination
        {
            get { return destination; }
        }
        //Creates baggage with a special GUID as an id.
        public Baggage(string destination)
        {
            this.destination = destination;
            id = Guid.NewGuid().ToString();
        }
    }
}
