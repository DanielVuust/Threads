using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Drink
    {

        private string drinkType;
        private int drinkNum;
        public string DrinkType { get { return drinkType; } }
        public int DrinkNum { get { return drinkNum; } }


        public Drink(int drinkType, int drinkNum)
        {
            this.drinkType = Drinks.GetDrinkTypeBasedOnIndex(drinkType);
            this.drinkNum = drinkNum;
        }
    }
}
