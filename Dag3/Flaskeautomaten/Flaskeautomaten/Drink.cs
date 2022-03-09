using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Drink
    {

        private DrinkTypes drinkType;
        private int drinkNum;
        public DrinkTypes DrinkType { get { return drinkType; } }
        public int DrinkNum { get { return drinkNum; } }


        public Drink(int drinkType, int drinkNum)
        {
            DrinksInfo drinksInfo = new DrinksInfo();
            this.drinkType = drinksInfo.GetDrinkTypeBasedOnIndex(drinkType);
            this.drinkNum = drinkNum;
        }
    }
}
