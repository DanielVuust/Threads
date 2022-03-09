using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Drinks
    {
        private static readonly List<string> _drinkTypes = new List<string>()
        {
            "Water",
            "Beer"
        };
        public int DrinkTypesCount { get { return _drinkTypes.Count; } }
        public static string GetDrinkTypeBasedOnIndex(int index)
        {
            return _drinkTypes[index];
        }
    }
}
