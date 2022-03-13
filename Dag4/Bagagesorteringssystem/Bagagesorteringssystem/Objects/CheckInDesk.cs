using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        private Queue<Baggage> currentQueue = new Queue<Baggage>();
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
            set { destination = value; }
        }
        public string Id
        {
            get { return id; }
        }
        public Queue<Baggage> CurrentQueue
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
            try
            {
                Monitor.Enter(currentQueue);

                this.currentQueue.Enqueue(baggage);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(currentQueue);
                Monitor.Exit(currentQueue);
            }
        }
        public void CheckInBaggageNextInQueue()
        {
            try
            {
                Monitor.Enter(Airport.DeskQueue);
                Baggage baggage = TakeBaggageFromPassengerQueue();

                //The desk queue has a max number of 5 object before it has to wait for space.
                if (Airport.DeskQueue.Count >= 5)
                {
                    Debug.Print($"Check in Desk {this.id} is waiting for space in DeskQueue");
                    Monitor.Wait(Airport.DeskQueue);
                }

                Debug.Print($"Baggage {baggage.Id} has been queued into DeskQueue");
                Airport.DeskQueue.Enqueue(baggage);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(Airport.DeskQueue);
                Monitor.Exit(Airport.DeskQueue);

            }
        }

        private Baggage TakeBaggageFromPassengerQueue()
        {
            Baggage baggage = null;
            try
            {
                Monitor.Enter(currentQueue);

                baggage = currentQueue.Dequeue();
                Debug.Print($"The check {this.id} in desk has taken a object from a passenger");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Monitor.PulseAll(currentQueue);
                Monitor.Exit(currentQueue);
            }

            return baggage;
        }
    }
}
