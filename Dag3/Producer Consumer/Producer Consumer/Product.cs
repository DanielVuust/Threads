using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer_Consumer
{
    class Product
    {
        private readonly string serialNum;
        public string SerialNum { get { return serialNum; } }

        public Product(string serialNum)
        {
            this.serialNum = serialNum;
        }
    }
}
