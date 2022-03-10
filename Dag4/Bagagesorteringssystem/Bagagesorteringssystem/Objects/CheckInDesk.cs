using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem.Objects
{
    class CheckInDesk
    {
        private const int timeToOpenNewDesk = 5000;
        private bool isOpen;
        private string destination;
        private string id;
        private List<Baggage> currentQueue = new List<Baggage>();
        public bool IsOpen
        {
            get { return isOpen; }
            set { 
                isOpen = value;
                Debug.Print($"Desk {id} is now open.");
            }
        }

        public string Destination
        {
            get { return destination; }
        }
        public string Id
        {
            get { return id; }
        }
        public List<Baggage> CurrentQueue
        {
            get { return currentQueue; }
        }

        public CheckInDesk(string destination)
        {
            this.destination = destination;
            id = Guid.NewGuid().ToString();
        }
        public void AddBaggageToCurrentQueue(Baggage baggage)
        {
            this.currentQueue.Add(baggage);
        }
        public void CheckInBaggage(Baggage baggage)
        {
           
            Monitor.Enter(Airport.DeskQueue);
            if (Airport.DeskQueue.Count > 5)
            {
                Debug.Print($"Checkin Desk {this.id} is wating for space in DeskQueue");
                Monitor.Wait(Airport.DeskQueue);
            }
            Debug.Print($"Baggage {baggage.Id} has been queued into DeskQueue");
            Airport.DeskQueue.Enqueue(baggage);
            Monitor.PulseAll(Airport.DeskQueue);
            Monitor.Exit(Airport.DeskQueue);
        }
    }
}
