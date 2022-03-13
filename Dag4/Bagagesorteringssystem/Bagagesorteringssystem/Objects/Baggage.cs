using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Baggage
    {
        private string id;
        private string destination;
        private string timeStamps;
        public string Id
        {
            get { return id; }
        }
        public string Destination
        {
            get { return destination; }
            set { value = destination; }
        }
        public string TimeStamps
        {
            get { return timeStamps; }
            set { timeStamps = value; }
        }
        //Creates baggage with a special GUID as an id.
        public Baggage(string destination)
        {
            this.destination = destination;
            id = Guid.NewGuid().ToString();
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
