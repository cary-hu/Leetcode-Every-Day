using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hammingDistance​​
{
    internal class MaxSlidingWindow​​
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var q = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => { return b - a; }));
            var n = nums.Length;
            var index = 0;
            int[] ans = new int[n - k + 1];
            for (int i = 0; i < n; i++)
            {
                q.Enqueue(new int[] { i, nums[i] }, nums[i]);
                if (i >= k - 1)
                {
                    while (q.Peek()[0] <= i - k)
                    {
                        q.Dequeue();
                    }
                    ans[index++] = q.Peek()[1];
                }
            }
            return ans;
        }​​
    }
}
