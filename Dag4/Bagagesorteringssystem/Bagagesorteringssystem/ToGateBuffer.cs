using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class ToGateBuffer
    {
        private Gate destination;
        public Gate Destination
        {
            get { return destination; }
        }

        public ToGateBuffer(Gate destination)
        {
            this.destination = destination;
        }
    }
}
