using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_philophers
{
    public class Philosopher
    {
        public int[] allowedForks = new int[2];
        public int philosopherNum;
        public bool isEating;
        public Philosopher(int philosopherNum, int totalPhilophers)
        {
            this.philosopherNum = philosopherNum;
            if (philosopherNum == totalPhilophers - 1)
            {
                allowedForks[0] = 0;
            }
            else
            {
                allowedForks[0] = philosopherNum++;
            }

            if(philosopherNum == 0)
            {
                allowedForks[1] = totalPhilophers;
            }
            else
            {
                allowedForks[1] = philosopherNum--;    

            }
        }
       
    }
}
