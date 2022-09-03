using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hammingDistance​​
{
    internal class GuessNumber​​
    {
        public int GuessNumber(int n)
        {
            int l = 1;
            int r = n;
            while (l < r)
            {
                var mid = l + (r - l) / 2;
                if (guess(mid) <= 0)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }​​
    }
}
