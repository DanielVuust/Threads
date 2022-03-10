using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Program
    {
        static void Main(string[] args)
        {

            SortingSystem sortingSystem = new SortingSystem();
            sortingSystem.StartSortingSystem();
            Console.Read();
        }
    }
}
