using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hammingDistance​​
{
    public class HammingDistance​​
    {
        public int HammingDistance(int x, int y)
        {
            var xor = x ^ y;
            var distance = 0;
            while (xor != 0)
            {
                if ((xor & 1) == 1)
                {
                    distance++;
                }
                xor >>= 1;
            }
            return distance;
        }​​
    }
}
