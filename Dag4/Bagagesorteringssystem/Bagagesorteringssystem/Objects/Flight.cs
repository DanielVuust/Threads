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
        private Baggage[] cargo;
        private int maxCargo;
        private string status;
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
        public Baggage[] Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        public int MaxCargo
        {
            get { return maxCargo; }
        }
        public string Status
        {
            get { return status; }
            set 
            { 
                this.AddTimeStampWithCurrentTime($"Status changed from {status} to {value}");
                status = value;
            }
        }

        public Flight(string destination)
        {
            this.destination = destination;
            flightId = Guid.NewGuid().ToString();
            maxCargo = new Random().Next(20, 50);
            status = "Waiting";
            cargo = new Baggage[maxCargo];
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
