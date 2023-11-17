/// <summary>
/// 20231117
/// https://leetcode.cn/problems/maximum-sum-queries/
/// </summary>
public class Solution
{
    public int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries)
    {
        int n = nums1.Length;
        var res = new int[queries.Length];
        Array.Fill(res, -1);
        int[][] sortedNums = new int[n][];
        for (int i = 0; i < n; i++)
        {
            sortedNums[i] = new int[2];
            sortedNums[i][0] = nums1[i];
            sortedNums[i][1] = nums2[i];
        }
        Array.Sort(sortedNums, (a, b) => b[0] - a[0]);
        int q = queries.Length;
        int[][] sortedQueries = new int[q][];
        for (int i = 0; i < q; i++)
        {
            sortedQueries[i] = new int[3];
            sortedQueries[i][0] = i;
            sortedQueries[i][1] = queries[i][0];
            sortedQueries[i][2] = queries[i][1];
        }
        Array.Sort(sortedQueries, (a, b) => b[1] - a[1]);

        IList<Tuple<int, int>> stack = new List<Tuple<int, int>>();
        int j = 0;
        foreach (int[] query in sortedQueries)
        {
            int i = query[0], x = query[1], y = query[2];
            while (j < n && sortedNums[j][0] >= x)
            {
                int[] pair = sortedNums[j];
                int num1 = pair[0], num2 = pair[1];
                while (stack.Count > 0 && stack[stack.Count - 1].Item2 <= num1 + num2)
                {
                    stack.RemoveAt(stack.Count - 1);
                }
                if (stack.Count == 0 || stack[stack.Count - 1].Item1 < num2)
                {
                    stack.Add(new Tuple<int, int>(num2, num1 + num2));
                }
                j++;
            }
            int k = BinarySearch(stack, y);
            if (k < stack.Count)
            {
                res[i] = stack[k].Item2;
            }
        }

        return res;
    }
    public int BinarySearch(IList<Tuple<int, int>> list, int target)
    {
        int low = 0, high = list.Count;
        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (list[mid].Item1 >= target)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }
        return low;
    }
}