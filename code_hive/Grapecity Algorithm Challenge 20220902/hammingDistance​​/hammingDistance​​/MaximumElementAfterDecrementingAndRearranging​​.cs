using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hammingDistance​​
{
    internal class MaximumElementAfterDecrementingAndRearranging​​
    {
        public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
        {
            Array.Sort(arr);
            arr[0] = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] >= 1)
                {
                    arr[i] = arr[i - 1] + 1;
                }
            }
            return arr[^1];
        }​​
    }
}
