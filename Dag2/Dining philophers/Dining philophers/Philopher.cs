using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_philophers
{
    public class Philopher
    {
        public int[] allowedForks = new int[2];
        public int philopherNum;
        public bool isEating;
        public Philopher(int philopherNum, int totalPhilophers)
        {
            this.philopherNum = philopherNum;
            if (philopherNum == totalPhilophers - 1)
            {
                allowedForks[0] = 0;
            }
            else
            {
                allowedForks[0] = philopherNum++;
            }
            if(philopherNum == 0)
            {
                allowedForks[1] = totalPhilophers;
            }
            else
            {
                allowedForks[1] = philopherNum--;    

            }
        }
       
    }
}
