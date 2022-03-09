using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer_Consumer
{
    static class Buffer
    {
        public static Queue<Product> BufferQueue = new Queue<Product>();
        public const int MaxQueue = 8;
    }
}
