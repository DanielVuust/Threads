using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem.Objects
{
    class CheckInDesk
    {
        private bool isOpen;
        private string destination;
        public bool IsOpen
        {
            get { return isOpen; }
            set { isOpen = value; }
        }

        public string Destination
        {
            get { return destination; }
        }

        public CheckInDesk(string destination)
        {
            this.destination = destination;
        }
    }
}
