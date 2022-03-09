using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    static class DrinkBuffers
    {
        public const int MaxBufferSize = 10;
        public static Queue<Drink> AllDrinksBuffer = new Queue<Drink>(MaxBufferSize);
        public static Queue<Drink> WaterDrinksBuffer = new Queue<Drink>(MaxBufferSize);
        public static Queue<Drink> BeerDrinksBuffer = new Queue<Drink>(MaxBufferSize);
    }
}
