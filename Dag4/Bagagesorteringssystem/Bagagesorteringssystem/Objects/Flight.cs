using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Flight
    {
        private string flightId;
        private string destination;
        private string timeStamps;
        public string FlightId
        {
            get { return flightId; }
        }
        
        public string Destination
        {
            get { return destination; }
        }
        public string TimeStamps
        {
            get { return timeStamps; }
            set { timeStamps = value; }
        }

        public Flight(string destination)
        {
            this.destination = destination;
            flightId = Guid.NewGuid().ToString();

        }
        public void AddTimeStampWithCurrentTime(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(DateTime.Now.ToString());
            stringBuilder.Append(" ");
            stringBuilder.Append(text);
            timeStamps += stringBuilder;
            Debug.Print("\t" + timeStamps);
        }
    }


}
