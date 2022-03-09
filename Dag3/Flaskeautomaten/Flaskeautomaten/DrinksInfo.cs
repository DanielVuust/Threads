using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    enum DrinkTypes
    {
        Water = 0,
        Beer = 1
    };
    class DrinksInfo
    {
        public int DrinkTypesCount { get { return Enum.GetNames(typeof(DrinkTypes)).Length; } }
        public DrinkTypes GetDrinkTypeBasedOnIndex(int index)
        {
            return (DrinkTypes)index;
        }
    }
}
