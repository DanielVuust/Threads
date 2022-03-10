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
        public string Id
        {
            get { return id; }
        }
        //Creates baggage with a special GUID as an id.
        public Baggage()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
